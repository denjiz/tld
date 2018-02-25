using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TLD.Model;
using TLD.Model.Detection;
using TLD.Model.Learning;

namespace TLD.Model.Integration
{
    [Serializable]
    public class Tld : ITld
    {
        private IObjectModel _objectModel;
        private ITracker _tracker;
        private ILearner _learner;
        private IDetector _detector;
        private IOutputStrategy _outputStrategy;

        [NonSerialized]
        private List<IBoundingBox> _boundingBoxes;

        [NonSerialized]
        private bool _useTracker;
        [NonSerialized]
        private bool _useLearner;
        [NonSerialized]
        private bool _useDetector;

        #region current state

        [NonSerialized]
        private Image<Gray, byte> _currentFrame;
        [NonSerialized]
        private IBoundingBox _currentBb;
        [NonSerialized]
        private bool _currentBbValid;

        #endregion

        public Tld(IObjectModel objectModel, ITracker tracker, ILearner learner, IDetector detector, IOutputStrategy outputStrategy)
        {
            _objectModel = objectModel;
            _tracker = tracker;
            _learner = learner;
            _detector = detector;
            _outputStrategy = outputStrategy;
        }

        #region ITld

        public void PostInstantiation()
        {
            _useTracker = true;
            _useLearner = true;
            _useDetector = true;
            _objectModel.PostInstantiation();
            _detector.PostInstantiation();
        }

        public void Initialize(Image<Gray, byte> frame, IBoundingBox bb)
        {
            _objectModel.Initialize();

            if (_useTracker)
                _tracker.Initialize(frame, bb);
            if (_useDetector)
                _detector.Initialize(frame, bb);
            if (_useLearner)
                _learner.Initialize(frame, bb);

            _boundingBoxes = new List<IBoundingBox>();

            _currentFrame = frame;
            _currentBb = bb;
            _currentBbValid = true;
        }

        public IBoundingBox FindObject(Image<Gray, byte> currentFrame)
        {
            IBoundingBox trackerBoundingBox = _useTracker ? _tracker.FindObject(currentFrame) : null;
            List<IBoundingBox> detectorBoundingBoxes = _useDetector ? _detector.FindObject(currentFrame) : null;

            bool reinitializeTracker;
            bool prevValid = _currentBbValid;
            bool currValid;
            IBoundingBox output = _outputStrategy.DetermineBoundingBox(
                trackerBoundingBox,
                detectorBoundingBoxes,
                currentFrame,
                out reinitializeTracker,
                prevValid,
                out currValid
            );
            _currentBbValid = currValid;

            if (reinitializeTracker)
            {
                _tracker.Initialize(currentFrame, output);
            }
            if (_currentBbValid && _useLearner)
            {
                _learner.TrainDetector(currentFrame, output, out currValid);
                _currentBbValid = currValid;
            }
            
            _currentFrame = currentFrame;
            _currentBb = output;

            return output;
        }

        public ITracker Tracker
        {
            get { return _tracker; }
        }

        public ILearner Learner
        {
            get { return _learner; }
            set { _learner = value; }
        }

        public IDetector Detector
        {
            get { return _detector; }
            set { _detector = value; }
        }

        #endregion

        public bool UseTracker
        {
            get { return _useTracker; }
            set { _useTracker = value; }
        }

        public bool UseLearner
        {
            get { return _useLearner; }
            set { _useLearner = value; }
        }

        public bool UseDetector 
        {
            get { return _useDetector; }
            set { _useDetector = value; }
        }
    }
}
