using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLD.Model.Learning
{
    [Serializable]
    public class PositivePatchSynthesisInfo
    {
        public PositivePatchSynthesisInfo(int ensembleCount, int nnCount, WarpInfo warpInfo, double gaussianSigma)
        {
            EnsembleCount = ensembleCount;
            NnCount = nnCount;
            WarpInfo = warpInfo;
            GaussianSigma = gaussianSigma;
        }

        public int EnsembleCount { get; set; }

        public int NnCount { get; set; }

        public WarpInfo WarpInfo { get; set; }

        public double GaussianSigma { get; set; }
    }
}
