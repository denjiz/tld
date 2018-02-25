using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TLD.Model.Detection;
using Emgu.CV;
using Emgu.CV.Structure;
using TLD.Model;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using Emgu.CV.CvEnum;

namespace TLD.ModelTesting.Detection
{
    [TestClass]
    public class EnsembleClassifierTests
    {
        /*
        [TestMethod]
        public void GenerateAllPatchCodes_3BitsPerCode()
        {
            // define expected
            BoolArrayKey[] expected = 
            {
                new BoolArrayKey(new bool[]{false,false,false}),
                new BoolArrayKey(new bool[]{false,false,true }),
                new BoolArrayKey(new bool[]{false,true ,false}),
                new BoolArrayKey(new bool[]{false,true ,true }),
                new BoolArrayKey(new bool[]{true ,false,false}),
                new BoolArrayKey(new bool[]{true ,false,true }),
                new BoolArrayKey(new bool[]{true ,true ,false}),
                new BoolArrayKey(new bool[]{true ,true ,true })
            };

            // get actual
            EnsembleClassifier classifier = new EnsembleClassifier(2, 3, 4, 4, 0.2);
            classifier.GenerateAllPatchCodes();
            BoolArrayKey[] actual = classifier.AllPatchCodes;

            // assert
            CollectionAssert.AreEquivalent(expected, actual);
        }
        */

        private string _resourceDir = @"..\..\Resource";

        [TestMethod]
        public void GetPosteriors_InitializationAndOneMethodCall()
        {
            // arrange - generate pixel comparisons
            PixelComparisonGroupF pcg1 = new PixelComparisonGroupF();
            pcg1.Value = new PixelComparisonF[]
            {
                new PixelComparisonF(new PointF(0,0.5f), new PointF(0.5f,0.5f)),
                new PixelComparisonF(new PointF(0.5f,0), new PointF(0.5f,0.5f)),
                new PixelComparisonF(new PointF(1,0.5f), new PointF(0.5f,0.5f)),
                new PixelComparisonF(new PointF(0.5f,1), new PointF(0.5f,0.5f))
            };
            PixelComparisonGroupF pcg2 = new PixelComparisonGroupF();
            pcg2.Value = new PixelComparisonF[]
            {
                new PixelComparisonF(new PointF(0,0.5f), new PointF(0.5f,0.5f)),
                new PixelComparisonF(new PointF(0.5f,0), new PointF(0.5f,0.5f)),
                new PixelComparisonF(new PointF(1,0.5f), new PointF(0.5f,0.5f)),
                new PixelComparisonF(new PointF(0.5f,1), new PointF(0.5f,0.5f))
            };
            IPixelComparisonScheduler pxs = new PixelComparisonSchedulerStub(
                new PixelComparisonGroupF[]{
                    pcg1,
                    pcg2
                }
            );

            // arrange - instantiate ensamble classifier
            ScanningWindowGeneratorStub swgEnsemble = new ScanningWindowGeneratorStub();
            IBoundingBox positiveScanningWindow = new BoundingBox(new PointF(480, 364), new SizeF(277, 217));
            swgEnsemble.ScanningWindows = new IBoundingBox[]
            {
                new BoundingBox(new PointF(163, 132), new SizeF(288, 220)),
                new BoundingBox(new PointF(478, 127), new SizeF(300, 199)),
                new BoundingBox(new PointF(150, 355), new SizeF(290, 214)),
                positiveScanningWindow,
            };
            foreach (IBoundingBox bb in swgEnsemble.ScanningWindows)
            {
                bb.ScanningWindow = bb.CreateScanningWindow();
            }
            EnsembleClassifier classifier = new EnsembleClassifier(swgEnsemble, pxs, 1.5);
            classifier.PostInstantiation();

            // arrange - define initialization frame and bb
            Image<Gray, byte> initFrame = new Image<Gray, byte>(Path.Combine(_resourceDir, "LP_up_left.jpg"));
            IBoundingBox initBb = new BoundingBox(new PointF(170, 150), new SizeF(269, 189));

            // arrange - initialize ensemble classifier
            classifier.Initialize(initFrame, initBb);

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
            IScanningWindowGenerator swg = new ScanningWindowGenerator(1.5f, 0.7f, 0.7f, 30);
            List<IBoundingBox> scanningWindows = swg.Generate(initFrame.Size, initBb).ToList();
            List<IBoundingBox> sortedScanningWindows = Service.SortScanningWindowsByOverlap(scanningWindows, initBb);
            List<IBoundingBox> negativeScanningWindows = Service.GetScanningWindowsWithOverlapLessThan(0.2f, initBb, sortedScanningWindows);

            List<Image<Gray, byte>> negativePatches = new List<Image<Gray, byte>>();
            int negativeCount = 100;
            int step = negativeScanningWindows.Count / negativeCount;
            for (int i = 0; i < negativeCount; i++)
            {
                IBoundingBox bb = negativeScanningWindows[i * step];
                negativePatches.Add(initFrame.GetPatch(bb.Center, Size.Round(bb.Size)));
            }

            // update classifier with new positive and negative patches
            classifier.Update(positivePatches, negativePatches);

            // arrange - define current frame
            Image<Gray, byte> currentFrame = new Image<Gray, byte>(Path.Combine(_resourceDir, "LP_down_right.jpg"));

            // define expected
            List<int> expected = new List<int>() { 3 };

            // get actual
            List<int> actual = classifier.AcceptedWindows(currentFrame, new List<int> { 0, 1, 2, 3 });

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
