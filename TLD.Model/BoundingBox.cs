using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TLD.Model.Detection;

namespace TLD.Model
{
    [Serializable]
    public class BoundingBox : IBoundingBox
    {
        [NonSerialized]
        private PointF _center;

        [NonSerialized]
        private SizeF _size;

        [NonSerialized]
        private ScanningWindow _scanningWindow;

        public BoundingBox(PointF center, SizeF size)
        {
            _center = center;
            _size = size;
        }

        #region IBoundingBox

        public PointF Center
        {
            get { return _center; }
            set { _center = value; }
        }

        public SizeF Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public float GetOverlap(IBoundingBox bb)
        {
            RectangleF r1 = GetRectangle();
            RectangleF r2 = bb.GetRectangle();

            // calculate intersection
            RectangleF rectInter = RectangleF.Intersect(r1, r2);
            float intersection = rectInter.Width * rectInter.Height;

            // calculate union
            float union = r1.Width * r1.Height + r2.Width * r2.Height - intersection;

            return intersection / union;
        }

        public RectangleF GetRectangle()
        {
            return new RectangleF(
                Center.X - Size.Width / 2,
                Center.Y - Size.Height / 2,
                Size.Width,
                Size.Height
            );
        }

        public IBoundingBox CreateInstance(PointF center, SizeF size)
        {
            return new BoundingBox(center, size);
        }

        public bool InsideFrame(Size size)
        {
            if (Left >= 0 && Right <= size.Width - 0.5f && Up >= 0 && Bottom <= size.Height - 0.5f)
            {
                return true;
            }
            return false;
        }

        public ScanningWindow CreateScanningWindow()
        {
            Point location = Point.Round(new PointF(_center.X - _size.Width / 2.0f + 0.5f, _center.Y - _size.Height / 2.0f + 0.5f ));
            Size size = System.Drawing.Size.Round(_size);

            ScanningWindow window = new ScanningWindow(location, size);
            return window;
        }

        public ScanningWindow ScanningWindow
        {
            get { return _scanningWindow; }
            set { _scanningWindow = value; }
        }

        #endregion

        public float Left { get { return Center.X - Size.Width / 2; } }
        public float Right { get { return Center.X + Size.Width / 2; } }
        public float Up { get { return Center.Y - Size.Height / 2; } }
        public float Bottom { get { return Center.Y + Size.Height / 2; } }

    }
}
