namespace TLD.View.Detection
{
    partial class frmPixelComparisons
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
            this._flpPixelComparisons = new System.Windows.Forms.FlowLayoutPanel();
            this._btnReschedulePixelComparisons = new System.Windows.Forms.Button();
            this._tlpMainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tlpMainPanel
            // 
            this._tlpMainPanel.ColumnCount = 1;
            this._tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpMainPanel.Controls.Add(this._flpPixelComparisons, 0, 0);
            this._tlpMainPanel.Controls.Add(this._btnReschedulePixelComparisons, 0, 1);
            this._tlpMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpMainPanel.Location = new System.Drawing.Point(0, 0);
            this._tlpMainPanel.Name = "_tlpMainPanel";
            this._tlpMainPanel.RowCount = 2;
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.33334F));
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this._tlpMainPanel.Size = new System.Drawing.Size(646, 264);
            this._tlpMainPanel.TabIndex = 0;
            // 
            // _flpPixelComparisons
            // 
            this._flpPixelComparisons.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flpPixelComparisons.Location = new System.Drawing.Point(3, 3);
            this._flpPixelComparisons.Name = "_flpPixelComparisons";
            this._flpPixelComparisons.Size = new System.Drawing.Size(640, 213);
            this._flpPixelComparisons.TabIndex = 0;
            // 
            // _btnReschedulePixelComparisons
            // 
            this._btnReschedulePixelComparisons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this._btnReschedulePixelComparisons.Location = new System.Drawing.Point(263, 222);
            this._btnReschedulePixelComparisons.Name = "_btnReschedulePixelComparisons";
            this._btnReschedulePixelComparisons.Size = new System.Drawing.Size(119, 39);
            this._btnReschedulePixelComparisons.TabIndex = 1;
            this._btnReschedulePixelComparisons.Text = "Reschedule";
            this._btnReschedulePixelComparisons.UseVisualStyleBackColor = true;
            this._btnReschedulePixelComparisons.Click += new System.EventHandler(this._btnGenerateNewPixelComparisons_Click);
            // 
            // frmPixelComparisons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(646, 264);
            this.Controls.Add(this._tlpMainPanel);
            this.Name = "frmPixelComparisons";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pixel Comparisons";
            this._tlpMainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tlpMainPanel;
        private System.Windows.Forms.FlowLayoutPanel _flpPixelComparisons;
        private System.Windows.Forms.Button _btnReschedulePixelComparisons;

    }
}