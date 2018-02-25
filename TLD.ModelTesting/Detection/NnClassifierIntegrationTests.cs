using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TLD.Model;
using Emgu.CV;
using Emgu.CV.Structure;
using System.IO;
using System.Drawing;
using TLD.Model.Detection;
using Emgu.CV.CvEnum;
using System.Collections.Generic;

namespace TLD.ModelTesting.Detection
{
    [TestClass]
    public class NnClassifierIntegrationTests
    {
        private string _resourceDir = @"..\..\Resource";

        [TestMethod]
        public void RejectPatches()
        {
            // arrange - create object model
            IObjectModel objectModel = new ObjectModel(new Size(15, 15));
            objectModel.PostInstantiation();
            // -> create 2 positive and 2 negative patches
            Image<Gray, byte> helpImage = new Image<Gray, byte>(Path.Combine(_resourceDir, "violeta_1.jpg"));
            Image<Gray, byte> posPatch1 = helpImage.GetPatch(new PointF(168, 178), new Size(80, 40)).Resize(objectModel.PatchSize.Width, objectModel.PatchSize.Height, INTER.CV_INTER_LINEAR);
            Image<Gray, byte> posPatch2 = helpImage.GetPatch(new PointF(169, 179), new Size(81, 41)).Resize(objectModel.PatchSize.Width, objectModel.PatchSize.Height, INTER.CV_INTER_LINEAR);
            Image<Gray, byte> negPatch1 = helpImage.GetPatch(new PointF(300, 200), new Size(50, 50)).Resize(objectModel.PatchSize.Width, objectModel.PatchSize.Height, INTER.CV_INTER_LINEAR);
            Image<Gray, byte> negPatch2 = helpImage.GetPatch(new PointF(200, 300), new Size(50, 50)).Resize(objectModel.PatchSize.Width, objectModel.PatchSize.Height, INTER.CV_INTER_LINEAR);
            // -> add patches to the object model
            objectModel.AddPositivePatch(posPatch1);
            objectModel.AddPositivePatch(posPatch2);
            objectModel.AddNegativePatch(negPatch1);
            objectModel.AddNegativePatch(negPatch2);

            // arrange - create scanning window generator with stub windows
            ScanningWindowGeneratorStub swg = new ScanningWindowGeneratorStub();
            swg.ScanningWindows = new IBoundingBox[]
            {
                new BoundingBox(new PointF(167, 177), new SizeF(79, 39)),
                new BoundingBox(new PointF(300, 300), new SizeF(80, 40))
            };

            // arrange - create classifier
            NnClassifier classifier = new NnClassifier(swg, objectModel, 0.75f, 0.6f);
            classifier.PostInstantiation();
            classifier.Initialize(new Image<Gray, byte>(new Size(0, 0)), new BoundingBox(new PointF(), new SizeF()));

            // define expected accepted patches
            List<int> expected = new List<int>() { 0 };

            // get actual accepted patches
            List<int> actual = classifier.AcceptedWindows(helpImage, new List<int>() { 0, 1 });

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RejectPatches_FrameRoiIsNotSetAfterProcessing()
        {
            // arrange - create object model
            IObjectModel objectModel = new ObjectModel(new Size(15, 15));
            objectModel.PostInstantiation();
            // -> create 1 patch
            Image<Gray, byte> helpImage = new Image<Gray, byte>(Path.Combine(_resourceDir, "violeta_1.jpg"));
            Image<Gray, byte> patch = helpImage.GetPatch(new PointF(168, 178), new Size(80, 40)).Resize(objectModel.PatchSize.Width, objectModel.PatchSize.Height, INTER.CV_INTER_LINEAR);
            // -> add patch to the object model
            objectModel.AddPositivePatch(patch);

            // arrange - create scanning window generator with stub windows
            ScanningWindowGeneratorStub swg = new ScanningWindowGeneratorStub();
            swg.ScanningWindows = new IBoundingBox[]
            {
                new BoundingBox(new PointF(167, 177), new SizeF(79, 39))
            };

            // arrange - create classifier
            NnClassifier classifier = new NnClassifier(swg, objectModel, 0.75f, 0.6f);
            classifier.PostInstantiation();
            classifier.Initialize(new Image<Gray, byte>(new Size(0, 0)), new BoundingBox(new PointF(), new SizeF()));

            // define expected frame ROI after processing
            Rectangle expected = new Rectangle(new Point(), helpImage.Size);

            // get actual frame ROI after processing
            classifier.AcceptedWindows(helpImage, new List<int>() { 0 });
            Rectangle actual = helpImage.ROI;

            // assert
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(!helpImage.IsROISet);  // just in case
        }
    }
}
