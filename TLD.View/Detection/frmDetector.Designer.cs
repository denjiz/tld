namespace TLD.View
{
    partial class frmDetector
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
            this._gbxScanningWindows = new System.Windows.Forms.GroupBox();
            this._gbxCascadedClassifier = new System.Windows.Forms.GroupBox();
            this._tlpMainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tlpMainPanel
            // 
            this._tlpMainPanel.ColumnCount = 1;
            this._tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpMainPanel.Controls.Add(this._gbxScanningWindows, 0, 0);
            this._tlpMainPanel.Controls.Add(this._gbxCascadedClassifier, 0, 1);
            this._tlpMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpMainPanel.Location = new System.Drawing.Point(0, 0);
            this._tlpMainPanel.Name = "_tlpMainPanel";
            this._tlpMainPanel.RowCount = 2;
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.34823F));
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.65177F));
            this._tlpMainPanel.Size = new System.Drawing.Size(289, 649);
            this._tlpMainPanel.TabIndex = 0;
            // 
            // _gbxScanningWindows
            // 
            this._gbxScanningWindows.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gbxScanningWindows.Location = new System.Drawing.Point(3, 3);
            this._gbxScanningWindows.Name = "_gbxScanningWindows";
            this._gbxScanningWindows.Size = new System.Drawing.Size(283, 165);
            this._gbxScanningWindows.TabIndex = 0;
            this._gbxScanningWindows.TabStop = false;
            this._gbxScanningWindows.Text = "Scanning Windows";
            // 
            // _gbxCascadedClassifier
            // 
            this._gbxCascadedClassifier.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gbxCascadedClassifier.Location = new System.Drawing.Point(3, 174);
            this._gbxCascadedClassifier.Name = "_gbxCascadedClassifier";
            this._gbxCascadedClassifier.Size = new System.Drawing.Size(283, 472);
            this._gbxCascadedClassifier.TabIndex = 1;
            this._gbxCascadedClassifier.TabStop = false;
            this._gbxCascadedClassifier.Text = "Cascaded Classifier";
            // 
            // frmDetector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 649);
            this.Controls.Add(this._tlpMainPanel);
            this.Name = "frmDetector";
            this.Text = "frmZdenekDetector";
            this._tlpMainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tlpMainPanel;
        private System.Windows.Forms.GroupBox _gbxScanningWindows;
        private System.Windows.Forms.GroupBox _gbxCascadedClassifier;

    }
}