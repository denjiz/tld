using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TLD.Model;
using TLD.Model.Learning;

namespace TLD.View
{
    [Serializable]
    class LearnerDummy : ILearner
    {
        public void Initialize(Image<Gray, byte> initialFrame, IBoundingBox initialBb)
        {
            throw new NotImplementedException();
        }

        public void TrainDetector(Image<Gray, byte> currentFrame, IBoundingBox currentBb, out bool valid)
        {
            throw new NotImplementedException();
        }


        public IObjectModel ObjectModel
        {
            get { throw new NotImplementedException(); }
        }


        public float ValidConservativeSimilarityThreshold
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
    }
}
