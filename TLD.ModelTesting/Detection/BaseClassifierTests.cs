using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Emgu.CV.Structure;
using Emgu.CV;
using System.IO;
using TLD.Model;
using System.Drawing;
using System.Collections.Generic;
using Emgu.CV.CvEnum;
using Extensions.Collections;
using TLD.Model.Detection;

namespace TLD.ModelTesting.Detection
{
    [TestClass]
    public class BaseClassifierTests
    {
        private string _resourceDir = @"..\..\Resource";

        [TestMethod]
        public void GetPosteriors_InitializationAndOneMethodCall()
        {
            // arrange - define initialization frame and bb
            Image<Gray, byte> initFrame = new Image<Gray,byte>(Path.Combine(_resourceDir, "LP_up_left.jpg"));
            IBoundingBox initBb = new BoundingBox(new PointF(170, 150), new SizeF(269, 189));

            // arrange - generate positive and negative patches
            // -> positive patches
            List<Image<Gray, byte>> positivePatches = new List<Image<Gray, byte>>();
            int positiveCount = 100;
            for (int i = 0; i < positiveCount; i++)
            {
                Image<Gray, byte> patch = Service.GenerateSimilarPatch(initFrame, initBb, 0, 0, 0);
                CvInvoke.cvSmooth(patch, patch, SMOOTH_TYPE.CV_GAUSSIAN, 0, 0, 1.5, 1.5);
                positivePatches.Add(patch);
            }

            // -> negative patches
            ScanningWindowGenerator swg = new ScanningWindowGenerator(1.2f, 0.1f, 0.1f, 20);
            IBoundingBox[] scanningWindows = swg.Generate(initFrame.Size, initBb);
            List<IBoundingBox> sortedScanningWindows = Service.SortScanningWindowsByOverlap(scanningWindows.ToList(), initBb);
            List<IBoundingBox> negativeScanningWindows = Service.GetScanningWindowsWithOverlapLessThan(0.2f, initBb, sortedScanningWindows);

            List<Image<Gray, byte>> negativePatches = new List<Image<Gray, byte>>();
            int negativeCount = 100;
            int step = negativeScanningWindows.Count/negativeCount;
            for (int i = 0; i < negativeCount; i++)
            {
                IBoundingBox bb = negativeScanningWindows[i * step];
                negativePatches.Add(initFrame.GetPatch(bb.Center, Size.Round(bb.Size)));
            }

            // arrange - instantiate and initialize base classifier
            PixelComparisonGroupF pcg = new PixelComparisonGroupF();
            pcg.Value = new PixelComparisonF[]
            {
                new PixelComparisonF(new PointF(0,0.5f), new PointF(0.5f,0.5f)),
                new PixelComparisonF(new PointF(0.5f,0), new PointF(0.5f,0.5f)),
                new PixelComparisonF(new PointF(1,0.5f), new PointF(0.5f,0.5f)),
                new PixelComparisonF(new PointF(0.5f,1), new PointF(0.5f,0.5f))
            };
            IPixelComparisonScheduler pxs = new PixelComparisonSchedulerStub(
                new PixelComparisonGroupF[]{
                    pcg
                }
            );
            BaseClassifier classifier = new BaseClassifier(swg, 0, pxs);
            classifier.PostInstantiation();
            classifier.Update(positivePatches, negativePatches);

            // arrange - define current frame used scanning windows
            Image<Gray, byte> currentFrame = new Image<Gray, byte>(Path.Combine(_resourceDir, "LP_down_right.jpg"));
            CvInvoke.cvSmooth(currentFrame, currentFrame, SMOOTH_TYPE.CV_GAUSSIAN, 0, 0, 1.5, 1.5);
            List<IBoundingBox> usedScanningWindows = new List<IBoundingBox>()
            {
                new BoundingBox(new PointF(163, 132), new SizeF(288, 220)),
                new BoundingBox(new PointF(478, 127), new SizeF(300, 199)),
                new BoundingBox(new PointF(150, 355), new SizeF(308, 214)),
                new BoundingBox(new PointF(480, 364), new SizeF(277, 217)),
            };

            // get actual
            List<double> posteriors = new List<double>();
            foreach (IBoundingBox bb in usedScanningWindows)
            {
                posteriors.Add(classifier.GetPosterior(currentFrame, bb));
            }

            // assert
            Assert.AreEqual(posteriors.Count, usedScanningWindows.Count);
            Assert.IsTrue(posteriors[0] < 0.5);
            Assert.IsTrue(posteriors[1] < 0.5);
            Assert.IsTrue(posteriors[2] < 0.5);
            Assert.IsTrue(posteriors[3] > 0.5);
        }

