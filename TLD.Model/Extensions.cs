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

namespace TLD.Model
{
    public static class Extensions
    {
        public static float DistanceTo(this PointF p1, PointF p2)
        {
            return (float)Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        public static PointF Multiply(this PointF point, float factorX, float factorY)
        {
            return new PointF(point.X * factorX, point.Y * factorY);
        }

        public static SizeF Multiply(this SizeF size, float factorX, float factorY)
        {
            return new SizeF(size.Width * factorX, size.Height * factorY);
        }

        public static PointF Divide(this PointF point, float factorX, float factorY)
        {
            return new PointF(point.X / factorX, point.Y / factorY);
        }

        public static SizeF Divide(this SizeF size, float factorX, float factorY)
        {
            return new SizeF(size.Width / factorX, size.Height / factorY);
        }

        public static PointF Add(this PointF me, PointF point)
        {
            return new PointF(me.X + point.X, me.Y + point.Y);
        }

        public static SizeF Add(this SizeF me, SizeF other)
        {
            return new SizeF(me.Width + other.Width, me.Height + other.Height);
        }

        public static Image<Gray, byte> GetPatch(this Image<Gray, byte> image, PointF center, Size size)
        {
            Image<Gray, byte> patch = new Image<Gray, byte>(size);
            CvInvoke.cvGetRectSubPix(image, patch, center);
            return patch;
        }

        public static bool IsEqualTo(this Image<Gray, byte> image, Image<Gray, byte> other)
        {
            if (image.Width != other.Width || image.Height != other.Height)
            {
                return false;
            }

            Image<Gray, byte> difference = image - other;
            return difference.CountNonzero()[0] == 0;
        }
    }
}
