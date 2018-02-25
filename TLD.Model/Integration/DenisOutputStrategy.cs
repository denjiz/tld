using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Drawing;

namespace TLD.Model.Integration
{
    [Serializable]
    public class DenisOutputStrategy : IOutputStrategy
    {
        private IObjectModel _objectModel;

        public DenisOutputStrategy(IObjectModel objectModel)
        {
            _objectModel = objectModel;
        }

        #region IOutputStrategy

        public IBoundingBox DetermineBoundingBox(IBoundingBox trackerBoundingBox, List<IBoundingBox> detectorBoundingBoxes, Image<Gray, byte> frame, out bool reinitializeTracker, bool prevValid, out bool currValid)
        {
            reinitializeTracker = false;
            currValid = false;

            /* If neither the tracker nor the detector output a bounding box,
             * the object is declared as not visible
             */
            if (trackerBoundingBox == null && detectorBoundingBoxes == null)
            {
                return null;
            }

            // calculate relative similarities for all bounding boxes
            Dictionary<IBoundingBox, float> relativeSimilarities = new Dictionary<IBoundingBox, float>();
            List<IBoundingBox> boundingBoxes = new List<IBoundingBox>();
            if (trackerBoundingBox != null)
            {
                boundingBoxes.Add(trackerBoundingBox);
            }
            if (detectorBoundingBoxes != null)
            {
                boundingBoxes.AddRange(detectorBoundingBoxes);
            }
            float maxConservativeSimilarity = -1;
            IBoundingBox maxConfidentBoundingBox = null;
            foreach (IBoundingBox boundingBox in boundingBoxes)
            {
                frame.ROI = Rectangle.Round(boundingBox.GetRectangle());
                Image<Gray, byte> patch = frame.Resize(_objectModel.PatchSize.Width, _objectModel.PatchSize.Height, INTER.CV_INTER_LINEAR);
                float conservativeSimilarity = _objectModel.RelativeSimilarity(patch);
                relativeSimilarities.Add(boundingBox, conservativeSimilarity);

                if (conservativeSimilarity > maxConservativeSimilarity)
                {
                    maxConservativeSimilarity = conservativeSimilarity;
                    maxConfidentBoundingBox = boundingBox;
                }
            }
            frame.ROI = Rectangle.Empty;

            IBoundingBox output = null;

            // if tracker is defined
            if (trackerBoundingBox != null)
            {
                output = trackerBoundingBox;

                if (detectorBoundingBoxes != null)
                {
                    // get detector bounding boxes
                    // that are more confident then the tracker
                    // and have sufficient rel. similarity
                    List<IBoundingBox> bbs = new List<IBoundingBox>();
                    foreach (IBoundingBox bb in detectorBoundingBoxes)
                    {
                        if (relativeSimilarities[bb] > relativeSimilarities[trackerBoundingBox]
                         && relativeSimilarities[bb] > 0.55f)
                        {
                            bbs.Add(bb);
                        }
                    }

                    // if there is only only one such bounding box,
                    // reinitialize the tracker
                    if (bbs.Count == 1)
                    {
                        output = bbs[0];
                        reinitializeTracker = true;
                    }
                }
            }
            
            // if tracker is not defined
            else
            {
                if (detectorBoundingBoxes != null)
                {
                    // get detector bounding boxes
                    // that have sufficient rel. similarity
                    List<IBoundingBox> bbs = new List<IBoundingBox>();
                    foreach (IBoundingBox bb in detectorBoundingBoxes)
                    {
                        if (relativeSimilarities[bb] > 0.55f)
                        {
                            bbs.Add(bb);
                        }
                    }

                    // if there is only only one such bounding box,
                    // reinitialize the tracker
                    if (bbs.Count == 1)
                    {
                        output = bbs[0];
                        reinitializeTracker = true;
                    }
                }
            }

            return output;
        }

        #endregion
    }
}
