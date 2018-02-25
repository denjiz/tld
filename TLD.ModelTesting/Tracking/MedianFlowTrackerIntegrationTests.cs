using System;
using System.Drawing;
using System.IO;
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
    public class MedianFlowTrackerIntegrationTests
    {
        private string _resourceDir = @"..\..\Resource";

        private MedianFlowTrackerBoundingBox _gridBb;
        private ILucasKanadeTracker _lkTracker;
        MedianFlowTracker.FBError_Calculator _fbErrorCalc;
        MedianFlowTracker.NCC_Calculator _nccCalc;
        private Size _patchSize;
        private float _madTrashold;
        private MedianFlowTracker _tracker;
        private Image<Gray, byte> _initialFrame;
        private IBoundingBox _initialBB;

        /// <summary>
        /// Instatiates a ready-to-go median flow tracker.
        /// All of its initial configuration is done here.
        /// </summary>
        private void InstantiateTracker()
        {
            // grid bounding box
            _gridBb = new MedianFlowTrackerBoundingBox
            (
                new Size(10, 10),
                new SizeF(5, 5)
            );

            // lucas kanade tracker
            _lkTracker = new LucasKanadeTracker(
                new Size(11, 11),
                2,
                new MCvTermCriteria(20, 0.03),
                LKFLOW_TYPE.DEFAULT,
                LKFLOW_TYPE.CV_LKFLOW_PYR_A_READY | LKFLOW_TYPE.CV_LKFLOW_PYR_B_READY
            );

            // fb error and ncc calculators
            _fbErrorCalc = Service.FBError;
            _nccCalc = Service.NCC;

            // patch size for calculating NCC
            _patchSize = new Size(11, 11);

            // MAD treshold
            _madTrashold = 10;

            // ** instantiate the median flow tracker **
            _tracker = new MedianFlowTracker(
                _gridBb,
                _lkTracker,
                _fbErrorCalc,
                _nccCalc,
                _patchSize,
                _madTrashold
            );

            // initial frame
            _initialFrame = new Image<Gray, byte>(Path.Combine(_resourceDir, "violeta_5.jpg"));

            // initial bounding box
            _initialBB = new BoundingBox(
                new PointF(90, 81),
                new SizeF(70, 40)
            );

            // ** initialize the median flow tracker **
            _tracker.Initialize(_initialFrame, _initialBB);
        }

        /* Test first tracking.
         * The tracker is instantiated with the initial frame,
         * and then its method 'FindObject' is called for the first time.
         * Tracker should return a bounding box that has 50% or more overlap
         * with the expected bounding box.
         */
        [TestMethod]
        public void FindObject_1stTracking()
        {
            // arrange - instantiate tracker
            InstantiateTracker();

            // arrange - load new/current frame
            Image<Gray, byte> currentFrame = new Image<Gray, byte>
            (
                Path.Combine(_resourceDir, "violeta_6.jpg")
            );

            // define expected - status and new/current bounding box
            MedianFlowTrackerStatus expectedStatus = MedianFlowTrackerStatus.OK;
            IBoundingBox expectedBB = new BoundingBox
            (
                new PointF(100, 89),
                new SizeF(70, 40)
            );

            // get actual
            IBoundingBox actualBB = _tracker.FindObject(currentFrame);
            MedianFlowTrackerStatus actualStatus = _tracker.Status;

            // assert
            Assert.AreEqual(expectedStatus, actualStatus);
            float overlap = actualBB.GetOverlap(expectedBB);
            Assert.AreEqual(0.95f, overlap, 0.05f);
        }

        /* Test second tracking.
         * The tracker is instantiated with the initial frame,
         * and then its method 'FindObject' is called twice.
         * Only the results of the second call are asserted.
         * Tracker should return a bounding box that has 50% or more overlap
         * with the expected bounding box.
         */
        [TestMethod]
        public void FindObject_2ndTracking()
        {
            // arrange - instantiate tracker
            InstantiateTracker();

            // arrange - track for the first time
            Image<Gray, byte> currentFrame1 = new Image<Gray, byte>
            (
                Path.Combine(_resourceDir, "violeta_6.jpg")
            );
            _tracker.FindObject(currentFrame1);

            // arrange - prepare new/current frame for tracking the second time
            Image<Gray, byte> currentFrame2 = new Image<Gray, byte>
            (
                Path.Combine(_resourceDir, "violeta_7.jpg")
            );

            // define expected - status and new/current bounding box
            MedianFlowTrackerStatus expectedStatus = MedianFlowTrackerStatus.OK;
            float expectedNccMedian = 0.9f;
            IBoundingBox expectedBB = new BoundingBox
            (
                new PointF(111, 101),
                new SizeF(70, 40)
            );

            // get actual
            IBoundingBox actualBB = _tracker.FindObject(currentFrame2);
            MedianFlowTrackerStatus actualStatus = _tracker.Status;
            float actualNccMedian = _tracker.NccMedian;

            // assert
            Assert.AreEqual(expectedStatus, actualStatus);
            Assert.AreEqual(expectedNccMedian, actualNccMedian, 0.1f);
            float overlap = actualBB.GetOverlap(expectedBB);
            Assert.AreEqual(0.95f, overlap, 0.05f);
        }
    }
}
