using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TLD.Model.Detection
{
    [Serializable]
    public class PixelComparisonF
    {
        private PointF _pixel1;
        private PointF _pixel2;

        public PixelComparisonF(PointF pixel1, PointF pixel2)
        {
            _pixel1 = pixel1;
            _pixel2 = pixel2;
        }

        public PointF Pixel1
        {
            get { return _pixel1; }
        }

        public PointF Pixel2
        {
            get { return _pixel2; }
        }
    }
}
