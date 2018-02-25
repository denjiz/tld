using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TLD.Model.Detection;

namespace TLD.Model.Learning
{
    public interface ILearner
    {
        void Initialize(Image<Gray, byte> initialFrame, IBoundingBox initialBb);
        void TrainDetector(Image<Gray, byte> currentFrame, IBoundingBox currentBb, out bool valid);

        IObjectModel ObjectModel { get; }
        float ValidConservativeSimilarityThreshold { get; set; }
    }
}
