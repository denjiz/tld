using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using TLD.Model;

namespace TLD.View
{
    static class TldSessionPersistor
    {
        private static string _tldOutputSuffix = "TldOutput";

        public static void Save(VideoFile video)
        {
            string videoDir = GetVideoDirectory(video);
            if (!Directory.Exists(videoDir))
            {
                Directory.CreateDirectory(videoDir);
            }

            // delete previous session results if they exist
            string videoSessionDir = GetVideoSessionDirectory(video);
            if (Directory.Exists(videoSessionDir))
            {
                Utils.ClearFolder(videoSessionDir);
            }

            // create new empty session
            Directory.CreateDirectory(videoSessionDir);

            SaveTldOutput(video, videoSessionDir);
            SaveModelUpdates(video, videoSessionDir);
        }

        private static string GetVideoDirectory(VideoFile video)
        {
            string videosDir = Path.GetDirectoryName(video.Path);
            string videoName = Path.GetFileNameWithoutExtension(video.Path);

            string videoDir = Path.Combine(videosDir, videoName);
            return videoDir;
        }

        private static string GetVideoSessionDirectory(VideoFile video)
        {
            string videoDir = GetVideoDirectory(video);
            string videoSessionDir = Path.Combine(videoDir, "session");
            return videoSessionDir;
        }

        public static void TryLoad(VideoFile video)
        {
            try
            {
                TryLoadTldOutput(video);
                TryLoadModelUpdates(video);
            }
            catch (Exception)
            {
            }
        }

        private static void TryLoadTldOutput(VideoFile video)
        {
            string path = GetTldOutputFile(GetVideoSessionDirectory(video));
            string[] lines = File.ReadAllLines(path);

            Dictionary<int, IBoundingBox> outputs = new Dictionary<int, IBoundingBox>();
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

                outputs.Add(frame, bb);
            }

            video.TldOutputs = outputs;
        }

        private static void TryLoadModelUpdates(VideoFile video)
        {
            string videoDir = GetVideoSessionDirectory(video);

            // load positive updates
            string[] lines = File.ReadAllLines(GetPositiveModelUpdatesFile(videoDir));
            Dictionary<int, List<Image<Gray, byte>>> positiveModelUpdates = new Dictionary<int,List<Image<Gray,byte>>>();
            foreach (string line in lines)
            {
                string[] splitted = line.Split();
                int frame = Convert.ToInt32(splitted[0]);

                List<Image<Gray, byte>> patches;
                if (splitted.Length > 1)
                {
                    patches = new List<Image<Gray, byte>>();
                    for (int i = 1; i < splitted.Length; i++)
                    {
                        string patchFilePath = Path.Combine(videoDir, splitted[i]);
                        patches.Add(new Image<Gray, byte>(patchFilePath));
                    }
                }
                else
                {
                    patches = null;
                }

                positiveModelUpdates.Add(frame, patches);
            }
            video.PositiveModelUpdates = positiveModelUpdates;

            // load negative updates
            lines = File.ReadAllLines(GetNegativeModelUpdatesFile(videoDir));
            Dictionary<int, List<Image<Gray, byte>>> negativeModelUpdates = new Dictionary<int, List<Image<Gray, byte>>>();
            foreach (string line in lines)
            {
                string[] splitted = line.Split();
                int frame = Convert.ToInt32(splitted[0]);

                List<Image<Gray, byte>> patches;
                if (splitted.Length > 1)
                {
                    patches = new List<Image<Gray, byte>>();
                    for (int i = 1; i < splitted.Length; i++)
                    {
                        string patchFilePath = Path.Combine(videoDir, splitted[i]);
                        patches.Add(new Image<Gray, byte>(patchFilePath));
                    }
                }
                else
                {
                    patches = null;
                }

                negativeModelUpdates.Add(frame, patches);
            }
            video.NegativeModelUpdates = negativeModelUpdates;
        }

        private static void SaveTldOutput(VideoFile video, string videoDir)
        {
            List<string> lines = new List<string>();

            foreach (KeyValuePair<int, IBoundingBox> pair in video.TldOutputs)
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

            File.WriteAllLines(GetTldOutputFile(videoDir), lines.ToArray());
        }

        private static void SaveModelUpdates(VideoFile video, string videoDir)
        {
            int patchIndex = 0;

            // positive updates
            List<string> lines = new List<string>();
            foreach (KeyValuePair<int, List<Image<Gray, byte>>> pair in video.PositiveModelUpdates)
            {
                int frame = pair.Key;
                List<Image<Gray, byte>> patches = pair.Value;

                string line = frame.ToString();
                if (patches != null)
                {
                    foreach (Image<Gray, byte> patch in patches)
                    {
                        string patchFileName = patchIndex++ + ".jpg";
                        line += " " + patchFileName;
                        patch.Save(Path.Combine(videoDir, patchFileName));
                    }
                }

                lines.Add(line);
            }

            File.WriteAllLines(GetPositiveModelUpdatesFile(videoDir), lines.ToArray());

            // negative updates
            lines.Clear();
            foreach (KeyValuePair<int, List<Image<Gray, byte>>> pair in video.NegativeModelUpdates)
            {
                int frame = pair.Key;
                List<Image<Gray, byte>> patches = pair.Value;

                string line = frame.ToString();
                if (patches != null)
                {
                    foreach (Image<Gray, byte> patch in patches)
                    {
                        string patchFileName = patchIndex++ + ".jpg";
                        line += " " + patchFileName;
                        patch.Save(Path.Combine(videoDir, patchFileName));
                    }
                }

                lines.Add(line);
            }

            File.WriteAllLines(GetNegativeModelUpdatesFile(videoDir), lines.ToArray());
        }

        private static string GetNegativeModelUpdatesFile(string videoDir)
        {
            return Path.Combine(videoDir, "negative_updates.txt");
        }

        private static string GetPositiveModelUpdatesFile(string videoDir)
        {
            return Path.Combine(videoDir, "positive_updates.txt");
        }

        private static string GetTldOutputFile(string videoDir)
        {
            return Path.Combine(videoDir, "output.txt");
        }
    }
}
