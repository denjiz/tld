using System;
using System.Drawing;
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
    public interface ILucasKanadeTracker
    {
        PointF[] TrackPointsForward(PointF[] previousPoints, Image<Gray, byte> currentFrame, out byte[] status);

        PointF[] TrackPointsBackward(out byte[] backStatus);

        void Initialize(Image<Gray, byte> frame);
    }
}
