using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLD.Model.Learning
{
    public class SimilarBoundingBoxGenerationInfo
    {
        public SimilarBoundingBoxGenerationInfo(int count, float maxShift, float maxScale)
        {
            Count = count;
            MaxShift = maxShift;
            MaxScale = maxScale;
        }

        public int Count { get; set; }
        public float MaxShift { get; set; }
        public float MaxScale { get; set; }
    }
}
