using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TLD.Model.Learning;

namespace TLD.View.Learning
{
    public partial class frmLearner : Form, IFrmSpecificLearner
    {
        private Learner _learner;
        private frmMain _frmMain;
        private frmObjectModel _frmObjectModel;

        public frmLearner(Learner learner, frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;

            _learner = learner;
            FillFormWithConfiguration();
            LoadComponents();
        }

        private void FillFormWithConfiguration()
        {
            DisableOnChangedEvents();

            // same similarity threshold
            Utils.NudSetValueFloat(_nudChangeSameSimilarityThreshold, _learner.SameSimilarityThreshold);

            // valid conservative similarity threshold
            Utils.NudSetValueFloat(_nudChangeConservativeSimilarityThreshold, _learner.ValidConservativeSimilarityThreshold);

            EnableOnChangedEvents();
        }

        private void DisableOnChangedEvents()
        {
            _nudChangeSameSimilarityThreshold.ValueChanged -= _nudChangeSameSimilarityThreshold_ValueChanged;
            _nudChangeConservativeSimilarityThreshold.ValueChanged -= _nudChangeConservativeSimilarityThreshold_ValueChanged;
        }

        private void EnableOnChangedEvents()
        {
            _nudChangeSameSimilarityThreshold.ValueChanged += _nudChangeSameSimilarityThreshold_ValueChanged;
            _nudChangeConservativeSimilarityThreshold.ValueChanged += _nudChangeConservativeSimilarityThreshold_ValueChanged;
        }

        private void LoadComponents()
        {
            // object model
            _frmObjectModel = new frmObjectModel(_learner.ObjectModel, _frmMain);
            _gbxObjectModel.Controls.Clear();
            _gbxObjectModel.Controls.Add(_frmObjectModel.MainPanel);
        }

        #region user input handling

        private void _nudChangeSameSimilarityThreshold_ValueChanged(object sender, EventArgs e)
        {
            _learner.SameSimilarityThreshold = Utils.NudGetValueFloat(_nudChangeSameSimilarityThreshold);
        }

        private void _nudChangeConservativeSimilarityThreshold_ValueChanged(object sender, EventArgs e)
        {
            _learner.ValidConservativeSimilarityThreshold = Utils.NudGetValueFloat(_nudChangeConservativeSimilarityThreshold);
        }

        #endregion

        public void OnTldInitialized()
        {
            _frmObjectModel.OnTldInitialized();
        }

        public void OnTldFindObjectCalled()
        {
            _frmObjectModel.OnTldFindObjectCalled();
        }

        public TableLayoutPanel Panel
        {
            get { return _tlpMainPanel; }
        }

        public frmObjectModel FrmObjectModel { get { return _frmObjectModel; } }
    }
}
