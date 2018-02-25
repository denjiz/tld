using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLD.Model.Learning
{
    [Serializable]
    public class NegativePatchPickingInfo
    {
        public NegativePatchPickingInfo(int ensembleCount, int nnCount, float overlap)
        {
            EnsembleCount = ensembleCount;
            NnCount = nnCount;
            Overlap = overlap;
        }

        public int EnsembleCount { get; set; }

        public int NnCount { get; set; }

        public float Overlap { get; set; }
    }
}
