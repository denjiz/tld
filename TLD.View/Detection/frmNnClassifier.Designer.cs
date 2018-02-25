namespace TLD.View.Detection
{
    partial class frmNnClassifier
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
            this._tlpRelativeSimilarity = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this._nudRelativeSimilarityThreshold = new System.Windows.Forms.NumericUpDown();
            this._tlpShowAcceptedWindows = new System.Windows.Forms.TableLayoutPanel();
            this._cbxShowAcceptedWindows = new System.Windows.Forms.CheckBox();
            this._lblShowAcceptedWindowCount = new System.Windows.Forms.Label();
            this._tlpMainPanel.SuspendLayout();
            this._tlpRelativeSimilarity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudRelativeSimilarityThreshold)).BeginInit();
            this._tlpShowAcceptedWindows.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tlpMainPanel
            // 
            this._tlpMainPanel.ColumnCount = 1;
            this._tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpMainPanel.Controls.Add(this._tlpRelativeSimilarity, 0, 1);
            this._tlpMainPanel.Controls.Add(this._tlpShowAcceptedWindows, 0, 0);
            this._tlpMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpMainPanel.Location = new System.Drawing.Point(0, 0);
            this._tlpMainPanel.Name = "_tlpMainPanel";
            this._tlpMainPanel.RowCount = 2;
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpMainPanel.Size = new System.Drawing.Size(282, 172);
            this._tlpMainPanel.TabIndex = 0;
            // 
            // _tlpRelativeSimilarity
            // 
            this._tlpRelativeSimilarity.ColumnCount = 2;
            this._tlpRelativeSimilarity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this._tlpRelativeSimilarity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpRelativeSimilarity.Controls.Add(this.label3, 0, 0);
            this._tlpRelativeSimilarity.Controls.Add(this._nudRelativeSimilarityThreshold, 1, 0);
            this._tlpRelativeSimilarity.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpRelativeSimilarity.Location = new System.Drawing.Point(3, 89);
            this._tlpRelativeSimilarity.Name = "_tlpRelativeSimilarity";
            this._tlpRelativeSimilarity.RowCount = 1;
            this._tlpRelativeSimilarity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpRelativeSimilarity.Size = new System.Drawing.Size(276, 80);
            this._tlpRelativeSimilarity.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 80);
            this.label3.TabIndex = 0;
            this.label3.Text = "Rel. Sim. Threshold";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _nudRelativeSimilarityThreshold
            // 
            this._nudRelativeSimilarityThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._nudRelativeSimilarityThreshold.DecimalPlaces = 2;
            this._nudRelativeSimilarityThreshold.Location = new System.Drawing.Point(196, 29);
            this._nudRelativeSimilarityThreshold.Name = "_nudRelativeSimilarityThreshold";
            this._nudRelativeSimilarityThreshold.Size = new System.Drawing.Size(77, 22);
            this._nudRelativeSimilarityThreshold.TabIndex = 1;
            this._nudRelativeSimilarityThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._nudRelativeSimilarityThreshold.ValueChanged += new System.EventHandler(this._nudRelativeSimilarityThreshold_ValueChanged);
            // 
            // _tlpShowAcceptedWindows
            // 
            this._tlpShowAcceptedWindows.ColumnCount = 2;
            this._tlpShowAcceptedWindows.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this._tlpShowAcceptedWindows.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpShowAcceptedWindows.Controls.Add(this._cbxShowAcceptedWindows, 0, 0);
            this._tlpShowAcceptedWindows.Controls.Add(this._lblShowAcceptedWindowCount, 1, 0);
            this._tlpShowAcceptedWindows.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpShowAcceptedWindows.Location = new System.Drawing.Point(3, 3);
            this._tlpShowAcceptedWindows.Name = "_tlpShowAcceptedWindows";
            this._tlpShowAcceptedWindows.RowCount = 1;
            this._tlpShowAcceptedWindows.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpShowAcceptedWindows.Size = new System.Drawing.Size(276, 80);
            this._tlpShowAcceptedWindows.TabIndex = 5;
            // 
            // _cbxShowAcceptedWindows
            // 
            this._cbxShowAcceptedWindows.AutoSize = true;
            this._cbxShowAcceptedWindows.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cbxShowAcceptedWindows.Location = new System.Drawing.Point(3, 3);
            this._cbxShowAcceptedWindows.Name = "_cbxShowAcceptedWindows";
            this._cbxShowAcceptedWindows.Size = new System.Drawing.Size(187, 74);
            this._cbxShowAcceptedWindows.TabIndex = 0;
            this._cbxShowAcceptedWindows.Text = "Show Windows :";
            this._cbxShowAcceptedWindows.UseVisualStyleBackColor = true;
            this._cbxShowAcceptedWindows.CheckedChanged += new System.EventHandler(this._cbxShowAcceptedWindows_CheckedChanged);
            // 
            // _lblShowAcceptedWindowCount
            // 
            this._lblShowAcceptedWindowCount.AutoSize = true;
            this._lblShowAcceptedWindowCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblShowAcceptedWindowCount.Location = new System.Drawing.Point(196, 0);
            this._lblShowAcceptedWindowCount.Name = "_lblShowAcceptedWindowCount";
            this._lblShowAcceptedWindowCount.Size = new System.Drawing.Size(77, 80);
            this._lblShowAcceptedWindowCount.TabIndex = 1;
            this._lblShowAcceptedWindowCount.Text = "-";
            this._lblShowAcceptedWindowCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmNnClassifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 172);
            this.Controls.Add(this._tlpMainPanel);
            this.Name = "frmNnClassifier";
            this.Text = "frmNnClassifier";
            this._tlpMainPanel.ResumeLayout(false);
            this._tlpRelativeSimilarity.ResumeLayout(false);
            this._tlpRelativeSimilarity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudRelativeSimilarityThreshold)).EndInit();
            this._tlpShowAcceptedWindows.ResumeLayout(false);
            this._tlpShowAcceptedWindows.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tlpMainPanel;
        private System.Windows.Forms.TableLayoutPanel _tlpShowAcceptedWindows;
        private System.Windows.Forms.CheckBox _cbxShowAcceptedWindows;
        private System.Windows.Forms.Label _lblShowAcceptedWindowCount;
        private System.Windows.Forms.TableLayoutPanel _tlpRelativeSimilarity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown _nudRelativeSimilarityThreshold;
    }
}