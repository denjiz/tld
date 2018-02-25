using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLD.Model.Learning
{
    [Serializable]
    public class WarpInfo
    {
        public WarpInfo(float maxShift, float maxScale, float maxAngle)
        {
            MaxShift = maxShift;
            MaxScale = maxScale;
            MaxAngle = maxAngle;
        }

        public float MaxShift { get; set; }

        public float MaxScale { get; set; }

        public float MaxAngle { get; set; }
    }
}
