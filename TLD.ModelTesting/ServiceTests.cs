using System;
using System.Linq;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TLD.Model;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Collections.Generic;
using TLD.Model.Detection;
using TLD.Model.Learning;

namespace TLD.ModelTesting
{
    [TestClass]
    public class ServiceTests
    {
        private string _resourceDir = @"..\..\Resource";

        [TestMethod]
        public void FBError()
        {
            // arrange
            PointF p1 = new PointF(5, 4);
            PointF p2 = new PointF(1, 1);

            // define expected
            float expectedError = 5f;

            // get actual
            float actualError = Service.FBError(p1, p2);

            // assert
            Assert.AreEqual(expectedError, actualError);
        }

        [TestMethod]
        public void NCC_SimilarPatches()
        {
            // arrange
            Image<Gray, byte> patch1 = new Image<Gray, byte>(Path.Combine(_resourceDir, "patch_yellow_15x12_1.jpg"));
            Image<Gray, byte> patch2 = new Image<Gray, byte>(Path.Combine(_resourceDir, "patch_yellow_15x12_2.jpg"));

            // define expected
            double min = 0.75;
            double max = 1;

            // get actual
            double ncc = Service.NCC(patch1, patch2);

            // assert
            Assert.IsTrue(ncc > min);
            Assert.IsTrue(ncc < max);
        }

        [TestMethod]
        public void NCC_DissimilarPatches()
        {
            // arrange
            Image<Gray, byte> patch1 = new Image<Gray, byte>(Path.Combine(_resourceDir, "patch_diagonal_ltrb_15x12_1.jpg"));
            Image<Gray, byte> patch2 = new Image<Gray, byte>(Path.Combine(_resourceDir, "patch_diagonal_ltrb_15x12_2.jpg"));

            // define expected
            double min = -1;
            double max = -0.75;

            // get actual
            double ncc = Service.NCC(patch1, patch2);

            // assert
            Assert.IsTrue(ncc > min);
            Assert.IsTrue(ncc < max);
        }

        [TestMethod]
        public void GetMedian_IntArray_OddLength()
        {
            // arrange
            int[] array = { 5, 78, 12 };

            // define expected
            int[] expectedArray = { 5, 12, 78 };
            float expectedMedian = 12;

            // get actual
            float actualMedian = Service.GetMedian<int>(array, i => i);

            // assert
            Assert.IsTrue(expectedArray.SequenceEqual<int>(array));
            Assert.AreEqual(expectedMedian, actualMedian);
        }

        [TestMethod]
        public void GetMedian_IntArray_EvenLength()
        {
            // arrange
            int[] array = { 5, 78, 12, 11 };

            // define expected
            int[] expectedArray = { 5, 11, 12, 78 };
            float expectedMedian = 11.5f;

            // get actual
            float actualMedian = Service.GetMedian<int>(array, i => i);

            // assert
            Assert.IsTrue(expectedArray.SequenceEqual<int>(array));
            Assert.AreEqual(expectedMedian, actualMedian);
        }

