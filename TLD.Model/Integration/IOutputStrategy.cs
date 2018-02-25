using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLD.Model.Integration
{
    public interface IOutputStrategy
    {
        IBoundingBox DetermineBoundingBox(IBoundingBox trackerBoundingBox, List<IBoundingBox> detectorBoundingBoxes, Image<Gray, byte> frame, out bool reinitializeTracker, bool prevValid, out bool currValid);
    }
}
