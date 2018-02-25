using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;

namespace TLD.Model.Detection
{
    public interface IClassifier
    {
        void Initialize(Image<Gray, byte> initialFrame, IBoundingBox initialBb);
        List<int> AcceptedWindows(Image<Gray, byte> frame, List<int> scanningWindows);

        void PostInstantiation();

        void Update(List<Image<Gray, byte>> positivePatches, List<Image<Gray, byte>> negativePatches);
    }
}
