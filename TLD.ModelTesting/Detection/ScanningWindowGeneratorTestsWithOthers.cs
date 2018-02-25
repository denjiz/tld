using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TLD.Model;
using System.Drawing;
using TLD.Model.Detection;
using Emgu.CV;
using Emgu.CV.Structure;

namespace TLD.ModelTesting.Detection
{
    [TestClass]
    public class ScanningWindowGeneratorTestsWithOthers
    {
        /* This function must not throw exception
         */ 
        [TestMethod]
        public void SwgAndBaseClassifier()
        {
            // arrange - define frame
            Image<Gray, byte> frame = new Image<Gray, byte>(new Size(4, 3));

            // arrange - create scanning window generator
            ScanningWindowGenerator swg = new ScanningWindowGenerator(2.0f, 0.1f, 0.1f, 1);

            // arrange - generate scanning windows
            swg.Generate(frame.Size, new BoundingBox(new PointF(2.5f, 1.5f), new SizeF(2, 1)));

            // arrange - create pixel comparison scheduler with for 1 base classifier with 1 comparisons
            PixelComparisonSchedulerStub pcs = new PixelComparisonSchedulerStub();
            PixelComparisonGroupF pcg = new PixelComparisonGroupF();
            pcg.Value = new PixelComparisonF[]
            {
                new PixelComparisonF(new PointF(0, 0), new PointF(1, 0)),
            };
            pcs.ScheduledPixelComparisons = new PixelComparisonGroupF[]
            {
                pcg
            };

            // arrange - create base classifier
            BaseClassifier classifier = new BaseClassifier(swg, 0, pcs);
            classifier.PostInstantiation();
            classifier.Initialize();
            classifier.SetCurrentFrame(frame);

            // calculate binary code for every window - this part must not throw exception
            for (int i = 0; i < swg.ScanningWindows.Length; i++)
            {
                classifier.CalculatePosteriorForWindow(i);
            }
        }
    }
}
