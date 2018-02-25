using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TLD.Model;

namespace TLD.ModelTesting
{
    [TestClass]
    public class ShiftTests
    {
        [TestMethod]
        public void HorizontalVertical()
        {
            //arrange
            Shift shift = new Shift(
                new PointF(10, 15),
                new PointF(12.5f, 9.3f),
                new PointF(9, 14)
            );

            // define expected
            float expectedHorizontal = 2.5f;
            float expectedVertical = -5.7f;

            // get actual
            float actualHorizontal = shift.Horizontal;
            float actualVertical = shift.Vertical;

            // assert
            Assert.AreEqual(expectedHorizontal, actualHorizontal);
            Assert.AreEqual(expectedVertical, actualVertical);
        }
    }
}
