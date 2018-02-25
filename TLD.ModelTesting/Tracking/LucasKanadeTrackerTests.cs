using System;
using System.IO;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using TLD.Model;

namespace TLD.ModelTesting
{
    [TestClass]
    public class LucasKanadeTrackerTests
    {
        private string _resourceDir = @"..\..\Resource";

        private bool PointsAreClose(PointF p1, PointF p2, float treshold)
        {
            if (Math.Abs(p1.X - p2.X) <= treshold && Math.Abs(p1.Y - p2.Y) <= treshold)
            {
                return true;
            }

            return false;
        }

        [TestMethod]
        public void TrackPointsForward_DoesntThrowException()
        {
            // arrange
            LucasKanadeTracker tracker = new LucasKanadeTracker(
                new Size(4, 4),
                2,
                new MCvTermCriteria(20, 0.03),
                LKFLOW_TYPE.DEFAULT,
                LKFLOW_TYPE.CV_LKFLOW_PYR_A_READY|LKFLOW_TYPE.CV_LKFLOW_PYR_B_READY
            );
            tracker.Initialize(new Image<Gray, byte>(Path.Combine(_resourceDir, "head_straight.jpg")));
            PointF[] previousPoints = new PointF[] { new PointF(320, 240) };
            Image<Gray, byte> currentFrame = new Image<Gray, byte>(Path.Combine(_resourceDir, "head_tilted.jpg"));

            // act
            byte[] status;
            PointF[] currentPoints = tracker.TrackPointsForward(previousPoints, currentFrame, out status);
        }

        [TestMethod]
        public void TrackPointsBackward_DoesntThrowException()
        {
            // arrange
            LucasKanadeTracker tracker = new LucasKanadeTracker(
                new Size(4, 4),
                2,
                new MCvTermCriteria(20, 0.03),
                LKFLOW_TYPE.DEFAULT,
                LKFLOW_TYPE.CV_LKFLOW_PYR_A_READY | LKFLOW_TYPE.CV_LKFLOW_PYR_B_READY
            );
            tracker.Initialize(new Image<Gray, byte>(Path.Combine(_resourceDir, "head_straight.jpg")));
            PointF[] previousPoints = new PointF[] { new PointF(320, 240) };
            Image<Gray, byte> currentFrame = new Image<Gray, byte>(Path.Combine(_resourceDir, "head_tilted.jpg"));
            byte[] status;
            PointF[] currentPoints = tracker.TrackPointsForward(previousPoints, currentFrame, out status);

            // act
            PointF[] backwardPoints = tracker.TrackPointsBackward(out status);
        }

