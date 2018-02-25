using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TLD.Model.Detection;

namespace TLD.Model
{
    [Serializable]
    public class Detector : IDetector
    {
        public delegate List<IBoundingBox> BoundingBoxSuppressionMethod(List<IBoundingBox> boundingBoxes);

        private IScanningWindowGenerator _scanningWindowGenerator;
        private IClassifier _cascadedClassifier;
        private BoundingBoxSuppressionMethod _suppressBoundingBoxes;

        [NonSerialized]
        private List<int> _scanningWindows;
        [NonSerialized]
        private List<IBoundingBox> _detections;

        public Detector(IScanningWindowGenerator scanningWindowGenerator, IClassifier classifier, BoundingBoxSuppressionMethod suppressionMethod)
        {
            _scanningWindowGenerator = scanningWindowGenerator;
            _cascadedClassifier = classifier;
            _suppressBoundingBoxes = suppressionMethod;
        }

        #region IDetector

        public void PostInstantiation()
        {
            _cascadedClassifier.PostInstantiation();
            _detections = new List<IBoundingBox>();
        }

        public void Initialize(Image<Gray, byte> frame, IBoundingBox boundingBox)
        {
            _scanningWindowGenerator.Generate(frame.Size, boundingBox);
            _cascadedClassifier.Initialize(frame, boundingBox);

            int scanningWindowCount = _scanningWindowGenerator.ScanningWindows.Length;
            _scanningWindows = new List<int>(scanningWindowCount);
            for (int i = 0; i < scanningWindowCount; i++)
            {
                _scanningWindows.Add(i);
            }
        }

        public List<IBoundingBox> FindObject(Image<Gray, byte> frame)
        {
            List<int> acceptedWindows = _cascadedClassifier.AcceptedWindows(frame, _scanningWindows);

            if (acceptedWindows.Count == 0)
            {
                _detections.Clear();
                return null;
            }

            int detectionsCount = acceptedWindows.Count;
            _detections = new List<IBoundingBox>(detectionsCount);
            for (int i = 0; i < detectionsCount; i++)
            {
                int index = acceptedWindows[i];
                _detections.Add(_scanningWindowGenerator.ScanningWindows[index]);
            }

            //_detections = _suppressBoundingBoxes(_scanningWindows);
            return _detections;
        }

        public void Update(List<Image<Gray, byte>> positivePatches, List<Image<Gray, byte>> negativePatches)
        {
            _cascadedClassifier.Update(positivePatches, negativePatches);
        }

        public List<IBoundingBox> Detections
        {
            get { return _detections; }
        }

        public IBoundingBox[] ScanningWindows
        {
            get { return _scanningWindowGenerator.ScanningWindows; }
        }

        #endregion

        #region properties (getters only)

        public IScanningWindowGenerator ScanningWindowGenerator { get { return _scanningWindowGenerator; } }

        public IClassifier CascadedClassifier { get { return _cascadedClassifier; } }

        #endregion
    }
}