        [TestMethod]
        public void GetPatchVariance_SimpleCase_Frame2x2_Patch2x2()
        {
            // arrange - create frame
            Image<Gray, byte> frame = new Image<Gray, byte>(2, 2);
            frame.Data[0, 0, 0] = 0;
            frame.Data[0, 1, 0] = 1;
            frame.Data[1, 0, 0] = 0;
            frame.Data[1, 1, 0] = 1;

            // arrange - define image bb
            IBoundingBox bb = new BoundingBox(new PointF(0.5f, 0.5f), new SizeF(2, 2));
            bb.ScanningWindow = bb.CreateScanningWindow();

            // arrange - calculate integral image for pixel values and integral image for squared pixel values
            Image<Gray, double> sum;
            Image<Gray, double> squareSum;
            frame.Integral(out sum, out squareSum);

            // define expected
            double expected = 0.25;

            // get actual
            Service.SetIntegralImage(sum);
            Service.SetSquaredIntegralImage(squareSum);
            double actual = Service.GetPatchVariance(bb);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPatchVariance_BiggerCase_Frame5x3_Patch3x1()
        {
            // arrange - create frame
            Image<Gray, byte> frame = new Image<Gray, byte>(5, 3);
            frame.Data[0, 0, 0] = 1;
            frame.Data[0, 1, 0] = 2;
            frame.Data[0, 2, 0] = 3;
            frame.Data[0, 3, 0] = 4;
            frame.Data[0, 4, 0] = 5;
            frame.Data[1, 0, 0] = 6;
            frame.Data[1, 1, 0] = 7;
            frame.Data[1, 2, 0] = 8;
            frame.Data[1, 3, 0] = 9;
            frame.Data[1, 4, 0] = 10;
            frame.Data[2, 0, 0] = 11;
            frame.Data[2, 1, 0] = 12;
            frame.Data[2, 2, 0] = 13;
            frame.Data[2, 3, 0] = 14;
            frame.Data[2, 4, 0] = 15;

            // arrange - define image bb
            IBoundingBox bb = new BoundingBox(new PointF(3, 1), new SizeF(3, 1));
            bb.ScanningWindow = bb.CreateScanningWindow();

            // arrange - calculate integral image for pixel values and integral image for squared pixel values
            Image<Gray, double> sum;
            Image<Gray, double> squareSum;
            frame.Integral(out sum, out squareSum);

            // define expected
            double expected = 0.666;

            // get actual
            Service.SetIntegralImage(sum);
            Service.SetSquaredIntegralImage(squareSum);
            double actual = Service.GetPatchVariance(bb);

            // assert
            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void GetPatchMean_Integral_SimpleCase_3x3()
        {
            // arrange - create frame
            Image<Gray, double> integral = new Image<Gray, double>(3, 3);
            integral.Data[0, 0, 0] = 0;
            integral.Data[0, 1, 0] = 0;
            integral.Data[0, 2, 0] = 0;
            integral.Data[1, 0, 0] = 0;
            integral.Data[1, 1, 0] = 0;
            integral.Data[1, 2, 0] = 1;
            integral.Data[2, 0, 0] = 0;
            integral.Data[2, 1, 0] = 1;
            integral.Data[2, 2, 0] = 2;

            // arrange - define image bb
            IBoundingBox bb = new BoundingBox(new PointF(0.5f, 0.5f), new SizeF(2, 2));
            bb.ScanningWindow = bb.CreateScanningWindow();

            // define expected
            double expected = 0.5;

            // get actual
            Service.SetIntegralImage(integral);
            double actual = Service.GetPatchMean_Integral(bb);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPatchMean_SquaredIntegral_SimpleCase_3x3()
        {
            // arrange - create frame
            Image<Gray, double> integral = new Image<Gray, double>(3, 3);
            integral.Data[0, 0, 0] = 0;
            integral.Data[0, 1, 0] = 0;
            integral.Data[0, 2, 0] = 0;
            integral.Data[1, 0, 0] = 0;
            integral.Data[1, 1, 0] = 0;
            integral.Data[1, 2, 0] = 1;
            integral.Data[2, 0, 0] = 0;
            integral.Data[2, 1, 0] = 1;
            integral.Data[2, 2, 0] = 2;

            // arrange - define image bb
            IBoundingBox bb = new BoundingBox(new PointF(0.5f, 0.5f), new SizeF(2, 2));
            bb.ScanningWindow = bb.CreateScanningWindow();

            // define expected
            double expected = 0.5;

            // get actual
            Service.SetSquaredIntegralImage(integral);
            double actual = Service.GetPatchMean_SquaredIntegral(bb);

            // assert
            Assert.AreEqual(expected, actual);
        }

        private bool PixelComparisonsAreEquivalent(List<PixelComparisonF> expected, List<PixelComparisonF> actual)
        {
            if (actual.Count != expected.Count)
            {
                return false;
            }

            foreach (PixelComparisonF c1 in expected)
            {
                bool found = false;
                foreach (PixelComparisonF c2 in actual)
                {
                    if (c1.Pixel1 == c2.Pixel1 && c1.Pixel2 == c2.Pixel2)
                    {
                        found = true;
                        break;
                    }
                }
                if (found == false)
                {
                    return false;
                }
            }

            return true;
        }

        [TestMethod]
        public void GeneratePixelComparisons_2x2()
        {
            // define expected
            List<PixelComparisonF> expected = new List<PixelComparisonF>()
            {
                new PixelComparisonF(new PointF(0, 0), new PointF(1, 0)),
                new PixelComparisonF(new PointF(0, 1), new PointF(1, 1)),
                new PixelComparisonF(new PointF(0, 0), new PointF(0, 1)),
                new PixelComparisonF(new PointF(1, 0), new PointF(1, 1))
            };

            // get actual
            List<PixelComparisonF> actual = Service.GeneratePixelComparisons(2, 2);

            // assert
            Assert.IsTrue(PixelComparisonsAreEquivalent(expected, actual));
        }

        [TestMethod]
        public void GeneratePixelComparisons_3x2()
        {
            // define expected
            List<PixelComparisonF> expected = new List<PixelComparisonF>()
            {
                new PixelComparisonF(new PointF(0, 0), new PointF(0.5f, 0)),
                new PixelComparisonF(new PointF(0, 0), new PointF(0.5f, 0)),
                new PixelComparisonF(new PointF(0.5f, 0), new PointF(1, 0)),
                new PixelComparisonF(new PointF(0, 1), new PointF(0.5f, 1)),
                new PixelComparisonF(new PointF(0, 1), new PointF(1, 1)),
                new PixelComparisonF(new PointF(0.5f, 1), new PointF(1, 1)),
                new PixelComparisonF(new PointF(0, 0), new PointF(0, 1)),
                new PixelComparisonF(new PointF(0.5f, 0), new PointF(0.5f, 1)),
                new PixelComparisonF(new PointF(1, 0), new PointF(1, 1)),
            };

            // get actual
            List<PixelComparisonF> actual = Service.GeneratePixelComparisons(3, 2);

            // assert
            Assert.IsTrue(PixelComparisonsAreEquivalent(expected, actual));
        }

        [TestMethod]
        public void SortScanningWindowsByOverlap()
        {
            // arrange - create bbs
            IBoundingBox bb1 = new BoundingBox(new PointF(0,0), new SizeF(1,1));
            IBoundingBox bb2 = new BoundingBox(new PointF(1,0), new SizeF(1,1));
            IBoundingBox bb3 = new BoundingBox(new PointF(0,1), new SizeF(1,1));
            IBoundingBox bb4 = new BoundingBox(new PointF(1,1), new SizeF(1,1));
            List<IBoundingBox> scanningWindows = new List<IBoundingBox>()
            {
                bb1, bb2, bb3, bb4
            };

            // define expected
            List<IBoundingBox> expected = new List<IBoundingBox>() { bb4, bb2, bb3, bb1 };

            // get actual
            IBoundingBox referenceBb = new BoundingBox(new PointF(0.7f, 0.6f), new Size(1, 1));
            List<IBoundingBox> actual = Service.SortScanningWindowsByOverlap(scanningWindows, referenceBb);

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetScanningWindowsWithOverlapGreaterOrEqualThan()
        {
            // arrange - create bbs
            IBoundingBox bb1 = new BoundingBox(new PointF(0, 0), new SizeF(1, 1));
            IBoundingBox bb2 = new BoundingBox(new PointF(1, 0), new SizeF(1, 1));
            IBoundingBox bb3 = new BoundingBox(new PointF(0, 1), new SizeF(1, 1));
            IBoundingBox bb4 = new BoundingBox(new PointF(1, 1), new SizeF(1, 1));
            List<IBoundingBox> scanningWindows = new List<IBoundingBox>()
            {
                bb1, bb2, bb3, bb4
            };

            // define expected
            List<IBoundingBox> expected = new List<IBoundingBox>() { bb4 };

            // get actual
            IBoundingBox referenceBb = new BoundingBox(new PointF(0.7f, 0.6f), new Size(1, 1));
            List<IBoundingBox> sortedScanningWindows = Service.SortScanningWindowsByOverlap(scanningWindows, referenceBb);
            List<IBoundingBox> actual = Service.GetScanningWindowsWithOverlapGreaterOrEqualThan(0.2f, referenceBb, sortedScanningWindows);

            // assert
            float overlap = bb4.GetOverlap(referenceBb); // debug info
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetScanningWindowsWithOverlapLessThan()
        {
            // arrange - create bbs
            IBoundingBox bb1 = new BoundingBox(new PointF(0, 0), new SizeF(1, 1));
            IBoundingBox bb2 = new BoundingBox(new PointF(1, 0), new SizeF(1, 1));
            IBoundingBox bb3 = new BoundingBox(new PointF(0, 1), new SizeF(1, 1));
            IBoundingBox bb4 = new BoundingBox(new PointF(1, 1), new SizeF(1, 1));
            List<IBoundingBox> scanningWindows = new List<IBoundingBox>()
            {
                bb1, bb2, bb3, bb4
            };

            // define expected
            List<IBoundingBox> expected = new List<IBoundingBox>() { bb2, bb3, bb1 };

            // get actual
            IBoundingBox referenceBb = new BoundingBox(new PointF(0.7f, 0.6f), new Size(1, 1));
            List<IBoundingBox> sortedScanningWindows = Service.SortScanningWindowsByOverlap(scanningWindows, referenceBb);
            List<IBoundingBox> actual = Service.GetScanningWindowsWithOverlapLessThan(0.2f, referenceBb, sortedScanningWindows);

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NonMaximalBoundingBoxSuppress_5Bb2Clusters()
        {
            // arrange - create bounding boxes
            List<IBoundingBox> bbs = new List<IBoundingBox>()
            {
                new BoundingBox(new PointF(0.5f,1.5f), new SizeF(2,4)),
                new BoundingBox(new PointF(0.5f,2.5f), new SizeF(2,4)),
                new BoundingBox(new PointF(2.5f,2.0f), new SizeF(4,5)),
                new BoundingBox(new PointF(2.5f,1.5f), new SizeF(4,4)),
                new BoundingBox(new PointF(2.5f,1.0f), new SizeF(4,3))
            };

            // define expected
            List<IBoundingBox> expected = new List<IBoundingBox>()
            {
                new BoundingBox(new PointF(0.5f, 2.0f), new SizeF(2,4)),
                new BoundingBox(new PointF(2.5f, 1.5f), new SizeF(4,4))
            };

            // get actual
            List<IBoundingBox> actual = Service.NonMaximalBoundingBoxSuppress(bbs);

            // assert
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Center, actual[i].Center);
                Assert.AreEqual(expected[i].Size, actual[i].Size);
            }
        }

        [TestMethod]
        public void NonMaximalBoundingBoxSuppress_2Bb2Clusters()
        {
            // arrange - create bounding boxes
            List<IBoundingBox> bbs = new List<IBoundingBox>()
            {
                new BoundingBox(new PointF(1.0f,1.0f), new SizeF(2,2)),
                new BoundingBox(new PointF(5.0f,5.0f), new SizeF(3,3)),
            };

            // define expected
            List<IBoundingBox> expected = new List<IBoundingBox>()
            {
                new BoundingBox(new PointF(1.0f,1.0f), new SizeF(2,2)),
                new BoundingBox(new PointF(5.0f,5.0f), new SizeF(3,3)),
            };

            // get actual
            List<IBoundingBox> actual = Service.NonMaximalBoundingBoxSuppress(bbs);

            // assert
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Center, actual[i].Center);
                Assert.AreEqual(expected[i].Size, actual[i].Size);
            }
        }

        [TestMethod]
        public void NonMaximalBoundingBoxSuppress_ClusterMerge()
        {
            // arrange - create bounding boxes
            List<IBoundingBox> bbs = new List<IBoundingBox>()
            {
                new BoundingBox(new PointF(1.5f,1.5f), new SizeF(4,4)),
                new BoundingBox(new PointF(4.5f,1.5f), new SizeF(4,4)),
                new BoundingBox(new PointF(2.5f,1.5f), new SizeF(4,4)),
                new BoundingBox(new PointF(3.5f,1.5f), new SizeF(4,4)),
            };

            // define expected
            List<IBoundingBox> expected = new List<IBoundingBox>()
            {
                new BoundingBox(new PointF(3.0f,1.5f), new SizeF(4,4)),
            };

            // get actual
            List<IBoundingBox> actual = Service.NonMaximalBoundingBoxSuppress(bbs);

            // assert
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Center, actual[i].Center);
                Assert.AreEqual(expected[i].Size, actual[i].Size);
            }
        }

