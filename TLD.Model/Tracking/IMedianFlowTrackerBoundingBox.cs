using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLD.Model
{
    public interface IMedianFlowTrackerBoundingBox : IBoundingBox
    {
        PointF[] GetGridPoints();
        IMedianFlowTrackerBoundingBox CreateCurrent(float transX, float transY, float scale);
    }
}
