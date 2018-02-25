using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TLD.Model
{
    public interface IObjectModel
    {
        void PostInstantiation();

        void Initialize();

        /// <summary>
        /// Patch size must be normalized.
        /// </summary>
        /// <param name="patch"></param>
        void AddPositivePatch(Image<Gray, byte> patch);

        /// <summary>
        /// Patch size must be normalized.
        /// </summary>
        /// <param name="patch"></param>
        void AddNegativePatch(Image<Gray, byte> patch);

        /// <summary>
        /// Patch size must be normalized.
        /// </summary>
        /// <param name="patch"></param>
        /// <returns></returns>
        float RelativeSimilarity(Image<Gray, byte> patch);

        /// <summary>
        /// Patch size must be normalized.
        /// </summary>
        /// <param name="patch"></param>
        /// <returns></returns>
        float RelativeSimilarity(Image<Gray, byte> patch, out float pnnSimilarity, out float nnnSimilarity);

        /// <summary>
        /// Patch size must be normalized.
        /// </summary>
        /// <param name="patch"></param>
        /// <returns></returns>
        float ConservativeSimilarity(Image<Gray, byte> patch);

        /// <summary>
        /// Patch size must be normalized.
        /// </summary>
        /// <param name="patch"></param>
        /// <returns></returns>
        float ConservativeSimilarity(Image<Gray, byte> patch, out float pnnSimilarity, out float nnnSimilarity);

        Size PatchSize { get; }

        List<Image<Gray, byte>> PositivePatches { get; }

        List<Image<Gray, byte>> NegativePatches { get; }
    }
}
