using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TLD.Model;
using TLD.Model.Detection;

namespace TLD.View.Detection
{
    public partial class frmNnClassifier : Form
    {
        private  frmMain _frmMain;
        private NnClassifier _classifier;

        public TableLayoutPanel MainPanel { get { return _tlpMainPanel; } }

        public frmNnClassifier(NnClassifier classifier, frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
            _classifier = classifier;

            FillWithConfiguration();
        }

        private void FillWithConfiguration()
        {
            DisableOnChangedEvents();

            // relative similarity threshold
            Utils.NudSetValueFloat(_nudRelativeSimilarityThreshold, _classifier.RelativeSimilarityThreshold);

            EnableOnChangedEvents();
        }

        private void DisableOnChangedEvents()
        {
            _nudRelativeSimilarityThreshold.ValueChanged -= _nudRelativeSimilarityThreshold_ValueChanged;
        }

        private void EnableOnChangedEvents()
        {
            _nudRelativeSimilarityThreshold.ValueChanged += _nudRelativeSimilarityThreshold_ValueChanged;
        }

        #region user input handling

        private void _cbxShowAcceptedWindows_CheckedChanged(object sender, EventArgs e)
        {
            RefreshVideoFrame();
        }

        private void _nudRelativeSimilarityThreshold_ValueChanged(object sender, EventArgs e)
        {
            _classifier.RelativeSimilarityThreshold = Utils.NudGetValueFloat(_nudRelativeSimilarityThreshold);
        }

        #endregion

        private void RefreshVideoFrame()
        {
            _frmMain.RefreshVideoFrame();
        }

        internal void Draw(PaintEventArgs e)
        {
            if (_cbxShowAcceptedWindows.Checked)
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

        internal void OnTldFindObjectCalled()
        {
            _lblShowAcceptedWindowCount.Text = _classifier.AcceptedPatches.Count.ToString();
        }
    }
}
