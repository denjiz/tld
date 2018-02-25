using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TLD.Model;
using System.Drawing;

namespace TLD.ModelTesting
{
    [TestClass]
    public class BoundingBoxTests
    {
        /* Test how a bb represents itself as a System.Drawing.RectangleF
         */

        [TestMethod]
        public void GetRectangle()
        {
            // arrange
            IBoundingBox bb = new BoundingBox
            (
                new PointF(3, 1.5f),
                new SizeF(2, 1)
            );

            // define expected
            RectangleF expected = new RectangleF
            (
                new PointF(2, 1),
                new SizeF(2, 1)
            );

            // get actual
            RectangleF actual = bb.GetRectangle();

            // assert
            Assert.AreEqual(expected, actual);
        }

        /* Test overlap calculation:
         * When boxes are partially overlapped, result is in range <0, 1>
         */

        [TestMethod]
        public void GetOverlap_PartialOverlap()
        {
            // arrange
            IBoundingBox bb1 = new BoundingBox
            (
                new PointF(3, 1.5f),
                new SizeF(3, 2)
            );
            IBoundingBox bb2 = new BoundingBox
            (
                new PointF(3.5f, 2.5f),
                new SizeF(2, 2)
            );

            // define expected
            float expected = 0.25f;

            // get actual
            float actual = bb1.GetOverlap(bb2);

            // assert
            Assert.AreEqual(expected, actual);
        }

        /* Test overlap calculation:
         * When boxes are totally overlapped, result is 1
         */

        [TestMethod]
        public void GetOverlap_TotalOverlap()
        {
            // arrange
            IBoundingBox bb1 = new BoundingBox
            (
                new PointF(3, 1.5f),
                new SizeF(3, 2)
            );
            IBoundingBox bb2 = new BoundingBox
            (
                new PointF(3, 1.5f),
                new SizeF(3, 2)
            );

            // define expected
            float expected = 1;

            // get actual
            float actual = bb1.GetOverlap(bb2);

            // assert
            Assert.AreEqual(expected, actual);
        }

        /* Test overlap calculation:
         * When boxes are not overlapped, result is 0
         */

        [TestMethod]
        public void GetOverlap_NoOverlap()
        {
            // arrange
            IBoundingBox bb1 = new BoundingBox
            (
                new PointF(3, 1.5f),
                new SizeF(3, 2)
            );
            IBoundingBox bb2 = new BoundingBox
            (
                new PointF(0, 1.5f),
                new SizeF(1, 2)
            );

            // define expected
            float expected = 0;

            // get actual
            float actual = bb1.GetOverlap(bb2);

            // assert
            Assert.AreEqual(expected, actual);
        }

        /* Test inside frame calculation.
         * If the box is entirely inside the frame, return true.
         */

        [TestMethod]
        public void InsideFrame_EntirelyInsideFrame()
        {
            // arrange
            IBoundingBox bb = new BoundingBox(new PointF(2, 2),new SizeF(1, 1));
            Size frameSize = new Size(5, 5);

            // define expected
            bool expected = true;

            // get actual
            bool actual = bb.InsideFrame(frameSize);

            // assert
            Assert.AreEqual(expected, actual);
        }

        /* Test inside frame calculation.
         * If the box is touching the frame edge, return true.
         */

        [TestMethod]
        public void InsideFrame_MarginalCase()
        {
            // arrange
            IBoundingBox bb = new BoundingBox(new PointF(1, 1), new SizeF(1, 1));
            Size frameSize = new Size(2, 2);

            // define expected
            bool expected = true;

            // get actual
            bool actual = bb.InsideFrame(frameSize);

            // assert
            Assert.AreEqual(expected, actual);
        }

        /* Test inside frame calculation.
         * If the box is partially inside the frame, return false.
         */

        [TestMethod]
        public void InsideFrame_PartiallyInside()
        {
            // arrange
            IBoundingBox bb = new BoundingBox(new PointF(1.5f, 1), new SizeF(1, 1));
            Size frameSize = new Size(2, 2);

            // define expected
            bool expected = false;

            // get actual
            bool actual = bb.InsideFrame(frameSize);

            // assert
            Assert.AreEqual(expected, actual);
        }

        /* Test inside frame calculation.
         * If the box is partially inside the frame, return false.
         */

        [TestMethod]
        public void InsideFrame_OutsideFrame()
        {
            // arrange
            IBoundingBox bb = new BoundingBox(new PointF(3, 1), new SizeF(1, 1));
            Size frameSize = new Size(2, 2);

            // define expected
            bool expected = false;

            // get actual
            bool actual = bb.InsideFrame(frameSize);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
