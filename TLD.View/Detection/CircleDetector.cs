using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TLD.Model;
using TLD.Model.Detection;

namespace TLD.View
{
    [Serializable]
    public class CircleDetector : IDetector
    {
        private PointF _center;

        public PointF Center
        {
            get { return _center; }
            set { _center = value; }
        }
        private float _radius;

        public float Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }
        private float _anglePerFrame;

        public float AnglePerFrame
        {
            get { return _anglePerFrame; }
            set { _anglePerFrame = value; }
        }
        private SizeF _bbSize;

        public SizeF BbSize
        {
            get { return _bbSize; }
            set { _bbSize = value; }
        }

        [NonSerialized]
        private float _currentAngle;

        [NonSerialized]
        private List<IBoundingBox> _boundingBoxes;
        private int _bbCount;

        public int BbCount
        {
            get { return _bbCount; }
            set { _bbCount = value; }
        }
        private float _bbAngleOffset;

        public float BbAngleOffset
        {
            get { return _bbAngleOffset; }
            set { _bbAngleOffset = value; }
        }

        public CircleDetector(PointF center, float radius, float anglePerFrame, SizeF bbSize, int bbCount, float bbAngleOffset)
        {
            _center = center;
            _radius = radius;
            _anglePerFrame = anglePerFrame;
            _bbSize = bbSize;
            _bbCount = bbCount;
            _bbAngleOffset = bbAngleOffset;
        }

        public List<IBoundingBox> FindObject(Image<Gray, byte> frame)
        {
            _boundingBoxes.Clear();
            for (int i = 0; i < _bbCount; i++)
            {
                float radians = ((float)Math.PI / 180.0f) * (_currentAngle + i*_bbAngleOffset);
                PointF bbCenter = new PointF
                (
                _center.X + (float)Math.Cos(radians) * _radius,
                _center.Y + (float)Math.Sin(radians) * _radius
                );
                _boundingBoxes.Add(new BoundingBox(bbCenter, _bbSize));
            }

            _currentAngle += _anglePerFrame;

            return _boundingBoxes;
        }

        public List<IBoundingBox> Detections
        {
            get { return _boundingBoxes; }
        }

        public void Initialize(Image<Gray, byte> frame, IBoundingBox boundingBox)
        {
            _boundingBoxes = new List<IBoundingBox>();
            _currentAngle = 0;
        }

        public void PostInstantiation()
        {
        }


        public IBoundingBox[] ScanningWindows
        {
            get { throw new NotImplementedException(); }
        }


        public void Update(List<Image<Gray, byte>> positivePatches, List<Image<Gray, byte>> negativePatches)
        {
            throw new NotImplementedException();
        }
    }
}
