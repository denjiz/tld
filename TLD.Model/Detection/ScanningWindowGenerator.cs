using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TLD.Model.Detection;

namespace TLD.Model
{
    [Serializable]
    public class ScanningWindowGenerator : IScanningWindowGenerator
    {
        private float _scaleStep;
        private float _xRelStep;
        private float _yRelStep;
        private int _minSize;

        [NonSerialized]
        private Size _frameSize;

        [NonSerialized]
        private IBoundingBox _initialBoundingBox;

        [NonSerialized]
        private IBoundingBox[] _scanningWindows;

        [NonSerialized]
        private bool _windowsGenerated;

        public ScanningWindowGenerator
        (
            float scaleStep,
            float xRelStep,
            float yRelStep,
            int minSize
        )
        {
            _scaleStep = scaleStep;
            _xRelStep = xRelStep;
            _yRelStep = yRelStep;
            _minSize = minSize;
        }

        #region IScanningWindowGenerator

        public IBoundingBox[] Generate(Size frameSize, IBoundingBox initialBb)
        {
            _frameSize = frameSize;
            _initialBoundingBox = initialBb;
            _windowsGenerated = true;

            List<IBoundingBox> _scanningWindowsList = new List<IBoundingBox>();

            // define minimum bounding box size
            float minSideSize = Math.Min(initialBb.Size.Width, initialBb.Size.Height);
            float ratio = minSideSize / _minSize;
            Size minBbSize = new Size
            (
                (int)Math.Ceiling(initialBb.Size.Width / ratio),
                (int)Math.Ceiling(initialBb.Size.Height / ratio)
            );

            // create bounding boxes
            Size bbSize = minBbSize;
            while (bbSize.Width <= frameSize.Width && bbSize.Height <= frameSize.Height)
            {
                // define x and y step
                float xStep = bbSize.Width * _xRelStep;
                float yStep = bbSize.Height * _yRelStep;

                for (float bbCenterY = bbSize.Height/2.0f -0.5f; bbCenterY + bbSize.Height / 2.0f <= frameSize.Height - 0.5f; bbCenterY += yStep)
                {
                    for (float bbCenterX = bbSize.Width/2.0f - 0.5f; bbCenterX + bbSize.Width / 2.0f <= frameSize.Width - 0.5f; bbCenterX += xStep)
                    {
                        IBoundingBox bb = initialBb.CreateInstance(
                            new PointF(bbCenterX, bbCenterY),
                            bbSize
                        );
                        bb.ScanningWindow = bb.CreateScanningWindow();

                        _scanningWindowsList.Add(bb);
                    }
                }

                bbSize = new Size((int)(bbSize.Width * _scaleStep), (int)(bbSize.Height * _scaleStep));
            }

            _scanningWindows = _scanningWindowsList.ToArray();
            return _scanningWindows;
        }

        public IBoundingBox[] ScanningWindows
        {
            get { return _scanningWindows; }
        }

        public float ScaleStep
        {
            get
            {
                return _scaleStep;
            }
            set
            {
                _scaleStep = value;
                if (_windowsGenerated)
                {
                    Generate(_frameSize, _initialBoundingBox);
                }
            }
        }

        public float HorizontalRelativeStep
        {
            get
            {
                return _xRelStep;
            }
            set
            {
                _xRelStep = value;
                if (_windowsGenerated)
                {
                    Generate(_frameSize, _initialBoundingBox);
                }
            }
        }

        public float VerticalRelativeStep
        {
            get
            {
                return _yRelStep;
            }
            set
            {
                _yRelStep = value;
                if (_windowsGenerated)
                {
                    Generate(_frameSize, _initialBoundingBox);
                }
            }
        }

        public int MinimumWindowSize
        {
            get
            {
                return _minSize;
            }
            set
            {
                _minSize = value;
                if (_windowsGenerated)
                {
                    Generate(_frameSize, _initialBoundingBox);
                }
            }
        }

        #endregion
    }
}
