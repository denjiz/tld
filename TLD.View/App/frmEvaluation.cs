using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TLD.Model;

namespace TLD.View.App
{
    public partial class frmEvaluation : Form
    {
        public frmEvaluation(VideoFile video)
        {
            InitializeComponent();
            CalculateStatistics(video);
        }

        private void CalculateStatistics(VideoFile video)
        {
            // calculate true/false positives/negatives
            int truePositives = 0;
            int falsePositives = 0;
            int trueNegatives = 0;
            int falseNegatives = 0;
            for (int i = 1; i < video.FrameCount; i++)
            {
                IBoundingBox groundTruth = video.GroundTruth[i];
                IBoundingBox tldOutput = video.TldOutputs[i];

                // object is visible
                if (groundTruth != null)
                {
                    // TLD found the object
                    if (tldOutput != null)
                    {
                        // object that TLD found is very close to ground truth
                        if (tldOutput.GetOverlap(groundTruth) > Utils.NudGetValueFloat(_nudRequiredOverlap))
                        {
                            truePositives++;
                        }
                        else
                        {
                            falsePositives++;
                            falseNegatives++;
                        }
                    }
                    // TLD didn't find the object
                    else
                    {
                        falseNegatives++;
                    }
                }

                // object is not visible
                else
                {
                    // TLD found the object
                    if (tldOutput != null)
                    {
                        falsePositives++;
                    }
                    // TLD didn't find the object
                    else
                    {
                        trueNegatives++;
                    }
                }
            }

            // display true/false positives/negatives
            _lblTruePositives.Text = truePositives.ToString();
            _lblFalsePositives.Text = falsePositives.ToString();
            _lblTrueNegatives.Text = trueNegatives.ToString();
            _lblFalseNegatives.Text = falseNegatives.ToString();

            // calculate precision and recall
            float precision = (float)truePositives / (truePositives + falsePositives);
            float recall = (float)truePositives / (truePositives + falseNegatives);

            // display precision and recall
            _lblPrecision.Text = precision.ToString();
            _lblRecall.Text = recall.ToString();
        }
    }
}
