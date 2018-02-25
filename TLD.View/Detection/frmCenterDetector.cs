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
    public partial class frmCenterDetector : Form, IFrmSpecificDetector
    {
        private CenterDetector _detector;

        public frmCenterDetector(CenterDetector detector)
        {
            InitializeComponent();
            _detector = detector;
            FillWithConfiguration();
        }

        private void FillWithConfiguration()
        {
            // center
            Utils.NudSetValueFloat(_nudBoundingBoxWidth, _detector.BbSize.Width);
            Utils.NudSetValueFloat(_nudBoundingBoxHeight, _detector.BbSize.Height);
        }

        #region user input handling

        private void _nudBoundingBoxWidth_ValueChanged(object sender, EventArgs e)
        {
            _detector.BbSize = new SizeF(Utils.NudGetValueFloat(_nudBoundingBoxWidth), _detector.BbSize.Height);
        }

        private void _nudBoundingBoxHeight_ValueChanged(object sender, EventArgs e)
        {
            _detector.BbSize = new SizeF(_detector.BbSize.Width, Utils.NudGetValueFloat(_nudBoundingBoxHeight));
        }

        #endregion

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
        }

        public void TldInitialized()
        {
        }

        public void OnTldFindObjectCalled()
        {
        }

        #endregion
    }
}
