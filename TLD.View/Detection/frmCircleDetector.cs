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
    public partial class frmCircleDetector : Form, IFrmSpecificDetector
    {
        private CircleDetector _detector;

        public frmCircleDetector(CircleDetector detector)
        {
            InitializeComponent();
            _detector = detector;
            FillWithConfiguration();
        }

        private void FillWithConfiguration()
        {
            // center
            Utils.NudSetValueFloat(_nudCenterX, _detector.Center.X);
            Utils.NudSetValueFloat(_nudCenterY, _detector.Center.Y);

            // radius
            Utils.NudSetValueFloat(_nudRadius, _detector.Radius);

            // angle per frame
            Utils.NudSetValueFloat(_nudAnglePerFrame, _detector.AnglePerFrame);

            // bb size
            Utils.NudSetValueFloat(_nudBoundingBoxWidth, _detector.BbSize.Width);
            Utils.NudSetValueFloat(_nudBoundingBoxHeight, _detector.BbSize.Height);

            // bb count
            Utils.NudSetValueInt(_nudBoundingBoxCount, _detector.BbCount);

            // bb angle offset
            Utils.NudSetValueFloat(_nudBoundingBoxAngleOffset, _detector.BbAngleOffset);
        }

        #region user input handling

        private void _nudCenterX_ValueChanged(object sender, EventArgs e)
        {
            _detector.Center = new PointF(Utils.NudGetValueFloat(_nudCenterX), _detector.Center.Y);
        }

        private void _nudCenterY_ValueChanged(object sender, EventArgs e)
        {
            _detector.Center = new PointF(_detector.Center.X, Utils.NudGetValueFloat(_nudCenterY));
        }

        private void _nudRadius_ValueChanged(object sender, EventArgs e)
        {
            _detector.Radius = Utils.NudGetValueFloat(_nudRadius);
        }

        private void _nudAnglePerFrame_ValueChanged(object sender, EventArgs e)
        {
            _detector.AnglePerFrame = Utils.NudGetValueFloat(_nudAnglePerFrame);
        }

        private void _nudBoundingBoxWidth_ValueChanged(object sender, EventArgs e)
        {
            _detector.BbSize = new SizeF(Utils.NudGetValueFloat(_nudBoundingBoxWidth), _detector.BbSize.Height);
        }

        private void _nudBoundingBoxHeight_ValueChanged(object sender, EventArgs e)
        {
            _detector.BbSize = new SizeF(_detector.BbSize.Width, Utils.NudGetValueFloat(_nudBoundingBoxHeight));
        }

        private void _nudBoundingBoxCount_ValueChanged(object sender, EventArgs e)
        {
            _detector.BbCount = Utils.NudGetValueInt(_nudBoundingBoxCount);
        }

        private void _nudBoundingBoxAngleOffset_ValueChanged(object sender, EventArgs e)
        {
            _detector.BbAngleOffset = Utils.NudGetValueFloat(_nudBoundingBoxAngleOffset);
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
