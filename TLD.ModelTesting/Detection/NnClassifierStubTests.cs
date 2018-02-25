using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TLD.Model;
using System.Drawing;
using TLD.Model.Detection;
using Emgu.CV.Structure;
using Emgu.CV;

namespace TLD.ModelTesting.Detection
{
    [TestClass]
    public class NnClassifierStubTests
    {
        [TestMethod]
        public void RejectPatches()
        {
            // arrange - create object model
            ObjectModelStub objectModel = new ObjectModelStub();

            // arrange - create scanning window generator with dummy windows
            ScanningWindowGeneratorStub swg = new ScanningWindowGeneratorStub();
            swg.ScanningWindows = new IBoundingBox[]
            {
                new BoundingBox(new PointF(10,10), new SizeF(5,5)),
                new BoundingBox(new PointF(10,10), new SizeF(5,5)),
                new BoundingBox(new PointF(10,10), new SizeF(5,5)),
            };

            // arrange - create nn classifier
            NnClassifier classifier = new NnClassifier(swg, objectModel, 0.75f, 0.6f);
            classifier.PostInstantiation();
            classifier.Initialize(new Image<Gray, byte>(new Size(0, 0)), new BoundingBox(new PointF(), new SizeF()));

            // arrange - hard code relative similarities of patches in scanning windows
            // 1. relative similarity of the patch in the first scanning window
            // is below the threshold -> scanning window is rejected
            // 2. relative similarity of the patch in the second scanning window
            // is the same as the threshold -> scanning window is rejected
            // 3. relative similarity of the patch in the third scanning window
            // is above the threshold -> scanning window is accepted
            objectModel.RelativeSimilarities = new List<float>() { 0.1f, 0.6f, 0.9f };
            objectModel.PnnSimilarities = new List<float>() { 0, 0.9f, 0.9f };
            objectModel.NnnSimilarities = new List<float>() { 1, 0.9f, 0 };

            // define expected accepted scanning windows
            List<int> expected = new List<int>() { 2 };

            // get actual accepted scanning windows
            List<int> actual = classifier.AcceptedWindows(new Image<Gray, byte>(new Size(1, 1)), new List<int>() { 0, 1, 2 });

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
