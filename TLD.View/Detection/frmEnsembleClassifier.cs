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
    public partial class frmEnsembleClassifier : Form
    {
        private EnsembleClassifier _classifier;

        private frmMain _frmMain;

        public frmEnsembleClassifier(EnsembleClassifier classifier, frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;

            _classifier = classifier;
            FillWithConfiguration();
        }

        public TableLayoutPanel Panel { get { return _tlpMainPanel; } }

        private void FillWithConfiguration()
        {
            DisableOnChangeEvents();

            // gaussian sigma
            Utils.NudSetValueDouble(_nudChangeGaussianSigma, _classifier.Sigma);

            // number of base classifiers
            Utils.NudSetValueInt(_nudChangeNumberOfBaseClassifiers, _classifier.BaseClassifierNumber);
            
            // maximum pixel comparisons per classifier
            Utils.NudSetValueInt(_nudChangeMaxComparisonsPerClassifier, _classifier.MaxComparisonsPerClassifier);

            EnableOnChangedEvents();
        }

        private void DisableOnChangeEvents()
        {
            _nudChangeGaussianSigma.ValueChanged -= _nudChangeGaussianSigma_ValueChanged;
            _nudChangeNumberOfBaseClassifiers.ValueChanged -= _nudChangeNumberOfBaseClassifiersClassifiers_ValueChanged;
            _nudChangeMaxComparisonsPerClassifier.ValueChanged -= _nudChangeMaxComparisonsPerClassifier_ValueChanged;
        }

        private void EnableOnChangedEvents()
        {
            _nudChangeGaussianSigma.ValueChanged += _nudChangeGaussianSigma_ValueChanged;
            _nudChangeNumberOfBaseClassifiers.ValueChanged += _nudChangeNumberOfBaseClassifiersClassifiers_ValueChanged;
            _nudChangeMaxComparisonsPerClassifier.ValueChanged += _nudChangeMaxComparisonsPerClassifier_ValueChanged;
        }

        public void OnTldFindObjectCalled()
        {
            _lblShowAcceptedWindowCount.Text = _classifier.AcceptedPatches.Count.ToString();
        }

        public void Draw(PaintEventArgs e)
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

        private void RefreshVideoFrame()
        {
            _frmMain.RefreshVideoFrame();
        }

        #region user input handing

        private void _cbxShowAcceptedWindows_CheckedChanged(object sender, EventArgs e)
        {
            RefreshVideoFrame();
        }

        private void _nudChangeGaussianSigma_ValueChanged(object sender, EventArgs e)
        {
            _classifier.Sigma = Utils.NudGetValueDouble(_nudChangeGaussianSigma);
        }

        private void _nudChangeNumberOfBaseClassifiersClassifiers_ValueChanged(object sender, EventArgs e)
        {
            _classifier.BaseClassifierNumber = Utils.NudGetValueInt(_nudChangeNumberOfBaseClassifiers);
        }

        private void _nudChangeMaxComparisonsPerClassifier_ValueChanged(object sender, EventArgs e)
        {
            _classifier.MaxComparisonsPerClassifier = Utils.NudGetValueInt(_nudChangeMaxComparisonsPerClassifier);
        }

        private void _btnPixelComparisons_Click(object sender, EventArgs e)
        {
            frmPixelComparisons frm = new frmPixelComparisons(_classifier.PixelComparisonScheduler);
            frm.ShowDialog();
        }

        #endregion
    }
}
