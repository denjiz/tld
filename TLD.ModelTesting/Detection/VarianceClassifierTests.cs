using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TLD.Model.Detection;
using Emgu.CV;
using Emgu.CV.Structure;
using System.IO;
using TLD.Model;
using System.Collections.Generic;
using TLD.ModelTesting.Detection;

namespace TLD.ModelTesting
{
    [TestClass]
    public class VarianceClassifierTests
    {
        private string _resourceDir = @"..\..\Resource";

        [TestMethod]
        public void RejectPatches_2scanningWindows()
        {
            // arrange - initialize classifier
            Image<Gray, byte> initialFrame = new Image<Gray, byte>(Path.Combine(_resourceDir, "violeta_1.jpg"));
            IBoundingBox initialBb = new BoundingBox(new PointF(168, 178), new SizeF(80, 40));

            // arrange - instantiate scanning window generator
            ScanningWindowGeneratorStub swg = new ScanningWindowGeneratorStub();
            IBoundingBox correctBb = initialBb.CreateInstance(new PointF(294, 281), new SizeF(80, 40));
            swg.ScanningWindows = new IBoundingBox[]
            {
                correctBb,
                initialBb.CreateInstance(new PointF(133,222), new SizeF(80, 40))
            };
            foreach (IBoundingBox bb in swg.ScanningWindows)
            {
                bb.ScanningWindow = bb.CreateScanningWindow();
            }

            // arrange - instantiate classifier
            VarianceClassifier classifier = new VarianceClassifier(swg, 0.5);
            classifier.Initialize(initialFrame, initialBb);

            // arrange - define future frame
            Image<Gray, byte> futureFrame = new Image<Gray, byte>(Path.Combine(_resourceDir, "violeta_4.jpg"));

            // define expected
            List<int> expected = new List<int>() { 0 };

            // get actual
            List<int> actual = classifier.AcceptedWindows(futureFrame, new List<int>() { 0, 1 });

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
