using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace TLD.Model
{
    public interface ITracker
    {
        void Initialize(Image<Gray, byte> frame, IBoundingBox boundingBox);
        IBoundingBox FindObject(Image<Gray, byte> currentFrame);

        bool FailureEnabled { get; set; }
        bool Failed { get; }
    }
}
