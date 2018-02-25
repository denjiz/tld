using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLD.Model.Detection
{
    public interface IDetector
    {
        void PostInstantiation();
        void Initialize(Image<Gray, byte> frame, IBoundingBox boundingBox);
        List<IBoundingBox> FindObject(Image<Gray, byte> frame);
        List<IBoundingBox> Detections { get; }
        IBoundingBox[] ScanningWindows { get; }

        void Update(List<Image<Gray, byte>> positivePatches, List<Image<Gray, byte>> negativePatches);
    }
}
