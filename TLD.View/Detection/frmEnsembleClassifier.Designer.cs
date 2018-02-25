namespace TLD.View.Detection
{
    partial class frmEnsembleClassifier
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
            this._tlpMaxComparisonsPerClass = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this._nudChangeMaxComparisonsPerClassifier = new System.Windows.Forms.NumericUpDown();
            this._tlpNumberOfBaseClassifiers = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this._nudChangeNumberOfBaseClassifiers = new System.Windows.Forms.NumericUpDown();
            this._btnPixelComparisons = new System.Windows.Forms.Button();
            this._tlpGaussianSigma = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this._nudChangeGaussianSigma = new System.Windows.Forms.NumericUpDown();
            this._tlpShowAcceptedWindows = new System.Windows.Forms.TableLayoutPanel();
            this._cbxShowAcceptedWindows = new System.Windows.Forms.CheckBox();
            this._lblShowAcceptedWindowCount = new System.Windows.Forms.Label();
            this._tlpMainPanel.SuspendLayout();
            this._tlpMaxComparisonsPerClass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudChangeMaxComparisonsPerClassifier)).BeginInit();
            this._tlpNumberOfBaseClassifiers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudChangeNumberOfBaseClassifiers)).BeginInit();
            this._tlpGaussianSigma.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudChangeGaussianSigma)).BeginInit();
            this._tlpShowAcceptedWindows.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tlpMainPanel
            // 
            this._tlpMainPanel.ColumnCount = 1;
            this._tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpMainPanel.Controls.Add(this._tlpMaxComparisonsPerClass, 0, 3);
            this._tlpMainPanel.Controls.Add(this._tlpNumberOfBaseClassifiers, 0, 2);
            this._tlpMainPanel.Controls.Add(this._btnPixelComparisons, 0, 4);
            this._tlpMainPanel.Controls.Add(this._tlpGaussianSigma, 0, 1);
            this._tlpMainPanel.Controls.Add(this._tlpShowAcceptedWindows, 0, 0);
            this._tlpMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpMainPanel.Location = new System.Drawing.Point(0, 0);
            this._tlpMainPanel.Name = "_tlpMainPanel";
            this._tlpMainPanel.RowCount = 5;
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._tlpMainPanel.Size = new System.Drawing.Size(282, 255);
            this._tlpMainPanel.TabIndex = 0;
            // 
            // _tlpMaxComparisonsPerClass
            // 
            this._tlpMaxComparisonsPerClass.ColumnCount = 2;
            this._tlpMaxComparisonsPerClass.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this._tlpMaxComparisonsPerClass.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpMaxComparisonsPerClass.Controls.Add(this.label2, 0, 0);
            this._tlpMaxComparisonsPerClass.Controls.Add(this._nudChangeMaxComparisonsPerClassifier, 1, 0);
            this._tlpMaxComparisonsPerClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpMaxComparisonsPerClass.Location = new System.Drawing.Point(3, 156);
            this._tlpMaxComparisonsPerClass.Name = "_tlpMaxComparisonsPerClass";
            this._tlpMaxComparisonsPerClass.RowCount = 1;
            this._tlpMaxComparisonsPerClass.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpMaxComparisonsPerClass.Size = new System.Drawing.Size(276, 45);
            this._tlpMaxComparisonsPerClass.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 45);
            this.label2.TabIndex = 0;
            this.label2.Text = "MPCPC";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _nudChangeMaxComparisonsPerClassifier
            // 
            this._nudChangeMaxComparisonsPerClassifier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._nudChangeMaxComparisonsPerClassifier.Location = new System.Drawing.Point(196, 11);
            this._nudChangeMaxComparisonsPerClassifier.Name = "_nudChangeMaxComparisonsPerClassifier";
            this._nudChangeMaxComparisonsPerClassifier.Size = new System.Drawing.Size(77, 22);
            this._nudChangeMaxComparisonsPerClassifier.TabIndex = 1;
            this._nudChangeMaxComparisonsPerClassifier.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._nudChangeMaxComparisonsPerClassifier.ValueChanged += new System.EventHandler(this._nudChangeMaxComparisonsPerClassifier_ValueChanged);
            // 
            // _tlpNumberOfBaseClassifiers
            // 
            this._tlpNumberOfBaseClassifiers.ColumnCount = 2;
            this._tlpNumberOfBaseClassifiers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this._tlpNumberOfBaseClassifiers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpNumberOfBaseClassifiers.Controls.Add(this.label1, 0, 0);
            this._tlpNumberOfBaseClassifiers.Controls.Add(this._nudChangeNumberOfBaseClassifiers, 1, 0);
            this._tlpNumberOfBaseClassifiers.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpNumberOfBaseClassifiers.Location = new System.Drawing.Point(3, 105);
            this._tlpNumberOfBaseClassifiers.Name = "_tlpNumberOfBaseClassifiers";
            this._tlpNumberOfBaseClassifiers.RowCount = 1;
            this._tlpNumberOfBaseClassifiers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpNumberOfBaseClassifiers.Size = new System.Drawing.Size(276, 45);
            this._tlpNumberOfBaseClassifiers.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Base Classifiers";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _nudChangeNumberOfBaseClassifiers
            // 
            this._nudChangeNumberOfBaseClassifiers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._nudChangeNumberOfBaseClassifiers.Location = new System.Drawing.Point(196, 11);
            this._nudChangeNumberOfBaseClassifiers.Name = "_nudChangeNumberOfBaseClassifiers";
            this._nudChangeNumberOfBaseClassifiers.Size = new System.Drawing.Size(77, 22);
            this._nudChangeNumberOfBaseClassifiers.TabIndex = 1;
            this._nudChangeNumberOfBaseClassifiers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._nudChangeNumberOfBaseClassifiers.ValueChanged += new System.EventHandler(this._nudChangeNumberOfBaseClassifiersClassifiers_ValueChanged);
            // 
            // _btnPixelComparisons
            // 
            this._btnPixelComparisons.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnPixelComparisons.Location = new System.Drawing.Point(3, 207);
            this._btnPixelComparisons.Name = "_btnPixelComparisons";
            this._btnPixelComparisons.Size = new System.Drawing.Size(276, 45);
            this._btnPixelComparisons.TabIndex = 2;
            this._btnPixelComparisons.Text = "Pixel Comparisons...";
            this._btnPixelComparisons.UseVisualStyleBackColor = true;
            this._btnPixelComparisons.Click += new System.EventHandler(this._btnPixelComparisons_Click);
            // 
            // _tlpGaussianSigma
            // 
            this._tlpGaussianSigma.ColumnCount = 2;
            this._tlpGaussianSigma.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this._tlpGaussianSigma.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpGaussianSigma.Controls.Add(this.label3, 0, 0);
            this._tlpGaussianSigma.Controls.Add(this._nudChangeGaussianSigma, 1, 0);
            this._tlpGaussianSigma.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpGaussianSigma.Location = new System.Drawing.Point(3, 54);
            this._tlpGaussianSigma.Name = "_tlpGaussianSigma";
            this._tlpGaussianSigma.RowCount = 1;
            this._tlpGaussianSigma.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpGaussianSigma.Size = new System.Drawing.Size(276, 45);
            this._tlpGaussianSigma.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 45);
            this.label3.TabIndex = 0;
            this.label3.Text = "Gaussian Sigma";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _nudChangeGaussianSigma
            // 
            this._nudChangeGaussianSigma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._nudChangeGaussianSigma.DecimalPlaces = 2;
            this._nudChangeGaussianSigma.Location = new System.Drawing.Point(196, 11);
            this._nudChangeGaussianSigma.Name = "_nudChangeGaussianSigma";
            this._nudChangeGaussianSigma.Size = new System.Drawing.Size(77, 22);
            this._nudChangeGaussianSigma.TabIndex = 1;
            this._nudChangeGaussianSigma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._nudChangeGaussianSigma.ValueChanged += new System.EventHandler(this._nudChangeGaussianSigma_ValueChanged);
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
            this._tlpShowAcceptedWindows.Size = new System.Drawing.Size(276, 45);
            this._tlpShowAcceptedWindows.TabIndex = 4;
            // 
            // _cbxShowAcceptedWindows
            // 
            this._cbxShowAcceptedWindows.AutoSize = true;
            this._cbxShowAcceptedWindows.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cbxShowAcceptedWindows.Location = new System.Drawing.Point(3, 3);
            this._cbxShowAcceptedWindows.Name = "_cbxShowAcceptedWindows";
            this._cbxShowAcceptedWindows.Size = new System.Drawing.Size(187, 39);
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
            this._lblShowAcceptedWindowCount.Size = new System.Drawing.Size(77, 45);
            this._lblShowAcceptedWindowCount.TabIndex = 1;
            this._lblShowAcceptedWindowCount.Text = "-";
            this._lblShowAcceptedWindowCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmEnsembleClassifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 255);
            this.Controls.Add(this._tlpMainPanel);
            this.Name = "frmEnsembleClassifier";
            this.Text = "frmEnsembleClassifier";
            this._tlpMainPanel.ResumeLayout(false);
            this._tlpMaxComparisonsPerClass.ResumeLayout(false);
            this._tlpMaxComparisonsPerClass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudChangeMaxComparisonsPerClassifier)).EndInit();
            this._tlpNumberOfBaseClassifiers.ResumeLayout(false);
            this._tlpNumberOfBaseClassifiers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudChangeNumberOfBaseClassifiers)).EndInit();
            this._tlpGaussianSigma.ResumeLayout(false);
            this._tlpGaussianSigma.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudChangeGaussianSigma)).EndInit();
            this._tlpShowAcceptedWindows.ResumeLayout(false);
            this._tlpShowAcceptedWindows.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tlpMainPanel;
        private System.Windows.Forms.TableLayoutPanel _tlpMaxComparisonsPerClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown _nudChangeMaxComparisonsPerClassifier;
        private System.Windows.Forms.TableLayoutPanel _tlpNumberOfBaseClassifiers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown _nudChangeNumberOfBaseClassifiers;
        private System.Windows.Forms.Button _btnPixelComparisons;
        private System.Windows.Forms.TableLayoutPanel _tlpGaussianSigma;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown _nudChangeGaussianSigma;
        private System.Windows.Forms.TableLayoutPanel _tlpShowAcceptedWindows;
        private System.Windows.Forms.CheckBox _cbxShowAcceptedWindows;
        private System.Windows.Forms.Label _lblShowAcceptedWindowCount;
    }
}