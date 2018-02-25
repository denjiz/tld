using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TLD.Model;
using System.Drawing;

namespace TLD.ModelTesting
{
    class MedianFlowTrackerBoundingBoxStub : BoundingBoxStub, IMedianFlowTrackerBoundingBox
    {
        public PointF[] VisiblePointsStub { get; set; }
        public MedianFlowTrackerBoundingBoxStub HardcodedNextBB { get; set; }

        public MedianFlowTrackerBoundingBoxStub(PointF center, SizeF size, PointF[] visiblePoints) : base(center, size)
        {
            VisiblePointsStub = visiblePoints;
        }

        public MedianFlowTrackerBoundingBoxStub(PointF center, SizeF size) : base(center, size)
        {
        }

        #region IMedianFlowTrackerBoundingBox

        public PointF[] GetGridPoints()
        {
            return VisiblePointsStub;
        }

        public IMedianFlowTrackerBoundingBox CreateCurrent(float transX, float transY, float scale)
        {
            if (HardcodedNextBB == null)
            {
                return new MedianFlowTrackerBoundingBoxStub(
                    new PointF(CenterStub.X + transX, CenterStub.Y + transY),
                    new SizeF(SizeStub.Width * scale, SizeStub.Height * scale)
                );
            }
            else
            {
                return HardcodedNextBB;
            }
            
        }

        #endregion
    }
}
