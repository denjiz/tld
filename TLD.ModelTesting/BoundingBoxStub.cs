using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TLD.Model;
using TLD.Model.Detection;

namespace TLD.ModelTesting
{
    class BoundingBoxStub : IBoundingBox
    {
        public PointF CenterStub { get; set; }
        public SizeF SizeStub { get; set; }

        public BoundingBoxStub(PointF center, SizeF size)
        {
            CenterStub = center;
            SizeStub = size;
        }

        internal bool IsEqualTo(BoundingBoxStub expectedBB)
        {
            return CenterStub == expectedBB.CenterStub && SizeStub == expectedBB.SizeStub;
        }

        #region IBoundingBox

        public PointF Center
        {
            get
            {
                return CenterStub;
            }
            set
            {
                CenterStub = value;
            }
        }

        public SizeF Size
        {
            get
            {
                return SizeStub;
            }
            set
            {
                SizeStub = value;
            }
        }

        public float GetOverlap(IBoundingBox bb)
        {
            throw new NotImplementedException();
        }

        public RectangleF GetRectangle()
        {
            throw new NotImplementedException();
        }

        public IBoundingBox CreateInstance(PointF center, SizeF size)
        {
            return new BoundingBoxStub(center, size);
        }

        public bool InsideFrame(Size size)
        {
            throw new NotImplementedException();
        }

        public ScanningWindow ScanningWindow
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion



        public ScanningWindow CreateScanningWindow()
        {
            throw new NotImplementedException();
        }
    }
}
