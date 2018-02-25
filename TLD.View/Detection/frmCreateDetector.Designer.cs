namespace TLD.View
{
    partial class frmCreateDetector
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
            this._tlpWriteDetectorName = new System.Windows.Forms.TableLayoutPanel();
            this._tlpChooseDetectorType = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._tbxWriteDetectorName = new System.Windows.Forms.TextBox();
            this._cmbxChooseDetectorType = new System.Windows.Forms.ComboBox();
            this._tlpOkCancel = new System.Windows.Forms.TableLayoutPanel();
            this._btnCreate = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._tlpMainPanel.SuspendLayout();
            this._tlpWriteDetectorName.SuspendLayout();
            this._tlpChooseDetectorType.SuspendLayout();
            this._tlpOkCancel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tlpMainPanel
            // 
            this._tlpMainPanel.ColumnCount = 1;
            this._tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpMainPanel.Controls.Add(this._tlpChooseDetectorType, 0, 1);
            this._tlpMainPanel.Controls.Add(this._tlpWriteDetectorName, 0, 0);
            this._tlpMainPanel.Controls.Add(this._tlpOkCancel, 0, 2);
            this._tlpMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpMainPanel.Location = new System.Drawing.Point(0, 0);
            this._tlpMainPanel.Name = "_tlpMainPanel";
            this._tlpMainPanel.RowCount = 3;
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._tlpMainPanel.Size = new System.Drawing.Size(282, 147);
            this._tlpMainPanel.TabIndex = 0;
            // 
            // _tlpWriteDetectorName
            // 
            this._tlpWriteDetectorName.ColumnCount = 2;
            this._tlpWriteDetectorName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._tlpWriteDetectorName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this._tlpWriteDetectorName.Controls.Add(this.label1, 0, 0);
            this._tlpWriteDetectorName.Controls.Add(this._tbxWriteDetectorName, 1, 0);
            this._tlpWriteDetectorName.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpWriteDetectorName.Location = new System.Drawing.Point(3, 3);
            this._tlpWriteDetectorName.Name = "_tlpWriteDetectorName";
            this._tlpWriteDetectorName.RowCount = 1;
            this._tlpWriteDetectorName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpWriteDetectorName.Size = new System.Drawing.Size(276, 42);
            this._tlpWriteDetectorName.TabIndex = 0;
            // 
            // _tlpChooseDetectorType
            // 
            this._tlpChooseDetectorType.ColumnCount = 2;
            this._tlpChooseDetectorType.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._tlpChooseDetectorType.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this._tlpChooseDetectorType.Controls.Add(this.label2, 0, 0);
            this._tlpChooseDetectorType.Controls.Add(this._cmbxChooseDetectorType, 1, 0);
            this._tlpChooseDetectorType.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpChooseDetectorType.Location = new System.Drawing.Point(3, 51);
            this._tlpChooseDetectorType.Name = "_tlpChooseDetectorType";
            this._tlpChooseDetectorType.RowCount = 1;
            this._tlpChooseDetectorType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpChooseDetectorType.Size = new System.Drawing.Size(276, 42);
            this._tlpChooseDetectorType.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type:";
            // 
            // _tbxWriteDetectorName
            // 
            this._tbxWriteDetectorName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._tbxWriteDetectorName.Location = new System.Drawing.Point(58, 22);
            this._tbxWriteDetectorName.Name = "_tbxWriteDetectorName";
            this._tbxWriteDetectorName.Size = new System.Drawing.Size(215, 22);
            this._tbxWriteDetectorName.TabIndex = 1;
            // 
            // _cmbxChooseDetectorType
            // 
            this._cmbxChooseDetectorType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._cmbxChooseDetectorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbxChooseDetectorType.FormattingEnabled = true;
            this._cmbxChooseDetectorType.Location = new System.Drawing.Point(58, 8);
            this._cmbxChooseDetectorType.Name = "_cmbxChooseDetectorType";
            this._cmbxChooseDetectorType.Size = new System.Drawing.Size(215, 24);
            this._cmbxChooseDetectorType.TabIndex = 2;
            // 
            // _tlpOkCancel
            // 
            this._tlpOkCancel.ColumnCount = 2;
            this._tlpOkCancel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpOkCancel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpOkCancel.Controls.Add(this._btnCreate, 0, 0);
            this._tlpOkCancel.Controls.Add(this._btnCancel, 1, 0);
            this._tlpOkCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpOkCancel.Location = new System.Drawing.Point(3, 99);
            this._tlpOkCancel.Name = "_tlpOkCancel";
            this._tlpOkCancel.RowCount = 1;
            this._tlpOkCancel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpOkCancel.Size = new System.Drawing.Size(276, 45);
            this._tlpOkCancel.TabIndex = 1;
            // 
            // _btnCreate
            // 
            this._btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this._btnCreate.Location = new System.Drawing.Point(9, 3);
            this._btnCreate.Name = "_btnCreate";
            this._btnCreate.Size = new System.Drawing.Size(120, 39);
            this._btnCreate.TabIndex = 0;
            this._btnCreate.Text = "Create";
            this._btnCreate.UseVisualStyleBackColor = true;
            this._btnCreate.Click += new System.EventHandler(this._btnCreate_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this._btnCancel.Location = new System.Drawing.Point(147, 3);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(120, 39);
            this._btnCancel.TabIndex = 1;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // frmCreateDetector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 147);
            this.Controls.Add(this._tlpMainPanel);
            this.Name = "frmCreateDetector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Detector";
            this._tlpMainPanel.ResumeLayout(false);
            this._tlpWriteDetectorName.ResumeLayout(false);
            this._tlpWriteDetectorName.PerformLayout();
            this._tlpChooseDetectorType.ResumeLayout(false);
            this._tlpChooseDetectorType.PerformLayout();
            this._tlpOkCancel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tlpMainPanel;
        private System.Windows.Forms.TableLayoutPanel _tlpChooseDetectorType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _cmbxChooseDetectorType;
        private System.Windows.Forms.TableLayoutPanel _tlpWriteDetectorName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tbxWriteDetectorName;
        private System.Windows.Forms.TableLayoutPanel _tlpOkCancel;
        private System.Windows.Forms.Button _btnCreate;
        private System.Windows.Forms.Button _btnCancel;
    }
}