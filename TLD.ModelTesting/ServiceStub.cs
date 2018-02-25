using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace TLD.ModelTesting
{
    class ServiceStub
    {
        public List<List<float>> FBErrorsList { get; set; }
        public List<List<float>> NCCsList { get; set; }

        public float FBErrorStub(PointF point1, PointF point2)
        {
            List<float> currentList = FBErrorsList[0];

            float error = currentList[0];
            currentList.RemoveAt(0);
            if (currentList.Count == 0)
            {
                FBErrorsList.Remove(currentList);
            }

            return error;
        }

        public float NCCStub(Image<Gray, byte> patch1, Image<Gray, byte> patch2)
        {
            List<float> currentList = NCCsList[0];

            float ncc = currentList[0];
            currentList.RemoveAt(0);
            if (currentList.Count == 0)
            {
                NCCsList.Remove(currentList);
            }

            return ncc;
        }
    }
}
