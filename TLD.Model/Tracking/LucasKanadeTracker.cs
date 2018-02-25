using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace TLD.Model
{
    [Serializable]
    public class LucasKanadeTracker : ILucasKanadeTracker
    {
        // supplied from client
        [NonSerialized]
        private Image<Gray, byte> _previousFrame;

        [NonSerialized]
        private Image<Gray, byte> _currentFrame;

        private Size _searchWindowSize;
        private int _levels;
        private MCvTermCriteria _terminationCriteria;
        private LKFLOW_TYPE _forwardFlags;
        private LKFLOW_TYPE _backwardFlags;

        // self-defined
        [NonSerialized]
        private Image<Gray, byte> _previousPyramidBuffer;

        [NonSerialized]
        private Image<Gray, byte> _currentPyramidBuffer;

        [NonSerialized]
        private PointF[] _currentPoints;

        public LucasKanadeTracker(
            Size searchWindowSize,
            int levels,
            MCvTermCriteria terminationCriteria,
            LKFLOW_TYPE forwardFlags,
            LKFLOW_TYPE backwardFlags
        )
        {
            // save arguments
            _searchWindowSize = searchWindowSize;
            _levels = levels;
            _terminationCriteria = terminationCriteria;
            _forwardFlags = forwardFlags;
            _backwardFlags = backwardFlags;
        }

        public void Initialize(Image<Gray, byte> frame)
        {
            _currentFrame = frame;

            // allocate space for the pyramids
            int width = frame.Width;
            int height = frame.Height;
            _previousPyramidBuffer = new Image<Gray, byte>(width + 8, height / 3);
            _currentPyramidBuffer = new Image<Gray, byte>(width + 8, height / 3);
        }

        public PointF[] TrackPointsForward(PointF[] previousPoints, Image<Gray, Byte> currentFrame, out byte[] status)
        {
            _previousFrame = _currentFrame;
            _currentFrame = currentFrame;

            float[] trackErrors;

            OpticalFlow.PyrLK(
                _previousFrame,
                currentFrame,
                _previousPyramidBuffer,
                _currentPyramidBuffer,
                previousPoints,
                _searchWindowSize,
                _levels,
                _terminationCriteria,
                _forwardFlags,
                out _currentPoints,
                out status,
                out trackErrors
            );

            return _currentPoints;
        }

        public PointF[] TrackPointsBackward(out byte[] status)
        {
            PointF[] backwardPoints;
            float[] trackErrors;

            OpticalFlow.PyrLK(
                _currentFrame,
                _previousFrame,
                _currentPyramidBuffer,
                _previousPyramidBuffer,
                _currentPoints,
                _searchWindowSize,
                _levels,
                _terminationCriteria,
                _backwardFlags,
                out backwardPoints,
                out status,
                out trackErrors
            );

            return backwardPoints;
        }

        #region properties

        public Size WindowSize
        {
            get { return _searchWindowSize; }
            set { _searchWindowSize = value; }
        }

        public int Levels
        {
            get { return _levels; }
            set { _levels = value; }
        }

        public double Epsilon
        {
            get { return _terminationCriteria.epsilon; }
            set { _terminationCriteria.epsilon = value; }
        }

        public int MaxIterations
        {
            get { return _terminationCriteria.max_iter; }
            set { _terminationCriteria.max_iter = value; }
        }

        #endregion
    }
}
