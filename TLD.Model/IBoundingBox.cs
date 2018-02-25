using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TLD.Model.Detection;

namespace TLD.Model
{
    public interface IBoundingBox
    {
        /// <summary>
        /// Gets or sets the center of the bounding box.
        /// </summary>
        PointF Center { get; set; }

        /// <summary>
        /// Gets or sets the size of the bounding box.
        /// </summary>
        SizeF Size { get; set; }

        /// <summary>
        /// Gets the overlap with another bounding box.
        /// Overlap is defined as the ratio between the intersection and the union of two bounding boxes.
        /// </summary>
        /// <param name="bb">The other bounding box.</param>
        /// <returns>0 if boxes are not overlapped,
        /// 1 if boxes are totally overlapped,
        /// or a value between 0 and 1 if boxes are partially overlapped.</returns>
        float GetOverlap(IBoundingBox bb);

        /// <summary>
        /// Gets the System.Drawing.RectangleF representation of the bounding box.
        /// </summary>
        /// <returns>A System.Drawing.RectangleF instance.</returns>
        RectangleF GetRectangle();

        /// <summary>
        /// Creates new instance of the bounding box's type.
        /// </summary>
        /// <param name="center">Center of the new bounding box.</param>
        /// <param name="size">Size of the new bounding box.</param>
        /// <returns></returns>
        IBoundingBox CreateInstance(PointF center, SizeF size);

        /// <summary>
        /// Return true if bounding box is entirely inside the frame.
        /// Otherwise returns false.
        /// </summary>
        /// <param name="size">Frame size.</param>
        /// <returns></returns>
        bool InsideFrame(Size size);

        /// <summary>
        /// Gets the scanning window of a bounding box.
        /// Scanning window has all integer values.
        /// </summary>
        ScanningWindow ScanningWindow { get; set; }

        /// <summary>
        /// Create the scanning window of a bounding box.
        /// Scanning window has all integer values.
        /// </summary>
        ScanningWindow CreateScanningWindow();
    }
}
