namespace TLD.View.Learning
{
    partial class frmLearner
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
            this._tlpChangeSameSimilarityThreshold = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this._nudChangeSameSimilarityThreshold = new System.Windows.Forms.NumericUpDown();
            this._tlpChangeConservativeSimilarityThreshold = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this._nudChangeConservativeSimilarityThreshold = new System.Windows.Forms.NumericUpDown();
            this._gbxObjectModel = new System.Windows.Forms.GroupBox();
            this._tlpMainPanel.SuspendLayout();
            this._tlpChangeSameSimilarityThreshold.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudChangeSameSimilarityThreshold)).BeginInit();
            this._tlpChangeConservativeSimilarityThreshold.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudChangeConservativeSimilarityThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // _tlpMainPanel
            // 
            this._tlpMainPanel.ColumnCount = 1;
            this._tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpMainPanel.Controls.Add(this._tlpChangeSameSimilarityThreshold, 0, 1);
            this._tlpMainPanel.Controls.Add(this._tlpChangeConservativeSimilarityThreshold, 0, 2);
            this._tlpMainPanel.Controls.Add(this._gbxObjectModel, 0, 0);
            this._tlpMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpMainPanel.Location = new System.Drawing.Point(0, 0);
            this._tlpMainPanel.Name = "_tlpMainPanel";
            this._tlpMainPanel.RowCount = 3;
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this._tlpMainPanel.Size = new System.Drawing.Size(318, 531);
            this._tlpMainPanel.TabIndex = 0;
            // 
            // _tlpChangeSameSimilarityThreshold
            // 
            this._tlpChangeSameSimilarityThreshold.ColumnCount = 2;
            this._tlpChangeSameSimilarityThreshold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this._tlpChangeSameSimilarityThreshold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpChangeSameSimilarityThreshold.Controls.Add(this.label1, 0, 0);
            this._tlpChangeSameSimilarityThreshold.Controls.Add(this._nudChangeSameSimilarityThreshold, 1, 0);
            this._tlpChangeSameSimilarityThreshold.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpChangeSameSimilarityThreshold.Location = new System.Drawing.Point(3, 480);
            this._tlpChangeSameSimilarityThreshold.Name = "_tlpChangeSameSimilarityThreshold";
            this._tlpChangeSameSimilarityThreshold.RowCount = 1;
            this._tlpChangeSameSimilarityThreshold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpChangeSameSimilarityThreshold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._tlpChangeSameSimilarityThreshold.Size = new System.Drawing.Size(312, 20);
            this._tlpChangeSameSimilarityThreshold.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Same Sim. Threshold";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _nudChangeSameSimilarityThreshold
            // 
            this._nudChangeSameSimilarityThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._nudChangeSameSimilarityThreshold.DecimalPlaces = 2;
            this._nudChangeSameSimilarityThreshold.Location = new System.Drawing.Point(221, 3);
            this._nudChangeSameSimilarityThreshold.Name = "_nudChangeSameSimilarityThreshold";
            this._nudChangeSameSimilarityThreshold.Size = new System.Drawing.Size(88, 22);
            this._nudChangeSameSimilarityThreshold.TabIndex = 1;
            this._nudChangeSameSimilarityThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._nudChangeSameSimilarityThreshold.ValueChanged += new System.EventHandler(this._nudChangeSameSimilarityThreshold_ValueChanged);
            // 
            // _tlpChangeConservativeSimilarityThreshold
            // 
            this._tlpChangeConservativeSimilarityThreshold.ColumnCount = 2;
            this._tlpChangeConservativeSimilarityThreshold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this._tlpChangeConservativeSimilarityThreshold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpChangeConservativeSimilarityThreshold.Controls.Add(this.label3, 0, 0);
            this._tlpChangeConservativeSimilarityThreshold.Controls.Add(this._nudChangeConservativeSimilarityThreshold, 1, 0);
            this._tlpChangeConservativeSimilarityThreshold.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpChangeConservativeSimilarityThreshold.Location = new System.Drawing.Point(3, 506);
            this._tlpChangeConservativeSimilarityThreshold.Name = "_tlpChangeConservativeSimilarityThreshold";
            this._tlpChangeConservativeSimilarityThreshold.RowCount = 1;
            this._tlpChangeConservativeSimilarityThreshold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpChangeConservativeSimilarityThreshold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this._tlpChangeConservativeSimilarityThreshold.Size = new System.Drawing.Size(312, 22);
            this._tlpChangeConservativeSimilarityThreshold.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cons. Sim. Threshold";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _nudChangeConservativeSimilarityThreshold
            // 
            this._nudChangeConservativeSimilarityThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._nudChangeConservativeSimilarityThreshold.DecimalPlaces = 2;
            this._nudChangeConservativeSimilarityThreshold.Location = new System.Drawing.Point(221, 3);
            this._nudChangeConservativeSimilarityThreshold.Name = "_nudChangeConservativeSimilarityThreshold";
            this._nudChangeConservativeSimilarityThreshold.Size = new System.Drawing.Size(88, 22);
            this._nudChangeConservativeSimilarityThreshold.TabIndex = 1;
            this._nudChangeConservativeSimilarityThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._nudChangeConservativeSimilarityThreshold.ValueChanged += new System.EventHandler(this._nudChangeConservativeSimilarityThreshold_ValueChanged);
            // 
            // _gbxObjectModel
            // 
            this._gbxObjectModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gbxObjectModel.Location = new System.Drawing.Point(3, 3);
            this._gbxObjectModel.Name = "_gbxObjectModel";
            this._gbxObjectModel.Size = new System.Drawing.Size(312, 471);
            this._gbxObjectModel.TabIndex = 0;
            this._gbxObjectModel.TabStop = false;
            this._gbxObjectModel.Text = "Object Model";
            // 
            // frmLearner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 531);
            this.Controls.Add(this._tlpMainPanel);
            this.Name = "frmLearner";
            this.Text = "frmLearning";
            this._tlpMainPanel.ResumeLayout(false);
            this._tlpChangeSameSimilarityThreshold.ResumeLayout(false);
            this._tlpChangeSameSimilarityThreshold.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudChangeSameSimilarityThreshold)).EndInit();
            this._tlpChangeConservativeSimilarityThreshold.ResumeLayout(false);
            this._tlpChangeConservativeSimilarityThreshold.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudChangeConservativeSimilarityThreshold)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tlpMainPanel;
        private System.Windows.Forms.GroupBox _gbxObjectModel;
        private System.Windows.Forms.TableLayoutPanel _tlpChangeConservativeSimilarityThreshold;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown _nudChangeConservativeSimilarityThreshold;
        private System.Windows.Forms.TableLayoutPanel _tlpChangeSameSimilarityThreshold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown _nudChangeSameSimilarityThreshold;
    }
}