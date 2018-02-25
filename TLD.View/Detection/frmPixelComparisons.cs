using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TLD.Model.Detection;

namespace TLD.View.Detection
{
    public partial class frmPixelComparisons : Form
    {
        private IPixelComparisonScheduler _scheduler;

        public frmPixelComparisons(IPixelComparisonScheduler scheduler)
        {
            InitializeComponent();

            _scheduler = scheduler;
            VisualizePixelComparisons();
        }

        private void VisualizePixelComparisons()
        {
            _flpPixelComparisons.Controls.Clear();
            foreach (PixelComparisonGroupF comparisonGroup in _scheduler.ScheduledPixelComparisons)
            {
                PictureBox pbx = GenerateComparisonPictureBox(comparisonGroup.Value);
                _flpPixelComparisons.Controls.Add(pbx);
            }
        }

        private PictureBox GenerateComparisonPictureBox(PixelComparisonF[] comparisons)
        {
            // create picture box
            PictureBox pbx = new PictureBox();
            pbx.Width = 100;
            pbx.Height = 100;
            pbx.BackColor = Color.White;

            // draw comparisons
            Image image = new Bitmap(pbx.Width, pbx.Height);
            using (Graphics g = Graphics.FromImage(image))
            {
                DrawComparisons(comparisons, g, image.Width, image.Height);
            }

            // return picture box with image
            pbx.Image = image;
            return pbx;
        }

        private void DrawComparisons(PixelComparisonF[] comparisons, Graphics g, int width, int height)
        {
            int patchWidth = _scheduler.PatchWidth;
            int patchHeight = _scheduler.PatchHeight;
            SizeF pixelSize = new SizeF((float)width / patchWidth, (float)height / patchHeight);
            SizeF halfPixelSize = new SizeF(pixelSize.Width / 2.0f, pixelSize.Height / 2.0f);
            SizeF drawPixelSize = new SizeF(pixelSize.Width * 0.8f, pixelSize.Height * 0.8f);
            SizeF halfDrawPixelSize = new SizeF(drawPixelSize.Width / 2.0f, drawPixelSize.Height / 2.0f);

            // draw pixels
            List<PointF> centers1 = new List<PointF>();
            List<PointF> centers2 = new List<PointF>();
            foreach (PixelComparisonF comparison in comparisons)
            {
                // create pixel representations
                PointF center1 = ScalePoint(comparison.Pixel1, width - pixelSize.Width, height - pixelSize.Height);
                center1 = new PointF(center1.X + halfPixelSize.Width, center1.Y + halfPixelSize.Height);
                centers1.Add(center1);
                Rectangle pixel1 = new Rectangle
                (
                Point.Round(new PointF(center1.X - halfDrawPixelSize.Width, center1.Y - halfDrawPixelSize.Height)),
                Size.Round(drawPixelSize)
                );

                PointF center2 = ScalePoint(comparison.Pixel2, width - pixelSize.Width, height - pixelSize.Height);
                center2 = new PointF(center2.X + halfPixelSize.Width, center2.Y + halfPixelSize.Height);
                centers2.Add(center2);
                Rectangle pixel2 = new Rectangle
                (
                Point.Round(new PointF(center2.X - halfDrawPixelSize.Width, center2.Y - halfDrawPixelSize.Height)),
                Size.Round(drawPixelSize)
                );

                // draw pixels
                g.FillRectangle(Brushes.Black, pixel1);
                g.FillRectangle(Brushes.Black, pixel2);
            }

            // draw connections
            for (int i = 0; i < comparisons.Length; i++)
            {
                g.DrawLine(Pens.Blue, centers1[i], centers2[i]);
            }
        }

        private PointF ScalePoint(PointF point, float width, float height)
        {
            return new PointF(point.X * width, point.Y * height);
        }

        private void _btnGenerateNewPixelComparisons_Click(object sender, EventArgs e)
        {
            _scheduler.SchedulePixelComparisons();
            VisualizePixelComparisons();
        }
    }
}
