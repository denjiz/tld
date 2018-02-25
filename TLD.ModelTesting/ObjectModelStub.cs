using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TLD.Model;

namespace TLD.ModelTesting
{
    class ObjectModelStub : IObjectModel
    {
        public List<float> RelativeSimilarities { get; set; }

        public List<float> PnnSimilarities { get; set; }

        public List<float> NnnSimilarities { get; set; }

        #region IObjectModel

        public void PostInstantiation()
        {
            throw new NotImplementedException();
        }

        public void AddPositivePatch(Image<Gray, byte> patch)
        {
            throw new NotImplementedException();
        }

        public void AddNegativePatch(Image<Gray, byte> patch)
        {
            throw new NotImplementedException();
        }

        public float RelativeSimilarity(Image<Gray, byte> patch)
        {
            float relativeSimilarity = RelativeSimilarities[0];
            RelativeSimilarities.RemoveAt(0);
            return relativeSimilarity;
        }

        public float RelativeSimilarity(Image<Gray, byte> patch, out float pnnSimilarity, out float nnnSimilarity)
        {
            pnnSimilarity = PnnSimilarities[0];
            PnnSimilarities.RemoveAt(0);
            nnnSimilarity = NnnSimilarities[0];
            NnnSimilarities.RemoveAt(0);

            float relativeSimilarity = RelativeSimilarities[0];
            RelativeSimilarities.RemoveAt(0);
            return relativeSimilarity;
        }

        public float ConservativeSimilarity(Image<Gray, byte> patch)
        {
            throw new NotImplementedException();
        }

        public Size PatchSize
        {
            get { return new Size(1,1); }
        }

        public List<Image<Gray, byte>> PositivePatches
        {
            get { throw new NotImplementedException(); }
        }

        public List<Image<Gray, byte>> NegativePatches
        {
            get { throw new NotImplementedException(); }
        }

        public float ConservativeSimilarity(Image<Gray, byte> patch, out float pnnSimilarity, out float nnnSimilarity)
        {
            throw new NotImplementedException();
        }

        #endregion


        public void Initialize()
        {
        }
    }
}
