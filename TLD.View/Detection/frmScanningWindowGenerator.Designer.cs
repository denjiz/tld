namespace TLD.View
{
    partial class frmScanningWindowGenerator
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
            this._tlpMinimumSize = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this._nudChangeMinimumSize = new System.Windows.Forms.NumericUpDown();
            this._tlpScaleStep = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this._nudChangeScaleStep = new System.Windows.Forms.NumericUpDown();
            this._tlpTranslationStep = new System.Windows.Forms.TableLayoutPanel();
            this._nudChangeVerticalStep = new System.Windows.Forms.NumericUpDown();
            this._lblCenter = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._nudChangeHorizontalStep = new System.Windows.Forms.NumericUpDown();
            this._tlpShowScanningWindows = new System.Windows.Forms.TableLayoutPanel();
            this._cbxShowScanningWindows = new System.Windows.Forms.CheckBox();
            this._lblDisplayWindowCount = new System.Windows.Forms.Label();
            this._tlpMainPanel.SuspendLayout();
            this._tlpMinimumSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudChangeMinimumSize)).BeginInit();
            this._tlpScaleStep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudChangeScaleStep)).BeginInit();
            this._tlpTranslationStep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudChangeVerticalStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudChangeHorizontalStep)).BeginInit();
            this._tlpShowScanningWindows.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tlpMainPanel
            // 
            this._tlpMainPanel.ColumnCount = 1;
            this._tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpMainPanel.Controls.Add(this._tlpMinimumSize, 0, 3);
            this._tlpMainPanel.Controls.Add(this._tlpScaleStep, 0, 1);
            this._tlpMainPanel.Controls.Add(this._tlpTranslationStep, 0, 2);
            this._tlpMainPanel.Controls.Add(this._tlpShowScanningWindows, 0, 0);
            this._tlpMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpMainPanel.Location = new System.Drawing.Point(0, 0);
            this._tlpMainPanel.Name = "_tlpMainPanel";
            this._tlpMainPanel.RowCount = 4;
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._tlpMainPanel.Size = new System.Drawing.Size(282, 255);
            this._tlpMainPanel.TabIndex = 1;
            // 
            // _tlpMinimumSize
            // 
            this._tlpMinimumSize.ColumnCount = 2;
            this._tlpMinimumSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this._tlpMinimumSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tlpMinimumSize.Controls.Add(this.label5, 0, 0);
            this._tlpMinimumSize.Controls.Add(this._nudChangeMinimumSize, 1, 0);
            this._tlpMinimumSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpMinimumSize.Location = new System.Drawing.Point(3, 192);
            this._tlpMinimumSize.Name = "_tlpMinimumSize";
            this._tlpMinimumSize.RowCount = 1;
            this._tlpMinimumSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpMinimumSize.Size = new System.Drawing.Size(276, 60);
            this._tlpMinimumSize.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(201, 60);
            this.label5.TabIndex = 1;
            this.label5.Text = "Minimum Window Size";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _nudChangeMinimumSize
            // 
            this._nudChangeMinimumSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._nudChangeMinimumSize.Location = new System.Drawing.Point(210, 19);
            this._nudChangeMinimumSize.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this._nudChangeMinimumSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this._nudChangeMinimumSize.Name = "_nudChangeMinimumSize";
            this._nudChangeMinimumSize.Size = new System.Drawing.Size(63, 22);
            this._nudChangeMinimumSize.TabIndex = 3;
            this._nudChangeMinimumSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._nudChangeMinimumSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // _tlpScaleStep
            // 
            this._tlpScaleStep.ColumnCount = 3;
            this._tlpScaleStep.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpScaleStep.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpScaleStep.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._tlpScaleStep.Controls.Add(this.label9, 0, 0);
            this._tlpScaleStep.Controls.Add(this._nudChangeScaleStep, 1, 0);
            this._tlpScaleStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpScaleStep.Location = new System.Drawing.Point(3, 66);
            this._tlpScaleStep.Name = "_tlpScaleStep";
            this._tlpScaleStep.RowCount = 1;
            this._tlpScaleStep.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpScaleStep.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this._tlpScaleStep.Size = new System.Drawing.Size(276, 57);
            this._tlpScaleStep.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 57);
            this.label9.TabIndex = 1;
            this.label9.Text = "Scale Step";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _nudChangeScaleStep
            // 
            this._nudChangeScaleStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._nudChangeScaleStep.DecimalPlaces = 2;
            this._nudChangeScaleStep.Location = new System.Drawing.Point(141, 17);
            this._nudChangeScaleStep.Minimum = new decimal(new int[] {
            11,
            0,
            0,
            65536});
            this._nudChangeScaleStep.Name = "_nudChangeScaleStep";
            this._nudChangeScaleStep.Size = new System.Drawing.Size(76, 22);
            this._nudChangeScaleStep.TabIndex = 3;
            this._nudChangeScaleStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._nudChangeScaleStep.Value = new decimal(new int[] {
            11,
            0,
            0,
            65536});
            // 
            // _tlpTranslationStep
            // 
            this._tlpTranslationStep.ColumnCount = 4;
            this._tlpTranslationStep.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this._tlpTranslationStep.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tlpTranslationStep.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._tlpTranslationStep.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tlpTranslationStep.Controls.Add(this._nudChangeVerticalStep, 3, 0);
            this._tlpTranslationStep.Controls.Add(this._lblCenter, 0, 0);
            this._tlpTranslationStep.Controls.Add(this.label4, 2, 0);
            this._tlpTranslationStep.Controls.Add(this._nudChangeHorizontalStep, 1, 0);
            this._tlpTranslationStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpTranslationStep.Location = new System.Drawing.Point(3, 129);
            this._tlpTranslationStep.Name = "_tlpTranslationStep";
            this._tlpTranslationStep.RowCount = 1;
            this._tlpTranslationStep.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpTranslationStep.Size = new System.Drawing.Size(276, 57);
            this._tlpTranslationStep.TabIndex = 10;
            // 
            // _nudChangeVerticalStep
            // 
            this._nudChangeVerticalStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._nudChangeVerticalStep.DecimalPlaces = 2;
            this._nudChangeVerticalStep.Location = new System.Drawing.Point(209, 17);
            this._nudChangeVerticalStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._nudChangeVerticalStep.Name = "_nudChangeVerticalStep";
            this._nudChangeVerticalStep.Size = new System.Drawing.Size(64, 22);
            this._nudChangeVerticalStep.TabIndex = 4;
            this._nudChangeVerticalStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._nudChangeVerticalStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // _lblCenter
            // 
            this._lblCenter.AutoSize = true;
            this._lblCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblCenter.Location = new System.Drawing.Point(3, 0);
            this._lblCenter.Name = "_lblCenter";
            this._lblCenter.Size = new System.Drawing.Size(104, 57);
            this._lblCenter.TabIndex = 1;
            this._lblCenter.Text = "Trans. Step";
            this._lblCenter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(182, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 57);
            this.label4.TabIndex = 2;
            this.label4.Text = "x";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _nudChangeHorizontalStep
            // 
            this._nudChangeHorizontalStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._nudChangeHorizontalStep.DecimalPlaces = 2;
            this._nudChangeHorizontalStep.Location = new System.Drawing.Point(113, 17);
            this._nudChangeHorizontalStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._nudChangeHorizontalStep.Name = "_nudChangeHorizontalStep";
            this._nudChangeHorizontalStep.Size = new System.Drawing.Size(63, 22);
            this._nudChangeHorizontalStep.TabIndex = 3;
            this._nudChangeHorizontalStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._nudChangeHorizontalStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // _tlpShowScanningWindows
            // 
            this._tlpShowScanningWindows.ColumnCount = 2;
            this._tlpShowScanningWindows.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this._tlpShowScanningWindows.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpShowScanningWindows.Controls.Add(this._cbxShowScanningWindows, 0, 0);
            this._tlpShowScanningWindows.Controls.Add(this._lblDisplayWindowCount, 1, 0);
            this._tlpShowScanningWindows.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpShowScanningWindows.Location = new System.Drawing.Point(3, 3);
            this._tlpShowScanningWindows.Name = "_tlpShowScanningWindows";
            this._tlpShowScanningWindows.RowCount = 1;
            this._tlpShowScanningWindows.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpShowScanningWindows.Size = new System.Drawing.Size(276, 57);
            this._tlpShowScanningWindows.TabIndex = 14;
            // 
            // _cbxShowScanningWindows
            // 
            this._cbxShowScanningWindows.AutoSize = true;
            this._cbxShowScanningWindows.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cbxShowScanningWindows.Location = new System.Drawing.Point(3, 3);
            this._cbxShowScanningWindows.Name = "_cbxShowScanningWindows";
            this._cbxShowScanningWindows.Size = new System.Drawing.Size(187, 51);
            this._cbxShowScanningWindows.TabIndex = 12;
            this._cbxShowScanningWindows.Text = "Show :";
            this._cbxShowScanningWindows.UseVisualStyleBackColor = true;
            this._cbxShowScanningWindows.CheckedChanged += new System.EventHandler(this._cbxShowScanningWindows_CheckedChanged);
            // 
            // _lblDisplayWindowCount
            // 
            this._lblDisplayWindowCount.AutoSize = true;
            this._lblDisplayWindowCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblDisplayWindowCount.Location = new System.Drawing.Point(196, 0);
            this._lblDisplayWindowCount.Name = "_lblDisplayWindowCount";
            this._lblDisplayWindowCount.Size = new System.Drawing.Size(77, 57);
            this._lblDisplayWindowCount.TabIndex = 1;
            this._lblDisplayWindowCount.Text = "-";
            this._lblDisplayWindowCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmScanningWindowGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 255);
            this.Controls.Add(this._tlpMainPanel);
            this.Name = "frmScanningWindowGenerator";
            this.Text = "frmScanningWindowGenerator";
            this._tlpMainPanel.ResumeLayout(false);
            this._tlpMinimumSize.ResumeLayout(false);
            this._tlpMinimumSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudChangeMinimumSize)).EndInit();
            this._tlpScaleStep.ResumeLayout(false);
            this._tlpScaleStep.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudChangeScaleStep)).EndInit();
            this._tlpTranslationStep.ResumeLayout(false);
            this._tlpTranslationStep.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudChangeVerticalStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudChangeHorizontalStep)).EndInit();
            this._tlpShowScanningWindows.ResumeLayout(false);
            this._tlpShowScanningWindows.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tlpMainPanel;
        private System.Windows.Forms.TableLayoutPanel _tlpMinimumSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown _nudChangeMinimumSize;
        private System.Windows.Forms.TableLayoutPanel _tlpScaleStep;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown _nudChangeScaleStep;
        private System.Windows.Forms.CheckBox _cbxShowScanningWindows;
        private System.Windows.Forms.TableLayoutPanel _tlpTranslationStep;
        private System.Windows.Forms.NumericUpDown _nudChangeVerticalStep;
        private System.Windows.Forms.Label _lblCenter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown _nudChangeHorizontalStep;
        private System.Windows.Forms.Label _lblDisplayWindowCount;
        private System.Windows.Forms.TableLayoutPanel _tlpShowScanningWindows;
    }
}