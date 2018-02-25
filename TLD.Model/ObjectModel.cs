using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;

namespace TLD.Model
{
    [Serializable]
    public class ObjectModel : IObjectModel
    {
        private Size _patchSize;

        [NonSerialized]
        private List<Image<Gray, byte>> _positivePatches;
        [NonSerialized]
        private List<Image<Gray, byte>> _negativePatches;

        public ObjectModel(Size patchSize)
        {
            _patchSize = patchSize;
            PostInstantiation();
        }

        #region IObjectModel

        public void PostInstantiation()
        {
            _positivePatches = new List<Image<Gray, byte>>();
            _negativePatches = new List<Image<Gray, byte>>();
        }

        public void Initialize()
        {
            _positivePatches.Clear();
            _negativePatches.Clear();
        }

        public float RelativeSimilarity(Image<Gray, byte> patch)
        {
            float pnnSimilarity, nnnSimilarity;
            return RelativeSimilarity(patch, out pnnSimilarity, out nnnSimilarity);
        }

        public float RelativeSimilarity(Image<Gray, byte> patch, out float pnnSimilarity, out float nnnSimilarity)
        {
            pnnSimilarity = PnnSimilarity(patch, _positivePatches.Count);
            nnnSimilarity = NnnSimilarity(patch);

            float sumSimilarity = pnnSimilarity + nnnSimilarity;
            if (sumSimilarity == 0)
            {
                return 0;
            }

            return pnnSimilarity / sumSimilarity;
        }

        public float ConservativeSimilarity(Image<Gray, byte> patch)
        {
            float pnnSimilarity = PnnSimilarity(patch, _positivePatches.Count / 2);
            float nnnSimilarity = NnnSimilarity(patch);

            float sumSimilarity = pnnSimilarity + nnnSimilarity;
            if (sumSimilarity == 0)
            {
                return 0;
            }

            return pnnSimilarity / sumSimilarity;
        }

        public float ConservativeSimilarity(Image<Gray, byte> patch, out float pnnSimilarity, out float nnnSimilarity)
        {
            pnnSimilarity = PnnSimilarity(patch, _positivePatches.Count / 2);
            nnnSimilarity = NnnSimilarity(patch);

            float sumSimilarity = pnnSimilarity + nnnSimilarity;
            if (sumSimilarity == 0)
            {
                return 0;
            }

            return pnnSimilarity / sumSimilarity;
        }

        public void AddPositivePatch(Image<Gray, byte> patch)
        {
            _positivePatches.Add(patch);
        }

        public void AddNegativePatch(Image<Gray, byte> patch)
        {
            _negativePatches.Add(patch);
        }

        public Size PatchSize
        {
            get { return _patchSize; }
        }

        public List<Image<Gray, byte>> PositivePatches
        {
            get { return _positivePatches; }
        }

        public List<Image<Gray, byte>> NegativePatches
        {
            get { return _negativePatches; }
        }

        #endregion

        /// <summary>
        /// Calculates similarity of an arbitrary patch and the nearest positive patch.
        /// </summary>
        /// <param name="patch">Arbitrary patch.</param>
        /// <returns></returns>
        private float PnnSimilarity(Image<Gray, byte> patch, int count)
        {
            float maxSimilarity = 0;
            for (int i = 0; i < count; i++)
            {
                float similarity = Similarity(_positivePatches[i], patch);
                if (similarity > maxSimilarity)
                {
                    maxSimilarity = similarity;
                }
            }

            return maxSimilarity;
        }

        /// <summary>
        /// Calculates similarity of an arbitrary patch and the nearest negative patch.
        /// </summary>
        /// <param name="patch"></param>
        /// <returns></returns>
        private float NnnSimilarity(Image<Gray, byte> patch)
        {
            float maxSimilarity = 0;
            for (int i = 0; i < _negativePatches.Count; i++)
            {
                float similarity = Similarity(_negativePatches[i], patch);
                if (similarity > maxSimilarity)
                {
                    maxSimilarity = similarity;
                }
            }

            return maxSimilarity;
        }

        /// <summary>
        /// Calculates similarity between 2 patches.
        /// </summary>
        /// <param name="patch1"></param>
        /// <param name="patch2"></param>
        /// <returns></returns>
        private float Similarity(Image<Gray, byte> patch1, Image<Gray, byte> patch2)
        {
            float ncc = Service.NCC(patch1, patch2);
            if (ncc < 0)
            {
                return 0;
            }
            return ncc;
        }
    }
}
