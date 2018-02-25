using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TLD.Model;
using TLD.Model.Detection;

namespace TLD.View
{
    [Serializable]
    class DetectorDummy : IDetector
    {
        public List<IBoundingBox> FindObject(Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> currentFrame)
        {
            throw new NotImplementedException();
        }


        public List<IBoundingBox> Detections
        {
            get { throw new NotImplementedException(); }
        }


        public void Initialize(Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> frame, IBoundingBox boundingBox)
        {
            throw new NotImplementedException();
        }

        public void PostInstantiation()
        {
            throw new NotImplementedException();
        }


        public IBoundingBox[] ScanningWindows
        {
            get { throw new NotImplementedException(); }
        }


        public void Update(List<Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>> positivePatches, List<Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>> negativePatches)
        {
            throw new NotImplementedException();
        }
    }
}
