using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLD.Model
{
    public class CurrentState
    {
        public static Dictionary<IBoundingBox, float> RelativeSimilarities { get; private set; }

        static CurrentState()
        {
            RelativeSimilarities = new Dictionary<IBoundingBox, float>();
        }

        public static double ObjectModelGaussianSigma { get; set; }
    }
}
