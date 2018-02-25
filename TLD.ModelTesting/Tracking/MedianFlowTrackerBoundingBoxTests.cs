using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TLD.Model;

namespace TLD.ModelTesting
{
    [TestClass]
    public class MedianFlowTrackerBoundingBoxTests
    {
        public static bool CompareGrids(PointF[,] grid1, PointF[,] grid2)
        {
            int rows1 = grid1.GetLength(0);
            int cols1 = grid1.GetLength(1);
            int rows2 = grid2.GetLength(0);
            int cols2 = grid2.GetLength(1);

            if (rows1 != rows2 || cols1 != cols2)
            {
                return false;
            }

            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    if (grid1[i, j] != grid2[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        [TestMethod]
        public void GetGrid_Simple()
        {
            // arrange
            MedianFlowTrackerBoundingBox box = new MedianFlowTrackerBoundingBox(new SizeF(2, 2));

            // define expected
            PointF[,] expected = new PointF[,] { 
                { new PointF(0.0f, 0.0f), new PointF(1.0f, 0.0f) },
                { new PointF(0.0f, 1.0f), new PointF(1.0f, 1.0f) }
            };

            // get actual
            PointF[,] actual = box.GetGrid(new Size(2, 2), new SizeF(0.0f, 0.0f));

            // assert
            Assert.IsTrue(CompareGrids(expected, actual));
        }

        [TestMethod]
        public void GetGrid_UniformPadding()
        {
            // arrange
            MedianFlowTrackerBoundingBox box = new MedianFlowTrackerBoundingBox(new SizeF(4, 4));

            // define expected
            PointF[,] expected = new PointF[,] { 
                { new PointF(1.0f, 1.0f), new PointF(2.0f, 1.0f) },
                { new PointF(1.0f, 2.0f), new PointF(2.0f, 2.0f) }
            };

            // get actual
            PointF[,] actual = box.GetGrid(new Size(2, 2), new SizeF(1.0f, 1.0f));

            // assert
            Assert.IsTrue(CompareGrids(expected, actual));
        }

        [TestMethod]
        public void GetGrid_NonUniformPadding()
        {
            // arrange
            MedianFlowTrackerBoundingBox box = new MedianFlowTrackerBoundingBox(new SizeF(6, 4));

            // define expected
            PointF[,] expected = new PointF[,] { 
                { new PointF(2.0f, 1.0f), new PointF(3.0f, 1.0f) },
                { new PointF(2.0f, 2.0f), new PointF(3.0f, 2.0f) }
            };

            // get actual
            PointF[,] actual = box.GetGrid(new Size(2, 2), new SizeF(2.0f, 1.0f));

            // assert
            Assert.IsTrue(CompareGrids(expected, actual));
        }

        [TestMethod]
        public void GetGrid_NonUniformSpacing()
        {
            // arrange
            MedianFlowTrackerBoundingBox box = new MedianFlowTrackerBoundingBox(new SizeF(4, 2));

            // define expected
            PointF[,] expected = new PointF[,] { 
                { new PointF(0.0f, 0.0f), new PointF(3.0f, 0.0f) },
                { new PointF(0.0f, 1.0f), new PointF(3.0f, 1.0f) }
            };

            // get actual
            PointF[,] actual = box.GetGrid(new Size(2, 2), new SizeF(0.0f, 0.0f));

            // assert
            Assert.IsTrue(CompareGrids(expected, actual));
        }

        [TestMethod]
        public void GetGrid_NonUniformPaddingAndSpacing()
        {
            // arrange
            MedianFlowTrackerBoundingBox box = new MedianFlowTrackerBoundingBox(new SizeF(5, 4));

            // define expected
            PointF[,] expected = new PointF[,] { 
                { new PointF(0.5f, 1.0f), new PointF(3.5f, 1.0f) },
                { new PointF(0.5f, 2.0f), new PointF(3.5f, 2.0f) }
            };

            // get actual
            PointF[,] actual = box.GetGrid(new Size(2, 2), new SizeF(0.5f, 1.0f));

            // assert
            Assert.IsTrue(CompareGrids(expected, actual));
        }

        [TestMethod]
        public void GetGrid_NonUniformPaddingAndSpacing_Big()
        {
            // arrange
            MedianFlowTrackerBoundingBox box = new MedianFlowTrackerBoundingBox(new SizeF(5, 5));

            // define expected
            PointF[,] expected = new PointF[,] { 
                { new PointF(0.5f, 1.0f), new PointF(2.0f, 1.0f), new PointF(3.5f, 1.0f) },
                { new PointF(0.5f, 3.0f), new PointF(2.0f, 3.0f), new PointF(3.5f, 3.0f) }
            };

            // get actual
            PointF[,] actual = box.GetGrid(new Size(3, 2), new SizeF(0.5f, 1.0f));

            // assert
            Assert.IsTrue(CompareGrids(expected, actual));
        }

        /*******************************************************************************************
         * The following methods test the MedianFlowTrackerBoundingBox's implementation of the
         * IMedianFlowTrackerBoundingBox interface
         *******************************************************************************************/

        /* Test a simple case.
         * Bounding box is not square.
         * Bounding box is entirely in the frame, so all grid points are visible.
         * There are 4 grid points, exactly in the box's corners.
         */

        [TestMethod]
        public void GetVisibleGridPoints_Simple()
        {
            // arrange
            IMedianFlowTrackerBoundingBox bb = new MedianFlowTrackerBoundingBox
            (
                new PointF(2.5f, 3),
                new SizeF(3, 2),        // bb is not square
                new Size(2, 2),         // there are 4 grid points
                new SizeF(0, 0)
            );

            // define expected
            PointF[] expectedPoints = 
            {
                new PointF(1,2), new PointF(4,2),
                new PointF(1,4), new PointF(4,4)
            };

            // get actual
            PointF[] actualPoints = bb.GetGridPoints();

            // assert
            CollectionAssert.AreEqual(expectedPoints, actualPoints);
        }

        /* Test padding.
         * Bounding box is not square.
         * Bounding box is entirely in the frame, so all grid points are visible.
         * There are 4 grid points.
         * There is also a horizontal and vertical padding, which are different.
         */

        [TestMethod]
        public void GetVisibleGridPoints_Padding()
        {
            // arrange
            IMedianFlowTrackerBoundingBox bb = new MedianFlowTrackerBoundingBox
            (
                new PointF(2.5f, 3),
                new SizeF(3, 2),        // bb is not square
                new Size(2, 2),         // there are 4 grid points
                new SizeF(1, 0.5f)      // padding, different for horizontal and vertical
            );

            // define expected
            PointF[] expectedPoints = 
            {
                new PointF(2, 2.5f), new PointF(3, 2.5f),
                new PointF(2, 3.5f), new PointF(3, 3.5f)
            };

            // get actual
            PointF[] actualPoints = bb.GetGridPoints();

            // assert
            CollectionAssert.AreEqual(expectedPoints, actualPoints);
        }

//        /* Test visibility.
//         * Bounding box is not square.
//         * Bounding box is not entirely in the frame, so some grid points are not visible.
//         * There are 4 grid points - only 1 point in the lower-left corner is visible.
//         *  - that means that the box is located close to the upper right corner
//         */
//
//        [TestMethod]
//        public void GetVisibleGridPoints_Visibility()
//        {
//            // arrange
//            IBoundingBox bb = new BoundingBox
//            (
//                new PointF(7.5f, -0.5f),    // located close to the upper right corner
//                new SizeF(3, 1),            // not square
//                new Size(2, 2),             // 4 grid points
//                new SizeF(0, 0),            // no padding
//                new Size(8, 6)
//            );
//
//            // define expected
//            PointF[] expectedPoints = { new PointF(6, 0) };
//
//            // get actual
//            PointF[] actualPoints = bb.GetVisibleGridPoints();
//
//            // assert
//            CollectionAssert.AreEqual(expectedPoints, actualPoints);
//        }

        /* Test how current bb, given the translation and scale, creates another bb
         */

        [TestMethod]
        public void CreateCurrent()
        {
            // arrange
            PointF center = new PointF(3, 2);
            SizeF size = new SizeF(4, 5);
            Size gridSize = new Size(4, 2);
            SizeF gridPadding = new SizeF(1,1);
            IMedianFlowTrackerBoundingBox bb = new MedianFlowTrackerBoundingBox(
                center,
                size,
                gridSize,
                gridPadding
            );

            // define expected
            PointF expectedCenter = new PointF(5.5f, 3.5f);
            SizeF expectedSize = new SizeF(6, 7.5f);
            Size expectedGridSize = gridSize;
            SizeF expectedGridPadding = gridPadding;

            // get actual
            IMedianFlowTrackerBoundingBox IactualBB = bb.CreateCurrent(2.5f, 1.5f, 1.5f);
            MedianFlowTrackerBoundingBox actualBB = IactualBB as MedianFlowTrackerBoundingBox;

            // assert
            Assert.AreEqual(expectedCenter, actualBB.Center);
            Assert.AreEqual(expectedSize, actualBB.Size);
            Assert.AreEqual(expectedGridSize, actualBB.GridSize);
            Assert.AreEqual(expectedGridPadding, actualBB.GridPadding);
        }

        
    }
}