        [TestMethod]
        public void NonMaximalBoundingBoxSuppress_4Bbs2LonelyClusters()
        {
            // arrange - create bounding boxes
            List<IBoundingBox> bbs = new List<IBoundingBox>()
            {
                new BoundingBox(new PointF(0.0f,0.0f), new SizeF(1,1)),
                new BoundingBox(new PointF(1.5f,1.5f), new SizeF(2,2)),
                new BoundingBox(new PointF(1.5f,1.5f), new SizeF(2,2)),
                new BoundingBox(new PointF(3.0f,3.0f), new SizeF(1,1)),
            };

            // define expected
            List<IBoundingBox> expected = new List<IBoundingBox>()
            {
                new BoundingBox(new PointF(0.0f,0.0f), new SizeF(1,1)),
                new BoundingBox(new PointF(1.5f,1.5f), new SizeF(2,2)),
                new BoundingBox(new PointF(3.0f,3.0f), new SizeF(1,1)),
            };

            // get actual
            List<IBoundingBox> actual = Service.NonMaximalBoundingBoxSuppress(bbs);

            // assert
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Center, actual[i].Center);
                Assert.AreEqual(expected[i].Size, actual[i].Size);
            }
        }

        [TestMethod]
        public void NonMaximalBoundingBoxSuppress_AfterClusterMerge()
        {
            // arrange - create bounding boxes
            List<IBoundingBox> bbs = new List<IBoundingBox>()
            {
                new BoundingBox(new PointF(1.5f,1.5f), new SizeF(4,4)),
                new BoundingBox(new PointF(4.5f,1.5f), new SizeF(4,4)),
                new BoundingBox(new PointF(7.0f,7.0f), new SizeF(1,1)),
                new BoundingBox(new PointF(2.5f,1.5f), new SizeF(4,4)),
                new BoundingBox(new PointF(3.5f,1.5f), new SizeF(4,4)),
                new BoundingBox(new PointF(8.0f,8.0f), new SizeF(1,1)),
                new BoundingBox(new PointF(9.0f,9.0f), new SizeF(1,1)),
            };

            // define expected
            List<IBoundingBox> expected = new List<IBoundingBox>()
            {
                new BoundingBox(new PointF(3.0f,1.5f), new SizeF(4,4)),
                new BoundingBox(new PointF(8.0f,8.0f), new SizeF(1,1)),
                new BoundingBox(new PointF(7.0f,7.0f), new SizeF(1,1)),
                new BoundingBox(new PointF(9.0f,9.0f), new SizeF(1,1)),
            };

            // get actual
            List<IBoundingBox> actual = Service.NonMaximalBoundingBoxSuppress(bbs);

            // assert
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Center, actual[i].Center);
                Assert.AreEqual(expected[i].Size, actual[i].Size);
            }
        }

        [TestMethod]
        public void NonMaximalBoundingBoxSuppress_DeadClusterRemains()
        {
            // arrange - create bounding boxes
            List<IBoundingBox> bbs = new List<IBoundingBox>()
            {
                new BoundingBox(new PointF(1.5f,1.5f), new SizeF(4,4)),
                new BoundingBox(new PointF(4.5f,1.5f), new SizeF(4,4)),
                new BoundingBox(new PointF(7.0f,7.0f), new SizeF(1,1)),
                new BoundingBox(new PointF(2.5f,1.5f), new SizeF(4,4)),
                new BoundingBox(new PointF(3.5f,1.5f), new SizeF(4,4)),
            };

            // define expected
            List<IBoundingBox> expected = new List<IBoundingBox>()
            {
                new BoundingBox(new PointF(3.0f,1.5f), new SizeF(4,4)),
                new BoundingBox(new PointF(7.0f,7.0f), new SizeF(1,1)),
            };

            // get actual
            List<IBoundingBox> actual = Service.NonMaximalBoundingBoxSuppress(bbs);

            // assert
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Center, actual[i].Center);
                Assert.AreEqual(expected[i].Size, actual[i].Size);
            }
        }

        [TestMethod]
        public void GenerateSimilarBoundingBoxes_AllBoxesInsideFrame()
        {
            // arrange - create frame size
            Size frameSize = new Size(5, 5);

            // arrange - create reference bounding box
            IBoundingBox boundingBox = new BoundingBox(new PointF(2, 2), new Size(1, 1));
            
            // arrange - create generation info
            SimilarBoundingBoxGenerationInfo genInfo = new SimilarBoundingBoxGenerationInfo(100, 0.1f, 0.1f);

            // get actual
            List<IBoundingBox> boundingBoxes = Service.GenerateSimilarBoundingBoxes(frameSize, boundingBox, genInfo);

            // assert
            Assert.AreEqual(100, boundingBoxes.Count);
            foreach (IBoundingBox bb in boundingBoxes)
            {
                Assert.AreEqual(boundingBox.Center.X, bb.Center.X, 0.1f);
                Assert.AreEqual(boundingBox.Center.Y, bb.Center.Y, 0.1f);
                Assert.AreEqual(boundingBox.Size.Width, bb.Size.Width, 0.1f);
                Assert.AreEqual(boundingBox.Size.Height, bb.Size.Height, 0.1f);
            }
        }

        [TestMethod]
        public void GenerateSimilarBoundingBoxes_AllBoxesOutsideFrame()
        {
            // arrange - create frame size
            Size frameSize = new Size(1, 1);

            // arrange - create reference bounding box
            IBoundingBox boundingBox = new BoundingBox(new PointF(2, 2), new Size(1, 1));

            // arrange - create generation info
            SimilarBoundingBoxGenerationInfo genInfo = new SimilarBoundingBoxGenerationInfo(100, 0.1f, 0.1f);

            // get actual
            List<IBoundingBox> boundingBoxes = Service.GenerateSimilarBoundingBoxes(frameSize, boundingBox, genInfo);

            // assert
            Assert.AreEqual(0, boundingBoxes.Count);
        }

        [TestMethod]
        public void PermuteTrainingExamples()
        {
            // arrange - create examples
            List<string> positiveExamples = new List<string>()
                { "a", "b", "c", "d", "e", "f", "g", "h" };

            List<string> negativeExamples = new List<string>()
                { "i", "j", "k", "l" };

            // arrange - define pairs
            Dictionary<string, bool> pairs = new Dictionary<string, bool>();
            foreach (string ex in positiveExamples)
            {
                pairs.Add(ex, true);
            }
            foreach (string ex in negativeExamples)
            {
                pairs.Add(ex, false);
            }

            // get actual
            string[] examples;
            bool[] labels;
            Service.PermuteTrainingExamples<string>(positiveExamples, negativeExamples, out examples, out labels);

            // assert
            int examplesCount = positiveExamples.Count + negativeExamples.Count;
            Assert.AreEqual(examplesCount, examples.Length);

            CollectionAssert.IsSubsetOf(positiveExamples, examples);
            CollectionAssert.IsSubsetOf(negativeExamples, examples);

            for (int i = 0; i < examplesCount; i++)
            {
                string example = examples[i];

                bool expectedLabel = pairs[example];
                bool actualLabel = labels[i];
                Assert.AreEqual(expectedLabel, actualLabel);
            }
        }
    }
}
