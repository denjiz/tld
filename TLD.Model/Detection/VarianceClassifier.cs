using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLD.Model.Detection
{
    [Serializable]
    public class VarianceClassifier : IClassifier
    {
        private IScanningWindowGenerator _scanningWindowGenerator;
        private double _thresholdCoefficient;

        [NonSerialized]
        private Image<Gray, double> _sum;
        [NonSerialized]
        private Image<Gray, double> _squareSum;

        [NonSerialized]
        List<int> _acceptedWindows;
        [NonSerialized]
        private double _initialVariance;
        [NonSerialized]
        private double _threshold;

        public VarianceClassifier(IScanningWindowGenerator swg, double thresholdCoefficient)
        {
            _scanningWindowGenerator = swg;
            _thresholdCoefficient = thresholdCoefficient;
        }

        #region IClassifier

        public void PostInstantiation()
        {
        }

        public void Initialize(Image<Gray, byte> initialFrame, IBoundingBox initialBb)
        {
            initialFrame.Integral(out _sum, out _squareSum);
            initialBb.ScanningWindow = initialBb.CreateScanningWindow();
            Service.SetIntegralImage(_sum);
            Service.SetSquaredIntegralImage(_squareSum);
            _initialVariance = Service.GetPatchVariance(initialBb);
            _threshold = _thresholdCoefficient * _initialVariance;
            _acceptedWindows = new List<int>(_scanningWindowGenerator.ScanningWindows.Length);
        }

        public List<int> AcceptedWindows(Image<Gray, byte> frame, List<int> scanningWindows)
        {
            _acceptedWindows.Clear();
            IBoundingBox[] allScanningWindows = _scanningWindowGenerator.ScanningWindows;

            // calculate integral images
            frame.Integral(out _sum, out _squareSum);
            Service.SetIntegralImage(_sum);
            Service.SetSquaredIntegralImage(_squareSum);

            // accept patches that have variance greater than a threshold
            for (int i = 0; i < allScanningWindows.Length; i++)
            {
                int index = scanningWindows[i];
                IBoundingBox bb = allScanningWindows[index];

                if (Service.GetPatchVariance(bb) > _threshold)
                {
                    _acceptedWindows.Add(index);
                }
            }

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

        public double ThresholdCoefficient 
        {
            get { return _thresholdCoefficient; }
            set 
            { 
                _thresholdCoefficient = value;
                _threshold = _thresholdCoefficient * _initialVariance;
            }
        }

        #endregion

        #region state (getters only)

        public Image<Gray, double> Sum
        {
            get { return _sum; }
        }

        public Image<Gray, double> SquareSum
        {
            get { return _squareSum; }
        }

        public double Threshold
        {
            get { return _threshold; }
        }

        public List<int> AcceptedPatches { get { return _acceptedWindows; } }

        #endregion
    }
}
