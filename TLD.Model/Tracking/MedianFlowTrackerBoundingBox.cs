using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TLD.Model
{
    [Serializable]
    public class MedianFlowTrackerBoundingBox : BoundingBox, IMedianFlowTrackerBoundingBox
    {
        public Size GridSize { get; set; }
        public SizeF GridPadding { get; set; }

        #region constructors
        public MedianFlowTrackerBoundingBox(SizeF size) : base(new PointF(), size)
        {
        }

        public MedianFlowTrackerBoundingBox(PointF center, SizeF size, Size gridSize, SizeF gridPadding) : base(center, size)
        {
            GridSize = gridSize;
            GridPadding = gridPadding;
        }

        public MedianFlowTrackerBoundingBox(Size gridSize, SizeF gridPadding) : base(new PointF(), new SizeF())
        {
            GridSize = gridSize;
            GridPadding = gridPadding;
        }

        public MedianFlowTrackerBoundingBox(PointF center, SizeF size) : base(center, size)
        {
        }

        #endregion

        public PointF[,] GetGrid(Size size, SizeF padding)
        {
            PointF[,] grid = new PointF[size.Height, size.Width];
            SizeF spacing = new SizeF(
                (Size.Width - 1 - 2 * padding.Width) / (size.Width - 1),
                (Size.Height - 1 - 2 * padding.Height) / (size.Height - 1)
            );

            for (int i = 0; i < size.Height; i++)
            {
                for (int j = 0; j < size.Width; j++)
                {
                    grid[i, j] = new PointF(
                        padding.Width + j * spacing.Width,
                        padding.Height + i * spacing.Height
                    );
                }
            }

            return grid;
        }

        #region IMedianFlowTrackerBoundingBox

        public PointF[] GetGridPoints()
        {
            PointF[] points = new PointF[GridSize.Width * GridSize.Height];
            SizeF spacing = new SizeF(
                (Size.Width - 2 * GridPadding.Width) / (GridSize.Width - 1),
                (Size.Height - 2 * GridPadding.Height) / (GridSize.Height - 1)
            );
            PointF offset = new PointF(
                Center.X - Size.Width / 2,
                Center.Y - Size.Height / 2
            );

            for (int i = 0; i < GridSize.Height; i++)
            {
                for (int j = 0; j < GridSize.Width; j++)
                {
                    points[i*GridSize.Width + j] = new PointF(
                        offset.X + GridPadding.Width + j * spacing.Width,
                        offset.Y + GridPadding.Height + i * spacing.Height
                    );
                }
            }

            return points;
        }

        public IMedianFlowTrackerBoundingBox CreateCurrent(float transX, float transY, float scale)
        {
            return new MedianFlowTrackerBoundingBox(
                new PointF(Center.X + transX, Center.Y + transY),
                new SizeF(Size.Width * scale, Size.Height * scale),
                GridSize,
                GridPadding
            );
        }

        #endregion
    }
}