        [TestMethod]
        public void StretchComparisonsOnWindow_Simple()
        {
            // arrange - create scanning window generator with 1 scanning window
            ScanningWindowGeneratorStub swg = new ScanningWindowGeneratorStub();
            IBoundingBox bb = new BoundingBox(new PointF(1.5f, 1.5f), new SizeF(2, 2));
            bb.ScanningWindow = bb.CreateScanningWindow();
            swg.ScanningWindows = new IBoundingBox[]
            {
                bb
            };

            // arrange - create pixel comparison scheduler with for 1 base classifier with 2 comparisons
            PixelComparisonSchedulerStub pcs = new PixelComparisonSchedulerStub();
            PixelComparisonGroupF pcg = new PixelComparisonGroupF();
            pcg.Value = new PixelComparisonF[]
            {
                new PixelComparisonF(new PointF(0, 0), new PointF(1, 0)),
                new PixelComparisonF(new PointF(0, 0), new PointF(0, 1))
            };
            pcs.ScheduledPixelComparisons = new PixelComparisonGroupF[]
            {
                pcg
            };

            // arrange - create base classifier
            BaseClassifier classifier = new BaseClassifier(swg, 0, pcs);

            // define expected
            Point[][] expected = new Point[2][];
            expected[0] = new Point[] { new Point(1, 1), new Point(2, 1) };
            expected[1] = new Point[] { new Point(1, 1), new Point(1, 2) };

            // get actual
            Point[][] actual = classifier.StretchComparisonsOnWindow(0);

            // assert
            Assert.AreEqual(2, actual.Length);
            Assert.AreEqual(2, actual[0].Length);
            Assert.AreEqual(2, actual[1].Length);
            Assert.AreEqual(expected[0][0], actual[0][0]);
            Assert.AreEqual(expected[0][1], actual[0][1]);
            Assert.AreEqual(expected[1][0], actual[1][0]);
            Assert.AreEqual(expected[1][1], actual[1][1]);
        }

        [TestMethod]
        public void StretchComparisonsOnWindow_LessSimple()
        {
            // arrange - create scanning window generator with 2 scanning windows
            ScanningWindowGeneratorStub swg = new ScanningWindowGeneratorStub();

            // first window is not important
            IBoundingBox bb1 = new BoundingBox(new PointF(), new SizeF());

            // second window is important
            IBoundingBox bb2 = new BoundingBox(new PointF(1.5f, 3.0f), new SizeF(2, 3));
            bb2.ScanningWindow = bb2.CreateScanningWindow();
            swg.ScanningWindows = new IBoundingBox[]
            {
                bb1,
                bb2
            };

            // arrange - create pixel comparison scheduler with for 1 base classifier with 2 comparisons
            PixelComparisonSchedulerStub pcs = new PixelComparisonSchedulerStub();
            PixelComparisonGroupF pcg = new PixelComparisonGroupF();
            pcg.Value = new PixelComparisonF[]
            {
                new PixelComparisonF(new PointF(0, 0), new PointF(0, 0.5f)),
                new PixelComparisonF(new PointF(1, 0.5f), new PointF(1, 1))
            };
            pcs.ScheduledPixelComparisons = new PixelComparisonGroupF[]
            {
                pcg
            };

            // arrange - create base classifier
            BaseClassifier classifier = new BaseClassifier(swg, 0, pcs);

            // define expected
            Point[][] expected = new Point[2][];
            expected[0] = new Point[] { new Point(1, 2), new Point(1, 3) };
            expected[1] = new Point[] { new Point(2, 3), new Point(2, 4) };

            // get actual
            Point[][] actual = classifier.StretchComparisonsOnWindow(1);

            // assert
            Assert.AreEqual(2, actual.Length);
            Assert.AreEqual(2, actual[0].Length);
            Assert.AreEqual(2, actual[1].Length);
            Assert.AreEqual(expected[0][0], actual[0][0]);
            Assert.AreEqual(expected[0][1], actual[0][1]);
            Assert.AreEqual(expected[1][0], actual[1][0]);
            Assert.AreEqual(expected[1][1], actual[1][1]);
        }