        [TestMethod]
        public void TrackPointsForward_Precision_SmallTranslationX5Y8()
        {
            // arrange
            LucasKanadeTracker tracker = new LucasKanadeTracker(
                new Size(4, 4),
                2,
                new MCvTermCriteria(20, 0.01),
                LKFLOW_TYPE.DEFAULT,
                LKFLOW_TYPE.CV_LKFLOW_PYR_A_READY | LKFLOW_TYPE.CV_LKFLOW_PYR_B_READY
            );
            tracker.Initialize(new Image<Gray, byte>(Path.Combine(_resourceDir, "head_close_1.jpg")));
            PointF pointOfInterest = new PointF(256, 333);
            PointF[] previousPoints = new PointF[] { pointOfInterest };
            Image<Gray, byte> currentFrame = new Image<Gray, byte>(Path.Combine(_resourceDir, "head_close_2.jpg"));
            
            // define expected 
            PointF expectedPoint = new PointF(261, 341);
            byte expectedStatus = 1;

            // get actual
            byte[] status;
            PointF actualPoint = tracker.TrackPointsForward(previousPoints, currentFrame, out status)[0];
            byte actualStatus = status[0];

            // assert
            Assert.IsTrue(PointsAreClose(expectedPoint, actualPoint, 2.0f));
            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [TestMethod]
        public void TrackPointsBackward_Precision_SmallTranslationX5Y8()
        {
            // arrange
            LucasKanadeTracker tracker = new LucasKanadeTracker(
                new Size(4, 4),
                2,
                new MCvTermCriteria(20, 0.01),
                LKFLOW_TYPE.DEFAULT,
                LKFLOW_TYPE.CV_LKFLOW_PYR_A_READY | LKFLOW_TYPE.CV_LKFLOW_PYR_B_READY
            );
            tracker.Initialize(new Image<Gray, byte>(Path.Combine(_resourceDir, "head_close_1.jpg")));
            PointF pointOfInterest = new PointF(256, 333);
            PointF[] previousPoints = new PointF[] { pointOfInterest };
            Image<Gray, byte> currentFrame = new Image<Gray, byte>(Path.Combine(_resourceDir, "head_close_2.jpg"));
            byte[] forwardStatus;
            tracker.TrackPointsForward(previousPoints, currentFrame, out forwardStatus);

            // define expected 
            PointF expectedPoint = new PointF(256, 333);
            byte expectedStatus = 1;

            // get actual
            byte[] backwardStatus;
            PointF actualPoint = tracker.TrackPointsBackward(out backwardStatus)[0];
            byte actualStatus = backwardStatus[0];

            // assert
            Assert.IsTrue(PointsAreClose(expectedPoint, actualPoint, 2.0f));
            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [TestMethod]
        public void ForwardAndBackward_On2ndAnd3rdFrame()
        {
            // arrange - initialization
            LucasKanadeTracker tracker = new LucasKanadeTracker(
                new Size(10, 10),
                4,
                new MCvTermCriteria(20, 0.01),
                LKFLOW_TYPE.DEFAULT,
                LKFLOW_TYPE.CV_LKFLOW_PYR_A_READY | LKFLOW_TYPE.CV_LKFLOW_PYR_B_READY
            );
            tracker.Initialize(new Image<Gray, byte>(Path.Combine(_resourceDir, "pen_1.jpg"))); // unimportant choice

            // arrange - simulate forward-backward tracking on frames 1 and 2
            PointF[] previousPoints = new PointF[] { new PointF(0, 0) };
            Image<Gray, byte> currentFrame = new Image<Gray, byte>(Path.Combine(_resourceDir, "head_close_1.jpg"));
            byte[] status;
            tracker.TrackPointsForward(previousPoints, currentFrame, out status);
            tracker.TrackPointsBackward(out status);

            // arrange - prepare data for forward-backward tracking on frames 2 and 3
            PointF pointOfInterest = new PointF(256, 333);
            previousPoints = new PointF[] { pointOfInterest };
            currentFrame = new Image<Gray, byte>(Path.Combine(_resourceDir, "head_close_2.jpg"));

            // define expected 
            PointF expectedForwardPoint = new PointF(261, 341);
            PointF expectedBackwardPoint = new PointF(256, 333);
            byte expectedForwardStatus = 1;
            byte expectedBackwardStatus = 1;

            // get actual
            byte[] forwardStatus;
            byte[] backwardStatus;
            PointF actualForwardPoint = tracker.TrackPointsForward(previousPoints, currentFrame, out forwardStatus)[0];
            PointF actualBackwardPoint = tracker.TrackPointsBackward(out backwardStatus)[0];
            byte actualForwardStatus = forwardStatus[0];
            byte actualBackwardStatus = backwardStatus[0];

            // assert
            Assert.IsTrue(PointsAreClose(expectedForwardPoint, actualForwardPoint, 2.0f));
            Assert.IsTrue(PointsAreClose(expectedBackwardPoint, actualBackwardPoint, 2.0f));
            Assert.AreEqual(expectedForwardStatus, actualForwardStatus);
            Assert.AreEqual(expectedBackwardStatus, actualBackwardStatus);
        }

        /* Tests what happens when points outside of the image are to be tracked.
         * 4 points are chosen: each behind one side of the image.
         * This test asserts that the points are failed to be tracked,
         * and also that their coordinates stay the same.
         */

        [TestMethod]
        public void TrackPointsForward_OutsidePoints_FailToBeTracked()
        {
            // arrange - instantiate tracker
            Image<Gray,byte> frame = new Image<Gray, byte>(Path.Combine(_resourceDir, "head_straight.jpg"));
            LucasKanadeTracker tracker = new LucasKanadeTracker(
                new Size(4, 4),
                2,
                new MCvTermCriteria(20, 0.03),
                LKFLOW_TYPE.DEFAULT,
                LKFLOW_TYPE.CV_LKFLOW_PYR_A_READY | LKFLOW_TYPE.CV_LKFLOW_PYR_B_READY
            );
            tracker.Initialize(frame);

            // define expected - create outside points
            int w = frame.Width;
            int h = frame.Height;
            PointF[] outsidePoints = 
            {
                new PointF( -5  ,   h/2),   // left
                new PointF(w+5  ,   h/2),   // right
                new PointF(w/2  ,    -5),   // up
                new PointF(w/2  ,   h+5)    // bottom
            };
            byte[] expectedStatus = { 0, 0, 0, 0 };

            // get actual - try to track the outside points
            byte[] actualStatus;
            PointF[] actualPoints = tracker.TrackPointsForward(
                outsidePoints,
                new Image<Gray, byte>(Path.Combine(_resourceDir, "head_close_1.jpg")),
                out actualStatus
            );

            // assert
            CollectionAssert.AreEqual(expectedStatus, actualStatus);
            CollectionAssert.AreEqual(outsidePoints, actualPoints);
        }

        /* This tests asserts that changing the termination criteria
         * affects the result
         */

        [TestMethod]
        public void TrackPointsForward_ChangingTerminationCriteriaChangesTheResult()
        {
            // arrange
            LucasKanadeTracker tracker = new LucasKanadeTracker(
                new Size(11, 11),
                2,
                new MCvTermCriteria(20, 0.03),
                LKFLOW_TYPE.DEFAULT,
                LKFLOW_TYPE.CV_LKFLOW_PYR_A_READY | LKFLOW_TYPE.CV_LKFLOW_PYR_B_READY
            );
            tracker.Initialize(new Image<Gray, byte>(Path.Combine(_resourceDir, "head_close_1.jpg")));
            PointF pointOfInterest = new PointF(256, 333);
            PointF[] previousPoints = new PointF[] { pointOfInterest };
            Image<Gray, byte> currentFrame = new Image<Gray, byte>(Path.Combine(_resourceDir, "head_close_2.jpg"));

            // initialization point
            PointF point = new PointF(int.MaxValue, int.MaxValue);

            // change max iterations 5 times
            tracker.Epsilon = int.MinValue;
            int[] maxIterations = { 0,1,2,3,4 };
            for (int i = 0; i < 5; i++)
            {
                tracker.MaxIterations = maxIterations[i];

                // track point
                byte[] status;
                tracker.Initialize(new Image<Gray, byte>(Path.Combine(_resourceDir, "head_close_1.jpg")));
                PointF actualPoint = tracker.TrackPointsForward(previousPoints, currentFrame, out status)[0];
                byte actualStatus = status[0];

                // assert that the point is tracked successfully
                Assert.AreEqual(1, actualStatus);

                // assert that this point is different than the point with different termination criteria
                Assert.AreNotEqual(point, actualPoint);

                point = actualPoint;
            }

            point = new PointF(int.MaxValue, int.MaxValue);

            // change epsilon 5 times
            tracker.MaxIterations = int.MaxValue;
            double[] epsilons = { 1, 0.6, 0.4, 0.1, 0.025 };
            for (int i = 0; i < 5; i++)
            {
                tracker.Epsilon = epsilons[i];

                // track point
                byte[] status;
                tracker.Initialize(new Image<Gray, byte>(Path.Combine(_resourceDir, "head_close_1.jpg")));
                PointF actualPoint = tracker.TrackPointsForward(previousPoints, currentFrame, out status)[0];
                byte actualStatus = status[0];

                // assert that the point is tracked successfully
                Assert.AreEqual(1, actualStatus);

                // assert that this point is different than the point with different termination criteria
                Assert.AreNotEqual(point, actualPoint);

                point = actualPoint;
            }
        }
    }
}
