using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TLD.Model.Detection;

namespace TLD.Model.Learning
{
    [Serializable]
    public class Learner : ILearner
    {
        private static Random _rand = new Random();

        private IObjectModel _objectModel;
        private IDetector _detector;
        private PositivePatchSynthesisInfo _initPositivePatchSynthesisInfo;
        private NegativePatchPickingInfo _initNegativePatchPickingInfo;
        private PositivePatchSynthesisInfo _runtimePosPatchSynthesisInfo;
        private NegativePatchPickingInfo _runtimeNegativePatchPickingInfo;

        private VarianceClassifier _varianceClassifier;
        private EnsembleClassifier _ensembleClassifier;
        private NnClassifier _nnClassifier;
        private float _sameSimilarityThreshold;
        private float _validConservativeSimilarityThreshold;
        

        public Learner(
            IObjectModel objectModel,
            IDetector detector,
            PositivePatchSynthesisInfo initPositivePatchSysthesisInfo,
            NegativePatchPickingInfo initNegativePatchPickingInfo,
            PositivePatchSynthesisInfo runtimePositivePatchSysthesisInfo,
            NegativePatchPickingInfo runtimeNegativePatchPickingInfo,
            float sameSimilarityThreshold,
            float validConservativeSimilarityThreshold
        )
        {
            _objectModel = objectModel;
            _detector = detector;
            _initPositivePatchSynthesisInfo = initPositivePatchSysthesisInfo;
            _initNegativePatchPickingInfo = initNegativePatchPickingInfo;
            _runtimePosPatchSynthesisInfo = runtimePositivePatchSysthesisInfo;
            _runtimeNegativePatchPickingInfo = runtimeNegativePatchPickingInfo;
            _sameSimilarityThreshold = sameSimilarityThreshold;
            _validConservativeSimilarityThreshold = validConservativeSimilarityThreshold;

            _varianceClassifier = ((_detector as Detector).CascadedClassifier as CascadedClassifier).VarianceClassifier as VarianceClassifier;
            _ensembleClassifier = ((_detector as Detector).CascadedClassifier as CascadedClassifier).EnsembleClassifier as EnsembleClassifier;
            _nnClassifier = ((_detector as Detector).CascadedClassifier as CascadedClassifier).NnClassifier as NnClassifier;
        }

        #region ILearner

        public void Initialize(Image<Gray, byte> initialFrame, IBoundingBox initialBb)
        {
            CurrentState.ObjectModelGaussianSigma = _runtimePosPatchSynthesisInfo.GaussianSigma;

            List<IBoundingBox> sortedScanningWindows = Service.SortScanningWindowsByOverlap(_detector.ScanningWindows.ToList(), initialBb);
            List<IBoundingBox> negativeScanningWindows = Service.GetScanningWindowsWithOverlapLessThan(_initNegativePatchPickingInfo.Overlap, initialBb, sortedScanningWindows);

            #region ensemble classifier

            // generate positive patches
            Image<Gray, byte> smoothFrame = new Image<Gray,byte>(initialFrame.Size);
            double sigma = _ensembleClassifier.Sigma;
            CvInvoke.cvSmooth(initialFrame, smoothFrame, SMOOTH_TYPE.CV_GAUSSIAN, 0, 0, sigma, sigma);

            List<Image<Gray, byte>> positivePatchesForEnsemble = GeneratePatches(
                smoothFrame,
                initialBb,
                _initPositivePatchSynthesisInfo.EnsembleCount,
                _initPositivePatchSynthesisInfo.WarpInfo,
                0,
                Size.Empty
            );

            // generate negative patches
            List<Image<Gray, byte>> negativePatchesForEnsemble = PickBoundingBoxesAndGeneratePatches(
                smoothFrame,
                negativeScanningWindows,
                _initNegativePatchPickingInfo.EnsembleCount,
                Size.Empty
            );

            // update ensemble classifier
            _ensembleClassifier.TrainWithUnseenPatches(positivePatchesForEnsemble, negativePatchesForEnsemble);

            #endregion

            #region nn classifier

            // generate positive patches
            List<Image<Gray, byte>> positivePatchesForNn = GeneratePatches(
                initialFrame,
                initialBb,
                _initPositivePatchSynthesisInfo.NnCount,
                _initPositivePatchSynthesisInfo.WarpInfo,
                _initPositivePatchSynthesisInfo.GaussianSigma,
                _objectModel.PatchSize
            );

            // generate negative patches
            List<Image<Gray, byte>> negativePatchesForNn = PickBoundingBoxesAndGeneratePatches(
                initialFrame,
                negativeScanningWindows,
                _initNegativePatchPickingInfo.NnCount,
                _objectModel.PatchSize
            );

            TrainNnClassifier(positivePatchesForNn, negativePatchesForNn);

            #endregion
        }

