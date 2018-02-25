using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TLD.Model;

namespace TLD.View
{
    public class VideoFile
    {
        public VideoFile(string path, Size frameBox)
        {
            Path = path;
            Capture = new Capture(Path);
            GroundTruth = new Dictionary<int, IBoundingBox>();

            // FPS
            NextFrame = FrameCount;

            Length = (float)Capture.GetCaptureProperty(CAP_PROP.CV_CAP_PROP_POS_MSEC);
            FPS = FrameCount / Length * 1000;
            FrameDelay = 1 / FPS * 1000;

            // frame size
            int frameWidth = (int)Capture.GetCaptureProperty(CAP_PROP.CV_CAP_PROP_FRAME_WIDTH);
            int frameHeight = (int)Capture.GetCaptureProperty(CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT);
            FrameSize = new Size(frameWidth, frameHeight);

            float normAspectRatio = 1.0f * frameBox.Width / frameBox.Height;
            float aspectRatio = 1.0f * frameWidth / frameHeight;
            float scale;
            if (aspectRatio > normAspectRatio)
            {
                scale = 1.0f * frameBox.Width / frameWidth;
            }
            else
            {
                scale = 1.0f * frameBox.Height / frameHeight;
            }

            NormalizedSize = new Size((int)(frameWidth * scale), (int)(frameHeight * scale));

            RewindToBeginning();
        }

        public Size FrameSize { get; set; }

        public Size NormalizedSize { get; set; }

        public float Length { get; private set; }

        public float FPS { get; private set; }

        public float FrameDelay { get; private set; }

        public string Path { get; set; }

        public Capture Capture { get; private set; }

        public bool Finished
        {
            get
            {
                if (NextFrame > FrameCount)
                {
                    return true;
                }
                return false;
            }
        }

        public int CurrentFrame 
        {
            get { return NextFrame - 1;}
            set { NextFrame = value + 1; }
        }

        public int NextFrame
        {
            get { return (int)Capture.GetCaptureProperty(CAP_PROP.CV_CAP_PROP_POS_FRAMES); }
            set { Capture.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_POS_FRAMES, value); }
        }

        public int FrameCount 
        {
            get { return (int)Capture.GetCaptureProperty(CAP_PROP.CV_CAP_PROP_FRAME_COUNT); }
        }

        public void Close()
        {
            Capture.Dispose();
        }

        public Dictionary<int, IBoundingBox> TldOutputs { get; set; }
        public Dictionary<int, List<Image<Gray, byte>>> PositiveModelUpdates { get; set; }
        public Dictionary<int, List<Image<Gray, byte>>> NegativeModelUpdates { get; set; }

        public Dictionary<int, IBoundingBox> GroundTruth { get; set; }

        internal void RewindToBeginning()
        {
            Capture.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_POS_FRAMES, 0);
        }

        public void StartNewTldSession(IBoundingBox initBb, List<Image<Gray, byte>> positivePatches, List<Image<Gray, byte>> negativePatches)
        {
            TldOutputs = new Dictionary<int, IBoundingBox>();
            TldOutputs.Add(0, initBb);
            PositiveModelUpdates = new Dictionary<int, List<Image<Gray, byte>>>();
            PositiveModelUpdates.Add(0, positivePatches);
            NegativeModelUpdates = new Dictionary<int, List<Image<Gray, byte>>>();
            NegativeModelUpdates.Add(0, negativePatches);
        }

        public void AddNewSessionInput(int frame, IBoundingBox output, List<Image<Gray, byte>> positivePatches, List<Image<Gray, byte>> negativePatches)
        {
            TldOutputs.Add(frame, output);
            PositiveModelUpdates.Add(frame, positivePatches);
            NegativeModelUpdates.Add(frame, negativePatches);
        }

        public IBoundingBox GetTldOutput(int frame)
        {
            return TldOutputs[frame];
        }

        public bool SessionComplete
        {
            get
            {
                if (TldOutputs != null)
                {
                    if (TldOutputs.Count == FrameCount)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
