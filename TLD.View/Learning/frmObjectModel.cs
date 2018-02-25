using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TLD.Model;

namespace TLD.View.Learning
{
    public partial class frmObjectModel : Form
    {
        private IObjectModel _objectModel;

        private frmMain _frmMain;
       
        public frmObjectModel(IObjectModel objectModel, frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;

            _objectModel = objectModel;
            NewPositivePatches = new List<Image<Gray, byte>>();
            NewNegativePatches = new List<Image<Gray, byte>>();
        }

        public void OnTldInitialized()
        {
            ClearPatches();
            CheckPatches();
        }

        public void OnTldFindObjectCalled()
        {
            NewPositivePatches.Clear();
            NewNegativePatches.Clear();
            CheckPatches();
        }

        private void ClearPatches()
        {
            _flpPositivePatches.Controls.Clear();
            _flpNegativePatches.Controls.Clear();
        }

        private void CheckPatches()
        {
            if (_flpPositivePatches.Controls.Count != _objectModel.PositivePatches.Count)
            {
                UpdatePatches(_flpPositivePatches, _objectModel.PositivePatches);
            }
            if (_flpNegativePatches.Controls.Count != _objectModel.NegativePatches.Count)
            {
                UpdatePatches(_flpNegativePatches, _objectModel.NegativePatches);
            }
        }

        private void UpdatePatches(FlowLayoutPanel panel, List<Image<Gray, byte>> allPatches)
        {
            List<Image<Gray, byte>> patches;
            if (panel == _flpPositivePatches)
            {
                patches = NewPositivePatches;
            }
            else
            {
                patches = NewNegativePatches;
            }

            int startingPatch = panel.Controls.Count;
            for (int i = startingPatch; i < allPatches.Count; i++)
            {
                Control patchControl = DrawingService.ImageToControl(allPatches[i]);
                int margin = 1;
                patchControl.Margin = new Padding(margin, margin, margin, margin);
                panel.Controls.Add(patchControl);
                patches.Add(allPatches[i]);
            }
        }

        public TableLayoutPanel MainPanel { get { return _tlpMainPanel; } }

        public List<Image<Gray, byte>> NewPositivePatches { get; set; }
        public List<Image<Gray, byte>> NewNegativePatches { get; set; }

        public IObjectModel ObjectModel
        {
            get { return _objectModel; }
            set { _objectModel = value; }
        }
    }
}
