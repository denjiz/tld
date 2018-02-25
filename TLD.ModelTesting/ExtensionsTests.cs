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
    public class ExtensionsTests
    {
        private string _resourceDir = @"..\..\Resource";

        [TestMethod]
        public void ImageEquality_DifferentSize()
        {
            // arrange
            Image<Gray, byte> image1 = new Image<Gray, byte>(Path.Combine(_resourceDir, "pattern_black_white_8x8_1.bmp"));
            Image<Gray, byte> image2 = new Image<Gray, byte>(Path.Combine(_resourceDir, "pattern_black_white_3x4_1.bmp"));

            // define expected
            bool expected = false;

            // get actual
            bool actual = image1.IsEqualTo(image2);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ImageEquality_SameSizeButDifferent()
        {
            // arrange
            Image<Gray, byte> image1 = new Image<Gray, byte>(Path.Combine(_resourceDir, "patch_yellow_15x12_1.jpg"));
            Image<Gray, byte> image2 = new Image<Gray, byte>(Path.Combine(_resourceDir, "patch_yellow_15x12_2.jpg"));

            // define expected
            bool expected = false;

            // get actual
            bool actual = image1.IsEqualTo(image2);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ImageEquality_SameSizeAndEqual()
        {
            // arrange
            Image<Gray, byte> image1 = new Image<Gray, byte>(Path.Combine(_resourceDir, "patch_yellow_15x12_1.jpg"));
            Image<Gray, byte> image2 = new Image<Gray, byte>(Path.Combine(_resourceDir, "patch_yellow_15x12_1.jpg"));

            // define expected
            bool expected = true;

            // get actual
            bool actual = image1.IsEqualTo(image2);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPatch_NoSubPixel()
        {
            // arrange
            Image<Gray, byte> image = new Image<Gray, byte>(Path.Combine(_resourceDir, "pattern_black_white_8x8_1.bmp"));

            // define expected
            Image<Gray, byte> expectedPatch = new Image<Gray, byte>(Path.Combine(_resourceDir, "pattern_black_white_3x4_1.bmp"));

            // get actual
            Image<Gray, byte> actualPatch = image.GetPatch(new PointF(3, 2.5f), new Size(3, 4));

            // assert
            Assert.IsTrue(actualPatch.IsEqualTo(expectedPatch));
        }

        [TestMethod]
        public void GetPatch_SubPixel()
        {
            // arrange
            Image<Gray, byte> image = new Image<Gray, byte>(Path.Combine(_resourceDir, "pattern_black_white_8x8_1.bmp"));

            // define expected
            Image<Gray, byte> expectedPatch = new Image<Gray, byte>(2, 2);
            expectedPatch.Data[0, 0, 0] = 192; expectedPatch.Data[0, 1, 0] = 255;
            expectedPatch.Data[1, 0, 0] = 128; expectedPatch.Data[1, 1, 0] = 128;

            // get actual
            Image<Gray, byte> actualPatch = image.GetPatch(new PointF(3, 2), new Size(2, 2));

            // assert
            Assert.IsTrue(actualPatch.IsEqualTo(expectedPatch));
        }
    }
}
