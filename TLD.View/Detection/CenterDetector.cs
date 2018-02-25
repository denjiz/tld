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
    public class CenterDetector : IDetector
    {
        [NonSerialized]
        private List<IBoundingBox> _boundingBoxes;

        [NonSerialized]
        private IBoundingBox _centerBox;

        private SizeF _bbSize;

        public SizeF BbSize
        {
            get { return _bbSize; }
            set 
            { 
                _bbSize = value;
                if (_centerBox != null)
                {
                    _centerBox.Size = _bbSize;
                }
            }
        }

        public CenterDetector(SizeF bbSize)
        {
            _bbSize = bbSize;
        }

        public List<IBoundingBox> FindObject(Image<Gray, byte> frame)
        {
            return _boundingBoxes;
        }

        public List<IBoundingBox> Detections
        {
            get { return _boundingBoxes; }
        }

        public void Initialize(Image<Gray, byte> frame, IBoundingBox boundingBox)
        {
            _centerBox = new BoundingBox(new PointF(frame.Width / 2.0f, frame.Height / 2.0f), _bbSize);
            _boundingBoxes = new List<IBoundingBox>() { _centerBox };
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
