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
    public class EnsembleClassifier : IClassifier
    {
        private static Random _rand = new Random();

        BaseClassifier[] _baseClassifiers;
        private IScanningWindowGenerator _scanningWindowGenerator;
        private IPixelComparisonScheduler _pixelComparisonScheduler;

        private int _baseClassifierNumber;
        private int _maxComparisonsPerClassifier;
        private double _sigma;

        [NonSerialized]
        private Image<Gray, byte> _smoothFrame;
        [NonSerialized]
        private List<int> _acceptedWindows;
        [NonSerialized]
        List<Image<Gray, byte>> _positivePatches;
        [NonSerialized]
        List<Image<Gray, byte>> _negativePatches;
        [NonSerialized]
        Dictionary<IBoundingBox, double> _posteriors;
        [NonSerialized]
        Dictionary<IBoundingBox, double> _positivePosteriors;

        public EnsembleClassifier(IScanningWindowGenerator swg, int baseClassifierNumber, int maxComparisonsPerClassifier, int patchWidth, int patchHeight, double sigma)
        {
            _scanningWindowGenerator = swg;
            _baseClassifierNumber = baseClassifierNumber;
            _maxComparisonsPerClassifier = maxComparisonsPerClassifier;
            _sigma = sigma;

            // generate pixel comparisons
            _pixelComparisonScheduler = new PixelComparisonScheduler
            (
            baseClassifierNumber,
            maxComparisonsPerClassifier,
            patchWidth,
            patchHeight
            );

            GenerateBaseClassifiers();
        }

        public EnsembleClassifier(IScanningWindowGenerator swg, IPixelComparisonScheduler pixelComparisonScheduler, double sigma)
        {
            _scanningWindowGenerator = swg;
            _pixelComparisonScheduler = pixelComparisonScheduler;
            _sigma = sigma;
            _baseClassifierNumber = pixelComparisonScheduler.BaseClassifierCount;
            _maxComparisonsPerClassifier = pixelComparisonScheduler.MaxComparisonsPerClassifier;

            GenerateBaseClassifiers();
        }

        private void GenerateBaseClassifiers()
        {
            _baseClassifiers = new BaseClassifier[_baseClassifierNumber];
            for (int i = 0; i < _baseClassifierNumber; i++)
            {
                _baseClassifiers[i] = new BaseClassifier(_scanningWindowGenerator, i, _pixelComparisonScheduler);
            }
        }

        #region IClassifier

        public void PostInstantiation()
        {
            _pixelComparisonScheduler.PostInstantiation();
            for (int i = 0; i < _baseClassifiers.Length; i++)
            {
                _baseClassifiers[i].PostInstantiation();
            }
            _posteriors = new Dictionary<IBoundingBox, double>();
            _positivePosteriors = new Dictionary<IBoundingBox, double>();
        }

        public void Initialize(Image<Gray, byte> initialFrame, IBoundingBox initialBb)
        {
            _acceptedWindows = new List<int>(_scanningWindowGenerator.ScanningWindows.Length);
            _smoothFrame = new Image<Gray, byte>(initialFrame.Size);
            for (int i = 0; i < _baseClassifiers.Length; i++)
            {
                _baseClassifiers[i].Initialize();
            }
        }

        public List<int> AcceptedWindows(Image<Gray, byte> frame, List<int> scanningWindows)
        {
            _acceptedWindows.Clear();
            IBoundingBox[] allScanningWindows = _scanningWindowGenerator.ScanningWindows;

            // smooth the image with gaussian kernel
            _smoothFrame.ROI = Rectangle.Empty;
            CvInvoke.cvSmooth
            (
            frame.Ptr,
            _smoothFrame.Ptr,
            SMOOTH_TYPE.CV_GAUSSIAN,
            0, 0,
            _sigma, _sigma
            );

            _posteriors.Clear();
            _positivePosteriors.Clear();
            for (int i = 0; i < _baseClassifiers.Length; i++)
            {
                _baseClassifiers[i].ForgetCodes();
                _baseClassifiers[i].SetCurrentFrame(_smoothFrame);
            }

            // accept all windows where probability is greater that 0.5
            for (int i = 0; i < scanningWindows.Count; i++)
            {
                int index = scanningWindows[i];
                IBoundingBox window = allScanningWindows[index];

                double posterior = CalculatePosteriorForWindow(index);
                if (posterior > 0.5f)
                {
                    _acceptedWindows.Add(index);
                    _positivePosteriors.Add(window, posterior);
                }
                _posteriors.Add(window, posterior);
            }

            return _acceptedWindows;
        }

        public void Update(List<Image<Gray, byte>> positivePatches, List<Image<Gray, byte>> negativePatches)
        {
            for (int i = 0; i < _baseClassifiers.Length; i++)
            {
                _baseClassifiers[i].Update(positivePatches, negativePatches);
            }
            _positivePatches = positivePatches;
            _negativePatches = negativePatches;
        }

        #endregion

        private double CalculatePosteriorForWindow(int windowIndex)
        {
            // average posteriors of individual base classifiers
            double sum = 0;
            for (int i = 0; i < _baseClassifiers.Length; i++)
            {
                sum += _baseClassifiers[i].CalculatePosteriorForWindow(windowIndex);
            }
            return sum / _baseClassifiers.Length;
        }

        private double CalculatePosterior(Image<Gray, byte> frame, IBoundingBox boundingBox, bool trainingMode)
        {
            // average posteriors of individual base classifiers
            double sum = 0;
            for (int i = 0; i < _baseClassifiers.Length; i++)
            {
                sum += _baseClassifiers[i].GetPosterior(frame, boundingBox);
                if (!trainingMode)
                {
                    _baseClassifiers[i].RememberLastCode();
                }
            }
            return sum / _baseClassifiers.Length;
        }

        #region training

        public void TrainWithUnseenPatches(List<Image<Gray, byte>> positivePatches, List<Image<Gray, byte>> negativePatches)
        {
            // collect patches and create labels and permute them
            Image<Gray, byte>[] patches;
            bool[] labels;
            Service.PermuteTrainingExamples<Image<Gray, byte>>(positivePatches, negativePatches, out patches, out labels);

            // train
            for (int i = 0; i < patches.Length; i++)
            {
                // get posterior
                Image<Gray, byte> frame = patches[i];
                SizeF size = frame.Size;
                BoundingBox bb = new BoundingBox(
                    new PointF((size.Width-1)/2.0f, (size.Height-1)/2.0f),
                    new SizeF(size.Width-1, size.Height-1)
                );
                double posterior = CalculatePosterior(patches[i], bb, true);

                // add if classification would be incorrect
                if (labels[i] == true && posterior <= 0.5f)
                {
                    for (int j = 0; j < _baseClassifiers.Length; j++)
                    {
                        _baseClassifiers[j].AddLastCodeAsPositive();
                    }
                }
                else if (labels[i] == false && posterior > 0.5f)
                {
                    for (int j = 0; j < _baseClassifiers.Length; j++)
                    {
                        _baseClassifiers[j].AddLastCodeAsNegative();
                    }
                }
            }
        }

        public void Train_NewPositive_SeenNegative_BoundingBoxes(IBoundingBox[] bbs, bool[] labels)
        {
            int baseCount = _baseClassifiers.Length;
            for (int i = 0; i < bbs.Length; i++)
            {
                IBoundingBox bb = bbs[i];
                bool label = labels[i];
                double posterior = CalculatePosterior(_smoothFrame, bb, true);

                if (label == true && posterior <= 0.5f)
                {
                    for (int j = 0; j < baseCount; j++)
                    {
                        _baseClassifiers[j].AddLastCodeAsPositive();
                    }
                }
                else if (label == false && posterior > 0.5f)
                {
                    for (int j = 0; j < baseCount; j++)
                    {
                        _baseClassifiers[j].AddLastCodeAsNegative();
                    }
                }
            }
        }

        public void TrainWithNewPositiveBoundingBoxes(List<IBoundingBox> positiveBbs)
        {
            for (int i = 0; i < positiveBbs.Count; i++)
            {
                if (CalculatePosterior(_smoothFrame, positiveBbs[i], true) <= 0.5f)
                {
                    for (int j = 0; j < _baseClassifiers.Length; j++)
                    {
                        _baseClassifiers[j].AddLastCodeAsPositive();
                    }
                }
            }
        }

        public void TrainWithMisclassifiedNegativeBoundingBoxes(List<IBoundingBox> negativeBbs)
        {
            for (int i = 0; i < negativeBbs.Count; i++)
            {
                IBoundingBox bb = negativeBbs[i];
                if (CalculatePosterior(_smoothFrame, bb, true) > 0.5)
                {
                    for (int j = 0; j < _baseClassifiers.Length; j++)
                    {
                        _baseClassifiers[j].AddSeenBoundingBoxAsNegative(bb);
                    }
                }
            }
        }

        #endregion

        #region helper functions
        /*
        public void GenerateAllPatchCodes()
        {
            // allocate array
            int length = (int)Math.Pow(2, _pixelComparisonScheduler.ComparisonsPerClassifier);
            _allPatchCodes = new BoolArrayKey[length];

            // create codes

        }
        */
        #endregion

        #region configuration (getters and setters)

        public int BaseClassifierNumber
        {
            get { return _baseClassifierNumber; }
            set
            {
                _baseClassifierNumber = value;
                _pixelComparisonScheduler.BaseClassifierCount = value;
                GenerateBaseClassifiers();
            }
        }

        public int MaxComparisonsPerClassifier
        {
            get { return _maxComparisonsPerClassifier; }
            set
            {
                _maxComparisonsPerClassifier = value;
                _pixelComparisonScheduler.MaxComparisonsPerClassifier = value;
                GenerateBaseClassifiers();
            }
        }

        public double Sigma
        {
            get { return _sigma; }
            set { _sigma = value; }
        }

        #endregion

        #region components (getters only)

        public IScanningWindowGenerator ScanningWindowGenerator
        {
            get { return _scanningWindowGenerator; }
        }

        public IPixelComparisonScheduler PixelComparisonScheduler
        {
            get { return _pixelComparisonScheduler; }
        }

        #endregion

        #region state (getters only)

        public Image<Gray, byte> SmoothFrame
        {
            get { return _smoothFrame; }
        }

        public Dictionary<IBoundingBox, double> PositivePosteriors
        {
            get { return _positivePosteriors; }
        }

        public Dictionary<IBoundingBox, double> Posteriors
        {
            get { return _posteriors; }
        }

        public List<int> AcceptedPatches
        {
            get { return _acceptedWindows; }
        }

        #endregion
    }
}