        public void TrainDetector(Image<Gray, byte> currentFrame, IBoundingBox currentBb, out bool valid)
        {
            // if patch is outside the image
            if (!currentBb.InsideFrame(currentFrame.Size))
            {
                valid = false;
                return;
            }

            // get normalized image patch
            currentFrame.ROI = Rectangle.Round(currentBb.GetRectangle());
            Image<Gray, byte> currentPatch = currentFrame.Resize(_objectModel.PatchSize.Width, _objectModel.PatchSize.Height, INTER.CV_INTER_LINEAR);
            currentFrame.ROI = Rectangle.Empty;

            // if appearance changed too fast
            float pnnSimilarity, nnnSimilarity;
            if (_objectModel.RelativeSimilarity(currentPatch, out pnnSimilarity, out nnnSimilarity) < 0.5f)
            {
                valid = false;
                return;
            }
            if (nnnSimilarity > _sameSimilarityThreshold)
            {
                valid = false;
                return;
            }

            #region ensemble classifier

            // generate positive patches
            List<Image<Gray, byte>> positivePatchesForEnsemble = GeneratePatches(
                _ensembleClassifier.SmoothFrame,
                currentBb,
                _runtimePosPatchSynthesisInfo.EnsembleCount,
                _runtimePosPatchSynthesisInfo.WarpInfo,
                0,
                Size.Empty
            );

            // pick negative patches
            List<IBoundingBox> allEnsembleNegativeBbs = new List<IBoundingBox>();
            foreach (KeyValuePair<IBoundingBox, double> pair in _ensembleClassifier.PositivePosteriors)
            {
                IBoundingBox bb = pair.Key;
                if (bb.GetOverlap(currentBb) < _runtimeNegativePatchPickingInfo.Overlap)
                {
                    allEnsembleNegativeBbs.Add(bb);
                }
            }

            List<Image<Gray, byte>> negativePatchesForEnsemble = PickBoundingBoxesAndGeneratePatches(
                _ensembleClassifier.SmoothFrame,
                allEnsembleNegativeBbs,
                _runtimeNegativePatchPickingInfo.EnsembleCount,
                Size.Empty
            );

            // train ensemble classifier
            int bootstrap = 1;
            for (int i = 0; i < bootstrap; i++)
            {
                _ensembleClassifier.TrainWithUnseenPatches(positivePatchesForEnsemble, negativePatchesForEnsemble);
            }

            #endregion

            #region nn classifier

            // generate positive patches
            List<Image<Gray, byte>> positivePatchesForNn = GeneratePatches(
                currentFrame,
                currentBb,
                _runtimePosPatchSynthesisInfo.NnCount,
                _runtimePosPatchSynthesisInfo.WarpInfo,
                _runtimePosPatchSynthesisInfo.GaussianSigma,
                _objectModel.PatchSize
            );

            int width = _objectModel.PatchSize.Width;
            int height = _objectModel.PatchSize.Height;
            for (int i = 0; i < positivePatchesForNn.Count; i++)
            {
                positivePatchesForNn[i] = positivePatchesForNn[i].Resize(width, height, INTER.CV_INTER_LINEAR);
            }
            /*
            // pick negative patches
            List<IBoundingBox> allNegativeNnBbs = new List<IBoundingBox>();
            IBoundingBox[] allBoundingBoxes = _nnClassifier.ScanningWindowGenerator.ScanningWindows;
            List<int> nnAcceptedPatches = _nnClassifier.AcceptedPatches;
            int nnAcceptedPatchesCount = nnAcceptedPatches.Count;

            for (int i = 0; i < nnAcceptedPatchesCount; i++)
            {
                int windowIndex = nnAcceptedPatches[i];
                IBoundingBox bb = allBoundingBoxes[windowIndex];
                if (bb.GetOverlap(currentBb) < _runtimeNegativePatchPickingInfo.Overlap)
                {
                    allNegativeNnBbs.Add(bb);
                }
            }

            List<Image<Gray, byte>> negativePatchesForNn = PickBoundingBoxesAndGeneratePatches(
                currentFrame,
                allNegativeNnBbs,
                _runtimeNegativePatchPickingInfo.NnCount,
                _objectModel.PatchSize
            );
            */

            List<Image<Gray, byte>> negativePatchesForNn = PickFromList<Image<Gray, byte>>(negativePatchesForEnsemble, _runtimeNegativePatchPickingInfo.NnCount);
            for (int i = 0; i < negativePatchesForNn.Count; i++)
            {
                negativePatchesForNn[i] = negativePatchesForNn[i].Resize(_objectModel.PatchSize.Width, ObjectModel.PatchSize.Height, INTER.CV_INTER_LINEAR);
            }

            // train nn classifier (update object model)
            TrainNnClassifier(positivePatchesForNn, negativePatchesForNn);

            #endregion

            valid = true;

            currentFrame.ROI = Rectangle.Empty;
        }

        public IObjectModel ObjectModel
        {
            get { return _objectModel; }
        }

