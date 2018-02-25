using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TLD.Model.Detection;
using TLD.View.Detection;

namespace TLD.View
{
    public partial class frmCascadedClassifier : Form
    {
        private CascadedClassifier _classifier;

        private frmMain _frmMain;
        private frmVarianceClassifier _frmVarianceClassifier;
        private frmEnsembleClassifier _frmEnsembleClassifier;
        private frmNnClassifier _frmNnClassifier;

        public frmCascadedClassifier(CascadedClassifier classifier, frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;

            _classifier = classifier;
            LoadComponents();
        }

        private void LoadComponents()
        {
            // variance classifier
            _frmVarianceClassifier = new frmVarianceClassifier(_classifier.VarianceClassifier as VarianceClassifier, _frmMain);
            _gbxVarianceClassifier.Controls.Clear();
            _gbxVarianceClassifier.Controls.Add(_frmVarianceClassifier.Panel);

            // ensemble classifier
            _frmEnsembleClassifier = new frmEnsembleClassifier(_classifier.EnsembleClassifier as EnsembleClassifier, _frmMain);
            _gbxEnsembleClassifier.Controls.Clear();
            _gbxEnsembleClassifier.Controls.Add(_frmEnsembleClassifier.Panel);

            // nn classifier
            _frmNnClassifier = new frmNnClassifier(_classifier.NnClassifier as NnClassifier, _frmMain);
            _gbxNnClassifier.Controls.Clear();
            _gbxNnClassifier.Controls.Add(_frmNnClassifier.MainPanel);
        }

        public void Draw(PaintEventArgs e)
        {
            _frmVarianceClassifier.Draw(e);
            _frmEnsembleClassifier.Draw(e);
            _frmNnClassifier.Draw(e);
        }

        public void OnTldFindObjectCalled()
        {
            _frmVarianceClassifier.OnTldFindObjectCalled();
            _frmEnsembleClassifier.OnTldFindObjectCalled();
            _frmNnClassifier.OnTldFindObjectCalled();
        }

        public TableLayoutPanel Panel { get { return _tlpMainPanel; } }
    }
}
