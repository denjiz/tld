using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TLD.Model;
using TLD.Model.Integration;

namespace TLD.View
{
    [Serializable]
    class AverageOutputStrategy : IOutputStrategy
    {
        /// <summary>
        /// Returns average (by center and size) of the given bounding boxes.
        /// </summary>
        /// <param name="boundingBoxes"></param>
        /// <param name="frame"></param>
        /// <returns></returns>
        public IBoundingBox DetermineBoundingBox(IBoundingBox trackerBoundingBox, List<IBoundingBox> detectorBoundingBoxes, Image<Gray, byte> frame, out bool reinitializeTracker, bool prevValid, out bool currValid)
        {
            reinitializeTracker = false;
            currValid = false;

            List<IBoundingBox> boundingBoxes = new List<IBoundingBox>();
            if (trackerBoundingBox != null)
            {
                boundingBoxes.Add(trackerBoundingBox);
            }
            if (detectorBoundingBoxes != null)
            {
                boundingBoxes.AddRange(detectorBoundingBoxes);
            }
            if (boundingBoxes.Count == 0)
            {
                return null;
            }
            PointF center = new PointF(0, 0);
            SizeF size = new SizeF(0, 0);
            foreach (IBoundingBox bb in boundingBoxes)
            {
                center.X += bb.Center.X;
                center.Y += bb.Center.Y;
                size.Width += bb.Size.Width;
                size.Height += bb.Size.Height;
            }

            int n = boundingBoxes.Count;
            center.X /= n;
            center.Y /= n;
            size.Width /= n;
            size.Height /= n;

            return new BoundingBox(center, size);
        }
    }
}
