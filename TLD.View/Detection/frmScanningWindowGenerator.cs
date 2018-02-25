using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TLD.Model;

namespace TLD.View
{
    public partial class frmScanningWindowGenerator : Form
    {
        private IScanningWindowGenerator _generator;
        private frmMain _frmMain;

        public TableLayoutPanel Panel { get { return _tlpMainPanel; } }
        private int ScanningWindowsCount { get { return _generator.ScanningWindows.Length; } }

        public frmScanningWindowGenerator(IScanningWindowGenerator generator, frmMain frmMain)
        {
            InitializeComponent();
            _generator = generator;
            _frmMain = frmMain;
            FillWithConfiguration();
        }

        private void FillWithConfiguration()
        {
            DisableOnChangedEvents();

            //      scale step
            Utils.NudSetValueFloat(_nudChangeScaleStep, _generator.ScaleStep);

            //      translation relative step
            Utils.NudSetValueFloat(_nudChangeHorizontalStep, _generator.HorizontalRelativeStep);
            Utils.NudSetValueFloat(_nudChangeVerticalStep, _generator.VerticalRelativeStep);

            //      minimum window size
            Utils.NudSetValueInt(_nudChangeMinimumSize, _generator.MinimumWindowSize);

            EnableOnChangedEvents();
        }

        private void DisableOnChangedEvents()
        {
            _nudChangeScaleStep.ValueChanged -= _nudChangeScaleStep_ValueChanged;
            _nudChangeHorizontalStep.ValueChanged -= _nudChangeHorizontalStep_ValueChanged;
            _nudChangeVerticalStep.ValueChanged -= _nudChangeVerticalStep_ValueChanged;
            _nudChangeMinimumSize.ValueChanged -= _nudChangeMinimumSize_ValueChanged;
        }

        private void EnableOnChangedEvents()
        {
            _nudChangeScaleStep.ValueChanged += _nudChangeScaleStep_ValueChanged;
            _nudChangeHorizontalStep.ValueChanged += _nudChangeHorizontalStep_ValueChanged;
            _nudChangeVerticalStep.ValueChanged += _nudChangeVerticalStep_ValueChanged;
            _nudChangeMinimumSize.ValueChanged += _nudChangeMinimumSize_ValueChanged;
        }

        #region user input handling

        private void _cbxShowScanningWindows_CheckedChanged(object sender, EventArgs e)
        {
            RefreshVideoFrame();
        }

        private void _nudChangeScaleStep_ValueChanged(object sender, EventArgs e)
        {
            _generator.ScaleStep = Utils.NudGetValueFloat(_nudChangeScaleStep);
            UpdateScanningWindowsCount();
            RefreshVideoFrame();
        }

        private void _nudChangeHorizontalStep_ValueChanged(object sender, EventArgs e)
        {
            _generator.HorizontalRelativeStep = Utils.NudGetValueFloat(_nudChangeHorizontalStep);
            UpdateScanningWindowsCount();
            RefreshVideoFrame();
        }

        private void _nudChangeVerticalStep_ValueChanged(object sender, EventArgs e)
        {
            _generator.VerticalRelativeStep = Utils.NudGetValueFloat(_nudChangeVerticalStep);
            UpdateScanningWindowsCount();
            RefreshVideoFrame();
        }

        private void _nudChangeMinimumSize_ValueChanged(object sender, EventArgs e)
        {
            _generator.MinimumWindowSize = Utils.NudGetValueInt(_nudChangeMinimumSize);
            UpdateScanningWindowsCount();
            RefreshVideoFrame();
        }

        #endregion

        private void UpdateScanningWindowsCount()
        {
            if (_generator.ScanningWindows != null)
            {
                _lblDisplayWindowCount.Text = ScanningWindowsCount.ToString();
            }
            else
            {
                _lblDisplayWindowCount.Text = "-";
            }
        }

        internal void TldInitialized()
        {
            UpdateScanningWindowsCount();
        }

        internal void Draw(PaintEventArgs e)
        {
            if (_cbxShowScanningWindows.Checked)
            {
                if (_generator.ScanningWindows != null)
                {
                    foreach (IBoundingBox bb in _generator.ScanningWindows)
                    {
                        DrawingService.DrawBoundingBox(e, bb, DetectorDrawingInfo.ScanningWindowPen);
                    }
                }
            }
        }

        private void RefreshVideoFrame()
        {
            _frmMain.RefreshVideoFrame();
        }
    }
}