        [TestMethod]
        public void StretchComparisonsOnWindows_2Windows()
        {
            // arrange - create scanning window generator with 2 scanning windows
            ScanningWindowGeneratorStub swg = new ScanningWindowGeneratorStub();

            IBoundingBox bb1 = new BoundingBox(new PointF(1.5f, 1.5f), new SizeF(2, 2));
            bb1.ScanningWindow = bb1.CreateScanningWindow();

            IBoundingBox bb2 = new BoundingBox(new PointF(1.5f, 3.0f), new SizeF(2, 3));
            bb2.ScanningWindow = bb2.CreateScanningWindow();
            swg.ScanningWindows = new IBoundingBox[]
            {
                bb1,
                bb2
            };

            // arrange - create pixel comparison scheduler with for 1 base classifier with 2 comparisons
            PixelComparisonSchedulerStub pcs = new PixelComparisonSchedulerStub();
            PixelComparisonGroupF pcg = new PixelComparisonGroupF();
            pcg.Value = new PixelComparisonF[]
            {
                new PixelComparisonF(new PointF(0, 0), new PointF(1, 0)),
                new PixelComparisonF(new PointF(0, 0), new PointF(0, 1))
            };
            pcs.ScheduledPixelComparisons = new PixelComparisonGroupF[]
            {
                pcg
            };

            // arrange - create base classifier
            BaseClassifier classifier = new BaseClassifier(swg, 0, pcs);

            // define expected for 1st window
            Point[][] expected1 = new Point[2][];
            expected1[0] = new Point[] { new Point(1, 1), new Point(2, 1) };
            expected1[1] = new Point[] { new Point(1, 1), new Point(1, 2) };

            // define expected for 2nd window
            Point[][] expected2 = new Point[2][];
            expected2[0] = new Point[] { new Point(1, 2), new Point(2, 2) };
            expected2[1] = new Point[] { new Point(1, 2), new Point(1, 4) };

            // get actual
            classifier.Initialize();
            Point[][][] AllComparisons = classifier.ComparisonsForWindow;
            Point[][] actual1 = AllComparisons[0];
            Point[][] actual2 = AllComparisons[1];

            // assert for 1st window
            Assert.AreEqual(2, actual1.Length);
            Assert.AreEqual(2, actual1[0].Length);
            Assert.AreEqual(2, actual1[1].Length);
            Assert.AreEqual(expected1[0][0], actual1[0][0]);
            Assert.AreEqual(expected1[0][1], actual1[0][1]);
            Assert.AreEqual(expected1[1][0], actual1[1][0]);
            Assert.AreEqual(expected1[1][1], actual1[1][1]);

            // assert for 2nd window
            Assert.AreEqual(2, actual2.Length);
            Assert.AreEqual(2, actual2[0].Length);
            Assert.AreEqual(2, actual2[1].Length);
            Assert.AreEqual(expected2[0][0], actual2[0][0]);
            Assert.AreEqual(expected2[0][1], actual2[0][1]);
            Assert.AreEqual(expected2[1][0], actual2[1][0]);
            Assert.AreEqual(expected2[1][1], actual2[1][1]);
        }

