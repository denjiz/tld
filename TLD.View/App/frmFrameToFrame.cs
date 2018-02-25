using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using TLD.Model;
using TLD.Model.Integration;

namespace TLD.View
{
    public partial class frmFrameToFrame : Form
    {
        private Image _previousFrame;
        private Image _currentFrame;
        private frmMain _frmMain;

        public frmFrameToFrame(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;

            // get rid of flickering
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, _pnlFrames, new object[] { true });
        }

        public void ShowFrames(Image previousFrame, Image currentFrame)
        {
            _previousFrame = previousFrame;
            _currentFrame = currentFrame;
            RefreshVideoFrames();
        }

        private void RefreshVideoFrames()
        {
            _pnlFrames.Invalidate();
        }

        private void _pnlFrames_Paint(object sender, PaintEventArgs e)
        {
            if (_previousFrame != null && _currentFrame != null)
            {
                e.Graphics.DrawImage(_previousFrame, PreviousFrameLocation);
                e.Graphics.DrawImage(_currentFrame, AdaptPointForCurrentFrame(new Point(0, 0)));

                if (_frmMain.tldRunning)
                {
                    if ((_frmMain.tld as Tld).UseTracker && !Tracker.Failed)
                    {
                        if (_cbxShowPrevOutput.Checked)
                        {
                            DrawingService.DrawBoundingBox(e, Tracker.PrevBoundingBox, TldDrawingInfo.TrackerOutputPen);
                        }
                        if (_cbxShowCurrentOutput.Checked)
                        {
                            DrawingService.DrawBoundingBox(e, CurrentFrameBoundingBox(Tracker.BoundingBox), TldDrawingInfo.TrackerOutputPen);
                        }

                        if (_cbxShowValidShifts.Checked)
                        {
                            foreach (Shift shift in Tracker.ValidShifts)
                            {
                                PointF prev = shift.Previous;
                                PointF forw = AdaptPointForCurrentFrame(shift.Forward);
                                e.Graphics.DrawLine(TldDrawingInfo.TrackerValidShiftPen, prev, forw);
                            }
                        }

                        if (_cbxShowReliableShifts.Checked)
                        {
                            foreach (Shift shift in Tracker.ReliableShifts)
                            {
                                PointF prev = shift.Previous;
                                PointF forw = AdaptPointForCurrentFrame(shift.Forward);
                                e.Graphics.DrawLine(TldDrawingInfo.TrackerReliableShiftPen, prev, forw);
                            }
                        }

                        if (_frmMain._cbxShowGrid.Checked)
                        {
                            DrawingService.DrawPoints(e, Tracker.PrevBoundingBox.GetGridPoints(), TldDrawingInfo.TrackerGridBrush, TldDrawingInfo.TrackerGridPointSize);
                        }

                        if (_frmMain._cbxShowValidTrackingPoints.Checked)
                        {
                            if (Tracker.ValidShifts != null)
                            {
                                PointF[] points = new PointF[Tracker.ValidShifts.Length];
                                for (int i = 0; i < points.Length; i++)
                                {
                                    points[i] = AdaptPointForCurrentFrame(Tracker.ValidShifts[i].Forward);
                                }
                                DrawingService.DrawPoints(e, points, TldDrawingInfo.TrackerValidPointBrush, TldDrawingInfo.TrackerValidPointSize);
                            }
                        }
                        if (_frmMain._cbxShowReliableTrackingPoints.Checked)
                        {
                            if (Tracker.ReliableShifts != null)
                            {
                                PointF[] points = new PointF[Tracker.ReliableShifts.Length];
                                for (int i = 0; i < points.Length; i++)
                                {
                                    points[i] = AdaptPointForCurrentFrame(Tracker.ReliableShifts[i].Forward);
                                }
                                DrawingService.DrawPoints(e, points, TldDrawingInfo.TrackerReliablePointBrush, TldDrawingInfo.TrackerReliablePointSize);
                            }
                        }
                    }
                }
            }
        }

        public MedianFlowTracker Tracker { get { return _frmMain.tld.Tracker as MedianFlowTracker; } }

        private IBoundingBox CurrentFrameBoundingBox(IBoundingBox bb)
        {
            return bb.CreateInstance(
                AdaptPointForCurrentFrame(bb.Center),
                bb.Size
            );
        }

        private PointF AdaptPointForCurrentFrame(PointF point)
        {
            return new PointF(point.X + _previousFrame.Width, point.Y + 120);
        }

        public Point PreviousFrameLocation
        {
            get { return new Point(0, 0); }
        }

        private void _cbxShowValidShifts_CheckedChanged(object sender, EventArgs e)
        {
            RefreshVideoFrames();
        }

        private void _cbxShowReliableShifts_CheckedChanged(object sender, EventArgs e)
        {
            RefreshVideoFrames();
        }

        private void _cbxShowCurrentOutput_CheckedChanged(object sender, EventArgs e)
        {
            RefreshVideoFrames();
        }

        private void _cbxShowPrevOutput_CheckedChanged(object sender, EventArgs e)
        {
            RefreshVideoFrames();
        }
    }
}
