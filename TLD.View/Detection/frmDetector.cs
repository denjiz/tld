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

namespace TLD.View
{
    public partial class frmDetector : Form, IFrmSpecificDetector
    {
        private Detector _detector;

        private frmMain _frmMain;
        private frmScanningWindowGenerator _frmScanningWindowGenerator;
        private frmCascadedClassifier _frmZdenekCascadedClassifier;

        public frmDetector(Detector detector, frmMain frmMain)
        {
            InitializeComponent();
            _detector = detector;
            _frmMain = frmMain;

            LoadComponents();
        }

        private void LoadComponents()
        {
            // scanning windows generator
            _frmScanningWindowGenerator = new frmScanningWindowGenerator(_detector.ScanningWindowGenerator, _frmMain);
            _gbxScanningWindows.Controls.Clear();
            _gbxScanningWindows.Controls.Add(_frmScanningWindowGenerator.Panel);

            // cascaded classifier
            _frmZdenekCascadedClassifier = new frmCascadedClassifier(_detector.CascadedClassifier as CascadedClassifier, _frmMain);
            _gbxCascadedClassifier.Controls.Clear();
            _gbxCascadedClassifier.Controls.Add(_frmZdenekCascadedClassifier.Panel);
        }

        #region interface implementations

        public TableLayoutPanel Panel
        {
            get { return _tlpMainPanel; }
        }

        public IDetector Detector
        {
            get { return _detector; }
        }

        public void Draw(PaintEventArgs e)
        {
            _frmScanningWindowGenerator.Draw(e);
            _frmZdenekCascadedClassifier.Draw(e);
        }

        public void TldInitialized()
        {
            _frmScanningWindowGenerator.TldInitialized();
        }

        public void OnTldFindObjectCalled()
        {
            _frmZdenekCascadedClassifier.OnTldFindObjectCalled();
        }

        #endregion
    }
}
