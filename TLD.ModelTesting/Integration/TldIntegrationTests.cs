using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TLD.Persistency;
using TLD.Model.Integration;
using System.IO;
using Emgu.CV.Structure;
using Emgu.CV;
using TLD.Model;
using System.Drawing;
using System.Collections.Generic;

namespace TLD.ModelTesting.Integration
{
    [TestClass]
    public class TldIntegrationTests
    {
        private string _resourceDir = @"..\..\Resource";

        #region helper functions

        private Image<Gray, byte>[] LoadVideoFrames(string framesFolder, int framesCount)
        {
            string framesPath = Path.Combine(_resourceDir, framesFolder);
            Image<Gray, byte>[] frames = new Image<Gray, byte>[framesCount];
            for (int i = 0; i < framesCount; i++)
            {
                string framePath = Path.Combine(framesPath, (i + 1).ToString() + ".jpg");
                frames[i] = new Image<Gray, byte>(framePath);
            }

            return frames;
        }

        #endregion

        /* Test a simple case - object moves out of view,
         * and then appears at a different location 
         * with appearance similar to the inital appearance.
         * Object trajectory:
         * 
         * ------------------
         * -      (3)       -
         * -                -
         * -     (1,4)      -      (2)
         * -                -
         * -                -
         * ------------------
         * 
         */

        [TestMethod]
        public void FindObject_MultipleTimes_Simple()
        {
            // arrange - instantiate tld
            ITld tld = TldHardcoded.Instantiate();

            // arrange - load video frames
            Image<Gray, byte>[] frames = LoadVideoFrames("Video1", 25);
        }

        // [CAN FAIL !!!]
        /* This test method tests how detector and learner interact.
         * TLD is initialized in the first frame;
         * detector has to find the object in the second frame.
         */
        [TestMethod]
        public void DetectObject_DetectorAndLearnerInteraction()
        {
            // arrange - instantiate tld
            Tld tld = Persistor.LoadTld(Path.Combine(_resourceDir, "tld.xml")) as Tld;

            // arrange - load init frame
            Image<Gray, byte> initFrame = new Image<Gray, byte>(Path.Combine(_resourceDir, "face_frame1.png"));

            // arrange - define init bounding box
            BoundingBox initBb = new BoundingBox(new PointF(286, 271), new SizeF(172, 143));

            // arrange - initialize TLD
            tld.Initialize(initFrame, initBb);

            // arrange - load second frame
            Image<Gray, byte> frame2 = new Image<Gray, byte>(Path.Combine(_resourceDir, "face_frame2.png"));

            // arrange - call 'FindObject' on TLD
            tld.FindObject(frame2);

            // define expected
            IBoundingBox expected = new BoundingBox(new PointF(285, 258), new SizeF(169, 136));

            // get actual
            List<IBoundingBox> detectorOutputs = tld.Detector.Detections;

            // assert - CAN FAIL !!! - detector should find the object
            Assert.IsTrue(detectorOutputs.Count >= 1);
            float expectedOverlap = 0.85f;
            foreach (IBoundingBox output in detectorOutputs)
            {
                float overlap = output.GetOverlap(expected);
                Assert.AreEqual(expectedOverlap, overlap, 0.15f);
            }
        }
    }
}
