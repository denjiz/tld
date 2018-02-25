namespace TLD.View
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._tldForm = new System.Windows.Forms.TableLayoutPanel();
            this._tlpVideo = new System.Windows.Forms.TableLayoutPanel();
            this._pnlVideo = new System.Windows.Forms.Panel();
            this._tlpVideoControls = new System.Windows.Forms.TableLayoutPanel();
            this._flpVideoFps = new System.Windows.Forms.FlowLayoutPanel();
            this.label18 = new System.Windows.Forms.Label();
            this._nudFrameWidth = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this._nudFrameHeight = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this._lblVideoFps = new System.Windows.Forms.Label();
            this._flpFrameSize = new System.Windows.Forms.FlowLayoutPanel();
            this.label21 = new System.Windows.Forms.Label();
            this._cbxVideoMode = new System.Windows.Forms.ComboBox();
            this._gbxVideoFileProperties = new System.Windows.Forms.GroupBox();
            this._tlpVideoFileProperties = new System.Windows.Forms.TableLayoutPanel();
            this._gbxTldSession = new System.Windows.Forms.GroupBox();
            this._flpTldSession = new System.Windows.Forms.FlowLayoutPanel();
            this._btnStartNewTldSessionUsingGTInit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this._btnSaveTldSession = new System.Windows.Forms.Button();
            this._btnLoadTldSession = new System.Windows.Forms.Button();
            this._btnEvaluateTldSession = new System.Windows.Forms.Button();
            this._flpVideoFilePath = new System.Windows.Forms.FlowLayoutPanel();
            this.label22 = new System.Windows.Forms.Label();
            this._tbxVideoFilePath = new System.Windows.Forms.TextBox();
            this._btnOpenVideoFile = new System.Windows.Forms.Button();
            this._flpVideoFileMisc = new System.Windows.Forms.FlowLayoutPanel();
            this._cbxVideoRealTime = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this._lblVideoFrame = new System.Windows.Forms.Label();
            this._gbxGroundTruthMode = new System.Windows.Forms.GroupBox();
            this._flpGroundTruthMode = new System.Windows.Forms.FlowLayoutPanel();
            this._btnEnterGroundTruthMode = new System.Windows.Forms.Button();
            this._btnExitGroundTruthMode = new System.Windows.Forms.Button();
            this._btnClearGroundTruthSession = new System.Windows.Forms.Button();
            this._btnSaveGroundTruth = new System.Windows.Forms.Button();
            this._btnLoadGroundTruth = new System.Windows.Forms.Button();
            this._cbxDrawGroundTruth = new System.Windows.Forms.CheckBox();
            this._flpVideoPlayback = new System.Windows.Forms.FlowLayoutPanel();
            this._btnStartPauseVideo = new System.Windows.Forms.Button();
            this._btnStopVideo = new System.Windows.Forms.Button();
            this._btnNextFrame = new System.Windows.Forms.Button();
            this._gbxTld = new System.Windows.Forms.GroupBox();
            this._tlpTld = new System.Windows.Forms.TableLayoutPanel();
            this._gbxDetection = new System.Windows.Forms.GroupBox();
            this._tlpDetection = new System.Windows.Forms.TableLayoutPanel();
            this._gbxDetectionGeneral = new System.Windows.Forms.GroupBox();
            this._tlpDetectionGeneral = new System.Windows.Forms.TableLayoutPanel();
            this._cbxShowDetectorObjects = new System.Windows.Forms.CheckBox();
            this._tlpChooseSpecificDetector = new System.Windows.Forms.TableLayoutPanel();
            this.label16 = new System.Windows.Forms.Label();
            this._cmbxChooseSpecificDetector = new System.Windows.Forms.ComboBox();
            this._cbxUseDetector = new System.Windows.Forms.CheckBox();
            this._gbxDetectionSpecific = new System.Windows.Forms.GroupBox();
            this._gbxTldGeneral = new System.Windows.Forms.GroupBox();
            this._tlpTldGeneral = new System.Windows.Forms.TableLayoutPanel();
            this._tlpTldTime = new System.Windows.Forms.TableLayoutPanel();
            this._lblTldAverageTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this._lblTldTime = new System.Windows.Forms.Label();
            this._tlpTldConfigGeneral = new System.Windows.Forms.TableLayoutPanel();
            this._cbxShowTldOutput = new System.Windows.Forms.CheckBox();
            this._gbxTracking = new System.Windows.Forms.GroupBox();
            this._tlpTracking = new System.Windows.Forms.TableLayoutPanel();
            this._gbxTrackingGeneral = new System.Windows.Forms.GroupBox();
            this._tlpTrackingGeneral = new System.Windows.Forms.TableLayoutPanel();
            this._cbxEnableTrackerFailure = new System.Windows.Forms.CheckBox();
            this._cbxShowTrackerObject = new System.Windows.Forms.CheckBox();
            this._cbxUseTracker = new System.Windows.Forms.CheckBox();
            this._gbxTrackingSpecific = new System.Windows.Forms.GroupBox();
            this._tlpTrackingSpecific = new System.Windows.Forms.TableLayoutPanel();
            this._flpNccMedian = new System.Windows.Forms.FlowLayoutPanel();
            this.label15 = new System.Windows.Forms.Label();
            this._lblNccMedian = new System.Windows.Forms.Label();
            this._tlpMadTreshold = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this._nudMadTreshold = new System.Windows.Forms.NumericUpDown();
            this._tlpNccPatchSize = new System.Windows.Forms.TableLayoutPanel();
            this._nudNccPatchHeight = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this._nudNccPatchWidth = new System.Windows.Forms.NumericUpDown();
            this._gbxBoundingBox = new System.Windows.Forms.GroupBox();
            this._tlpTrackerBoundingBox = new System.Windows.Forms.TableLayoutPanel();
            this._cbxShowGrid = new System.Windows.Forms.CheckBox();
            this._tlpGridPadding = new System.Windows.Forms.TableLayoutPanel();
            this._nudGridPaddingHeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._nudGridPaddingWidth = new System.Windows.Forms.NumericUpDown();
            this._tlpGridSize = new System.Windows.Forms.TableLayoutPanel();
            this._nudGridHeight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._nudGridWidth = new System.Windows.Forms.NumericUpDown();
            this._gbxLucasKanade = new System.Windows.Forms.GroupBox();
            this._tlpLucasKanade = new System.Windows.Forms.TableLayoutPanel();
            this._tlpLkWindowSize = new System.Windows.Forms.TableLayoutPanel();
            this._nudLkWindowHeight = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this._nudLkWindowWidth = new System.Windows.Forms.NumericUpDown();
            this._tlpLkLevels = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this._nudLkLevels = new System.Windows.Forms.NumericUpDown();
            this._gbxLkTermCriteria = new System.Windows.Forms.GroupBox();
            this._tlpLkTermCriteria = new System.Windows.Forms.TableLayoutPanel();
            this._tlpLkMaxIterations = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this._nudLkMaxIterations = new System.Windows.Forms.NumericUpDown();
            this._tlpLkEpsilon = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this._nudLkEpsilon = new System.Windows.Forms.NumericUpDown();
            this._cbxShowValidTrackingPoints = new System.Windows.Forms.CheckBox();
            this._cbxShowReliableTrackingPoints = new System.Windows.Forms.CheckBox();
            this._flpFbErrorMedian = new System.Windows.Forms.FlowLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this._lblFbErrorMedian = new System.Windows.Forms.Label();
            this._gbxLearning = new System.Windows.Forms.GroupBox();
            this._tlpLearning = new System.Windows.Forms.TableLayoutPanel();
            this._gbxLearningSpecific = new System.Windows.Forms.GroupBox();
            this._gbxLearningGeneral = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._cbxUseLearner = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frametoframeViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nCCCalculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._tldForm.SuspendLayout();
            this._tlpVideo.SuspendLayout();
            this._tlpVideoControls.SuspendLayout();
            this._flpVideoFps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudFrameWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudFrameHeight)).BeginInit();
            this._flpFrameSize.SuspendLayout();
            this._gbxVideoFileProperties.SuspendLayout();
            this._tlpVideoFileProperties.SuspendLayout();
            this._gbxTldSession.SuspendLayout();
            this._flpTldSession.SuspendLayout();
            this._flpVideoFilePath.SuspendLayout();
            this._flpVideoFileMisc.SuspendLayout();
            this._gbxGroundTruthMode.SuspendLayout();
            this._flpGroundTruthMode.SuspendLayout();
            this._flpVideoPlayback.SuspendLayout();
            this._gbxTld.SuspendLayout();
            this._tlpTld.SuspendLayout();
            this._gbxDetection.SuspendLayout();
            this._tlpDetection.SuspendLayout();
            this._gbxDetectionGeneral.SuspendLayout();
            this._tlpDetectionGeneral.SuspendLayout();
            this._tlpChooseSpecificDetector.SuspendLayout();
            this._gbxTldGeneral.SuspendLayout();
            this._tlpTldGeneral.SuspendLayout();
            this._tlpTldTime.SuspendLayout();
            this._tlpTldConfigGeneral.SuspendLayout();
            this._gbxTracking.SuspendLayout();
            this._tlpTracking.SuspendLayout();
            this._gbxTrackingGeneral.SuspendLayout();
            this._tlpTrackingGeneral.SuspendLayout();
            this._gbxTrackingSpecific.SuspendLayout();
            this._tlpTrackingSpecific.SuspendLayout();
            this._flpNccMedian.SuspendLayout();
            this._tlpMadTreshold.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudMadTreshold)).BeginInit();
            this._tlpNccPatchSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudNccPatchHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudNccPatchWidth)).BeginInit();
            this._gbxBoundingBox.SuspendLayout();
            this._tlpTrackerBoundingBox.SuspendLayout();
            this._tlpGridPadding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudGridPaddingHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudGridPaddingWidth)).BeginInit();
            this._tlpGridSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudGridHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudGridWidth)).BeginInit();
            this._gbxLucasKanade.SuspendLayout();
            this._tlpLucasKanade.SuspendLayout();
            this._tlpLkWindowSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudLkWindowHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudLkWindowWidth)).BeginInit();
            this._tlpLkLevels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudLkLevels)).BeginInit();
            this._gbxLkTermCriteria.SuspendLayout();
            this._tlpLkTermCriteria.SuspendLayout();
            this._tlpLkMaxIterations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudLkMaxIterations)).BeginInit();
            this._tlpLkEpsilon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudLkEpsilon)).BeginInit();
            this._flpFbErrorMedian.SuspendLayout();
            this._gbxLearning.SuspendLayout();
            this._tlpLearning.SuspendLayout();
            this._gbxLearningGeneral.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tldForm
            // 
            this._tldForm.ColumnCount = 2;
            this._tldForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.1664F));
            this._tldForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.8336F));
            this._tldForm.Controls.Add(this._tlpVideo, 0, 0);
            this._tldForm.Controls.Add(this._gbxTld, 1, 0);
            this._tldForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tldForm.Location = new System.Drawing.Point(0, 28);
            this._tldForm.Name = "_tldForm";
            this._tldForm.RowCount = 1;
            this._tldForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tldForm.Size = new System.Drawing.Size(1358, 636);
            this._tldForm.TabIndex = 3;
            // 
            // _tlpVideo
            // 
            this._tlpVideo.ColumnCount = 1;
            this._tlpVideo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpVideo.Controls.Add(this._pnlVideo, 0, 0);
            this._tlpVideo.Controls.Add(this._tlpVideoControls, 0, 1);
            this._tlpVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpVideo.Location = new System.Drawing.Point(3, 3);
            this._tlpVideo.Name = "_tlpVideo";
            this._tlpVideo.RowCount = 2;
            this._tlpVideo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this._tlpVideo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this._tlpVideo.Size = new System.Drawing.Size(607, 630);
            this._tlpVideo.TabIndex = 2;
            // 
            // _pnlVideo
            // 
            this._pnlVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlVideo.Location = new System.Drawing.Point(3, 3);
            this._pnlVideo.Name = "_pnlVideo";
            this._pnlVideo.Size = new System.Drawing.Size(601, 372);
            this._pnlVideo.TabIndex = 2;
            this._pnlVideo.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxCapture_Paint);
            this._pnlVideo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxCapture_MouseDown);
            this._pnlVideo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbxCapture_MouseMove);
            this._pnlVideo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbxCapture_MouseUp);
            // 
            // _tlpVideoControls
            // 
            this._tlpVideoControls.ColumnCount = 1;
            this._tlpVideoControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpVideoControls.Controls.Add(this._flpVideoFps, 0, 1);
            this._tlpVideoControls.Controls.Add(this._flpFrameSize, 0, 2);
            this._tlpVideoControls.Controls.Add(this._gbxVideoFileProperties, 0, 3);
            this._tlpVideoControls.Controls.Add(this._flpVideoPlayback, 0, 0);
            this._tlpVideoControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpVideoControls.Location = new System.Drawing.Point(3, 381);
            this._tlpVideoControls.Name = "_tlpVideoControls";
            this._tlpVideoControls.RowCount = 4;
            this._tlpVideoControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this._tlpVideoControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._tlpVideoControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._tlpVideoControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this._tlpVideoControls.Size = new System.Drawing.Size(601, 246);
            this._tlpVideoControls.TabIndex = 1;
            // 
            // _flpVideoFps
            // 
            this._flpVideoFps.Controls.Add(this.label18);
            this._flpVideoFps.Controls.Add(this._nudFrameWidth);
            this._flpVideoFps.Controls.Add(this.label20);
            this._flpVideoFps.Controls.Add(this._nudFrameHeight);
            this._flpVideoFps.Controls.Add(this.label17);
            this._flpVideoFps.Controls.Add(this._lblVideoFps);
            this._flpVideoFps.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flpVideoFps.Location = new System.Drawing.Point(0, 36);
            this._flpVideoFps.Margin = new System.Windows.Forms.Padding(0);
            this._flpVideoFps.Name = "_flpVideoFps";
            this._flpVideoFps.Size = new System.Drawing.Size(601, 24);
            this._flpVideoFps.TabIndex = 3;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(83, 17);
            this.label18.TabIndex = 2;
            this.label18.Text = "Frame Size:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _nudFrameWidth
            // 
            this._nudFrameWidth.Location = new System.Drawing.Point(92, 3);
            this._nudFrameWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this._nudFrameWidth.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this._nudFrameWidth.Name = "_nudFrameWidth";
            this._nudFrameWidth.Size = new System.Drawing.Size(66, 22);
            this._nudFrameWidth.TabIndex = 3;
            this._nudFrameWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._nudFrameWidth.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this._nudFrameWidth.ValueChanged += new System.EventHandler(this._nudFrameWidth_ValueChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(164, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(14, 17);
            this.label20.TabIndex = 5;
            this.label20.Text = "x";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _nudFrameHeight
            // 
            this._nudFrameHeight.Location = new System.Drawing.Point(184, 3);
            this._nudFrameHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this._nudFrameHeight.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this._nudFrameHeight.Name = "_nudFrameHeight";
            this._nudFrameHeight.Size = new System.Drawing.Size(66, 22);
            this._nudFrameHeight.TabIndex = 4;
            this._nudFrameHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._nudFrameHeight.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this._nudFrameHeight.ValueChanged += new System.EventHandler(this._nudFrameHeight_ValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(256, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 17);
            this.label17.TabIndex = 0;
            this.label17.Text = "FPS :";
            // 
            // _lblVideoFps
            // 
            this._lblVideoFps.AutoSize = true;
            this._lblVideoFps.Location = new System.Drawing.Point(304, 0);
            this._lblVideoFps.Name = "_lblVideoFps";
            this._lblVideoFps.Size = new System.Drawing.Size(13, 17);
            this._lblVideoFps.TabIndex = 1;
            this._lblVideoFps.Text = "-";
            // 
            // _flpFrameSize
            // 
            this._flpFrameSize.Controls.Add(this.label21);
            this._flpFrameSize.Controls.Add(this._cbxVideoMode);
            this._flpFrameSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flpFrameSize.Location = new System.Drawing.Point(0, 60);
            this._flpFrameSize.Margin = new System.Windows.Forms.Padding(0);
            this._flpFrameSize.Name = "_flpFrameSize";
            this._flpFrameSize.Size = new System.Drawing.Size(601, 24);
            this._flpFrameSize.TabIndex = 4;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(87, 17);
            this.label21.TabIndex = 1;
            this.label21.Text = "Video Mode:";
            // 
            // _cbxVideoMode
            // 
            this._cbxVideoMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbxVideoMode.FormattingEnabled = true;
            this._cbxVideoMode.Location = new System.Drawing.Point(96, 3);
            this._cbxVideoMode.Name = "_cbxVideoMode";
            this._cbxVideoMode.Size = new System.Drawing.Size(121, 24);
            this._cbxVideoMode.TabIndex = 0;
            this._cbxVideoMode.SelectedIndexChanged += new System.EventHandler(this._cbxVideoMode_SelectedIndexChanged);
            // 
            // _gbxVideoFileProperties
            // 
            this._gbxVideoFileProperties.Controls.Add(this._tlpVideoFileProperties);
            this._gbxVideoFileProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gbxVideoFileProperties.Location = new System.Drawing.Point(3, 87);
            this._gbxVideoFileProperties.Name = "_gbxVideoFileProperties";
            this._gbxVideoFileProperties.Size = new System.Drawing.Size(595, 156);
            this._gbxVideoFileProperties.TabIndex = 5;
            this._gbxVideoFileProperties.TabStop = false;
            this._gbxVideoFileProperties.Text = "Video File Settings";
            // 
            // _tlpVideoFileProperties
            // 
            this._tlpVideoFileProperties.ColumnCount = 1;
            this._tlpVideoFileProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpVideoFileProperties.Controls.Add(this._gbxTldSession, 0, 2);
            this._tlpVideoFileProperties.Controls.Add(this._flpVideoFilePath, 0, 0);
            this._tlpVideoFileProperties.Controls.Add(this._flpVideoFileMisc, 0, 3);
            this._tlpVideoFileProperties.Controls.Add(this._gbxGroundTruthMode, 0, 1);
            this._tlpVideoFileProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpVideoFileProperties.Location = new System.Drawing.Point(3, 18);
            this._tlpVideoFileProperties.Name = "_tlpVideoFileProperties";
            this._tlpVideoFileProperties.RowCount = 4;
            this._tlpVideoFileProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this._tlpVideoFileProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._tlpVideoFileProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._tlpVideoFileProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this._tlpVideoFileProperties.Size = new System.Drawing.Size(589, 135);
            this._tlpVideoFileProperties.TabIndex = 0;
            // 
            // _gbxTldSession
            // 
            this._gbxTldSession.Controls.Add(this._flpTldSession);
            this._gbxTldSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gbxTldSession.Location = new System.Drawing.Point(3, 78);
            this._gbxTldSession.Name = "_gbxTldSession";
            this._gbxTldSession.Size = new System.Drawing.Size(583, 39);
            this._gbxTldSession.TabIndex = 6;
            this._gbxTldSession.TabStop = false;
            this._gbxTldSession.Text = "TLD Session";
            // 
            // _flpTldSession
            // 
            this._flpTldSession.Controls.Add(this._btnStartNewTldSessionUsingGTInit);
            this._flpTldSession.Controls.Add(this.button1);
            this._flpTldSession.Controls.Add(this._btnSaveTldSession);
            this._flpTldSession.Controls.Add(this._btnLoadTldSession);
            this._flpTldSession.Controls.Add(this._btnEvaluateTldSession);
            this._flpTldSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flpTldSession.Location = new System.Drawing.Point(3, 18);
            this._flpTldSession.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this._flpTldSession.Name = "_flpTldSession";
            this._flpTldSession.Size = new System.Drawing.Size(577, 18);
            this._flpTldSession.TabIndex = 3;
            // 
            // _btnStartNewTldSessionUsingGTInit
            // 
            this._btnStartNewTldSessionUsingGTInit.Location = new System.Drawing.Point(3, 3);
            this._btnStartNewTldSessionUsingGTInit.Name = "_btnStartNewTldSessionUsingGTInit";
            this._btnStartNewTldSessionUsingGTInit.Size = new System.Drawing.Size(75, 27);
            this._btnStartNewTldSessionUsingGTInit.TabIndex = 5;
            this._btnStartNewTldSessionUsingGTInit.Text = "Start new";
            this._btnStartNewTldSessionUsingGTInit.UseVisualStyleBackColor = true;
            this._btnStartNewTldSessionUsingGTInit.Click += new System.EventHandler(this._btnStartNewTldSessionUsingGTInit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(84, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "Replay";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this._btnReplayTldSession_Click);
            // 
            // _btnSaveTldSession
            // 
            this._btnSaveTldSession.Location = new System.Drawing.Point(165, 3);
            this._btnSaveTldSession.Name = "_btnSaveTldSession";
            this._btnSaveTldSession.Size = new System.Drawing.Size(75, 27);
            this._btnSaveTldSession.TabIndex = 3;
            this._btnSaveTldSession.Text = "Save";
            this._btnSaveTldSession.UseVisualStyleBackColor = true;
            this._btnSaveTldSession.Click += new System.EventHandler(this._btnSaveTldSession_Click);
            // 
            // _btnLoadTldSession
            // 
            this._btnLoadTldSession.Location = new System.Drawing.Point(246, 3);
            this._btnLoadTldSession.Name = "_btnLoadTldSession";
            this._btnLoadTldSession.Size = new System.Drawing.Size(75, 27);
            this._btnLoadTldSession.TabIndex = 4;
            this._btnLoadTldSession.Text = "Load";
            this._btnLoadTldSession.UseVisualStyleBackColor = true;
            this._btnLoadTldSession.Click += new System.EventHandler(this._btnLoadTldSession_Click);
            // 
            // _btnEvaluateTldSession
            // 
            this._btnEvaluateTldSession.Location = new System.Drawing.Point(327, 3);
            this._btnEvaluateTldSession.Name = "_btnEvaluateTldSession";
            this._btnEvaluateTldSession.Size = new System.Drawing.Size(93, 27);
            this._btnEvaluateTldSession.TabIndex = 6;
            this._btnEvaluateTldSession.Text = "Evaluate...";
            this._btnEvaluateTldSession.UseVisualStyleBackColor = true;
            this._btnEvaluateTldSession.Click += new System.EventHandler(this._btnEvaluateTldSession_Click);
            // 
            // _flpVideoFilePath
            // 
            this._flpVideoFilePath.Controls.Add(this.label22);
            this._flpVideoFilePath.Controls.Add(this._tbxVideoFilePath);
            this._flpVideoFilePath.Controls.Add(this._btnOpenVideoFile);
            this._flpVideoFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flpVideoFilePath.Location = new System.Drawing.Point(0, 0);
            this._flpVideoFilePath.Margin = new System.Windows.Forms.Padding(0);
            this._flpVideoFilePath.Name = "_flpVideoFilePath";
            this._flpVideoFilePath.Size = new System.Drawing.Size(589, 30);
            this._flpVideoFilePath.TabIndex = 1;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 8);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 17);
            this.label22.TabIndex = 0;
            this.label22.Text = "Path:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _tbxVideoFilePath
            // 
            this._tbxVideoFilePath.Location = new System.Drawing.Point(50, 3);
            this._tbxVideoFilePath.Name = "_tbxVideoFilePath";
            this._tbxVideoFilePath.Size = new System.Drawing.Size(376, 22);
            this._tbxVideoFilePath.TabIndex = 1;
            // 
            // _btnOpenVideoFile
            // 
            this._btnOpenVideoFile.Location = new System.Drawing.Point(432, 3);
            this._btnOpenVideoFile.Name = "_btnOpenVideoFile";
            this._btnOpenVideoFile.Size = new System.Drawing.Size(90, 27);
            this._btnOpenVideoFile.TabIndex = 2;
            this._btnOpenVideoFile.Text = "Open...";
            this._btnOpenVideoFile.UseVisualStyleBackColor = true;
            this._btnOpenVideoFile.Click += new System.EventHandler(this._btnOpenVideoFile_Click);
            // 
            // _flpVideoFileMisc
            // 
            this._flpVideoFileMisc.Controls.Add(this._cbxVideoRealTime);
            this._flpVideoFileMisc.Controls.Add(this.label23);
            this._flpVideoFileMisc.Controls.Add(this._lblVideoFrame);
            this._flpVideoFileMisc.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flpVideoFileMisc.Location = new System.Drawing.Point(0, 120);
            this._flpVideoFileMisc.Margin = new System.Windows.Forms.Padding(0);
            this._flpVideoFileMisc.Name = "_flpVideoFileMisc";
            this._flpVideoFileMisc.Size = new System.Drawing.Size(589, 15);
            this._flpVideoFileMisc.TabIndex = 4;
            // 
            // _cbxVideoRealTime
            // 
            this._cbxVideoRealTime.AutoSize = true;
            this._cbxVideoRealTime.Checked = true;
            this._cbxVideoRealTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this._cbxVideoRealTime.Location = new System.Drawing.Point(3, 3);
            this._cbxVideoRealTime.Name = "_cbxVideoRealTime";
            this._cbxVideoRealTime.Size = new System.Drawing.Size(90, 21);
            this._cbxVideoRealTime.TabIndex = 0;
            this._cbxVideoRealTime.Text = "Real-time";
            this._cbxVideoRealTime.UseVisualStyleBackColor = true;
            this._cbxVideoRealTime.CheckedChanged += new System.EventHandler(this._cbxVideoRealTime_CheckedChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(106, 3);
            this.label23.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(52, 17);
            this.label23.TabIndex = 1;
            this.label23.Text = "Frame:";
            // 
            // _lblVideoFrame
            // 
            this._lblVideoFrame.AutoSize = true;
            this._lblVideoFrame.Location = new System.Drawing.Point(164, 3);
            this._lblVideoFrame.Margin = new System.Windows.Forms.Padding(3);
            this._lblVideoFrame.Name = "_lblVideoFrame";
            this._lblVideoFrame.Size = new System.Drawing.Size(13, 17);
            this._lblVideoFrame.TabIndex = 2;
            this._lblVideoFrame.Text = "-";
            // 
            // _gbxGroundTruthMode
            // 
            this._gbxGroundTruthMode.Controls.Add(this._flpGroundTruthMode);
            this._gbxGroundTruthMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gbxGroundTruthMode.Location = new System.Drawing.Point(3, 30);
            this._gbxGroundTruthMode.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this._gbxGroundTruthMode.Name = "_gbxGroundTruthMode";
            this._gbxGroundTruthMode.Size = new System.Drawing.Size(583, 45);
            this._gbxGroundTruthMode.TabIndex = 5;
            this._gbxGroundTruthMode.TabStop = false;
            this._gbxGroundTruthMode.Text = "Ground Truth Mode";
            // 
            // _flpGroundTruthMode
            // 
            this._flpGroundTruthMode.Controls.Add(this._btnEnterGroundTruthMode);
            this._flpGroundTruthMode.Controls.Add(this._btnExitGroundTruthMode);
            this._flpGroundTruthMode.Controls.Add(this._btnClearGroundTruthSession);
            this._flpGroundTruthMode.Controls.Add(this._btnSaveGroundTruth);
            this._flpGroundTruthMode.Controls.Add(this._btnLoadGroundTruth);
            this._flpGroundTruthMode.Controls.Add(this._cbxDrawGroundTruth);
            this._flpGroundTruthMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flpGroundTruthMode.Location = new System.Drawing.Point(3, 18);
            this._flpGroundTruthMode.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this._flpGroundTruthMode.Name = "_flpGroundTruthMode";
            this._flpGroundTruthMode.Size = new System.Drawing.Size(577, 24);
            this._flpGroundTruthMode.TabIndex = 5;
            // 
            // _btnEnterGroundTruthMode
            // 
            this._btnEnterGroundTruthMode.Location = new System.Drawing.Point(3, 3);
            this._btnEnterGroundTruthMode.Name = "_btnEnterGroundTruthMode";
            this._btnEnterGroundTruthMode.Size = new System.Drawing.Size(75, 26);
            this._btnEnterGroundTruthMode.TabIndex = 0;
            this._btnEnterGroundTruthMode.Text = "Enter";
            this._btnEnterGroundTruthMode.UseVisualStyleBackColor = true;
            this._btnEnterGroundTruthMode.Click += new System.EventHandler(this._btnEnterGroundTruthMode_Click);
            // 
            // _btnExitGroundTruthMode
            // 
            this._btnExitGroundTruthMode.Location = new System.Drawing.Point(84, 3);
            this._btnExitGroundTruthMode.Name = "_btnExitGroundTruthMode";
            this._btnExitGroundTruthMode.Size = new System.Drawing.Size(75, 26);
            this._btnExitGroundTruthMode.TabIndex = 1;
            this._btnExitGroundTruthMode.Text = "Exit";
            this._btnExitGroundTruthMode.UseVisualStyleBackColor = true;
            this._btnExitGroundTruthMode.Click += new System.EventHandler(this._btnExitGroundTruthMode_Click);
            // 
            // _btnClearGroundTruthSession
            // 
            this._btnClearGroundTruthSession.Location = new System.Drawing.Point(165, 3);
            this._btnClearGroundTruthSession.Name = "_btnClearGroundTruthSession";
            this._btnClearGroundTruthSession.Size = new System.Drawing.Size(75, 26);
            this._btnClearGroundTruthSession.TabIndex = 5;
            this._btnClearGroundTruthSession.Text = "Clear";
            this._btnClearGroundTruthSession.UseVisualStyleBackColor = true;
            this._btnClearGroundTruthSession.Click += new System.EventHandler(this._btnClearGroundTruthSession_Click);
            // 
            // _btnSaveGroundTruth
            // 
            this._btnSaveGroundTruth.Location = new System.Drawing.Point(246, 3);
            this._btnSaveGroundTruth.Name = "_btnSaveGroundTruth";
            this._btnSaveGroundTruth.Size = new System.Drawing.Size(75, 26);
            this._btnSaveGroundTruth.TabIndex = 2;
            this._btnSaveGroundTruth.Text = "Save";
            this._btnSaveGroundTruth.UseVisualStyleBackColor = true;
            this._btnSaveGroundTruth.Click += new System.EventHandler(this._btnSaveGroundTruth_Click);
            // 
            // _btnLoadGroundTruth
            // 
            this._btnLoadGroundTruth.Location = new System.Drawing.Point(327, 3);
            this._btnLoadGroundTruth.Name = "_btnLoadGroundTruth";
            this._btnLoadGroundTruth.Size = new System.Drawing.Size(75, 26);
            this._btnLoadGroundTruth.TabIndex = 3;
            this._btnLoadGroundTruth.Text = "Load";
            this._btnLoadGroundTruth.UseVisualStyleBackColor = true;
            this._btnLoadGroundTruth.Click += new System.EventHandler(this._btnLoadGroundTruth_Click);
            // 
            // _cbxDrawGroundTruth
            // 
            this._cbxDrawGroundTruth.AutoSize = true;
            this._cbxDrawGroundTruth.Location = new System.Drawing.Point(408, 3);
            this._cbxDrawGroundTruth.Name = "_cbxDrawGroundTruth";
            this._cbxDrawGroundTruth.Size = new System.Drawing.Size(62, 21);
            this._cbxDrawGroundTruth.TabIndex = 4;
            this._cbxDrawGroundTruth.Text = "Draw";
            this._cbxDrawGroundTruth.UseVisualStyleBackColor = true;
            this._cbxDrawGroundTruth.CheckedChanged += new System.EventHandler(this._cbxDrawGroundTruth_CheckedChanged);
            // 
            // _flpVideoPlayback
            // 
            this._flpVideoPlayback.Controls.Add(this._btnStartPauseVideo);
            this._flpVideoPlayback.Controls.Add(this._btnStopVideo);
            this._flpVideoPlayback.Controls.Add(this._btnNextFrame);
            this._flpVideoPlayback.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flpVideoPlayback.Location = new System.Drawing.Point(0, 0);
            this._flpVideoPlayback.Margin = new System.Windows.Forms.Padding(0);
            this._flpVideoPlayback.Name = "_flpVideoPlayback";
            this._flpVideoPlayback.Size = new System.Drawing.Size(601, 36);
            this._flpVideoPlayback.TabIndex = 6;
            // 
            // _btnStartPauseVideo
            // 
            this._btnStartPauseVideo.Location = new System.Drawing.Point(3, 3);
            this._btnStartPauseVideo.Name = "_btnStartPauseVideo";
            this._btnStartPauseVideo.Size = new System.Drawing.Size(108, 30);
            this._btnStartPauseVideo.TabIndex = 2;
            this._btnStartPauseVideo.Text = "Start";
            this._btnStartPauseVideo.UseVisualStyleBackColor = true;
            this._btnStartPauseVideo.Click += new System.EventHandler(this._btnStartPause_Click);
            // 
            // _btnStopVideo
            // 
            this._btnStopVideo.Location = new System.Drawing.Point(117, 3);
            this._btnStopVideo.Name = "_btnStopVideo";
            this._btnStopVideo.Size = new System.Drawing.Size(108, 30);
            this._btnStopVideo.TabIndex = 3;
            this._btnStopVideo.Text = "Stop";
            this._btnStopVideo.UseVisualStyleBackColor = true;
            this._btnStopVideo.Click += new System.EventHandler(this._btnStopVideo_Click);
            // 
            // _btnNextFrame
            // 
            this._btnNextFrame.Location = new System.Drawing.Point(231, 3);
            this._btnNextFrame.Name = "_btnNextFrame";
            this._btnNextFrame.Size = new System.Drawing.Size(108, 30);
            this._btnNextFrame.TabIndex = 5;
            this._btnNextFrame.Text = "Next Frame";
            this._btnNextFrame.UseVisualStyleBackColor = true;
            this._btnNextFrame.Click += new System.EventHandler(this._btnNextFrame_Click);
            // 
            // _gbxTld
            // 
            this._gbxTld.Controls.Add(this._tlpTld);
            this._gbxTld.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gbxTld.Location = new System.Drawing.Point(616, 3);
            this._gbxTld.Name = "_gbxTld";
            this._gbxTld.Size = new System.Drawing.Size(739, 630);
            this._gbxTld.TabIndex = 3;
            this._gbxTld.TabStop = false;
            this._gbxTld.Text = "TLD";
            // 
            // _tlpTld
            // 
            this._tlpTld.ColumnCount = 3;
            this._tlpTld.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._tlpTld.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._tlpTld.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._tlpTld.Controls.Add(this._gbxDetection, 2, 1);
            this._tlpTld.Controls.Add(this._gbxTldGeneral, 0, 0);
            this._tlpTld.Controls.Add(this._gbxTracking, 0, 1);
            this._tlpTld.Controls.Add(this._gbxLearning, 1, 1);
            this._tlpTld.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpTld.Location = new System.Drawing.Point(3, 18);
            this._tlpTld.Name = "_tlpTld";
            this._tlpTld.RowCount = 2;
            this._tlpTld.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._tlpTld.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this._tlpTld.Size = new System.Drawing.Size(733, 609);
            this._tlpTld.TabIndex = 0;
            // 
            // _gbxDetection
            // 
            this._gbxDetection.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this._gbxDetection.Controls.Add(this._tlpDetection);
            this._gbxDetection.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gbxDetection.Location = new System.Drawing.Point(491, 63);
            this._gbxDetection.Name = "_gbxDetection";
            this._gbxDetection.Size = new System.Drawing.Size(239, 543);
            this._gbxDetection.TabIndex = 0;
            this._gbxDetection.TabStop = false;
            this._gbxDetection.Text = "Detection";
            // 
            // _tlpDetection
            // 
            this._tlpDetection.ColumnCount = 1;
            this._tlpDetection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpDetection.Controls.Add(this._gbxDetectionGeneral, 0, 0);
            this._tlpDetection.Controls.Add(this._gbxDetectionSpecific, 0, 1);
            this._tlpDetection.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpDetection.Location = new System.Drawing.Point(3, 18);
            this._tlpDetection.Name = "_tlpDetection";
            this._tlpDetection.RowCount = 2;
            this._tlpDetection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.15385F));
            this._tlpDetection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.84615F));
            this._tlpDetection.Size = new System.Drawing.Size(233, 522);
            this._tlpDetection.TabIndex = 0;
            // 
            // _gbxDetectionGeneral
            // 
            this._gbxDetectionGeneral.Controls.Add(this._tlpDetectionGeneral);
            this._gbxDetectionGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gbxDetectionGeneral.Location = new System.Drawing.Point(3, 3);
            this._gbxDetectionGeneral.Name = "_gbxDetectionGeneral";
            this._gbxDetectionGeneral.Size = new System.Drawing.Size(227, 52);
            this._gbxDetectionGeneral.TabIndex = 0;
            this._gbxDetectionGeneral.TabStop = false;
            this._gbxDetectionGeneral.Text = "General";
            // 
            // _tlpDetectionGeneral
            // 
            this._tlpDetectionGeneral.ColumnCount = 1;
            this._tlpDetectionGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpDetectionGeneral.Controls.Add(this._cbxShowDetectorObjects, 0, 2);
            this._tlpDetectionGeneral.Controls.Add(this._tlpChooseSpecificDetector, 0, 0);
            this._tlpDetectionGeneral.Controls.Add(this._cbxUseDetector, 0, 1);
            this._tlpDetectionGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpDetectionGeneral.Location = new System.Drawing.Point(3, 18);
            this._tlpDetectionGeneral.Name = "_tlpDetectionGeneral";
            this._tlpDetectionGeneral.RowCount = 3;
            this._tlpDetectionGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this._tlpDetectionGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpDetectionGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpDetectionGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._tlpDetectionGeneral.Size = new System.Drawing.Size(221, 31);
            this._tlpDetectionGeneral.TabIndex = 0;
            // 
            // _cbxShowDetectorObjects
            // 
            this._cbxShowDetectorObjects.AutoSize = true;
            this._cbxShowDetectorObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cbxShowDetectorObjects.Location = new System.Drawing.Point(3, 18);
            this._cbxShowDetectorObjects.Name = "_cbxShowDetectorObjects";
            this._cbxShowDetectorObjects.Size = new System.Drawing.Size(215, 10);
            this._cbxShowDetectorObjects.TabIndex = 5;
            this._cbxShowDetectorObjects.Text = "Show Objects";
            this._cbxShowDetectorObjects.UseVisualStyleBackColor = true;
            this._cbxShowDetectorObjects.CheckedChanged += new System.EventHandler(this._cbxShowDetectorObjects_CheckedChanged);
            // 
            // _tlpChooseSpecificDetector
            // 
            this._tlpChooseSpecificDetector.ColumnCount = 2;
            this._tlpChooseSpecificDetector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.47208F));
            this._tlpChooseSpecificDetector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.52792F));
            this._tlpChooseSpecificDetector.Controls.Add(this.label16, 0, 0);
            this._tlpChooseSpecificDetector.Controls.Add(this._cmbxChooseSpecificDetector, 1, 0);
            this._tlpChooseSpecificDetector.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpChooseSpecificDetector.Location = new System.Drawing.Point(3, 3);
            this._tlpChooseSpecificDetector.Name = "_tlpChooseSpecificDetector";
            this._tlpChooseSpecificDetector.RowCount = 1;
            this._tlpChooseSpecificDetector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpChooseSpecificDetector.Size = new System.Drawing.Size(215, 1);
            this._tlpChooseSpecificDetector.TabIndex = 6;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(61, 1);
            this.label16.TabIndex = 0;
            this.label16.Text = "Detector";
            // 
            // _cmbxChooseSpecificDetector
            // 
            this._cmbxChooseSpecificDetector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._cmbxChooseSpecificDetector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbxChooseSpecificDetector.FormattingEnabled = true;
            this._cmbxChooseSpecificDetector.Items.AddRange(new object[] {
            "New detector..."});
            this._cmbxChooseSpecificDetector.Location = new System.Drawing.Point(70, 3);
            this._cmbxChooseSpecificDetector.Name = "_cmbxChooseSpecificDetector";
            this._cmbxChooseSpecificDetector.Size = new System.Drawing.Size(142, 24);
            this._cmbxChooseSpecificDetector.TabIndex = 1;
            this._cmbxChooseSpecificDetector.SelectedIndexChanged += new System.EventHandler(this._cmbxChooseSpecificDetector_SelectedIndexChanged);
            // 
            // _cbxUseDetector
            // 
            this._cbxUseDetector.AutoSize = true;
            this._cbxUseDetector.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cbxUseDetector.Location = new System.Drawing.Point(3, 3);
            this._cbxUseDetector.Name = "_cbxUseDetector";
            this._cbxUseDetector.Size = new System.Drawing.Size(215, 9);
            this._cbxUseDetector.TabIndex = 7;
            this._cbxUseDetector.Text = "Use";
            this._cbxUseDetector.UseVisualStyleBackColor = true;
            this._cbxUseDetector.CheckedChanged += new System.EventHandler(this._cbxUseDetector_CheckedChanged);
            // 
            // _gbxDetectionSpecific
            // 
            this._gbxDetectionSpecific.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gbxDetectionSpecific.Location = new System.Drawing.Point(3, 61);
            this._gbxDetectionSpecific.Name = "_gbxDetectionSpecific";
            this._gbxDetectionSpecific.Size = new System.Drawing.Size(227, 458);
            this._gbxDetectionSpecific.TabIndex = 1;
            this._gbxDetectionSpecific.TabStop = false;
            this._gbxDetectionSpecific.Text = "Specific";
            // 
            // _gbxTldGeneral
            // 
            this._tlpTld.SetColumnSpan(this._gbxTldGeneral, 3);
            this._gbxTldGeneral.Controls.Add(this._tlpTldGeneral);
            this._gbxTldGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gbxTldGeneral.Location = new System.Drawing.Point(3, 3);
            this._gbxTldGeneral.Name = "_gbxTldGeneral";
            this._gbxTldGeneral.Size = new System.Drawing.Size(727, 54);
            this._gbxTldGeneral.TabIndex = 0;
            this._gbxTldGeneral.TabStop = false;
            this._gbxTldGeneral.Text = "General";
            // 
            // _tlpTldGeneral
            // 
            this._tlpTldGeneral.ColumnCount = 1;
            this._tlpTldGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpTldGeneral.Controls.Add(this._tlpTldTime, 0, 0);
            this._tlpTldGeneral.Controls.Add(this._tlpTldConfigGeneral, 0, 1);
            this._tlpTldGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpTldGeneral.Location = new System.Drawing.Point(3, 18);
            this._tlpTldGeneral.Margin = new System.Windows.Forms.Padding(0);
            this._tlpTldGeneral.Name = "_tlpTldGeneral";
            this._tlpTldGeneral.RowCount = 2;
            this._tlpTldGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpTldGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpTldGeneral.Size = new System.Drawing.Size(721, 33);
            this._tlpTldGeneral.TabIndex = 0;
            // 
            // _tlpTldTime
            // 
            this._tlpTldTime.ColumnCount = 5;
            this._tlpTldTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._tlpTldTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._tlpTldTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._tlpTldTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._tlpTldTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpTldTime.Controls.Add(this._lblTldAverageTime, 3, 0);
            this._tlpTldTime.Controls.Add(this.label5, 0, 0);
            this._tlpTldTime.Controls.Add(this.label19, 2, 0);
            this._tlpTldTime.Controls.Add(this._lblTldTime, 1, 0);
            this._tlpTldTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpTldTime.Location = new System.Drawing.Point(0, 0);
            this._tlpTldTime.Margin = new System.Windows.Forms.Padding(0);
            this._tlpTldTime.Name = "_tlpTldTime";
            this._tlpTldTime.RowCount = 1;
            this._tlpTldTime.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpTldTime.Size = new System.Drawing.Size(721, 16);
            this._tlpTldTime.TabIndex = 0;
            // 
            // _lblTldAverageTime
            // 
            this._lblTldAverageTime.AutoSize = true;
            this._lblTldAverageTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblTldAverageTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._lblTldAverageTime.Location = new System.Drawing.Point(291, 0);
            this._lblTldAverageTime.Name = "_lblTldAverageTime";
            this._lblTldAverageTime.Size = new System.Drawing.Size(66, 16);
            this._lblTldAverageTime.TabIndex = 3;
            this._lblTldAverageTime.Text = "-";
            this._lblTldAverageTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Time:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.Location = new System.Drawing.Point(147, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(138, 16);
            this.label19.TabIndex = 2;
            this.label19.Text = "Average Time: ";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _lblTldTime
            // 
            this._lblTldTime.AutoSize = true;
            this._lblTldTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblTldTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._lblTldTime.Location = new System.Drawing.Point(75, 0);
            this._lblTldTime.Name = "_lblTldTime";
            this._lblTldTime.Size = new System.Drawing.Size(66, 16);
            this._lblTldTime.TabIndex = 1;
            this._lblTldTime.Text = "-";
            this._lblTldTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _tlpTldConfigGeneral
            // 
            this._tlpTldConfigGeneral.ColumnCount = 2;
            this._tlpTldConfigGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._tlpTldConfigGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this._tlpTldConfigGeneral.Controls.Add(this._cbxShowTldOutput, 0, 0);
            this._tlpTldConfigGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpTldConfigGeneral.Location = new System.Drawing.Point(0, 16);
            this._tlpTldConfigGeneral.Margin = new System.Windows.Forms.Padding(0);
            this._tlpTldConfigGeneral.Name = "_tlpTldConfigGeneral";
            this._tlpTldConfigGeneral.RowCount = 1;
            this._tlpTldConfigGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpTldConfigGeneral.Size = new System.Drawing.Size(721, 17);
            this._tlpTldConfigGeneral.TabIndex = 1;
            // 
            // _cbxShowTldOutput
            // 
            this._cbxShowTldOutput.AutoSize = true;
            this._cbxShowTldOutput.Checked = true;
            this._cbxShowTldOutput.CheckState = System.Windows.Forms.CheckState.Checked;
            this._cbxShowTldOutput.Location = new System.Drawing.Point(3, 3);
            this._cbxShowTldOutput.Name = "_cbxShowTldOutput";
            this._cbxShowTldOutput.Size = new System.Drawing.Size(111, 11);
            this._cbxShowTldOutput.TabIndex = 0;
            this._cbxShowTldOutput.Text = "Show Output";
            this._cbxShowTldOutput.UseVisualStyleBackColor = true;
            this._cbxShowTldOutput.CheckedChanged += new System.EventHandler(this._cbxShowTldOutput_CheckedChanged);
            // 
            // _gbxTracking
            // 
            this._gbxTracking.BackColor = System.Drawing.Color.LightGreen;
            this._gbxTracking.Controls.Add(this._tlpTracking);
            this._gbxTracking.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gbxTracking.ForeColor = System.Drawing.SystemColors.ControlText;
            this._gbxTracking.Location = new System.Drawing.Point(3, 63);
            this._gbxTracking.Name = "_gbxTracking";
            this._gbxTracking.Size = new System.Drawing.Size(238, 543);
            this._gbxTracking.TabIndex = 1;
            this._gbxTracking.TabStop = false;
            this._gbxTracking.Text = "Tracking";
            // 
            // _tlpTracking
            // 
            this._tlpTracking.ColumnCount = 1;
            this._tlpTracking.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpTracking.Controls.Add(this._gbxTrackingGeneral, 0, 0);
            this._tlpTracking.Controls.Add(this._gbxTrackingSpecific, 0, 1);
            this._tlpTracking.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpTracking.Location = new System.Drawing.Point(3, 18);
            this._tlpTracking.Name = "_tlpTracking";
            this._tlpTracking.RowCount = 2;
            this._tlpTracking.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.96154F));
            this._tlpTracking.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.03846F));
            this._tlpTracking.Size = new System.Drawing.Size(232, 522);
            this._tlpTracking.TabIndex = 0;
            // 
            // _gbxTrackingGeneral
            // 
            this._gbxTrackingGeneral.Controls.Add(this._tlpTrackingGeneral);
            this._gbxTrackingGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gbxTrackingGeneral.Location = new System.Drawing.Point(3, 3);
            this._gbxTrackingGeneral.Name = "_gbxTrackingGeneral";
            this._gbxTrackingGeneral.Size = new System.Drawing.Size(226, 77);
            this._gbxTrackingGeneral.TabIndex = 0;
            this._gbxTrackingGeneral.TabStop = false;
            this._gbxTrackingGeneral.Text = "General";
            // 
            // _tlpTrackingGeneral
            // 
            this._tlpTrackingGeneral.ColumnCount = 1;
            this._tlpTrackingGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpTrackingGeneral.Controls.Add(this._cbxEnableTrackerFailure, 0, 2);
            this._tlpTrackingGeneral.Controls.Add(this._cbxShowTrackerObject, 0, 1);
            this._tlpTrackingGeneral.Controls.Add(this._cbxUseTracker, 0, 0);
            this._tlpTrackingGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpTrackingGeneral.Location = new System.Drawing.Point(3, 18);
            this._tlpTrackingGeneral.Name = "_tlpTrackingGeneral";
            this._tlpTrackingGeneral.RowCount = 3;
            this._tlpTrackingGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._tlpTrackingGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._tlpTrackingGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._tlpTrackingGeneral.Size = new System.Drawing.Size(220, 56);
            this._tlpTrackingGeneral.TabIndex = 0;
            // 
            // _cbxEnableTrackerFailure
            // 
            this._cbxEnableTrackerFailure.AutoSize = true;
            this._cbxEnableTrackerFailure.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cbxEnableTrackerFailure.Location = new System.Drawing.Point(3, 39);
            this._cbxEnableTrackerFailure.Name = "_cbxEnableTrackerFailure";
            this._cbxEnableTrackerFailure.Size = new System.Drawing.Size(214, 14);
            this._cbxEnableTrackerFailure.TabIndex = 6;
            this._cbxEnableTrackerFailure.Text = "Enable Failure";
            this._cbxEnableTrackerFailure.UseVisualStyleBackColor = true;
            this._cbxEnableTrackerFailure.CheckedChanged += new System.EventHandler(this._cbxEnableTrackerFailure_CheckedChanged);
            // 
            // _cbxShowTrackerObject
            // 
            this._cbxShowTrackerObject.AutoSize = true;
            this._cbxShowTrackerObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cbxShowTrackerObject.Location = new System.Drawing.Point(3, 21);
            this._cbxShowTrackerObject.Name = "_cbxShowTrackerObject";
            this._cbxShowTrackerObject.Size = new System.Drawing.Size(214, 12);
            this._cbxShowTrackerObject.TabIndex = 4;
            this._cbxShowTrackerObject.Text = "Show Object";
            this._cbxShowTrackerObject.UseVisualStyleBackColor = true;
            this._cbxShowTrackerObject.CheckedChanged += new System.EventHandler(this._cbxShowTrackerObject_CheckedChanged);
            // 
            // _cbxUseTracker
            // 
            this._cbxUseTracker.AutoSize = true;
            this._cbxUseTracker.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cbxUseTracker.Location = new System.Drawing.Point(3, 3);
            this._cbxUseTracker.Name = "_cbxUseTracker";
            this._cbxUseTracker.Size = new System.Drawing.Size(214, 12);
            this._cbxUseTracker.TabIndex = 5;
            this._cbxUseTracker.Text = "Use";
            this._cbxUseTracker.UseVisualStyleBackColor = true;
            this._cbxUseTracker.CheckedChanged += new System.EventHandler(this._cbxUseTracker_CheckedChanged);
            // 
            // _gbxTrackingSpecific
            // 
            this._gbxTrackingSpecific.Controls.Add(this._tlpTrackingSpecific);
            this._gbxTrackingSpecific.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gbxTrackingSpecific.Location = new System.Drawing.Point(3, 86);
            this._gbxTrackingSpecific.Name = "_gbxTrackingSpecific";
            this._gbxTrackingSpecific.Size = new System.Drawing.Size(226, 433);
            this._gbxTrackingSpecific.TabIndex = 1;
            this._gbxTrackingSpecific.TabStop = false;
            this._gbxTrackingSpecific.Text = "Specific";
            // 
            // _tlpTrackingSpecific
            // 
            this._tlpTrackingSpecific.ColumnCount = 1;
            this._tlpTrackingSpecific.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpTrackingSpecific.Controls.Add(this._flpNccMedian, 0, 7);
            this._tlpTrackingSpecific.Controls.Add(this._tlpMadTreshold, 0, 3);
            this._tlpTrackingSpecific.Controls.Add(this._tlpNccPatchSize, 0, 2);
            this._tlpTrackingSpecific.Controls.Add(this._gbxBoundingBox, 0, 0);
            this._tlpTrackingSpecific.Controls.Add(this._gbxLucasKanade, 0, 1);
            this._tlpTrackingSpecific.Controls.Add(this._cbxShowValidTrackingPoints, 0, 4);
            this._tlpTrackingSpecific.Controls.Add(this._cbxShowReliableTrackingPoints, 0, 5);
            this._tlpTrackingSpecific.Controls.Add(this._flpFbErrorMedian, 0, 6);
            this._tlpTrackingSpecific.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpTrackingSpecific.Location = new System.Drawing.Point(3, 18);
            this._tlpTrackingSpecific.Name = "_tlpTrackingSpecific";
            this._tlpTrackingSpecific.RowCount = 8;
            this._tlpTrackingSpecific.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.60097F));
            this._tlpTrackingSpecific.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.11922F));
            this._tlpTrackingSpecific.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.417041F));
            this._tlpTrackingSpecific.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.605381F));
            this._tlpTrackingSpecific.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this._tlpTrackingSpecific.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this._tlpTrackingSpecific.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this._tlpTrackingSpecific.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this._tlpTrackingSpecific.Size = new System.Drawing.Size(220, 412);
            this._tlpTrackingSpecific.TabIndex = 0;
            // 
            // _flpNccMedian
            // 
            this._flpNccMedian.Controls.Add(this.label15);
            this._flpNccMedian.Controls.Add(this._lblNccMedian);
            this._flpNccMedian.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flpNccMedian.Location = new System.Drawing.Point(3, 390);
            this._flpNccMedian.Name = "_flpNccMedian";
            this._flpNccMedian.Size = new System.Drawing.Size(214, 19);
            this._flpNccMedian.TabIndex = 10;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Left;
            this.label15.Location = new System.Drawing.Point(3, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(90, 17);
            this.label15.TabIndex = 0;
            this.label15.Text = "NCC Median:";
            // 
            // _lblNccMedian
            // 
            this._lblNccMedian.AutoSize = true;
            this._lblNccMedian.Dock = System.Windows.Forms.DockStyle.Left;
            this._lblNccMedian.Location = new System.Drawing.Point(99, 0);
            this._lblNccMedian.Name = "_lblNccMedian";
            this._lblNccMedian.Size = new System.Drawing.Size(13, 17);
            this._lblNccMedian.TabIndex = 1;
            this._lblNccMedian.Text = "-";
            // 
            // _tlpMadTreshold
            // 
            this._tlpMadTreshold.ColumnCount = 3;
            this._tlpMadTreshold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this._tlpMadTreshold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpMadTreshold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._tlpMadTreshold.Controls.Add(this.label13, 0, 0);
            this._tlpMadTreshold.Controls.Add(this._nudMadTreshold, 1, 0);
            this._tlpMadTreshold.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpMadTreshold.Location = new System.Drawing.Point(3, 307);
            this._tlpMadTreshold.Name = "_tlpMadTreshold";
            this._tlpMadTreshold.RowCount = 1;
            this._tlpMadTreshold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpMadTreshold.Size = new System.Drawing.Size(214, 17);
            this._tlpMadTreshold.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(3, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(122, 17);
            this.label13.TabIndex = 1;
            this.label13.Text = "MAD Treshold";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _nudMadTreshold
            // 
            this._nudMadTreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._nudMadTreshold.DecimalPlaces = 2;
            this._nudMadTreshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this._nudMadTreshold.Location = new System.Drawing.Point(131, 3);
            this._nudMadTreshold.Name = "_nudMadTreshold";
            this._nudMadTreshold.Size = new System.Drawing.Size(58, 22);
            this._nudMadTreshold.TabIndex = 3;
            this._nudMadTreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._nudMadTreshold.ValueChanged += new System.EventHandler(this._nudMadTreshold_ValueChanged);
            // 
            // _tlpNccPatchSize
            // 
            this._tlpNccPatchSize.ColumnCount = 4;
            this._tlpNccPatchSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpNccPatchSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpNccPatchSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._tlpNccPatchSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpNccPatchSize.Controls.Add(this._nudNccPatchHeight, 3, 0);
            this._tlpNccPatchSize.Controls.Add(this.label11, 0, 0);
            this._tlpNccPatchSize.Controls.Add(this.label12, 2, 0);
            this._tlpNccPatchSize.Controls.Add(this._nudNccPatchWidth, 1, 0);
            this._tlpNccPatchSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpNccPatchSize.Location = new System.Drawing.Point(3, 269);
            this._tlpNccPatchSize.Name = "_tlpNccPatchSize";
            this._tlpNccPatchSize.RowCount = 1;
            this._tlpNccPatchSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpNccPatchSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this._tlpNccPatchSize.Size = new System.Drawing.Size(214, 32);
            this._tlpNccPatchSize.TabIndex = 4;
            // 
            // _nudNccPatchHeight
            // 
            this._nudNccPatchHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._nudNccPatchHeight.Location = new System.Drawing.Point(152, 5);
            this._nudNccPatchHeight.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this._nudNccPatchHeight.Name = "_nudNccPatchHeight";
            this._nudNccPatchHeight.Size = new System.Drawing.Size(59, 22);
            this._nudNccPatchHeight.TabIndex = 4;
            this._nudNccPatchHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._nudNccPatchHeight.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this._nudNccPatchHeight.ValueChanged += new System.EventHandler(this._nudNccPatchHeight_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 32);
            this.label11.TabIndex = 1;
            this.label11.Text = "NCC Patch Size";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(131, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 32);
            this.label12.TabIndex = 2;
            this.label12.Text = "x";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _nudNccPatchWidth
            // 
            this._nudNccPatchWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._nudNccPatchWidth.Location = new System.Drawing.Point(67, 5);
            this._nudNccPatchWidth.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this._nudNccPatchWidth.Name = "_nudNccPatchWidth";
            this._nudNccPatchWidth.Size = new System.Drawing.Size(58, 22);
            this._nudNccPatchWidth.TabIndex = 3;
            this._nudNccPatchWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._nudNccPatchWidth.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this._nudNccPatchWidth.ValueChanged += new System.EventHandler(this._nudNccPatchWidth_ValueChanged);
            // 
            // _gbxBoundingBox
            // 
            this._gbxBoundingBox.Controls.Add(this._tlpTrackerBoundingBox);
            this._gbxBoundingBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gbxBoundingBox.Location = new System.Drawing.Point(3, 3);
            this._gbxBoundingBox.Name = "_gbxBoundingBox";
            this._gbxBoundingBox.Size = new System.Drawing.Size(214, 91);
            this._gbxBoundingBox.TabIndex = 0;
            this._gbxBoundingBox.TabStop = false;
            this._gbxBoundingBox.Text = "Bounding Box";
            // 
            // _tlpTrackerBoundingBox
            // 
            this._tlpTrackerBoundingBox.ColumnCount = 1;
            this._tlpTrackerBoundingBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpTrackerBoundingBox.Controls.Add(this._cbxShowGrid, 0, 2);
            this._tlpTrackerBoundingBox.Controls.Add(this._tlpGridPadding, 0, 1);
            this._tlpTrackerBoundingBox.Controls.Add(this._tlpGridSize, 0, 0);
            this._tlpTrackerBoundingBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpTrackerBoundingBox.Location = new System.Drawing.Point(3, 18);
            this._tlpTrackerBoundingBox.Name = "_tlpTrackerBoundingBox";
            this._tlpTrackerBoundingBox.RowCount = 3;
            this._tlpTrackerBoundingBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._tlpTrackerBoundingBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._tlpTrackerBoundingBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._tlpTrackerBoundingBox.Size = new System.Drawing.Size(208, 70);
            this._tlpTrackerBoundingBox.TabIndex = 0;
            // 
            // _cbxShowGrid
            // 
            this._cbxShowGrid.AutoSize = true;
            this._cbxShowGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this._cbxShowGrid.Location = new System.Drawing.Point(3, 49);
            this._cbxShowGrid.Name = "_cbxShowGrid";
            this._cbxShowGrid.Size = new System.Drawing.Size(95, 18);
            this._cbxShowGrid.TabIndex = 3;
            this._cbxShowGrid.Text = "Show Grid";
            this._cbxShowGrid.UseVisualStyleBackColor = true;
            this._cbxShowGrid.CheckedChanged += new System.EventHandler(this._cbxShowGrid_CheckedChanged);
            // 
            // _tlpGridPadding
            // 
            this._tlpGridPadding.ColumnCount = 4;
            this._tlpGridPadding.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this._tlpGridPadding.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tlpGridPadding.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._tlpGridPadding.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tlpGridPadding.Controls.Add(this._nudGridPaddingHeight, 3, 0);
            this._tlpGridPadding.Controls.Add(this.label3, 0, 0);
            this._tlpGridPadding.Controls.Add(this.label4, 2, 0);
            this._tlpGridPadding.Controls.Add(this._nudGridPaddingWidth, 1, 0);
            this._tlpGridPadding.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpGridPadding.Location = new System.Drawing.Point(3, 26);
            this._tlpGridPadding.Name = "_tlpGridPadding";
            this._tlpGridPadding.RowCount = 1;
            this._tlpGridPadding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpGridPadding.Size = new System.Drawing.Size(202, 17);
            this._tlpGridPadding.TabIndex = 3;
            // 
            // _nudGridPaddingHeight
            // 
            this._nudGridPaddingHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._nudGridPaddingHeight.DecimalPlaces = 2;
            this._nudGridPaddingHeight.Location = new System.Drawing.Point(153, 3);
            this._nudGridPaddingHeight.Name = "_nudGridPaddingHeight";
            this._nudGridPaddingHeight.Size = new System.Drawing.Size(46, 22);
            this._nudGridPaddingHeight.TabIndex = 4;
            this._nudGridPaddingHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._nudGridPaddingHeight.ValueChanged += new System.EventHandler(this._nudGridPaddingHeight_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Grid Padd.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(133, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "x";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _nudGridPaddingWidth
            // 
            this._nudGridPaddingWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._nudGridPaddingWidth.DecimalPlaces = 2;
            this._nudGridPaddingWidth.Location = new System.Drawing.Point(83, 3);
            this._nudGridPaddingWidth.Name = "_nudGridPaddingWidth";
            this._nudGridPaddingWidth.Size = new System.Drawing.Size(44, 22);
            this._nudGridPaddingWidth.TabIndex = 3;
            this._nudGridPaddingWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._nudGridPaddingWidth.ValueChanged += new System.EventHandler(this._nudGridPaddingWidth_ValueChanged);
            // 
            // _tlpGridSize
            // 
            this._tlpGridSize.ColumnCount = 4;
            this._tlpGridSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this._tlpGridSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tlpGridSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._tlpGridSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tlpGridSize.Controls.Add(this._nudGridHeight, 3, 0);
            this._tlpGridSize.Controls.Add(this.label2, 0, 0);
            this._tlpGridSize.Controls.Add(this.label1, 2, 0);
            this._tlpGridSize.Controls.Add(this._nudGridWidth, 1, 0);
            this._tlpGridSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpGridSize.Location = new System.Drawing.Point(3, 3);
            this._tlpGridSize.Name = "_tlpGridSize";
            this._tlpGridSize.RowCount = 1;
            this._tlpGridSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpGridSize.Size = new System.Drawing.Size(202, 17);
            this._tlpGridSize.TabIndex = 2;
            // 
            // _nudGridHeight
            // 
            this._nudGridHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._nudGridHeight.Location = new System.Drawing.Point(153, 3);
            this._nudGridHeight.Name = "_nudGridHeight";
            this._nudGridHeight.Size = new System.Drawing.Size(46, 22);
            this._nudGridHeight.TabIndex = 4;
            this._nudGridHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._nudGridHeight.ValueChanged += new System.EventHandler(this._nudGridHeight_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Grid Size";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(133, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "x";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _nudGridWidth
            // 
            this._nudGridWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._nudGridWidth.Location = new System.Drawing.Point(83, 3);
            this._nudGridWidth.Name = "_nudGridWidth";
            this._nudGridWidth.Size = new System.Drawing.Size(44, 22);
            this._nudGridWidth.TabIndex = 3;
            this._nudGridWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._nudGridWidth.ValueChanged += new System.EventHandler(this._nudGridWidth_ValueChanged);
            // 
            // _gbxLucasKanade
            // 
            this._gbxLucasKanade.Controls.Add(this._tlpLucasKanade);
            this._gbxLucasKanade.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gbxLucasKanade.Location = new System.Drawing.Point(3, 100);
            this._gbxLucasKanade.Name = "_gbxLucasKanade";
            this._gbxLucasKanade.Size = new System.Drawing.Size(214, 163);
            this._gbxLucasKanade.TabIndex = 1;
            this._gbxLucasKanade.TabStop = false;
            this._gbxLucasKanade.Text = "Lucas-Kanade Tracker";
            // 
            // _tlpLucasKanade
            // 
            this._tlpLucasKanade.ColumnCount = 1;
            this._tlpLucasKanade.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpLucasKanade.Controls.Add(this._tlpLkWindowSize, 0, 0);
            this._tlpLucasKanade.Controls.Add(this._tlpLkLevels, 0, 1);
            this._tlpLucasKanade.Controls.Add(this._gbxLkTermCriteria, 0, 2);
            this._tlpLucasKanade.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpLucasKanade.Location = new System.Drawing.Point(3, 18);
            this._tlpLucasKanade.Name = "_tlpLucasKanade";
            this._tlpLucasKanade.RowCount = 3;
            this._tlpLucasKanade.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._tlpLucasKanade.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._tlpLucasKanade.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this._tlpLucasKanade.Size = new System.Drawing.Size(208, 142);
            this._tlpLucasKanade.TabIndex = 0;
            // 
            // _tlpLkWindowSize
            // 
            this._tlpLkWindowSize.ColumnCount = 4;
            this._tlpLkWindowSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpLkWindowSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpLkWindowSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._tlpLkWindowSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpLkWindowSize.Controls.Add(this._nudLkWindowHeight, 3, 0);
            this._tlpLkWindowSize.Controls.Add(this.label6, 0, 0);
            this._tlpLkWindowSize.Controls.Add(this.label7, 2, 0);
            this._tlpLkWindowSize.Controls.Add(this._nudLkWindowWidth, 1, 0);
            this._tlpLkWindowSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpLkWindowSize.Location = new System.Drawing.Point(3, 3);
            this._tlpLkWindowSize.Name = "_tlpLkWindowSize";
            this._tlpLkWindowSize.RowCount = 1;
            this._tlpLkWindowSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpLkWindowSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this._tlpLkWindowSize.Size = new System.Drawing.Size(202, 22);
            this._tlpLkWindowSize.TabIndex = 3;
            // 
            // _nudLkWindowHeight
            // 
            this._nudLkWindowHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._nudLkWindowHeight.Location = new System.Drawing.Point(143, 3);
            this._nudLkWindowHeight.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this._nudLkWindowHeight.Name = "_nudLkWindowHeight";
            this._nudLkWindowHeight.Size = new System.Drawing.Size(56, 22);
            this._nudLkWindowHeight.TabIndex = 4;
            this._nudLkWindowHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._nudLkWindowHeight.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this._nudLkWindowHeight.ValueChanged += new System.EventHandler(this._nudLkWindowHeight_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 22);
            this.label6.TabIndex = 1;
            this.label6.Text = "Window Size";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(123, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 22);
            this.label7.TabIndex = 2;
            this.label7.Text = "x";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _nudLkWindowWidth
            // 
            this._nudLkWindowWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._nudLkWindowWidth.Location = new System.Drawing.Point(63, 3);
            this._nudLkWindowWidth.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this._nudLkWindowWidth.Name = "_nudLkWindowWidth";
            this._nudLkWindowWidth.Size = new System.Drawing.Size(54, 22);
            this._nudLkWindowWidth.TabIndex = 3;
            this._nudLkWindowWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._nudLkWindowWidth.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this._nudLkWindowWidth.ValueChanged += new System.EventHandler(this._nudLkWindowWidth_ValueChanged);
            // 
            // _tlpLkLevels
            // 
            this._tlpLkLevels.ColumnCount = 3;
            this._tlpLkLevels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpLkLevels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpLkLevels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this._tlpLkLevels.Controls.Add(this.label8, 0, 0);
            this._tlpLkLevels.Controls.Add(this._nudLkLevels, 1, 0);
            this._tlpLkLevels.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpLkLevels.Location = new System.Drawing.Point(3, 31);
            this._tlpLkLevels.Name = "_tlpLkLevels";
            this._tlpLkLevels.RowCount = 1;
            this._tlpLkLevels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpLkLevels.Size = new System.Drawing.Size(202, 22);
            this._tlpLkLevels.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 22);
            this.label8.TabIndex = 1;
            this.label8.Text = "Levels";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _nudLkLevels
            // 
            this._nudLkLevels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._nudLkLevels.Location = new System.Drawing.Point(63, 3);
            this._nudLkLevels.Name = "_nudLkLevels";
            this._nudLkLevels.Size = new System.Drawing.Size(54, 22);
            this._nudLkLevels.TabIndex = 3;
            this._nudLkLevels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._nudLkLevels.ValueChanged += new System.EventHandler(this._nudLkLevels_ValueChanged);
            // 
            // _gbxLkTermCriteria
            // 
            this._gbxLkTermCriteria.Controls.Add(this._tlpLkTermCriteria);
            this._gbxLkTermCriteria.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gbxLkTermCriteria.Location = new System.Drawing.Point(3, 59);
            this._gbxLkTermCriteria.Name = "_gbxLkTermCriteria";
            this._gbxLkTermCriteria.Size = new System.Drawing.Size(202, 80);
            this._gbxLkTermCriteria.TabIndex = 5;
            this._gbxLkTermCriteria.TabStop = false;
            this._gbxLkTermCriteria.Text = "Termination Criteria";
            // 
            // _tlpLkTermCriteria
            // 
            this._tlpLkTermCriteria.ColumnCount = 1;
            this._tlpLkTermCriteria.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpLkTermCriteria.Controls.Add(this._tlpLkMaxIterations, 0, 0);
            this._tlpLkTermCriteria.Controls.Add(this._tlpLkEpsilon, 0, 1);
            this._tlpLkTermCriteria.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpLkTermCriteria.Location = new System.Drawing.Point(3, 18);
            this._tlpLkTermCriteria.Name = "_tlpLkTermCriteria";
            this._tlpLkTermCriteria.RowCount = 2;
            this._tlpLkTermCriteria.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpLkTermCriteria.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpLkTermCriteria.Size = new System.Drawing.Size(196, 59);
            this._tlpLkTermCriteria.TabIndex = 0;
            // 
            // _tlpLkMaxIterations
            // 
            this._tlpLkMaxIterations.ColumnCount = 3;
            this._tlpLkMaxIterations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpLkMaxIterations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpLkMaxIterations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._tlpLkMaxIterations.Controls.Add(this.label10, 0, 0);
            this._tlpLkMaxIterations.Controls.Add(this._nudLkMaxIterations, 1, 0);
            this._tlpLkMaxIterations.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpLkMaxIterations.Location = new System.Drawing.Point(3, 3);
            this._tlpLkMaxIterations.Name = "_tlpLkMaxIterations";
            this._tlpLkMaxIterations.RowCount = 1;
            this._tlpLkMaxIterations.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpLkMaxIterations.Size = new System.Drawing.Size(190, 23);
            this._tlpLkMaxIterations.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 23);
            this.label10.TabIndex = 1;
            this.label10.Text = "Max Iterations";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _nudLkMaxIterations
            // 
            this._nudLkMaxIterations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._nudLkMaxIterations.Location = new System.Drawing.Point(98, 3);
            this._nudLkMaxIterations.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this._nudLkMaxIterations.Name = "_nudLkMaxIterations";
            this._nudLkMaxIterations.Size = new System.Drawing.Size(51, 22);
            this._nudLkMaxIterations.TabIndex = 3;
            this._nudLkMaxIterations.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._nudLkMaxIterations.ValueChanged += new System.EventHandler(this._nudLkMaxIterations_ValueChanged);
            // 
            // _tlpLkEpsilon
            // 
            this._tlpLkEpsilon.ColumnCount = 3;
            this._tlpLkEpsilon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpLkEpsilon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpLkEpsilon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._tlpLkEpsilon.Controls.Add(this.label9, 0, 0);
            this._tlpLkEpsilon.Controls.Add(this._nudLkEpsilon, 1, 0);
            this._tlpLkEpsilon.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpLkEpsilon.Location = new System.Drawing.Point(3, 32);
            this._tlpLkEpsilon.Name = "_tlpLkEpsilon";
            this._tlpLkEpsilon.RowCount = 1;
            this._tlpLkEpsilon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpLkEpsilon.Size = new System.Drawing.Size(190, 24);
            this._tlpLkEpsilon.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 24);
            this.label9.TabIndex = 1;
            this.label9.Text = "Epsilon";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _nudLkEpsilon
            // 
            this._nudLkEpsilon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._nudLkEpsilon.DecimalPlaces = 3;
            this._nudLkEpsilon.Location = new System.Drawing.Point(98, 3);
            this._nudLkEpsilon.Name = "_nudLkEpsilon";
            this._nudLkEpsilon.Size = new System.Drawing.Size(51, 22);
            this._nudLkEpsilon.TabIndex = 3;
            this._nudLkEpsilon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._nudLkEpsilon.ValueChanged += new System.EventHandler(this._nudLkEpsilon_ValueChanged);
            // 
            // _cbxShowValidTrackingPoints
            // 
            this._cbxShowValidTrackingPoints.AutoSize = true;
            this._cbxShowValidTrackingPoints.Dock = System.Windows.Forms.DockStyle.Left;
            this._cbxShowValidTrackingPoints.Location = new System.Drawing.Point(3, 330);
            this._cbxShowValidTrackingPoints.Name = "_cbxShowValidTrackingPoints";
            this._cbxShowValidTrackingPoints.Size = new System.Drawing.Size(142, 14);
            this._cbxShowValidTrackingPoints.TabIndex = 8;
            this._cbxShowValidTrackingPoints.Text = "Show Valid Points";
            this._cbxShowValidTrackingPoints.UseVisualStyleBackColor = true;
            this._cbxShowValidTrackingPoints.CheckedChanged += new System.EventHandler(this._cbxShowValidTrackingPoints_CheckedChanged);
            // 
            // _cbxShowReliableTrackingPoints
            // 
            this._cbxShowReliableTrackingPoints.AutoSize = true;
            this._cbxShowReliableTrackingPoints.Dock = System.Windows.Forms.DockStyle.Left;
            this._cbxShowReliableTrackingPoints.Location = new System.Drawing.Point(3, 350);
            this._cbxShowReliableTrackingPoints.Name = "_cbxShowReliableTrackingPoints";
            this._cbxShowReliableTrackingPoints.Size = new System.Drawing.Size(162, 14);
            this._cbxShowReliableTrackingPoints.TabIndex = 7;
            this._cbxShowReliableTrackingPoints.Text = "Show Reliable Points";
            this._cbxShowReliableTrackingPoints.UseVisualStyleBackColor = true;
            this._cbxShowReliableTrackingPoints.CheckedChanged += new System.EventHandler(this._cbxShowReliableTrackingPoints_CheckedChanged);
            // 
            // _flpFbErrorMedian
            // 
            this._flpFbErrorMedian.Controls.Add(this.label14);
            this._flpFbErrorMedian.Controls.Add(this._lblFbErrorMedian);
            this._flpFbErrorMedian.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flpFbErrorMedian.Location = new System.Drawing.Point(3, 370);
            this._flpFbErrorMedian.Name = "_flpFbErrorMedian";
            this._flpFbErrorMedian.Size = new System.Drawing.Size(214, 14);
            this._flpFbErrorMedian.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Left;
            this.label14.Location = new System.Drawing.Point(3, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(115, 17);
            this.label14.TabIndex = 0;
            this.label14.Text = "FB Error Median:";
            // 
            // _lblFbErrorMedian
            // 
            this._lblFbErrorMedian.AutoSize = true;
            this._lblFbErrorMedian.Dock = System.Windows.Forms.DockStyle.Left;
            this._lblFbErrorMedian.Location = new System.Drawing.Point(124, 0);
            this._lblFbErrorMedian.Name = "_lblFbErrorMedian";
            this._lblFbErrorMedian.Size = new System.Drawing.Size(13, 17);
            this._lblFbErrorMedian.TabIndex = 1;
            this._lblFbErrorMedian.Text = "-";
            // 
            // _gbxLearning
            // 
            this._gbxLearning.BackColor = System.Drawing.Color.MediumPurple;
            this._gbxLearning.Controls.Add(this._tlpLearning);
            this._gbxLearning.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gbxLearning.Location = new System.Drawing.Point(247, 63);
            this._gbxLearning.Name = "_gbxLearning";
            this._gbxLearning.Size = new System.Drawing.Size(238, 543);
            this._gbxLearning.TabIndex = 0;
            this._gbxLearning.TabStop = false;
            this._gbxLearning.Text = "Learning";
            // 
            // _tlpLearning
            // 
            this._tlpLearning.ColumnCount = 1;
            this._tlpLearning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpLearning.Controls.Add(this._gbxLearningSpecific, 0, 1);
            this._tlpLearning.Controls.Add(this._gbxLearningGeneral, 0, 0);
            this._tlpLearning.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpLearning.Location = new System.Drawing.Point(3, 18);
            this._tlpLearning.Name = "_tlpLearning";
            this._tlpLearning.RowCount = 2;
            this._tlpLearning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._tlpLearning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this._tlpLearning.Size = new System.Drawing.Size(232, 522);
            this._tlpLearning.TabIndex = 0;
            // 
            // _gbxLearningSpecific
            // 
            this._gbxLearningSpecific.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gbxLearningSpecific.Location = new System.Drawing.Point(3, 55);
            this._gbxLearningSpecific.Name = "_gbxLearningSpecific";
            this._gbxLearningSpecific.Size = new System.Drawing.Size(226, 464);
            this._gbxLearningSpecific.TabIndex = 0;
            this._gbxLearningSpecific.TabStop = false;
            this._gbxLearningSpecific.Text = "Specific";
            // 
            // _gbxLearningGeneral
            // 
            this._gbxLearningGeneral.Controls.Add(this.tableLayoutPanel1);
            this._gbxLearningGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gbxLearningGeneral.Location = new System.Drawing.Point(3, 3);
            this._gbxLearningGeneral.Name = "_gbxLearningGeneral";
            this._gbxLearningGeneral.Size = new System.Drawing.Size(226, 46);
            this._gbxLearningGeneral.TabIndex = 1;
            this._gbxLearningGeneral.TabStop = false;
            this._gbxLearningGeneral.Text = "General";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this._cbxUseLearner, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(220, 25);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _cbxUseLearner
            // 
            this._cbxUseLearner.AutoSize = true;
            this._cbxUseLearner.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cbxUseLearner.Location = new System.Drawing.Point(3, 3);
            this._cbxUseLearner.Name = "_cbxUseLearner";
            this._cbxUseLearner.Size = new System.Drawing.Size(214, 19);
            this._cbxUseLearner.TabIndex = 0;
            this._cbxUseLearner.Text = "Use";
            this._cbxUseLearner.UseVisualStyleBackColor = true;
            this._cbxUseLearner.CheckedChanged += new System.EventHandler(this._cbxUseLearner_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1358, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frametoframeViewToolStripMenuItem,
            this.nCCCalculatorToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.optionsToolStripMenuItem.Text = "Tools";
            // 
            // frametoframeViewToolStripMenuItem
            // 
            this.frametoframeViewToolStripMenuItem.Name = "frametoframeViewToolStripMenuItem";
            this.frametoframeViewToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.frametoframeViewToolStripMenuItem.Text = "Frame-to-frame view...";
            this.frametoframeViewToolStripMenuItem.Click += new System.EventHandler(this.frametoframeViewToolStripMenuItem_Click);
            // 
            // nCCCalculatorToolStripMenuItem
            // 
            this.nCCCalculatorToolStripMenuItem.Name = "nCCCalculatorToolStripMenuItem";
            this.nCCCalculatorToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.nCCCalculatorToolStripMenuItem.Text = "NCC calculator...";
            this.nCCCalculatorToolStripMenuItem.Click += new System.EventHandler(this.nCCCalculatorToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 664);
            this.Controls.Add(this._tldForm);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Tracking-Learning-Detection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this._tldForm.ResumeLayout(false);
            this._tlpVideo.ResumeLayout(false);
            this._tlpVideoControls.ResumeLayout(false);
            this._flpVideoFps.ResumeLayout(false);
            this._flpVideoFps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudFrameWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudFrameHeight)).EndInit();
            this._flpFrameSize.ResumeLayout(false);
            this._flpFrameSize.PerformLayout();
            this._gbxVideoFileProperties.ResumeLayout(false);
            this._tlpVideoFileProperties.ResumeLayout(false);
            this._gbxTldSession.ResumeLayout(false);
            this._flpTldSession.ResumeLayout(false);
            this._flpVideoFilePath.ResumeLayout(false);
            this._flpVideoFilePath.PerformLayout();
            this._flpVideoFileMisc.ResumeLayout(false);
            this._flpVideoFileMisc.PerformLayout();
            this._gbxGroundTruthMode.ResumeLayout(false);
            this._flpGroundTruthMode.ResumeLayout(false);
            this._flpGroundTruthMode.PerformLayout();
            this._flpVideoPlayback.ResumeLayout(false);
            this._gbxTld.ResumeLayout(false);
            this._tlpTld.ResumeLayout(false);
            this._gbxDetection.ResumeLayout(false);
            this._tlpDetection.ResumeLayout(false);
            this._gbxDetectionGeneral.ResumeLayout(false);
            this._tlpDetectionGeneral.ResumeLayout(false);
            this._tlpDetectionGeneral.PerformLayout();
            this._tlpChooseSpecificDetector.ResumeLayout(false);
            this._tlpChooseSpecificDetector.PerformLayout();
            this._gbxTldGeneral.ResumeLayout(false);
            this._tlpTldGeneral.ResumeLayout(false);
            this._tlpTldTime.ResumeLayout(false);
            this._tlpTldTime.PerformLayout();
            this._tlpTldConfigGeneral.ResumeLayout(false);
            this._tlpTldConfigGeneral.PerformLayout();
            this._gbxTracking.ResumeLayout(false);
            this._tlpTracking.ResumeLayout(false);
            this._gbxTrackingGeneral.ResumeLayout(false);
            this._tlpTrackingGeneral.ResumeLayout(false);
            this._tlpTrackingGeneral.PerformLayout();
            this._gbxTrackingSpecific.ResumeLayout(false);
            this._tlpTrackingSpecific.ResumeLayout(false);
            this._tlpTrackingSpecific.PerformLayout();
            this._flpNccMedian.ResumeLayout(false);
            this._flpNccMedian.PerformLayout();
            this._tlpMadTreshold.ResumeLayout(false);
            this._tlpMadTreshold.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudMadTreshold)).EndInit();
            this._tlpNccPatchSize.ResumeLayout(false);
            this._tlpNccPatchSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudNccPatchHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudNccPatchWidth)).EndInit();
            this._gbxBoundingBox.ResumeLayout(false);
            this._tlpTrackerBoundingBox.ResumeLayout(false);
            this._tlpTrackerBoundingBox.PerformLayout();
            this._tlpGridPadding.ResumeLayout(false);
            this._tlpGridPadding.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudGridPaddingHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudGridPaddingWidth)).EndInit();
            this._tlpGridSize.ResumeLayout(false);
            this._tlpGridSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudGridHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudGridWidth)).EndInit();
            this._gbxLucasKanade.ResumeLayout(false);
            this._tlpLucasKanade.ResumeLayout(false);
            this._tlpLkWindowSize.ResumeLayout(false);
            this._tlpLkWindowSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudLkWindowHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudLkWindowWidth)).EndInit();
            this._tlpLkLevels.ResumeLayout(false);
            this._tlpLkLevels.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudLkLevels)).EndInit();
            this._gbxLkTermCriteria.ResumeLayout(false);
            this._tlpLkTermCriteria.ResumeLayout(false);
            this._tlpLkMaxIterations.ResumeLayout(false);
            this._tlpLkMaxIterations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudLkMaxIterations)).EndInit();
            this._tlpLkEpsilon.ResumeLayout(false);
            this._tlpLkEpsilon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudLkEpsilon)).EndInit();
            this._flpFbErrorMedian.ResumeLayout(false);
            this._flpFbErrorMedian.PerformLayout();
            this._gbxLearning.ResumeLayout(false);
            this._tlpLearning.ResumeLayout(false);
            this._gbxLearningGeneral.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tldForm;
        private System.Windows.Forms.TableLayoutPanel _tlpVideo;
        private System.Windows.Forms.Button _btnStartPauseVideo;
        private System.Windows.Forms.GroupBox _gbxTld;
        private System.Windows.Forms.TableLayoutPanel _tlpTld;
        private System.Windows.Forms.GroupBox _gbxDetection;
        private System.Windows.Forms.GroupBox _gbxTldGeneral;
        private System.Windows.Forms.GroupBox _gbxTracking;
        private System.Windows.Forms.TableLayoutPanel _tlpTrackingSpecific;
        private System.Windows.Forms.GroupBox _gbxBoundingBox;
        private System.Windows.Forms.TableLayoutPanel _tlpTrackerBoundingBox;
        private System.Windows.Forms.TableLayoutPanel _tlpGridPadding;
        private System.Windows.Forms.NumericUpDown _nudGridPaddingHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown _nudGridPaddingWidth;
        private System.Windows.Forms.TableLayoutPanel _tlpGridSize;
        private System.Windows.Forms.NumericUpDown _nudGridHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown _nudGridWidth;
        public System.Windows.Forms.CheckBox _cbxShowGrid;
        private System.Windows.Forms.GroupBox _gbxLearning;
        private System.Windows.Forms.Label _lblTldTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox _gbxLucasKanade;
        private System.Windows.Forms.TableLayoutPanel _tlpLucasKanade;
        private System.Windows.Forms.TableLayoutPanel _tlpLkWindowSize;
        private System.Windows.Forms.NumericUpDown _nudLkWindowHeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown _nudLkWindowWidth;
        private System.Windows.Forms.TableLayoutPanel _tlpLkLevels;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown _nudLkLevels;
        private System.Windows.Forms.TableLayoutPanel _tlpLkEpsilon;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown _nudLkEpsilon;
        private System.Windows.Forms.TableLayoutPanel _tlpLkMaxIterations;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown _nudLkMaxIterations;
        private System.Windows.Forms.GroupBox _gbxLkTermCriteria;
        private System.Windows.Forms.TableLayoutPanel _tlpLkTermCriteria;
        private System.Windows.Forms.TableLayoutPanel _tlpNccPatchSize;
        private System.Windows.Forms.NumericUpDown _nudNccPatchHeight;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown _nudNccPatchWidth;
        private System.Windows.Forms.TableLayoutPanel _tlpMadTreshold;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown _nudMadTreshold;
        public System.Windows.Forms.CheckBox _cbxShowReliableTrackingPoints;
        public System.Windows.Forms.CheckBox _cbxShowValidTrackingPoints;
        private System.Windows.Forms.FlowLayoutPanel _flpFbErrorMedian;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label _lblFbErrorMedian;
        private System.Windows.Forms.FlowLayoutPanel _flpNccMedian;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label _lblNccMedian;
        public System.Windows.Forms.CheckBox _cbxShowTrackerObject;
        private System.Windows.Forms.TableLayoutPanel _tlpTracking;
        private System.Windows.Forms.GroupBox _gbxTrackingGeneral;
        private System.Windows.Forms.TableLayoutPanel _tlpTrackingGeneral;
        private System.Windows.Forms.GroupBox _gbxTrackingSpecific;
        private System.Windows.Forms.TableLayoutPanel _tlpDetection;
        private System.Windows.Forms.GroupBox _gbxDetectionGeneral;
        private System.Windows.Forms.TableLayoutPanel _tlpDetectionGeneral;
        private System.Windows.Forms.CheckBox _cbxShowDetectorObjects;
        private System.Windows.Forms.GroupBox _gbxDetectionSpecific;
        private System.Windows.Forms.TableLayoutPanel _tlpChooseSpecificDetector;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox _cmbxChooseSpecificDetector;
        private System.Windows.Forms.TableLayoutPanel _tlpVideoControls;
        private System.Windows.Forms.FlowLayoutPanel _flpVideoFps;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label _lblVideoFps;
        private System.Windows.Forms.Panel _pnlVideo;
        private System.Windows.Forms.Label _lblTldAverageTime;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox _cbxUseDetector;
        private System.Windows.Forms.CheckBox _cbxUseTracker;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown _nudFrameWidth;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown _nudFrameHeight;
        private System.Windows.Forms.FlowLayoutPanel _flpFrameSize;
        private System.Windows.Forms.CheckBox _cbxEnableTrackerFailure;
        private System.Windows.Forms.TableLayoutPanel _tlpLearning;
        private System.Windows.Forms.GroupBox _gbxLearningSpecific;
        private System.Windows.Forms.GroupBox _gbxLearningGeneral;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox _cbxUseLearner;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox _cbxVideoMode;
        private System.Windows.Forms.GroupBox _gbxVideoFileProperties;
        private System.Windows.Forms.TableLayoutPanel _tlpVideoFileProperties;
        private System.Windows.Forms.FlowLayoutPanel _flpVideoFilePath;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox _tbxVideoFilePath;
        private System.Windows.Forms.Button _btnOpenVideoFile;
        private System.Windows.Forms.FlowLayoutPanel _flpTldSession;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button _btnSaveTldSession;
        private System.Windows.Forms.Button _btnLoadTldSession;
        private System.Windows.Forms.FlowLayoutPanel _flpVideoPlayback;
        private System.Windows.Forms.Button _btnStopVideo;
        private System.Windows.Forms.Button _btnNextFrame;
        private System.Windows.Forms.TableLayoutPanel _tlpTldGeneral;
        private System.Windows.Forms.TableLayoutPanel _tlpTldTime;
        private System.Windows.Forms.TableLayoutPanel _tlpTldConfigGeneral;
        private System.Windows.Forms.CheckBox _cbxShowTldOutput;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frametoframeViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nCCCalculatorToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel _flpVideoFileMisc;
        private System.Windows.Forms.CheckBox _cbxVideoRealTime;
        private System.Windows.Forms.FlowLayoutPanel _flpGroundTruthMode;
        private System.Windows.Forms.Button _btnEnterGroundTruthMode;
        private System.Windows.Forms.GroupBox _gbxGroundTruthMode;
        private System.Windows.Forms.Button _btnExitGroundTruthMode;
        private System.Windows.Forms.Button _btnSaveGroundTruth;
        private System.Windows.Forms.Button _btnLoadGroundTruth;
        private System.Windows.Forms.GroupBox _gbxTldSession;
        private System.Windows.Forms.Button _btnStartNewTldSessionUsingGTInit;
        private System.Windows.Forms.CheckBox _cbxDrawGroundTruth;
        private System.Windows.Forms.Button _btnEvaluateTldSession;
        private System.Windows.Forms.Button _btnClearGroundTruthSession;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label _lblVideoFrame;

    }
}