        [TestMethod]
        public void CalculateBinaryCodeForWindow_1Window()
        {
            // arrange - load frame
            Image<Gray, byte> frame = new Image<Gray, byte>(Path.Combine(_resourceDir, "patch_12x10.jpg"));

            // arrange - create scanning window generator with 1 scanning window
            ScanningWindowGeneratorStub swg = new ScanningWindowGeneratorStub();

            IBoundingBox bb = new BoundingBox(new PointF(6.5f, 4.0f), new SizeF(1, 2));
            bb.ScanningWindow = bb.CreateScanningWindow();

            swg.ScanningWindows = new IBoundingBox[]
            {
                bb,
            };

            // arrange - create pixel comparison scheduler with for 1 base classifier with 4 comparisons
            PixelComparisonSchedulerStub pcs = new PixelComparisonSchedulerStub();
            PixelComparisonGroupF pcg = new PixelComparisonGroupF();
            pcg.Value = new PixelComparisonF[]
            {
                new PixelComparisonF(new PointF(0, 0), new PointF(1, 0)),
                new PixelComparisonF(new PointF(0, 1), new PointF(1, 1)),
                new PixelComparisonF(new PointF(0, 0), new PointF(0, 1)),
                new PixelComparisonF(new PointF(1, 0), new PointF(1, 1))
            };
            pcs.ScheduledPixelComparisons = new PixelComparisonGroupF[]
            {
                pcg
            };

            // arrange - create base classifier
            BaseClassifier classifier = new BaseClassifier(swg, 0, pcs);
            classifier.PostInstantiation();
            classifier.Initialize();

            // define expected
            bool[] expected = new bool[] { false, false, true, true };

            // get actual
            classifier.SetCurrentFrame(frame);
            bool[] actual = classifier.CalculateBinaryCodeForWindow(0).Data;

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateIntegerBinaryCodeForWindow_1Window()
        {
            // arrange - load frame
            Image<Gray, byte> frame = new Image<Gray, byte>(new Size(2, 2));
            frame[0, 0] = new Gray(1);
            frame[0, 1] = new Gray(2);
            frame[1, 0] = new Gray(3);
            frame[1, 1] = new Gray(4);

            // arrange - create scanning window generator with 1 scanning window
            ScanningWindowGeneratorStub swg = new ScanningWindowGeneratorStub();

            IBoundingBox bb = new BoundingBox(new PointF(0.5f, 0.5f), new SizeF(2, 2));
            bb.ScanningWindow = bb.CreateScanningWindow();

            swg.ScanningWindows = new IBoundingBox[]
            {
                bb,
            };

            // arrange - create pixel comparison scheduler with for 1 base classifier with 4 comparisons
            PixelComparisonSchedulerStub pcs = new PixelComparisonSchedulerStub();
            PixelComparisonGroupF pcg = new PixelComparisonGroupF();
            pcg.Value = new PixelComparisonF[]
            {
                new PixelComparisonF(new PointF(0, 0), new PointF(1, 0)),
                new PixelComparisonF(new PointF(0, 1), new PointF(1, 1)),
                new PixelComparisonF(new PointF(0, 1), new PointF(0, 0)),
                new PixelComparisonF(new PointF(1, 1), new PointF(1, 0))
            };
            pcs.ScheduledPixelComparisons = new PixelComparisonGroupF[]
            {
                pcg
            };

            // arrange - create base classifier
            BaseClassifier classifier = new BaseClassifier(swg, 0, pcs);
            classifier.PostInstantiation();
            classifier.Initialize();

            // define expected
            int expected = 3;

            // get actual
            classifier.SetCurrentFrame(frame);
            int actual = classifier.CalculateIntegerBinaryCodeForWindow(0);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
