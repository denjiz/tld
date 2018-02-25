using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TLD.ModelTesting.Intertesting
{
    [TestClass]
    public class GridComparingTests
    {
        [TestMethod]
        public void CompareGrids_Both2x2_Equal()
        {
            // arrange
            PointF[,] grid1 = new PointF[,]{
                { new PointF(1,2), new PointF(3,4) },
                { new PointF(5,6), new PointF(7,8) }
            };
            PointF[,] grid2 = new PointF[,]{
                { new PointF(1,2), new PointF(3,4) },
                { new PointF(5,6), new PointF(7,8) }
            };

            // define expected
            bool expected = true;

            // get actual
            bool actual = MedianFlowTrackerBoundingBoxTests.CompareGrids(grid1, grid2);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CompareGrids_Both2x2_NotEqual()
        {
            // arrange
            PointF[,] grid1 = new PointF[,]{
                { new PointF(1,2), new PointF(3,4) },
                { new PointF(5,6), new PointF(7,8) }
            };
            PointF[,] grid2 = new PointF[,]{
                { new PointF(1,2), new PointF(3,4) },
                { new PointF(5,6), new PointF(7,7) }
            };

            // define expected
            bool expected = false;

            // get actual
            bool actual = MedianFlowTrackerBoundingBoxTests.CompareGrids(grid1, grid2);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CompareGrids_First1x2_Second2x2()
        {
            // arrange
            PointF[,] grid1 = new PointF[,]{
                { new PointF(1,2), new PointF(3,4) }
            };
            PointF[,] grid2 = new PointF[,]{
                { new PointF(1,2), new PointF(3,4) },
                { new PointF(5,6), new PointF(7,7) }
            };

            // define expected
            bool expected = false;

            // get actual
            bool actual = MedianFlowTrackerBoundingBoxTests.CompareGrids(grid1, grid2);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CompareGrids_First2x2_Second2x1()
        {
            // arrange
            PointF[,] grid1 = new PointF[,]{
                { new PointF(1,2), new PointF(3,4) },
                { new PointF(5,6), new PointF(7,7) }
            };
            PointF[,] grid2 = new PointF[,]{
                { new PointF(1,2)},
                { new PointF(5,6)}
            };

            // define expected
            bool expected = false;

            // get actual
            bool actual = MedianFlowTrackerBoundingBoxTests.CompareGrids(grid1, grid2);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CompareGrids_First1x2_Second2x1()
        {
            // arrange
            PointF[,] grid1 = new PointF[,]{
                { new PointF(1,2), new PointF(3,4) }
            };
            PointF[,] grid2 = new PointF[,]{
                { new PointF(1,2)},
                { new PointF(5,6)}
            };

            // define expected
            bool expected = false;

            // get actual
            bool actual = MedianFlowTrackerBoundingBoxTests.CompareGrids(grid1, grid2);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
