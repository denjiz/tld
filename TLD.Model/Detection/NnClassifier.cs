using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TLD.Model.Detection
{
    [Serializable]
    public class NnClassifier : IClassifier
    {
        private IScanningWindowGenerator _scanningWindowGenerator;
        private IObjectModel _objectModel;
        private float _pnnSimilarityThreshold;
        private float _relativeSimilarityThreshold;

        [NonSerialized]
        List<float> _relativeSimilarities;
        [NonSerialized]
        List<int> _acceptedWindows;
        [NonSerialized]
        Dictionary<IBoundingBox, Image<Gray, byte>> _patches;

        public NnClassifier(IScanningWindowGenerator swg, IObjectModel objectModel, float pnnSimilarityThreshold, float relativeSimilarityThreshold)
        {
            _scanningWindowGenerator = swg;
            _objectModel = objectModel;
            _pnnSimilarityThreshold = pnnSimilarityThreshold;
            _relativeSimilarityThreshold = relativeSimilarityThreshold;
        }

        #region IClassifier

        public void PostInstantiation()
        {
            _relativeSimilarities = new List<float>();
            _patches = new Dictionary<IBoundingBox, Image<Gray, byte>>();
        }

        public void Initialize(Image<Gray, byte> initialFrame, IBoundingBox initialBb)
        {
            _acceptedWindows = new List<int>(_scanningWindowGenerator.ScanningWindows.Length);
        }

        public List<int> AcceptedWindows(Image<Gray, byte> frame, List<int> scanningWindows)
        {
            _acceptedWindows.Clear();
            IBoundingBox[] allScanningWindows = _scanningWindowGenerator.ScanningWindows;

            _relativeSimilarities.Clear();
            _patches.Clear();
            CurrentState.RelativeSimilarities.Clear();
            for (int i = 0; i < scanningWindows.Count; i++)
            {
                // get relative similarity of the patch to the object model
                int windowIndex = scanningWindows[i];
                IBoundingBox bb = allScanningWindows[windowIndex];
                Image<Gray, byte> patch = Service.GeneratePatch(frame, bb, null, CurrentState.ObjectModelGaussianSigma, _objectModel.PatchSize);

                float pnn, nnn;
                float relativeSimilarity = _objectModel.RelativeSimilarity(patch, out pnn, out nnn);
                if (pnn > _pnnSimilarityThreshold && relativeSimilarity > _relativeSimilarityThreshold)
                {
                    _acceptedWindows.Add(windowIndex);
                }

                CurrentState.RelativeSimilarities.Add(bb, relativeSimilarity);
                _patches.Add(bb, patch);
            }
            frame.ROI = Rectangle.Empty;

            return _acceptedWindows;
        }

        public void Update(List<Image<Gray, byte>> positivePatches, List<Image<Gray, byte>> negativePatches)
        {
        }

        #endregion

        #region components (getters only)

        public IScanningWindowGenerator ScanningWindowGenerator
        {
            get { return _scanningWindowGenerator; }
        }

        #endregion

        #region configuration (getters and setters)

        public float PnnSimilarityThreshold
        {
            get { return _pnnSimilarityThreshold; }
            set { _pnnSimilarityThreshold = value; }
        }

        public float RelativeSimilarityThreshold
        {
            get { return _relativeSimilarityThreshold; }
            set { _relativeSimilarityThreshold = value; }
        }
        
        #endregion

        #region state (getters only)

        public List<int> AcceptedPatches
        {
            get { return _acceptedWindows; }
        }

        public Dictionary<IBoundingBox, Image<Gray, byte>> Patches
        {
            get { return _patches; }
        }

        #endregion
    }
}
