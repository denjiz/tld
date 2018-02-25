namespace TLD.View
{
    partial class frmNccCalculator
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
            this._flpImagePath = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this._tbxImagePath = new System.Windows.Forms.TextBox();
            this._btnOpenImage = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._pnlImage = new System.Windows.Forms.Panel();
            this._tlpPatches = new System.Windows.Forms.TableLayoutPanel();
            this._tlpPatch2 = new System.Windows.Forms.TableLayoutPanel();
            this._pnlPatch2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this._tlpNormalizedPatchSize = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this._flpNormalizedPatchSize = new System.Windows.Forms.FlowLayoutPanel();
            this._nudNormalizedWidth = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this._nudNormalizedHeight = new System.Windows.Forms.NumericUpDown();
            this._tlpPatch1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this._pnlPatch1 = new System.Windows.Forms.Panel();
            this._flpNcc = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this._lblNcc = new System.Windows.Forms.Label();
            this._tlpMainPanel.SuspendLayout();
            this._flpImagePath.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this._tlpPatches.SuspendLayout();
            this._tlpPatch2.SuspendLayout();
            this._tlpNormalizedPatchSize.SuspendLayout();
            this._flpNormalizedPatchSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudNormalizedWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudNormalizedHeight)).BeginInit();
            this._tlpPatch1.SuspendLayout();
            this._flpNcc.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tlpMainPanel
            // 
            this._tlpMainPanel.ColumnCount = 1;
            this._tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpMainPanel.Controls.Add(this._flpImagePath, 0, 0);
            this._tlpMainPanel.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this._tlpMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpMainPanel.Location = new System.Drawing.Point(0, 0);
            this._tlpMainPanel.Name = "_tlpMainPanel";
            this._tlpMainPanel.RowCount = 2;
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this._tlpMainPanel.Size = new System.Drawing.Size(1196, 624);
            this._tlpMainPanel.TabIndex = 0;
            // 
            // _flpImagePath
            // 
            this._flpImagePath.Controls.Add(this.label1);
            this._flpImagePath.Controls.Add(this._tbxImagePath);
            this._flpImagePath.Controls.Add(this._btnOpenImage);
            this._flpImagePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flpImagePath.Location = new System.Drawing.Point(3, 3);
            this._flpImagePath.Name = "_flpImagePath";
            this._flpImagePath.Size = new System.Drawing.Size(1190, 56);
            this._flpImagePath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Image:";
            // 
            // _tbxImagePath
            // 
            this._tbxImagePath.Location = new System.Drawing.Point(59, 3);
            this._tbxImagePath.Name = "_tbxImagePath";
            this._tbxImagePath.Size = new System.Drawing.Size(414, 22);
            this._tbxImagePath.TabIndex = 1;
            // 
            // _btnOpenImage
            // 
            this._btnOpenImage.Location = new System.Drawing.Point(479, 3);
            this._btnOpenImage.Name = "_btnOpenImage";
            this._btnOpenImage.Size = new System.Drawing.Size(109, 27);
            this._btnOpenImage.TabIndex = 2;
            this._btnOpenImage.Text = "Open...";
            this._btnOpenImage.UseVisualStyleBackColor = true;
            this._btnOpenImage.Click += new System.EventHandler(this._btnOpenImage_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this._pnlImage, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._tlpPatches, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 65);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1190, 556);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // _pnlImage
            // 
            this._pnlImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlImage.Location = new System.Drawing.Point(3, 3);
            this._pnlImage.Name = "_pnlImage";
            this._pnlImage.Size = new System.Drawing.Size(946, 550);
            this._pnlImage.TabIndex = 0;
            this._pnlImage.Paint += new System.Windows.Forms.PaintEventHandler(this._pnlImage_Paint);
            this._pnlImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this._pnlImage_MouseDown);
            this._pnlImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this._pnlImage_MouseMove);
            this._pnlImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this._pnlImage_MouseUp);
            // 
            // _tlpPatches
            // 
            this._tlpPatches.ColumnCount = 1;
            this._tlpPatches.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpPatches.Controls.Add(this._tlpPatch2, 0, 2);
            this._tlpPatches.Controls.Add(this._tlpNormalizedPatchSize, 0, 0);
            this._tlpPatches.Controls.Add(this._tlpPatch1, 0, 1);
            this._tlpPatches.Controls.Add(this._flpNcc, 0, 3);
            this._tlpPatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpPatches.Location = new System.Drawing.Point(955, 3);
            this._tlpPatches.Name = "_tlpPatches";
            this._tlpPatches.RowCount = 4;
            this._tlpPatches.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this._tlpPatches.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpPatches.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpPatches.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tlpPatches.Size = new System.Drawing.Size(232, 550);
            this._tlpPatches.TabIndex = 1;
            // 
            // _tlpPatch2
            // 
            this._tlpPatch2.ColumnCount = 1;
            this._tlpPatch2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpPatch2.Controls.Add(this._pnlPatch2, 0, 1);
            this._tlpPatch2.Controls.Add(this.label5, 0, 0);
            this._tlpPatch2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpPatch2.Location = new System.Drawing.Point(3, 250);
            this._tlpPatch2.Name = "_tlpPatch2";
            this._tlpPatch2.RowCount = 2;
            this._tlpPatch2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._tlpPatch2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this._tlpPatch2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._tlpPatch2.Size = new System.Drawing.Size(226, 159);
            this._tlpPatch2.TabIndex = 5;
            // 
            // _pnlPatch2
            // 
            this._pnlPatch2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlPatch2.Location = new System.Drawing.Point(3, 18);
            this._pnlPatch2.Name = "_pnlPatch2";
            this._pnlPatch2.Size = new System.Drawing.Size(220, 138);
            this._pnlPatch2.TabIndex = 2;
            this._pnlPatch2.Paint += new System.Windows.Forms.PaintEventHandler(this._pnlPatch2_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Patch 2";
            // 
            // _tlpNormalizedPatchSize
            // 
            this._tlpNormalizedPatchSize.ColumnCount = 1;
            this._tlpNormalizedPatchSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpNormalizedPatchSize.Controls.Add(this.label2, 0, 0);
            this._tlpNormalizedPatchSize.Controls.Add(this._flpNormalizedPatchSize, 0, 1);
            this._tlpNormalizedPatchSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpNormalizedPatchSize.Location = new System.Drawing.Point(3, 3);
            this._tlpNormalizedPatchSize.Name = "_tlpNormalizedPatchSize";
            this._tlpNormalizedPatchSize.RowCount = 2;
            this._tlpNormalizedPatchSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpNormalizedPatchSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpNormalizedPatchSize.Size = new System.Drawing.Size(226, 76);
            this._tlpNormalizedPatchSize.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Normalized Patch Size:";
            // 
            // _flpNormalizedPatchSize
            // 
            this._flpNormalizedPatchSize.Controls.Add(this._nudNormalizedWidth);
            this._flpNormalizedPatchSize.Controls.Add(this.label3);
            this._flpNormalizedPatchSize.Controls.Add(this._nudNormalizedHeight);
            this._flpNormalizedPatchSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flpNormalizedPatchSize.Location = new System.Drawing.Point(3, 41);
            this._flpNormalizedPatchSize.Name = "_flpNormalizedPatchSize";
            this._flpNormalizedPatchSize.Size = new System.Drawing.Size(220, 32);
            this._flpNormalizedPatchSize.TabIndex = 1;
            // 
            // _nudNormalizedWidth
            // 
            this._nudNormalizedWidth.Location = new System.Drawing.Point(3, 3);
            this._nudNormalizedWidth.Name = "_nudNormalizedWidth";
            this._nudNormalizedWidth.Size = new System.Drawing.Size(52, 22);
            this._nudNormalizedWidth.TabIndex = 0;
            this._nudNormalizedWidth.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "x";
            // 
            // _nudNormalizedHeight
            // 
            this._nudNormalizedHeight.Location = new System.Drawing.Point(81, 3);
            this._nudNormalizedHeight.Name = "_nudNormalizedHeight";
            this._nudNormalizedHeight.Size = new System.Drawing.Size(52, 22);
            this._nudNormalizedHeight.TabIndex = 2;
            this._nudNormalizedHeight.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // _tlpPatch1
            // 
            this._tlpPatch1.ColumnCount = 1;
            this._tlpPatch1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpPatch1.Controls.Add(this.label4, 0, 0);
            this._tlpPatch1.Controls.Add(this._pnlPatch1, 0, 1);
            this._tlpPatch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpPatch1.Location = new System.Drawing.Point(3, 85);
            this._tlpPatch1.Name = "_tlpPatch1";
            this._tlpPatch1.RowCount = 2;
            this._tlpPatch1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._tlpPatch1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this._tlpPatch1.Size = new System.Drawing.Size(226, 159);
            this._tlpPatch1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Patch 1";
            // 
            // _pnlPatch1
            // 
            this._pnlPatch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlPatch1.Location = new System.Drawing.Point(3, 18);
            this._pnlPatch1.Name = "_pnlPatch1";
            this._pnlPatch1.Size = new System.Drawing.Size(220, 138);
            this._pnlPatch1.TabIndex = 1;
            this._pnlPatch1.Paint += new System.Windows.Forms.PaintEventHandler(this._pnlPatch1_Paint);
            // 
            // _flpNcc
            // 
            this._flpNcc.Controls.Add(this.label6);
            this._flpNcc.Controls.Add(this._lblNcc);
            this._flpNcc.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flpNcc.Location = new System.Drawing.Point(3, 415);
            this._flpNcc.Name = "_flpNcc";
            this._flpNcc.Size = new System.Drawing.Size(226, 132);
            this._flpNcc.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "NCC: ";
            // 
            // _lblNcc
            // 
            this._lblNcc.AutoSize = true;
            this._lblNcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._lblNcc.Location = new System.Drawing.Point(76, 0);
            this._lblNcc.Name = "_lblNcc";
            this._lblNcc.Size = new System.Drawing.Size(19, 25);
            this._lblNcc.TabIndex = 1;
            this._lblNcc.Text = "-";
            // 
            // frmNccCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 624);
            this.Controls.Add(this._tlpMainPanel);
            this.Name = "frmNccCalculator";
            this.Text = "NCC Calculator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNccCalculator_FormClosing);
            this._tlpMainPanel.ResumeLayout(false);
            this._flpImagePath.ResumeLayout(false);
            this._flpImagePath.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this._tlpPatches.ResumeLayout(false);
            this._tlpPatch2.ResumeLayout(false);
            this._tlpPatch2.PerformLayout();
            this._tlpNormalizedPatchSize.ResumeLayout(false);
            this._tlpNormalizedPatchSize.PerformLayout();
            this._flpNormalizedPatchSize.ResumeLayout(false);
            this._flpNormalizedPatchSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudNormalizedWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudNormalizedHeight)).EndInit();
            this._tlpPatch1.ResumeLayout(false);
            this._tlpPatch1.PerformLayout();
            this._flpNcc.ResumeLayout(false);
            this._flpNcc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tlpMainPanel;
        private System.Windows.Forms.FlowLayoutPanel _flpImagePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tbxImagePath;
        private System.Windows.Forms.Button _btnOpenImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel _pnlImage;
        private System.Windows.Forms.TableLayoutPanel _tlpPatches;
        private System.Windows.Forms.TableLayoutPanel _tlpNormalizedPatchSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel _flpNormalizedPatchSize;
        private System.Windows.Forms.NumericUpDown _nudNormalizedWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown _nudNormalizedHeight;
        private System.Windows.Forms.TableLayoutPanel _tlpPatch2;
        private System.Windows.Forms.Panel _pnlPatch2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel _tlpPatch1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel _pnlPatch1;
        private System.Windows.Forms.FlowLayoutPanel _flpNcc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label _lblNcc;
    }
}