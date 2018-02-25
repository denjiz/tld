using System;
using System.Collections;
using System.Collections.Generic;
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
    public class MedianFlowTrackerTests
    {
        private MedianFlowTracker _tracker;
        private Size _frameSize;
        private LucasKanadeTrackerStub _LKtracker;
        private ServiceStub _service;
        private int _madThreshold;
        private MedianFlowTrackerBoundingBoxStub _bb;

        private void ArrangeTypicalCase()
        {
            // 1. arrange
            //  1.1 initialize median flow tracker
            //      1.1.1 frame size
            _frameSize = new Size(8, 6);

            //      1.1.2 bounding box
            PointF bbCenter = new PointF(3.5f, 2.5f);
            SizeF bbSize = new SizeF(3, 1);
            PointF[] bbVisiblePoints = new PointF[] {
                new PointF(2,2), new PointF(3,2), new PointF(4,2), new PointF(5,2),
                new PointF(2,3), new PointF(3,3), new PointF(4,3), new PointF(5,3),
            };
            _bb = new MedianFlowTrackerBoundingBoxStub(bbCenter, bbSize, bbVisiblePoints);

            //      1.1.3 lucas kanade tracker
            List<PointF[]> forwardPointsList = new List<PointF[]>();
            forwardPointsList.Add(new PointF[] {
                new PointF(0,3), new PointF(2,3), new PointF(4,0), new PointF(8,0),
                new PointF(0,5), new PointF(3,1), new PointF(4,5), new PointF(6,5),
            });
            List<PointF[]> backwardPointsList = new List<PointF[]>();
            backwardPointsList.Add(new PointF[] {
                new PointF(2,2), new PointF(3,2), new PointF(7,0), new PointF(8,0),
                new PointF(2,3), new PointF(6,1), new PointF(4,3), new PointF(-1,5),
            });
            List<byte[]> forwardStatusList = new List<byte[]>();
            forwardStatusList.Add(new byte[] {
                1, 1, 1, 0,
                1, 1, 1, 1
            });
            List<byte[]> backwardStatusList = new List<byte[]>();
            backwardStatusList.Add(new byte[] {
                1, 1, 1, 1,
                0, 1, 1, 1
            });
            _LKtracker = new LucasKanadeTrackerStub(
                forwardPointsList,
                backwardPointsList,
                forwardStatusList,
                backwardStatusList
            );

            //      1.1.4. FBError and NCC calculators
            _service = new ServiceStub();
            _service.FBErrorsList = new List<List<float>>();
            _service.FBErrorsList.Add(new List<float>() {
                0, 0, 2,
                2, 0, 0 
            });
            _service.NCCsList = new List<List<float>>();
            _service.NCCsList.Add(new List<float>() {
                1, 1, -1,
                -1, 1, 1
            });
            TLD.Model.MedianFlowTracker.FBError_Calculator fb_calc = _service.FBErrorStub;
            TLD.Model.MedianFlowTracker.NCC_Calculator ncc_calc = _service.NCCStub;

            //      1.1.5. MAD threshold
            _madThreshold = 10;

            //      1.1.6. instantiate and initialize
            _tracker = new MedianFlowTracker(
                _bb,
                _LKtracker,
                fb_calc,
                ncc_calc,
                new Size(2, 2),
                _madThreshold
            );
            _tracker.Initialize(new Image<Gray, byte>(_frameSize), _bb);
        }

        #region typical case description
        /* This method tests the typical case in object tracking.
         * Frame size: 8x6
         * 
         * This is what happens:
         * 
         *      1. Bounding box from the previous frame returns its visible points:
         *          Center:   (3.5, 2.5)
         *          Size:     (  3,   1)
         *      
         *          |- - - - - - - -|
         *          |- - - - - - - -|
         *          |- - 1 2 3 4 - -|
         *          |- - 5 6 7 8 - -|
         *          |- - - - - - - -|
         *          |- - - - - - - -|
         *          
         *      
         *      2. Lucas Kanade tracker tracks the points forward:
         *          - fails to track one point
         *          - wrongly tracks 2 points
         *      
         *          (ground truth: - translation: (-0.5, 1.5))
         *          (              - scale: 2                )
         *      
         *          |- - - - 3 - - -|4
         *          |- - - 6 - - - -|
         *          |- - - - - - - -|
         *          |1 * 2 * * * * -|
         *          |* - - - - - * -|
         *          |5 * * * 7 * 8 -|
         *                   
         *          
         *      3. Lucas Kanade tracker tracks the points backward:
         *          - fails to track one point
         *          
         *          |- - - - - - - 3|4
         *          |- - - - - - 6 -|
         *          |- - 1 2 * * - -|
         *          |- - * * 7 8 - -|
         *          |- - - - - - - -|
         *         5|- - - - - - - -|
         *          
         * 
         *      4. Tracker keeps valid shifts
         *          - valid shift is a is a shift where the initial point is valid:
         *              - it means that it is tracked succeesfully both forward and backward
         *          
         *          valid points:
         *                          |- - - - - - - -|
         *                          |- - - - - - - -|
         *                          |- - 1 2 3 - - -|
         *                          |- - - 6 7 8 - -|
         *                          |- - - - - - - -|
         *                          |- - - - - - - -|
         *                          
         *      
         *      5. Tracker keeps reliable shifts
         *          - reliable shift is a shift which has, at the same time:
         *              - FB error <= median(FB error)
         *              - NCC      >= median(NCC)
         *          
         *          shift   |   FB error   |   NCC
         *                  |   (made up)  |
         *          ========|==============|======
         *          1       |       0      |    1
         *          2       |       0      |    1
         *          3       |       2      |   -1
         *          6       |       2      |   -1
         *          7       |       0      |    1
         *          8       |       0      |    1
         *          
         *          reliable points:
         *                          |- - - - - - - -|
         *                          |- - - - - - - -|
         *                          |- - 1 2 - - - -|
         *                          |- - - - 7 8 - -|
         *                          |- - - - - - - -|
         *                          |- - - - - - - -|
         *                          
         *      
         *      7. Tracker calculates the horizontal translation, vertical translation, and scale of the previous bounding box
         *         based on the median of best shifts
         *      
         *          - horizontal translation    = median(horizontal translation(reliable shifts)) = -0.5
         *          - vertical translation      = median(vertical   translation(reliable shifts)) =  1.5
         *          - scale                     = median (...)                                    =    2
         *          
         *          final bounding box
         *          Center:   (3, 4)
         *          Size:     (6, 2)
         *          
         *          |- - - - - - - -|
         *          |- - - - - - - -|
         *          |- - - - - - - -|
         *          |1 * 2 * * * * -|
         *          |* - - - - - * -|
         *          |* * * * 7 * 8 -|
        */
        #endregion

        [TestMethod]
        public void FindObject_TypicalCase()
        {
            // 1. arrange
            ArrangeTypicalCase();

            // 2. define expected
            PointF expectedCenter = new PointF(3, 4);
            SizeF expectedSize = new SizeF(6, 2);
            MedianFlowTrackerStatus expectedStatus = MedianFlowTrackerStatus.OK;

            // 3. get actual
            IBoundingBox actualBB = _tracker.FindObject(new Image<Gray, byte>(_frameSize));
            MedianFlowTrackerStatus actualStatus = _tracker.Status;

            // 4. assert
            Assert.AreEqual(expectedCenter, (actualBB as BoundingBoxStub).CenterStub);
            Assert.AreEqual(expectedSize, (actualBB as BoundingBoxStub).SizeStub);
            Assert.AreEqual(expectedStatus, actualStatus);
        }

        /*********************************************************************************************
         * Tests described from now on are described in terms of difference from the typical test case
         ********************************************************************************************/

        /* This method changes fb error and ncc values.
         * This results in different reliable shifts.
         */

        [TestMethod]
        public void FindObject_DifferentReliableShifts()
        {
            // 1.1 arrange - typical case
            ArrangeTypicalCase();

            // 1.2 arrange - change fb error and ncc values - we want points 3 and 6 to be reliable
            // points order in lists:             {  1,  2,  3,  6,  7,  8}
            _service.FBErrorsList = new List<List<float>>();
            _service.FBErrorsList.Add(new List<float>() {
                0, 0, 0,
                0, 2, 2 
            });
            _service.NCCsList = new List<List<float>>();
            _service.NCCsList.Add(new List<float>() {
                -1, -1,  1,
                 1,  1,  1
            });

            // 2. define expected
            PointF expectedCenter = new PointF(3.5f, 0.5f);
            SizeF expectedSize = new SizeF(3, 1);
            MedianFlowTrackerStatus expectedStatus = MedianFlowTrackerStatus.OK;

            // 3. get actual
            IBoundingBox actualBB = _tracker.FindObject(new Image<Gray, byte>(_frameSize));
            MedianFlowTrackerStatus actualStatus = _tracker.Status;

            // 4. assert
            Assert.AreEqual(expectedCenter, (actualBB as BoundingBoxStub).CenterStub);
            Assert.AreEqual(expectedSize, (actualBB as BoundingBoxStub).SizeStub);
            Assert.AreEqual(expectedStatus, actualStatus);
        }

        /* This test method test the case where there are no valid shifts.
         * Tracker should return null and set its status appropriately.
         */

        [TestMethod]
        public void FindObject_NoValidShifts()
        {
            // 1.1 arrange - typical case
            ArrangeTypicalCase();

            // 1.2 arrange - change how points are tracked forward and backward.
            // No point is tracked both forward and backward succesfully.
            _LKtracker.ForwardStatusList = new List<byte[]>();
            _LKtracker.ForwardStatusList.Add(new byte[]{
                1, 1, 1, 1,
                0, 0, 0, 0
            });
            _LKtracker.BackwardStatusList = new List<byte[]>();
            _LKtracker.BackwardStatusList.Add(new byte[]{
                0, 0, 0, 0,
                1, 1, 0, 0
            });
            
            // 2. define expected
            IBoundingBox expectedBB = null;
            MedianFlowTrackerStatus expectedStatus = MedianFlowTrackerStatus.NOT_ENOUGH_VALID_SHIFTS;

            // 3. get actual
            IBoundingBox actualBB = _tracker.FindObject(new Image<Gray, byte>(_frameSize));
            MedianFlowTrackerStatus actualStatus = _tracker.Status;

            // 4. assert
            Assert.AreEqual(expectedBB, actualBB);
            Assert.AreEqual(expectedStatus, actualStatus);
        }

        /* This test method test the case where there are no reliable shifts.
         * Tracker should return null and set its status appropriately.
         */

        [TestMethod]
        public void FindObject_NoReliableShifts()
        {
            // 1.1 arrange - typical case
            ArrangeTypicalCase();

            // 1.2 arrange - change fb error and ncc for each point.
            // No point has both fbError <= median(fbError) and ncc >= median(ncc)
            _service.FBErrorsList = new List<List<float>>();
            _service.FBErrorsList.Add(new List<float>() {
                0, 0, 0,
                2, 2, 2 
            });
            _service.NCCsList = new List<List<float>>();
            _service.NCCsList.Add(new List<float>() {
                -1, -1, -1,
                 1,  1,  1
            });

            // 2. define expected
            IBoundingBox expectedBB = null;
            MedianFlowTrackerStatus expectedStatus = MedianFlowTrackerStatus.NOT_ENOUGH_RELIABLE_SHIFTS;

            // 3. get actual
            IBoundingBox actualBB = _tracker.FindObject(new Image<Gray, byte>(_frameSize));
            MedianFlowTrackerStatus actualStatus = _tracker.Status;

            // 4. assert
            Assert.AreEqual(expectedBB, actualBB);
            Assert.AreEqual(expectedStatus, actualStatus);
        }

        /* This test method test the case where there is 1 reliable shift.
         * Tracker should return null, because 1 reliable shift is sufficient
         * to estimate the translation of the bounding box, but is not sufficient
         * to estimate the scale of the bounding box (which needs at least 2 reliable
         * shifts).
         * So we can see that this is a marginal case: 1 reliable shift
         * is not enough for the tracker to work, but 2 reliable shifts are.
         */

        [TestMethod]
        public void FindObject_1ReliableShift()
        {
            // 1.1 arrange - typical case
            ArrangeTypicalCase();

            // 1.2 arrange - change fb error and ncc for each point.
            // Only one point has both fbError <= median(fbError) and ncc >= median(ncc)
            _service.FBErrorsList = new List<List<float>>();
            _service.FBErrorsList.Add(new List<float>() {
                0, 0, 0,
                2, 2, 2 
            });
            _service.NCCsList = new List<List<float>>();
            _service.NCCsList.Add(new List<float>() {
                1, -1, -1,
               -1,  1,  1
            });

            // 2. define expected
            IBoundingBox expectedBB = null;
            MedianFlowTrackerStatus expectedStatus = MedianFlowTrackerStatus.NOT_ENOUGH_RELIABLE_SHIFTS;

            // 3. get actual
            IBoundingBox actualBB = _tracker.FindObject(new Image<Gray, byte>(_frameSize));
            MedianFlowTrackerStatus actualStatus = _tracker.Status;

            // 4. assert
            Assert.AreEqual(expectedBB, actualBB);
            Assert.AreEqual(expectedStatus, actualStatus);
        }

        /* This test method test the case where there is 1 valid shift.
         * Tracker should return null and set its status appropriately.
         * The tracker fails because if there is 1 valid shift, there can
         * be at most 1 reliable shift, which is not enough to estimate
         * the scale of the bounding box.
         * We can also see that this is a marginal case: 1 valid shift is 
         * *CERTAINLY* not enough for the tracker to work properly, but 2 valid 
         * shifts *MAY BE*.
         */

        [TestMethod]
        public void FindObject_1ValidShift()
        {
            // 1.1 arrange - typical case
            ArrangeTypicalCase();

            // 1.2 arrange - change how points are tracked forward and backward.
            // Only 1 point is tracked both forward and backward succesfully.
            _LKtracker.ForwardStatusList = new List<byte[]>();
            _LKtracker.ForwardStatusList.Add(new byte[]{
                1, 0, 0, 0,
                0, 0, 0, 0
            });
            _LKtracker.BackwardStatusList = new List<byte[]>();
            _LKtracker.BackwardStatusList.Add(new byte[]{
                1, 0, 0, 0,
                0, 0, 0, 0
            });

            // 2. define expected
            IBoundingBox expectedBB = null;
            MedianFlowTrackerStatus expectedStatus = MedianFlowTrackerStatus.NOT_ENOUGH_VALID_SHIFTS;

            // 3. get actual
            IBoundingBox actualBB = _tracker.FindObject(new Image<Gray, byte>(_frameSize));
            MedianFlowTrackerStatus actualStatus = _tracker.Status;

            // 4. assert
            Assert.AreEqual(expectedBB, actualBB);
            Assert.AreEqual(expectedStatus, actualStatus);
        }

        /* This test method tests the case where there are 2 reliable shifts.
         * Tracker succeeds.
         * This is a marginal case: 2 reliable shifts are enough for
         * the tracker to work properly, but 1 reliable shift is not.
         */

        [TestMethod]
        public void FindObject_2ReliableShifts()
        {
            // 1.1 arrange - typical case
            ArrangeTypicalCase();

            // 1.2 arrange - change fb error and ncc for each point.
            // Exactly 2 shifts have both fbError <= median(fbError) and ncc >= median(ncc)
            _service.FBErrorsList = new List<List<float>>();
            _service.FBErrorsList.Add(new List<float>() {
                0, 0, 0,
                2, 2, 2 
            });
            _service.NCCsList = new List<List<float>>();
            _service.NCCsList.Add(new List<float>() {
                1,  1, -1,
               -1, -1,  1
            });

            // 2. define expected
            IBoundingBox expectedBB = new BoundingBoxStub(
                new PointF(2, 3.5f),
                new SizeF(6, 2)
            );
            MedianFlowTrackerStatus expectedStatus = MedianFlowTrackerStatus.OK;

            // 3. get actual
            IBoundingBox actualBB = _tracker.FindObject(new Image<Gray, byte>(_frameSize));
            MedianFlowTrackerStatus actualStatus = _tracker.Status;

            // 4. assert
            Assert.IsTrue((actualBB as BoundingBoxStub).IsEqualTo(expectedBB as BoundingBoxStub));
            Assert.AreEqual(expectedStatus, actualStatus);
        }

        /* This test method tests the case where there are 2 valid shifts.
         * Tracker succeeds; fb errors and nnc-s are both set so that the 2
         * valid shifts are both reliable.
         * This is a marginal case: 2 valid shifts *MAY BE* enough for
         * the tracker to work properly, but 1 reliable shift is *CERTAINLY NOT*.
         */

        [TestMethod]
        public void FindObject_2ValidShifts_Succeeds()
        {
            // 1.1 arrange - typical case
            ArrangeTypicalCase();

            // 1.2 arrange - change how points are tracked forward and backward.
            // Exactly 2 points are tracked both forward and backward succesfully.
            _LKtracker.ForwardStatusList = new List<byte[]>();
            _LKtracker.ForwardStatusList.Add(new byte[]{
                1, 1, 0, 0,
                0, 0, 0, 0
            });
            _LKtracker.BackwardStatusList = new List<byte[]>();
            _LKtracker.BackwardStatusList.Add(new byte[]{
                1, 1, 0, 0,
                0, 0, 0, 0
            });

            // 1.3 arrange - change fb error and ncc for each point.
            // Exactly 2 shifts have both fbError <= median(fbError) and ncc >= median(ncc)
            _service.FBErrorsList = new List<List<float>>();
            _service.FBErrorsList.Add(new List<float>() {
                0, 0, 0,
                2, 2, 2 
            });
            _service.NCCsList = new List<List<float>>();
            _service.NCCsList.Add(new List<float>() {
                1,  1, -1,
               -1, -1,  1
            });

            // 2. define expected
            IBoundingBox expectedBB = new BoundingBoxStub(
                new PointF(2, 3.5f),
                new SizeF(6, 2)
            );
            MedianFlowTrackerStatus expectedStatus = MedianFlowTrackerStatus.OK;

            // 3. get actual
            IBoundingBox actualBB = _tracker.FindObject(new Image<Gray, byte>(_frameSize));
            MedianFlowTrackerStatus actualStatus = _tracker.Status;

            // 4. assert
            Assert.IsTrue((actualBB as BoundingBoxStub).IsEqualTo(expectedBB as BoundingBoxStub));
            Assert.AreEqual(expectedStatus, actualStatus);
        }

        /* This test method tests the case where there are 2 valid shifts.
         * Tracker fails; fb errors and nnc-s are both set so only 1 of 2 valid
         * shifts is reliable.
         * This is a marginal case: 2 valid shifts *MAY BE* enough for
         * the tracker to work properly, but 1 reliable shift is *CERTAINLY NOT*.
         */

        [TestMethod]
        public void FindObject_2ValidShifts_Fails()
        {
            // 1.1 arrange - typical case
            ArrangeTypicalCase();

            // 1.2 arrange - change how points are tracked forward and backward.
            // Exactly 2 points are tracked both forward and backward succesfully.
            _LKtracker.ForwardStatusList = new List<byte[]>();
            _LKtracker.ForwardStatusList.Add(new byte[]{
                1, 1, 0, 0,
                0, 0, 0, 0
            });
            _LKtracker.BackwardStatusList = new List<byte[]>();
            _LKtracker.BackwardStatusList.Add(new byte[]{
                1, 1, 0, 0,
                0, 0, 0, 0
            });

            // 1.3 arrange - change fb error and ncc for each point.
            // Exactly 1 shift has both fbError <= median(fbError) and ncc >= median(ncc)
            _service.FBErrorsList = new List<List<float>>();
            _service.FBErrorsList.Add(new List<float>() {
                0, 0, 0,
                2, 2, 2 
            });
            _service.NCCsList = new List<List<float>>();
            _service.NCCsList.Add(new List<float>() {
                1, -1, -1,
               -1,  1,  1
            });

            // 2. define expected
            IBoundingBox expectedBB = null;
            MedianFlowTrackerStatus expectedStatus = MedianFlowTrackerStatus.NOT_ENOUGH_RELIABLE_SHIFTS;

            // 3. get actual
            IBoundingBox actualBB = _tracker.FindObject(new Image<Gray, byte>(_frameSize));
            MedianFlowTrackerStatus actualStatus = _tracker.Status;

            // 4. assert
            Assert.AreEqual(expectedBB, actualBB);
            Assert.AreEqual(expectedStatus, actualStatus);
        }

        /* This test method tests the case where MAD (Median Absolute Deviation) is
         * bigger that a threshold.
         * Tracker should fail and set its status appropriately.
         */

        [TestMethod]
        public void FindObject_MADTooBig()
        {
            // 1.1 arrange - typical case
            ArrangeTypicalCase();

            // 1.2 arrange - change how points are tracked forward and backward.
            // 4 points are tracked both forward and backward succesfully.
            _LKtracker.ForwardStatusList = new List<byte[]>();
            _LKtracker.ForwardStatusList.Add(new byte[]{
                1, 1, 1, 1,
                0, 0, 0, 0
            });
            _LKtracker.BackwardStatusList = new List<byte[]>();
            _LKtracker.BackwardStatusList.Add(new byte[]{
                1, 1, 1, 1,
                0, 0, 0, 0
            });

            // 1.3 arrange - change fb error for each point.
            // MAD must be bigger that a threshold ( == 10, set in ArrangeTypicalCase()).
            _service.FBErrorsList = new List<List<float>>();
            _service.FBErrorsList.Add(new List<float>() {
                0, 0, 21, 21
            });
            _service.NCCsList = new List<List<float>>();
            _service.NCCsList.Add(new List<float>() {
                1, 1, 1, 1
            });

            // 2. define expected
            IBoundingBox expectedBB = null;
            MedianFlowTrackerStatus expectedStatus = MedianFlowTrackerStatus.MAD_TOO_BIG;

            // 3. get actual
            IBoundingBox actualBB = _tracker.FindObject(new Image<Gray, byte>(_frameSize));
            MedianFlowTrackerStatus actualStatus = _tracker.Status;

            // 4. assert
            Assert.AreEqual(expectedBB, actualBB);
            Assert.AreEqual(expectedStatus, actualStatus);
        }

        /* This test method tests the case where object tracking is continued after initialization.
         * It does so by invoking the tracker's method 'FindObject' the second time. It means
         * that tracker is invoked with the 3rd; first frame is set when initializing the tracker
         * and second frame is used when invoking the tracker for the first time. First two frames
         * are both set in the typical case scenario.
         * 
         * This is what happens after the second invoke of the tracker's method 'FindObject':
         * 
         *      1. Bounding box from the previous frame returns its visible points:
         *          Center:   (3.5, 2.5)
         *          Size:     (  3,   1)
         *      
         *          |- - - - - - - -|
         *          |- - - - - - - -|
         *          |- - - - - - - -|
         *          |1 - 2 - 3 - 4 -|
         *          |- - - - - - - -|
         *          |5 - 6 - 7 - 8 -|
         *          
         *      
         *      2. Lucas Kanade tracker tracks the points forward:
         *          - succeeds to track all points
         *          - correctly tracks all points
         *      
         *          (ground truth: - translation: (1, 0))
         *          (              - scale: 1           )
         *      
         *          |- - - - - - - -|
         *          |- - - - - - - -|
         *          |- - - - - - - -|
         *          |- 1 - 2 - 3 - 4|
         *          |- - - - - - - -|
         *          |- 5 - 6 - 7 - 8|
         *                   
         *          
         *      3. Lucas Kanade tracker tracks the points backward:
         *          - succeeds to track all points
         *          
         *          |- - - - - - - -|
         *          |- - - - - - - -|
         *          |- - - - - - - -|
         *          |1 - 2 - 3 - 4 -|
         *          |- - - - - - - -|
         *          |5 - 6 - 7 - 8 -|
         *          
         * 
         *      4. Tracker keeps valid shifts
         *          - valid shift is a is a shift where the initial point is valid:
         *              - it means that it is tracked succeesfully both forward and backward
         *          
         *          valid points:
         *                          |- - - - - - - -|
         *                          |- - - - - - - -|
         *                          |- - - - - - - -|
         *                          |1 - 2 - 3 - 4 -|
         *                          |- - - - - - - -|
         *                          |5 - 6 - 7 - 8 -|
         *                          
         *      
         *      5. Tracker keeps reliable shifts
         *          - reliable shift is a shift which has, at the same time:
         *              - FB error <= median(FB error)
         *              - NCC      >= median(NCC)
         *          
         *          shift   |   FB error   |   NCC
         *                  |   (made up)  |
         *          ========|==============|======
         *          1       |       0      |    1
         *          2       |       0      |    1
         *          3       |       0      |    1
         *          4       |       0      |    1
         *          5       |       0      |    1
         *          6       |       0      |    1
         *          7       |       0      |    1
         *          8       |       0      |    1
         *          
         *          reliable points:
         *                          |- - - - - - - -|
         *                          |- - - - - - - -|
         *                          |- - - - - - - -|
         *                          |1 - 2 - 3 - 4 -|
         *                          |- - - - - - - -|
         *                          |5 - 6 - 7 - 8 -|
         *                          
         *      
         *      7. Tracker calculates the horizontal translation, vertical translation, and scale of the previous bounding box
         *         based on the median of best shifts
         *      
         *          - horizontal translation    = median(horizontal translation(reliable shifts)) = 1
         *          - vertical translation      = median(vertical   translation(reliable shifts)) = 0
         *          - scale                     = median (...)                                    = 1
         *          
         *          final bounding box
         *          Center:   (4, 4)
         *          Size:     (6, 2)
         *          
         *          |- - - - - - - -|
         *          |- - - - - - - -|
         *          |- - - - - - - -|
         *          |- 1 * 2 * 3 * 4|
         *          |- - - - - - - -|
         *          |- 5 * 6 * 7 * 8|
         */

        [TestMethod]
        public void FindObject_PostInit()
        {
            // 1.1 arrange - typical case
            ArrangeTypicalCase();

            // 1.2. arrange data for the 2nd frame
            //      1.2.1 bounding box
            PointF bbCenter = new PointF(3, 4);
            SizeF bbSize = new SizeF(6, 2);
            PointF[] bbVisiblePoints = new PointF[] {
                new PointF(0,3), new PointF(2,3), new PointF(4,3), new PointF(6,3),
                new PointF(0,5), new PointF(2,5), new PointF(4,5), new PointF(6,5)
            };
            IMedianFlowTrackerBoundingBox bb = new MedianFlowTrackerBoundingBoxStub(bbCenter, bbSize, bbVisiblePoints);
            _bb.HardcodedNextBB = (bb as MedianFlowTrackerBoundingBoxStub);

            //      1.2.2 arrange - set forward and backward points.
            //                      All points are tracked both forward and backward succesfully.
            _LKtracker.ForwardPointsList.Add(new PointF[]{
                new PointF(1,3), new PointF(3,3), new PointF(5,3), new PointF(7,3),
                new PointF(1,5), new PointF(3,5), new PointF(5,5), new PointF(7,5)
            });
            _LKtracker.BackwardPointsList.Add(new PointF[]{
                new PointF(0,3), new PointF(2,3), new PointF(4,3), new PointF(6,3),
                new PointF(0,5), new PointF(2,5), new PointF(4,5), new PointF(6,5)
            });
            _LKtracker.ForwardStatusList.Add(new byte[]{
                1, 1, 1, 1,
                1, 1, 1, 1
            });
            _LKtracker.BackwardStatusList.Add(new byte[]{
                1, 1, 1, 1,
                1, 1, 1, 1
            });

            //      1.2.3 arrange - change fb error for each point.
            //                      Every point should be reliable.
            _service.FBErrorsList.Add(new List<float>() {
                0, 0, 0, 0,
                0, 0, 0, 0
            });
            _service.NCCsList.Add(new List<float>() {
                1, 1, 1, 1,
                1, 1, 1, 1
            });

            // 1.3. arrange - call tracker the first time
            _tracker.FindObject(new Image<Gray, byte>(_frameSize));

            // 2. define expected
            IBoundingBox expectedBB = new BoundingBoxStub(
                new PointF(4,4),
                new SizeF(6,2)
            );
            MedianFlowTrackerStatus expectedStatus = MedianFlowTrackerStatus.OK;

            // 3. get actual - call tracker for the second time
            IBoundingBox actualBB = _tracker.FindObject(new Image<Gray, byte>(_frameSize));
            MedianFlowTrackerStatus actualStatus = _tracker.Status;

            // 4. assert
            Assert.AreEqual((expectedBB as BoundingBoxStub).CenterStub, (actualBB as BoundingBoxStub).CenterStub);
            Assert.AreEqual((expectedBB as BoundingBoxStub).SizeStub, (actualBB as BoundingBoxStub).SizeStub);
            Assert.AreEqual(expectedStatus, actualStatus);
        }
    }
}
