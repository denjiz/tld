using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TLD.Model.Detection
{
    public class ScanningWindow
    {
        public Point Location;
        public Size Size;
        public double Area;

        public ScanningWindow(Point location, Size size)
        {
            Location = location;
            Size = size;
            Area = size.Width * size.Height;

            CalculateIntegralPoints();
        }

        #region integral image

        public Point A, B, C, D;
        public int AX, AY, BX, BY, CX, CY, DX, DY;

        private void CalculateIntegralPoints()
        {
            A = Location;
            B = new Point(A.X + Size.Width, A.Y);
            C = new Point(A.X, A.Y + Size.Height);
            D = new Point(B.X, C.Y);

            AX = A.X; AY = A.Y;
            BX = B.X; BY = B.Y;
            CX = C.X; CY = C.Y;
            DX = D.X; DY = D.Y;
        }

        #endregion
    }
}