        public float ValidConservativeSimilarityThreshold
        {
            get { return _validConservativeSimilarityThreshold; }
            set { _validConservativeSimilarityThreshold = value; }
        }

        #endregion

        private List<T> PickFromList<T>(List<T> list, int count)
        {
            int currentCount = list.Count;
            if (currentCount == 0)
            {
                return new List<T>();
            }

            List<T> result = new List<T>(count);
            int wantedCount = count;
            double step = (double)currentCount / wantedCount;
            for (int i = 0; i < wantedCount; i++)
            {
                int index = (int)(i * step);
                result.Add(list[index]);
            }

            return result;
        }

        private Image<Gray, byte> CreateModelPatch(IBoundingBox boundingBox, Image<Gray, byte> frame, INTER interpolation, double gaussianSigma)
        {
            frame.ROI = Rectangle.Round(boundingBox.GetRectangle());
            Image<Gray, byte> patch = frame.Resize(
                _objectModel.PatchSize.Width,
                _objectModel.PatchSize.Height,
                interpolation
            );
            frame.ROI = Rectangle.Empty;

            if (gaussianSigma != 0)
            {
                CvInvoke.cvSmooth(
                    patch,
                    patch,
                    SMOOTH_TYPE.CV_GAUSSIAN,
                    0, 0,
                    gaussianSigma, gaussianSigma
                );
            }

            return patch;
        }

        private void TrainNnClassifier(List<Image<Gray, byte>> positivePatches, List<Image<Gray, byte>> negativePatches)
        {
            Image<Gray, byte>[] patches;
            bool[] labels;
            Service.PermuteTrainingExamples<Image<Gray, byte>>(positivePatches, negativePatches, out patches, out labels);

            // first, update object model with first positive example
            if (positivePatches.Count > 0)
            {
                UpdateObjectModel(positivePatches[0], true);
            }

            // update object model with permuted patches
            for (int i = 0; i < patches.Length; i++)
            {
                UpdateObjectModel(patches[i], labels[i]);
            }
        }

        private void UpdateObjectModel(Image<Gray, byte> patch, bool label)
        {
            // calculate relative similarity
            float pnnSimilarity, nnnSimilarity;
            float relativeSimilarity = _objectModel.RelativeSimilarity(patch, out pnnSimilarity, out nnnSimilarity);

            // positive patch
            if (label == true)
            {
                if (!(pnnSimilarity > _nnClassifier.PnnSimilarityThreshold && relativeSimilarity > _nnClassifier.RelativeSimilarityThreshold))
                {
                    if (pnnSimilarity < _sameSimilarityThreshold)
                    {
                        _objectModel.AddPositivePatch(patch);
                    }
                }
            } 

            // negative patch
            else
            {
                if (relativeSimilarity > 0.5f)
                {
                    if (nnnSimilarity < _sameSimilarityThreshold)
                    {
                        _objectModel.AddNegativePatch(patch);
                    }
                }
            }
        }

        private List<Image<Gray, byte>> GeneratePatches(Image<Gray, byte> frame, IBoundingBox bb, int count, WarpInfo warpInfo, double gaussianSigma, Size newSize)
        {
            List<Image<Gray, byte>> patches = new List<Image<Gray, byte>>();
            for (int i = 0; i < count; i++)
            {
                Image<Gray, byte> patch = Service.GeneratePatch(frame, bb, warpInfo, gaussianSigma, newSize);
                patches.Add(patch);
            }

            return patches;
        }

        private List<Image<Gray, byte>> PickBoundingBoxesAndGeneratePatches(Image<Gray, byte> frame, List<IBoundingBox> allBoundingBoxes, int count, Size newSize)
        {
            List<Image<Gray, byte>> patches = new List<Image<Gray, byte>>();

            List<IBoundingBox> boundingBoxes = PickFromList<IBoundingBox>(allBoundingBoxes, count);
            if (boundingBoxes.Count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    Image<Gray, byte> patch = Service.GeneratePatch(
                        frame,
                        boundingBoxes[i],
                        null,
                        0,
                        newSize
                        );

                    patches.Add(patch);
                }
            }

            return patches;
        }

        private List<Image<Gray, byte>> PickNegativePatches(Image<Gray, byte> frame, List<IBoundingBox> negativeScanningWindows, NegativePatchPickingInfo pickingInfo)
        {
            List<Image<Gray, byte>> patches = new List<Image<Gray, byte>>();
            float step = negativeScanningWindows.Count / pickingInfo.EnsembleCount;
            for (int i = 0; i < pickingInfo.EnsembleCount; i++)
            {
                int index = (int)(i * step);
                IBoundingBox bb = negativeScanningWindows[index];
                Image<Gray, byte> patch = frame.GetPatch(bb.Center, Size.Round(bb.Size));
                patches.Add(patch);
            }

            return patches;
        }

        public float SameSimilarityThreshold
        {
            get { return _sameSimilarityThreshold; }
            set { _sameSimilarityThreshold = value; }
        }
    }
}
