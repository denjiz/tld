using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TLD.Model.Detection;
using TLD.Model;

namespace TLD.View
{
    public partial class frmVarianceClassifier : Form
    {
        private VarianceClassifier _classifier;
        private frmMain _frmMain;

        public frmVarianceClassifier(VarianceClassifier classifier, frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;

            _classifier = classifier;
            FillFormWithConfiguration();
        }

        private void FillFormWithConfiguration()
        {
            DisableOnChangedEvent();

            // threshold coefficient
            Utils.NudSetValueDouble(_nudChangeThresholdCoefficient, _classifier.ThresholdCoefficient);

            EnableOnChangedEvents();
        }

        private void DisableOnChangedEvent()
        {
            _nudChangeThresholdCoefficient.ValueChanged -= _nudChangeThresholdCoefficient_ValueChanged;
        }

        private void EnableOnChangedEvents()
        {
            _nudChangeThresholdCoefficient.ValueChanged += _nudChangeThresholdCoefficient_ValueChanged;
        }

        public TableLayoutPanel Panel { get { return _tlpMainPanel; } }

        #region user input handling

        private void _cbxShowAcceptedPatches_CheckedChanged(object sender, EventArgs e)
        {
            RefreshVideoFrame();
        }

        private void _nudChangeThresholdCoefficient_ValueChanged(object sender, EventArgs e)
        {
            _classifier.ThresholdCoefficient = Utils.NudGetValueDouble(_nudChangeThresholdCoefficient);
        }

        #endregion

        public void Draw(PaintEventArgs e)
        {
            if (_cbxShowAcceptedPatches.Checked)
            {
                if (_classifier.AcceptedPatches != null)
                {
                    IBoundingBox[] allWindows = _classifier.ScanningWindowGenerator.ScanningWindows;
                    foreach (int windowIndex in _classifier.AcceptedPatches)
                    {
                        IBoundingBox window = allWindows[windowIndex];
                        DrawingService.DrawBoundingBox(e, window, DetectorDrawingInfo.VarianceClassifierPen);
                    }
                }
            }
        }

        public void TldInitialized()
        {

        }

        public void OnTldFindObjectCalled()
        {
            _lblDisplayAcceptedPatchesCount.Text = _classifier.AcceptedPatches.Count.ToString();
        }

        private void RefreshVideoFrame()
        {
            _frmMain.RefreshVideoFrame();
        }
    }
}
