using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TLD.Model;
using System.Drawing;
using System.Collections.Generic;

namespace TLD.ModelTesting
{
    [TestClass]
    public class ScanningWindowGeneratorTests
    {
        [TestMethod]
        public void Generate_SimpleCase()
        {
            // arrange - instantiate generator
            ScanningWindowGenerator generator = new ScanningWindowGenerator
            (
                2.0f,
                1.0f,
                1.0f,
                1
            );

            // arrange - define frame size and initial bounding box
            Size frameSize = new Size(2, 2);
            IBoundingBox initialBb = new BoundingBox(new PointF(0, 0), new SizeF(1, 1));

            // define expected
            IBoundingBox[] expected = new IBoundingBox[]
            {
                initialBb.CreateInstance(new PointF(0,0), new SizeF(1,1)),
                initialBb.CreateInstance(new PointF(1,0), new SizeF(1,1)),
                initialBb.CreateInstance(new PointF(0,1), new SizeF(1,1)),
                initialBb.CreateInstance(new PointF(1,1), new SizeF(1,1)),
                initialBb.CreateInstance(new PointF(0.5f,0.5f), new SizeF(2,2)),
            };

            // get actual
            IBoundingBox[] actual = generator.Generate(frameSize, initialBb);

            // assert
            Assert.IsTrue(BoundingBoxListsAreEqual(expected.ToList(), actual.ToList()));
        }

        [TestMethod]
        public void Generate_NonRectangularFrameAndInitialBb()
        {
            // arrange - instantiate generator
            ScanningWindowGenerator generator = new ScanningWindowGenerator
            (
                2.0f,
                0.5f,
                1.0f,
                1
            );

            // arrange - define frame size and initial bounding box
            Size frameSize = new Size(4, 3);
            IBoundingBox initialBb = new BoundingBox(new PointF(2.5f, 2), new SizeF(2, 1));

            // define expected
            IBoundingBox[] expected = new IBoundingBox[]
            {
                initialBb.CreateInstance(new PointF(0.5f,0), new SizeF(2,1)),
                initialBb.CreateInstance(new PointF(1.5f,0), new SizeF(2,1)),
                initialBb.CreateInstance(new PointF(2.5f,0), new SizeF(2,1)),
                initialBb.CreateInstance(new PointF(0.5f,1), new SizeF(2,1)),
                initialBb.CreateInstance(new PointF(1.5f,1), new SizeF(2,1)),
                initialBb.CreateInstance(new PointF(2.5f,1), new SizeF(2,1)),
                initialBb.CreateInstance(new PointF(0.5f,2), new SizeF(2,1)),
                initialBb.CreateInstance(new PointF(1.5f,2), new SizeF(2,1)),
                initialBb.CreateInstance(new PointF(2.5f,2), new SizeF(2,1)),
                initialBb.CreateInstance(new PointF(1.5f,0.5f), new SizeF(4,2))
            };

            // get actual
            IBoundingBox[] actual = generator.Generate(frameSize, initialBb);

            // assert
            Assert.IsTrue(BoundingBoxListsAreEqual(expected.ToList(), actual.ToList()));
        }

        private bool BoundingBoxListsAreEqual(List<IBoundingBox> list1, List<IBoundingBox> list2)
        {
            if (list1.Count != list2.Count)
            {
                return false;
            }

            for (int i = 0; i < list1.Count; i++)
            {
                IBoundingBox bb1 = list1[i];
                IBoundingBox bb2 = list2[i];
                if (bb1.Center != bb2.Center || bb1.Size != bb2.Size)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
