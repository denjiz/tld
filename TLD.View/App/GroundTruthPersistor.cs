using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using TLD.Model;

namespace TLD.View.App
{
    class GroundTruthPersistor
    {
        internal static void Save(VideoFile video)
        {
            List<string> lines = new List<string>();

            foreach (KeyValuePair<int, IBoundingBox> pair in video.GroundTruth)
            {
                int frame = pair.Key;
                IBoundingBox bb = pair.Value;

                string line = frame.ToString();
                if (bb != null)
                {
                    line += " " + bb.Center.X + " " + bb.Center.Y + " " + bb.Size.Width + " " + bb.Size.Height;
                }
                lines.Add(line);
            }

            string videoDir = GetVideoDirectory(video);
            if (!Directory.Exists(videoDir))
            {
                Directory.CreateDirectory(videoDir);
            }
            File.WriteAllLines(GetVideoGroundTruthFilePath(video), lines.ToArray());
        }

        private static string GetVideoDirectory(VideoFile video)
        {
            string videosDir = Path.GetDirectoryName(video.Path);
            string videoName = Path.GetFileNameWithoutExtension(video.Path);

            string videoDir = Path.Combine(videosDir, videoName);
            return videoDir;
        }

        private static string GetVideoGroundTruthFilePath(VideoFile video)
        {
            string path = Path.Combine(GetVideoDirectory(video), "ground truth.txt");
            return path;
        }

        internal static void TryLoad(VideoFile video)
        {
            try
            {
                string path = GetVideoGroundTruthFilePath(video);
                string[] lines = File.ReadAllLines(path);

                Dictionary<int, IBoundingBox> bbs = new Dictionary<int, IBoundingBox>();
                foreach (string line in lines)
                {
                    string[] splitted = line.Split();
                    int frame = Convert.ToInt32(splitted[0]);
                    IBoundingBox bb;

                    if (splitted.Length == 5)
                    {
                        float centerX = Convert.ToSingle(splitted[1]);
                        float centerY = Convert.ToSingle(splitted[2]);
                        float width = Convert.ToSingle(splitted[3]);
                        float height = Convert.ToSingle(splitted[4]);

                        bb = new BoundingBox(new PointF(centerX, centerY), new SizeF(width, height));
                    }
                    else
                    {
                        bb = null;
                    }

                    bbs.Add(frame, bb);
                }

                video.GroundTruth = bbs;
            }
            catch (Exception)
            {
            }
        }
    }
}
