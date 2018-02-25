namespace TLD.View.App
{
    partial class frmEvaluation
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
            this._flpRequiredOverlap = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this._nudRequiredOverlap = new System.Windows.Forms.NumericUpDown();
            this._tlpStatistics = new System.Windows.Forms.TableLayoutPanel();
            this._lblRecall = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this._lblTruePositives = new System.Windows.Forms.Label();
            this._lblFalsePositives = new System.Windows.Forms.Label();
            this._lblTrueNegatives = new System.Windows.Forms.Label();
            this._lblFalseNegatives = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._lblPrecision = new System.Windows.Forms.Label();
            this._tlpMainPanel.SuspendLayout();
            this._flpRequiredOverlap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudRequiredOverlap)).BeginInit();
            this._tlpStatistics.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tlpMainPanel
            // 
            this._tlpMainPanel.ColumnCount = 1;
            this._tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpMainPanel.Controls.Add(this._flpRequiredOverlap, 0, 0);
            this._tlpMainPanel.Controls.Add(this._tlpStatistics, 0, 1);
            this._tlpMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpMainPanel.Location = new System.Drawing.Point(0, 0);
            this._tlpMainPanel.Name = "_tlpMainPanel";
            this._tlpMainPanel.RowCount = 2;
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this._tlpMainPanel.Size = new System.Drawing.Size(519, 370);
            this._tlpMainPanel.TabIndex = 0;
            // 
            // _flpRequiredOverlap
            // 
            this._flpRequiredOverlap.Controls.Add(this.label1);
            this._flpRequiredOverlap.Controls.Add(this._nudRequiredOverlap);
            this._flpRequiredOverlap.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flpRequiredOverlap.Location = new System.Drawing.Point(3, 3);
            this._flpRequiredOverlap.Name = "_flpRequiredOverlap";
            this._flpRequiredOverlap.Size = new System.Drawing.Size(513, 31);
            this._flpRequiredOverlap.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Required Overlap:";
            // 
            // _nudRequiredOverlap
            // 
            this._nudRequiredOverlap.DecimalPlaces = 2;
            this._nudRequiredOverlap.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this._nudRequiredOverlap.Location = new System.Drawing.Point(133, 3);
            this._nudRequiredOverlap.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._nudRequiredOverlap.Name = "_nudRequiredOverlap";
            this._nudRequiredOverlap.Size = new System.Drawing.Size(72, 22);
            this._nudRequiredOverlap.TabIndex = 1;
            this._nudRequiredOverlap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._nudRequiredOverlap.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // _tlpStatistics
            // 
            this._tlpStatistics.ColumnCount = 2;
            this._tlpStatistics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpStatistics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpStatistics.Controls.Add(this._lblRecall, 1, 5);
            this._tlpStatistics.Controls.Add(this.label7, 0, 5);
            this._tlpStatistics.Controls.Add(this._lblTruePositives, 1, 0);
            this._tlpStatistics.Controls.Add(this._lblFalsePositives, 1, 1);
            this._tlpStatistics.Controls.Add(this._lblTrueNegatives, 1, 2);
            this._tlpStatistics.Controls.Add(this._lblFalseNegatives, 1, 3);
            this._tlpStatistics.Controls.Add(this.label5, 0, 3);
            this._tlpStatistics.Controls.Add(this.label2, 0, 0);
            this._tlpStatistics.Controls.Add(this.label3, 0, 1);
            this._tlpStatistics.Controls.Add(this.label4, 0, 2);
            this._tlpStatistics.Controls.Add(this.label6, 0, 4);
            this._tlpStatistics.Controls.Add(this._lblPrecision, 1, 4);
            this._tlpStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpStatistics.Location = new System.Drawing.Point(3, 40);
            this._tlpStatistics.Name = "_tlpStatistics";
            this._tlpStatistics.RowCount = 6;
            this._tlpStatistics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this._tlpStatistics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this._tlpStatistics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this._tlpStatistics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this._tlpStatistics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._tlpStatistics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._tlpStatistics.Size = new System.Drawing.Size(513, 327);
            this._tlpStatistics.TabIndex = 1;
            // 
            // _lblRecall
            // 
            this._lblRecall.AutoSize = true;
            this._lblRecall.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblRecall.Location = new System.Drawing.Point(259, 261);
            this._lblRecall.Name = "_lblRecall";
            this._lblRecall.Size = new System.Drawing.Size(251, 66);
            this._lblRecall.TabIndex = 12;
            this._lblRecall.Text = "-";
            this._lblRecall.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 261);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(250, 66);
            this.label7.TabIndex = 10;
            this.label7.Text = "Recall:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lblTruePositives
            // 
            this._lblTruePositives.AutoSize = true;
            this._lblTruePositives.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblTruePositives.Location = new System.Drawing.Point(259, 0);
            this._lblTruePositives.Name = "_lblTruePositives";
            this._lblTruePositives.Size = new System.Drawing.Size(251, 49);
            this._lblTruePositives.TabIndex = 8;
            this._lblTruePositives.Text = "-";
            this._lblTruePositives.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lblFalsePositives
            // 
            this._lblFalsePositives.AutoSize = true;
            this._lblFalsePositives.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblFalsePositives.Location = new System.Drawing.Point(259, 49);
            this._lblFalsePositives.Name = "_lblFalsePositives";
            this._lblFalsePositives.Size = new System.Drawing.Size(251, 49);
            this._lblFalsePositives.TabIndex = 5;
            this._lblFalsePositives.Text = "-";
            this._lblFalsePositives.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lblTrueNegatives
            // 
            this._lblTrueNegatives.AutoSize = true;
            this._lblTrueNegatives.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblTrueNegatives.Location = new System.Drawing.Point(259, 98);
            this._lblTrueNegatives.Name = "_lblTrueNegatives";
            this._lblTrueNegatives.Size = new System.Drawing.Size(251, 49);
            this._lblTrueNegatives.TabIndex = 6;
            this._lblTrueNegatives.Text = "-";
            this._lblTrueNegatives.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lblFalseNegatives
            // 
            this._lblFalseNegatives.AutoSize = true;
            this._lblFalseNegatives.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblFalseNegatives.Location = new System.Drawing.Point(259, 147);
            this._lblFalseNegatives.Name = "_lblFalseNegatives";
            this._lblFalseNegatives.Size = new System.Drawing.Size(251, 49);
            this._lblFalseNegatives.TabIndex = 7;
            this._lblFalseNegatives.Text = "-";
            this._lblFalseNegatives.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(250, 49);
            this.label5.TabIndex = 4;
            this.label5.Text = "False Negatives:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 49);
            this.label2.TabIndex = 1;
            this.label2.Text = "True Positives:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 49);
            this.label3.TabIndex = 2;
            this.label3.Text = "False Positives:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(250, 49);
            this.label4.TabIndex = 3;
            this.label4.Text = "True Negatives:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(250, 65);
            this.label6.TabIndex = 9;
            this.label6.Text = "Precision:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lblPrecision
            // 
            this._lblPrecision.AutoSize = true;
            this._lblPrecision.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblPrecision.Location = new System.Drawing.Point(259, 196);
            this._lblPrecision.Name = "_lblPrecision";
            this._lblPrecision.Size = new System.Drawing.Size(251, 65);
            this._lblPrecision.TabIndex = 11;
            this._lblPrecision.Text = "-";
            this._lblPrecision.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmEvaluation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 370);
            this.Controls.Add(this._tlpMainPanel);
            this.Name = "frmEvaluation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evaluation";
            this._tlpMainPanel.ResumeLayout(false);
            this._flpRequiredOverlap.ResumeLayout(false);
            this._flpRequiredOverlap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudRequiredOverlap)).EndInit();
            this._tlpStatistics.ResumeLayout(false);
            this._tlpStatistics.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tlpMainPanel;
        private System.Windows.Forms.FlowLayoutPanel _flpRequiredOverlap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown _nudRequiredOverlap;
        private System.Windows.Forms.TableLayoutPanel _tlpStatistics;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label _lblTruePositives;
        private System.Windows.Forms.Label _lblFalsePositives;
        private System.Windows.Forms.Label _lblTrueNegatives;
        private System.Windows.Forms.Label _lblFalseNegatives;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label _lblRecall;
        private System.Windows.Forms.Label _lblPrecision;
    }
}