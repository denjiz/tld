using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TLD.Model;

namespace TLD.View
{
    internal class DrawingService
    {
        public static void DrawBoundingBox(PaintEventArgs e, IBoundingBox bb, Pen pen)
        {
            Rectangle rect = Rectangle.Round(bb.GetRectangle());
            e.Graphics.DrawRectangle(pen, rect);
        }

        public static void DrawPoints(PaintEventArgs e, PointF[] points, Brush brush, float size)
        {
            for (int i = 0; i < points.Length; i++)
            {
                e.Graphics.FillEllipse(brush, points[i].X-size/2, points[i].Y-size/2, size, size);
            }
        }

        public static Control ImageToControl(Image<Gray, byte> image)
        {
            PictureBox control = new PictureBox();
            control.Size = new Size(image.Size.Width, image.Size.Height);
            control.Image = image.ToBitmap();
            return control;
        }
    }
}
