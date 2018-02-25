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
    public partial class frmCreateDetector : Form
    {
        internal delegate void DetectorChangedCallback(IFrmSpecificDetector detectorForm, string name, Type type);
        DetectorChangedCallback _callback;

        private List<Type> _types;

        internal frmCreateDetector(DetectorChangedCallback callback)
        {
            InitializeComponent();
            _callback = callback;
            FillDetectorTypeList();
            FillDetectorTypeComboBox();
        }

        private void FillDetectorTypeList()
        {
            _types = new List<Type>()
            {
                typeof(CenterDetector)
            };
        }

        private void FillDetectorTypeComboBox()
        {
            foreach (Type type in _types)
            {
                _cmbxChooseDetectorType.Items.Add(type);
            }
        }

        private void _btnCreate_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                IFrmSpecificDetector detectorForm;
                //if (SelectedType == typeof(CenterDetector))
                {
                    detectorForm = CreateCenterDetectorForm();
                }

                _callback(detectorForm, _tbxWriteDetectorName.Text, SelectedType);
                Close();
            }
        }

        private IFrmSpecificDetector CreateCenterDetectorForm()
        {
            CenterDetector detector = new CenterDetector(new SizeF(100, 70));
            return new frmCenterDetector(detector);
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private Type SelectedType { get { return (Type)_cmbxChooseDetectorType.SelectedItem; } }

        private bool ValidateForm()
        {
            if (_tbxWriteDetectorName.Text == "")
            {
                MessageBox.Show("Detector name can't be empty!");
                return false;
            }

            if (_cmbxChooseDetectorType.SelectedIndex == -1)
            {
                MessageBox.Show("Detector type must be chosen!");
                return false;
            }

            return true;
        }
    }
}
