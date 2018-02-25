using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TLD.Model.Learning;

namespace TLD.Model.Integration
{
    [Serializable]
    public class ZdenekOutputStrategy : IOutputStrategy
    {
        private IObjectModel _objectModel;
        private ILearner _learner;

        public float ConsSimValidThreshold { get { return _learner.ValidConservativeSimilarityThreshold; } }

        public ZdenekOutputStrategy(IObjectModel objectModel, ILearner learner)
        {
            _objectModel = objectModel;
            _learner = learner;
        }

        #region IOutputStrategy

        public IBoundingBox DetermineBoundingBox(IBoundingBox trackerBoundingBox, List<IBoundingBox> detectorBoundingBoxes, Image<Gray, byte> frame, out bool reinitializeTracker, bool prevValid, out bool currValid)
        {
            IBoundingBox output = null;
            reinitializeTracker = false;
            currValid = false;

            /* [Zdenek] If neither the tracker nor the detector output a bounding box,
             * the object is declared as not visible
             */
            if (trackerBoundingBox == null && detectorBoundingBoxes == null)
            {
                return null;
            }

            // calculate relative similarities for all bounding boxes
            Dictionary<IBoundingBox, float> relativeSimilarities = new Dictionary<IBoundingBox, float>();

            // -> tracker
            if (trackerBoundingBox != null)
            {
                frame.ROI = Rectangle.Round(trackerBoundingBox.GetRectangle());
                Size patchSize = _objectModel.PatchSize;
                Image<Gray, byte> trackerPatch = frame.Resize(patchSize.Width, patchSize.Height, INTER.CV_INTER_LINEAR);
                relativeSimilarities.Add(trackerBoundingBox, _objectModel.RelativeSimilarity(trackerPatch));
                frame.ROI = Rectangle.Empty;
            }

            // -> detector
            if (detectorBoundingBoxes != null)
            {
                for (int i = 0; i < detectorBoundingBoxes.Count; i++)
                {
                    IBoundingBox bb = detectorBoundingBoxes[i];
                    relativeSimilarities.Add(bb, CurrentState.RelativeSimilarities[bb]);
                }
            }

            // if tracker is defined
            if (trackerBoundingBox != null)
            {
                output = trackerBoundingBox;

                if (detectorBoundingBoxes != null)
                {
                    float bigOverlap = 0.8f;

                    // get detector bounding boxes
                    // that are far from tracker
                    // and are more confident then the tracker
                    List<IBoundingBox> bbs = new List<IBoundingBox>();
                    foreach (IBoundingBox bb in detectorBoundingBoxes)
                    {
                        if (bb.GetOverlap(trackerBoundingBox) < bigOverlap 
                            && relativeSimilarities[bb] > relativeSimilarities[trackerBoundingBox])
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
                        currValid = false;
                    }

                    // otherwise calculate weighted average with close detections
                    else
                    {
                        int trackerRepeat = 1;
                        PointF center = trackerBoundingBox.Center.Multiply(trackerRepeat, trackerRepeat);
                        SizeF size = trackerBoundingBox.Size.Multiply(trackerRepeat, trackerRepeat);

                        // consider detector bounding boxes that are close to the tracker
                        int bbCount = trackerRepeat;
                        foreach (IBoundingBox bb in detectorBoundingBoxes)
                        {
                            if (bb.GetOverlap(trackerBoundingBox) >= bigOverlap)
                            {
                                center = center.Add(bb.Center);
                                size = size.Add(bb.Size);
                                bbCount++;
                            }
                        }

                        output = trackerBoundingBox.CreateInstance(
                            center.Divide(bbCount, bbCount),
                            size.Divide(bbCount, bbCount)
                        );
                    }
                }
            }
            
            // if tracker is not defined
            else
            {
                if (detectorBoundingBoxes != null)
                {
                    List<IBoundingBox> suppressedBbs = Service.NonMaximalBoundingBoxSuppress(detectorBoundingBoxes);

                    // if there is a single detection, reinitialize the tracker
                    if (suppressedBbs.Count == 1)
                    {
                        output = suppressedBbs[0];
                        reinitializeTracker = true;
                        currValid = false;
                    }
                }
            }

            if (output != null)
            {
                if (prevValid == true)
                {
                    currValid = true;
                }
                else
                {
                    Image<Gray, byte> outputPatch = frame.GetPatch(output.Center, Size.Round(output.Size))
                                                     .Resize(_objectModel.PatchSize.Width, _objectModel.PatchSize.Height, INTER.CV_INTER_LINEAR);

                    float pnn, nnn;
                    float conservativeSimilarity = _objectModel.ConservativeSimilarity(outputPatch, out pnn, out nnn);
                    if (pnn > 0.8f && conservativeSimilarity >= ConsSimValidThreshold)
                    {
                        currValid = true;
                    }
                }
            }

            return output;
        }

        #endregion
    }
}
