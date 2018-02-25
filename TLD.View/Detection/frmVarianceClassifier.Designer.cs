namespace TLD.View
{
    partial class frmVarianceClassifier
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
            this._tlpMainPanel = new System.Windows.Forms.TableLayoutPanel();
            this._tlpThresholdCoefficient = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this._nudChangeThresholdCoefficient = new System.Windows.Forms.NumericUpDown();
            this._cbxShowAcceptedPatches = new System.Windows.Forms.CheckBox();
            this._lblDisplayAcceptedPatchesCount = new System.Windows.Forms.Label();
            this._tlpShowAcceptedPatches = new System.Windows.Forms.TableLayoutPanel();
            this._tlpMainPanel.SuspendLayout();
            this._tlpThresholdCoefficient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudChangeThresholdCoefficient)).BeginInit();
            this._tlpShowAcceptedPatches.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tlpMainPanel
            // 
            this._tlpMainPanel.ColumnCount = 1;
            this._tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpMainPanel.Controls.Add(this._tlpThresholdCoefficient, 0, 1);
            this._tlpMainPanel.Controls.Add(this._tlpShowAcceptedPatches, 0, 0);
            this._tlpMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpMainPanel.Location = new System.Drawing.Point(0, 0);
            this._tlpMainPanel.Name = "_tlpMainPanel";
            this._tlpMainPanel.RowCount = 2;
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpMainPanel.Size = new System.Drawing.Size(282, 255);
            this._tlpMainPanel.TabIndex = 0;
            // 
            // _tlpThresholdCoefficient
            // 
            this._tlpThresholdCoefficient.ColumnCount = 2;
            this._tlpThresholdCoefficient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this._tlpThresholdCoefficient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpThresholdCoefficient.Controls.Add(this.label1, 0, 0);
            this._tlpThresholdCoefficient.Controls.Add(this._nudChangeThresholdCoefficient, 1, 0);
            this._tlpThresholdCoefficient.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpThresholdCoefficient.Location = new System.Drawing.Point(3, 130);
            this._tlpThresholdCoefficient.Name = "_tlpThresholdCoefficient";
            this._tlpThresholdCoefficient.RowCount = 1;
            this._tlpThresholdCoefficient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpThresholdCoefficient.Size = new System.Drawing.Size(276, 122);
            this._tlpThresholdCoefficient.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 122);
            this.label1.TabIndex = 0;
            this.label1.Text = "Threshold Coefficient";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _nudChangeThresholdCoefficient
            // 
            this._nudChangeThresholdCoefficient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._nudChangeThresholdCoefficient.DecimalPlaces = 2;
            this._nudChangeThresholdCoefficient.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._nudChangeThresholdCoefficient.Location = new System.Drawing.Point(196, 50);
            this._nudChangeThresholdCoefficient.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._nudChangeThresholdCoefficient.Name = "_nudChangeThresholdCoefficient";
            this._nudChangeThresholdCoefficient.Size = new System.Drawing.Size(77, 22);
            this._nudChangeThresholdCoefficient.TabIndex = 1;
            this._nudChangeThresholdCoefficient.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._nudChangeThresholdCoefficient.ValueChanged += new System.EventHandler(this._nudChangeThresholdCoefficient_ValueChanged);
            // 
            // _cbxShowAcceptedPatches
            // 
            this._cbxShowAcceptedPatches.AutoSize = true;
            this._cbxShowAcceptedPatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cbxShowAcceptedPatches.Location = new System.Drawing.Point(3, 3);
            this._cbxShowAcceptedPatches.Name = "_cbxShowAcceptedPatches";
            this._cbxShowAcceptedPatches.Size = new System.Drawing.Size(187, 115);
            this._cbxShowAcceptedPatches.TabIndex = 1;
            this._cbxShowAcceptedPatches.Text = "Show Windows :";
            this._cbxShowAcceptedPatches.UseVisualStyleBackColor = true;
            this._cbxShowAcceptedPatches.CheckedChanged += new System.EventHandler(this._cbxShowAcceptedPatches_CheckedChanged);
            // 
            // _lblDisplayAcceptedPatchesCount
            // 
            this._lblDisplayAcceptedPatchesCount.AutoSize = true;
            this._lblDisplayAcceptedPatchesCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblDisplayAcceptedPatchesCount.Location = new System.Drawing.Point(196, 0);
            this._lblDisplayAcceptedPatchesCount.Name = "_lblDisplayAcceptedPatchesCount";
            this._lblDisplayAcceptedPatchesCount.Size = new System.Drawing.Size(77, 121);
            this._lblDisplayAcceptedPatchesCount.TabIndex = 1;
            this._lblDisplayAcceptedPatchesCount.Text = "-";
            this._lblDisplayAcceptedPatchesCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _tlpShowAcceptedPatches
            // 
            this._tlpShowAcceptedPatches.ColumnCount = 2;
            this._tlpShowAcceptedPatches.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this._tlpShowAcceptedPatches.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpShowAcceptedPatches.Controls.Add(this._lblDisplayAcceptedPatchesCount, 1, 0);
            this._tlpShowAcceptedPatches.Controls.Add(this._cbxShowAcceptedPatches, 0, 0);
            this._tlpShowAcceptedPatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpShowAcceptedPatches.Location = new System.Drawing.Point(3, 3);
            this._tlpShowAcceptedPatches.Name = "_tlpShowAcceptedPatches";
            this._tlpShowAcceptedPatches.RowCount = 1;
            this._tlpShowAcceptedPatches.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpShowAcceptedPatches.Size = new System.Drawing.Size(276, 121);
            this._tlpShowAcceptedPatches.TabIndex = 3;
            // 
            // frmVarianceClassifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 255);
            this.Controls.Add(this._tlpMainPanel);
            this.Name = "frmVarianceClassifier";
            this.Text = "frmZdenekVarianceClassifier";
            this._tlpMainPanel.ResumeLayout(false);
            this._tlpThresholdCoefficient.ResumeLayout(false);
            this._tlpThresholdCoefficient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudChangeThresholdCoefficient)).EndInit();
            this._tlpShowAcceptedPatches.ResumeLayout(false);
            this._tlpShowAcceptedPatches.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tlpMainPanel;
        private System.Windows.Forms.TableLayoutPanel _tlpThresholdCoefficient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown _nudChangeThresholdCoefficient;
        private System.Windows.Forms.CheckBox _cbxShowAcceptedPatches;
        private System.Windows.Forms.Label _lblDisplayAcceptedPatchesCount;
        private System.Windows.Forms.TableLayoutPanel _tlpShowAcceptedPatches;
    }
}