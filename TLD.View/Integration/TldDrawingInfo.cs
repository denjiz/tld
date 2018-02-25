using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TLD.View
{
    static class TldDrawingInfo
    {
        private static GroupBox _trackerGroupBox;
        private static GroupBox _detectorGroupBox;

        public static GroupBox TrackerGroupBox
        {
            get { return TldDrawingInfo._trackerGroupBox; }
            set
            {
                TldDrawingInfo._trackerGroupBox = value;
                TrackerOutputPen = new Pen(_trackerGroupBox.BackColor, 3);
            }
        }

        public static GroupBox DetectorGroupBox
        {
            get { return TldDrawingInfo._detectorGroupBox; }
            set
            {
                TldDrawingInfo._detectorGroupBox = value;
                DetectorOutputPen = new Pen(_detectorGroupBox.BackColor, 3);
            }
        }

        public static Pen DetectorOutputPen { get; set; }
        public static Pen TrackerOutputPen { get; set; }
        public static Brush TrackerGridBrush { get { return Brushes.White; } }
        public static float TrackerGridPointSize { get { return 2; } }
        public static Brush TrackerValidPointBrush { get { return Brushes.Blue; } }
        public static float TrackerValidPointSize { get { return 4; } }
        public static Brush TrackerReliablePointBrush { get { return Brushes.LawnGreen; } }
        public static float TrackerReliablePointSize { get { return 4; } }
        public static Pen TrackerValidShiftPen { get { return new Pen(Color.White, 1); } }
        public static Pen TrackerReliableShiftPen { get { return new Pen(Color.White, 1); } }

        public static Pen GroundTruthPen { get { return new Pen(Color.White, 4); } }
        public static Pen GroundTruthSessionPen { get { return new Pen(Color.White, 1); } }
    }
}
