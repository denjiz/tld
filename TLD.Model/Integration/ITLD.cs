using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TLD.Model.Detection;
using TLD.Model.Learning;

namespace TLD.Model.Integration
{
    public interface ITld
    {
        void PostInstantiation();
        void Initialize(Image<Gray, byte> frame, IBoundingBox bb);
        IBoundingBox FindObject(Image<Gray, byte> currentFrame);

        ITracker Tracker { get; }
        ILearner Learner { get; set; }
        IDetector Detector { get; set; }
    }
}
