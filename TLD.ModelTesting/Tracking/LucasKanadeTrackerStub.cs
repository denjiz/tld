using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using TLD.Model;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace TLD.ModelTesting
{
    class LucasKanadeTrackerStub : ILucasKanadeTracker
    {
        public List<PointF[]> ForwardPointsList { get; set; }
        public List<PointF[]> BackwardPointsList { get; set; }
        public List<byte[]> ForwardStatusList { get; set; }
        public List<byte[]> BackwardStatusList { get; set; }

        public LucasKanadeTrackerStub(
            List<PointF[]> forwardPointsList,
            List<PointF[]> backwardPointsList,
            List<byte[]> forwardStatusList,
            List<byte[]> backwardStatusList
        )
        {
            ForwardPointsList = forwardPointsList;
            BackwardPointsList = backwardPointsList;
            ForwardStatusList = forwardStatusList;
            BackwardStatusList = backwardStatusList;
        }

        public PointF[] TrackPointsForward(PointF[] previousPoints, Image<Gray, byte> currentFrame, out byte[] status)
        {
            PointF[] forwardPoints = ForwardPointsList[0];
            ForwardPointsList.RemoveAt(0);
            byte[] forwardStatus = ForwardStatusList[0];
            ForwardStatusList.RemoveAt(0);

            status = forwardStatus;
            return forwardPoints;
        }

        public PointF[] TrackPointsBackward(out byte[] status)
        {
            PointF[] backwardPoints = BackwardPointsList[0];
            BackwardPointsList.RemoveAt(0);
            byte[] backwardStatus = BackwardStatusList[0];
            BackwardStatusList.RemoveAt(0);

            status = backwardStatus;
            return backwardPoints;
        }

        public void Initialize(Image<Gray, byte> frame)
        {
            return;
        }
    }
}
