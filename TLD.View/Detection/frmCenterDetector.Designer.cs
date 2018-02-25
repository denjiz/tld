namespace TLD.View
{
    partial class frmCenterDetector
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
            this._tlpBoundingBoxSize = new System.Windows.Forms.TableLayoutPanel();
            this._nudBoundingBoxHeight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._nudBoundingBoxWidth = new System.Windows.Forms.NumericUpDown();
            this._tlpMainPanel.SuspendLayout();
            this._tlpBoundingBoxSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudBoundingBoxHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudBoundingBoxWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // _tlpMainPanel
            // 
            this._tlpMainPanel.ColumnCount = 1;
            this._tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpMainPanel.Controls.Add(this._tlpBoundingBoxSize, 0, 0);
            this._tlpMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpMainPanel.Location = new System.Drawing.Point(0, 0);
            this._tlpMainPanel.Name = "_tlpMainPanel";
            this._tlpMainPanel.RowCount = 2;
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this._tlpMainPanel.Size = new System.Drawing.Size(291, 538);
            this._tlpMainPanel.TabIndex = 0;
            // 
            // _tlpBoundingBoxSize
            // 
            this._tlpBoundingBoxSize.ColumnCount = 4;
            this._tlpBoundingBoxSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpBoundingBoxSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpBoundingBoxSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._tlpBoundingBoxSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpBoundingBoxSize.Controls.Add(this._nudBoundingBoxHeight, 3, 0);
            this._tlpBoundingBoxSize.Controls.Add(this.label2, 0, 0);
            this._tlpBoundingBoxSize.Controls.Add(this.label3, 2, 0);
            this._tlpBoundingBoxSize.Controls.Add(this._nudBoundingBoxWidth, 1, 0);
            this._tlpBoundingBoxSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpBoundingBoxSize.Location = new System.Drawing.Point(3, 3);
            this._tlpBoundingBoxSize.Name = "_tlpBoundingBoxSize";
            this._tlpBoundingBoxSize.RowCount = 1;
            this._tlpBoundingBoxSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpBoundingBoxSize.Size = new System.Drawing.Size(285, 47);
            this._tlpBoundingBoxSize.TabIndex = 9;
            // 
            // _nudBoundingBoxHeight
            // 
            this._nudBoundingBoxHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._nudBoundingBoxHeight.DecimalPlaces = 2;
            this._nudBoundingBoxHeight.Location = new System.Drawing.Point(201, 12);
            this._nudBoundingBoxHeight.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this._nudBoundingBoxHeight.Name = "_nudBoundingBoxHeight";
            this._nudBoundingBoxHeight.Size = new System.Drawing.Size(81, 22);
            this._nudBoundingBoxHeight.TabIndex = 4;
            this._nudBoundingBoxHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._nudBoundingBoxHeight.ValueChanged += new System.EventHandler(this._nudBoundingBoxHeight_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 47);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bounding Box Size";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(173, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 47);
            this.label3.TabIndex = 2;
            this.label3.Text = "x";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _nudBoundingBoxWidth
            // 
            this._nudBoundingBoxWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._nudBoundingBoxWidth.DecimalPlaces = 2;
            this._nudBoundingBoxWidth.Location = new System.Drawing.Point(88, 12);
            this._nudBoundingBoxWidth.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this._nudBoundingBoxWidth.Name = "_nudBoundingBoxWidth";
            this._nudBoundingBoxWidth.Size = new System.Drawing.Size(79, 22);
            this._nudBoundingBoxWidth.TabIndex = 3;
            this._nudBoundingBoxWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._nudBoundingBoxWidth.ValueChanged += new System.EventHandler(this._nudBoundingBoxWidth_ValueChanged);
            // 
            // frmCenterDetector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 538);
            this.Controls.Add(this._tlpMainPanel);
            this.Name = "frmCenterDetector";
            this.Text = "frmCenterDetector";
            this._tlpMainPanel.ResumeLayout(false);
            this._tlpBoundingBoxSize.ResumeLayout(false);
            this._tlpBoundingBoxSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudBoundingBoxHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudBoundingBoxWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tlpMainPanel;
        private System.Windows.Forms.TableLayoutPanel _tlpBoundingBoxSize;
        private System.Windows.Forms.NumericUpDown _nudBoundingBoxHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown _nudBoundingBoxWidth;
    }
}