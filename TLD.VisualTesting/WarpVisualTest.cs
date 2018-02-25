using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using TLD.Model;

namespace TLD.VisualTesting
{
    class WarpVisualTest
    {
        private static string _resourceDir = @"..\..\Resource";

        public static void Run()
        {
            Image<Gray, byte> image = new Image<Gray, byte>(Path.Combine(_resourceDir, "violeta_1.jpg"));

            string warpWinName = "Warp";
            CvInvoke.cvNamedWindow(warpWinName);
            string originalWinName = "Original";
            CvInvoke.cvNamedWindow(originalWinName);
            CvInvoke.cvShowImage(originalWinName, image);

            int key = 110;
            Image<Gray, byte> background = new Image<Gray,byte>(200, 200, new Gray(1));
            while (true)
            {
                if (key == 110)
                {
                    key = -1;
                    Image<Gray, byte> patch = Service.GenerateSimilarPatch(
                    image,
                    new BoundingBox(new PointF(166, 177), new SizeF(80, 40)),
                    0.1f,
                    0.1f,
                    30.0f
                    );
                    CvInvoke.cvShowImage(warpWinName, patch);
                }

                key = CvInvoke.cvWaitKey(0);
                if (key == 27)
                {
                    break;
                }
                
            }

            CvInvoke.cvDestroyWindow(warpWinName);
        }
    }
}
