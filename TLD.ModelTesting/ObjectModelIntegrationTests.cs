using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TLD.Model;
using Emgu.CV;
using Emgu.CV.Structure;
using System.IO;
using System.Drawing;
using Emgu.CV.CvEnum;

namespace TLD.ModelTesting
{
    [TestClass]
    public class ObjectModelIntegrationTests
    {
        private string _resourceDir = @"..\..\Resource";

        [TestMethod]
        public void RelativeSimilarity()
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

            // arrange - create 2 test patches, 1 should be positive and 1 negative
            Image<Gray, byte> posPatch = helpImage.GetPatch(new PointF(167, 177), new Size(79, 39)).Resize(objectModel.PatchSize.Width, objectModel.PatchSize.Height, INTER.CV_INTER_LINEAR);
            Image<Gray, byte> negPatch = helpImage.GetPatch(new PointF(300, 300), new Size(80, 40)).Resize(objectModel.PatchSize.Width, objectModel.PatchSize.Height, INTER.CV_INTER_LINEAR);

            // get actual relative similarities with the object model
            float actual1 = objectModel.RelativeSimilarity(posPatch);
            float actual2 = objectModel.RelativeSimilarity(negPatch);

            // assert
            Assert.IsTrue(actual1 >  0.5f && actual2 <= 1.0f);
            Assert.IsTrue(actual2 >= 0.0f && actual2 <= 0.5f);
        }

        [TestMethod]
        public void RelativeSimilarity_IfModelEmptyThenZero()
        {
            // arrange - create empty object model
            IObjectModel objectModel = new ObjectModel(new Size(15, 15));
            objectModel.PostInstantiation();

            // arrange - create 1 test patch
            Image<Gray, byte> helpImage = new Image<Gray, byte>(Path.Combine(_resourceDir, "violeta_1.jpg"));
            Image<Gray, byte> patch = helpImage.GetPatch(new PointF(167, 177), new Size(79, 39)).Resize(objectModel.PatchSize.Width, objectModel.PatchSize.Height, INTER.CV_INTER_LINEAR);

            // define expected relative similarity
            float expected = 0.0f;

            // get actual relative similarity
            float actual = objectModel.RelativeSimilarity(patch);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
