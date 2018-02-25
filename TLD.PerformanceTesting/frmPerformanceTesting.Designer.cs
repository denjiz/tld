namespace TLD.PerformanceTesting
{
    partial class frmPerformanceTesting
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
            this._flpAvailableTests = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRunBoolArrayKeyTest = new System.Windows.Forms.Button();
            this._rtbxTestResults = new System.Windows.Forms.RichTextBox();
            this._tlpMainPanel.SuspendLayout();
            this._flpAvailableTests.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tlpMainPanel
            // 
            this._tlpMainPanel.ColumnCount = 2;
            this._tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.63027F));
            this._tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.36973F));
            this._tlpMainPanel.Controls.Add(this._flpAvailableTests, 0, 0);
            this._tlpMainPanel.Controls.Add(this._rtbxTestResults, 1, 0);
            this._tlpMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpMainPanel.Location = new System.Drawing.Point(0, 0);
            this._tlpMainPanel.Name = "_tlpMainPanel";
            this._tlpMainPanel.RowCount = 1;
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpMainPanel.Size = new System.Drawing.Size(806, 382);
            this._tlpMainPanel.TabIndex = 0;
            // 
            // _flpAvailableTests
            // 
            this._flpAvailableTests.Controls.Add(this.label1);
            this._flpAvailableTests.Controls.Add(this.btnRunBoolArrayKeyTest);
            this._flpAvailableTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flpAvailableTests.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._flpAvailableTests.Location = new System.Drawing.Point(3, 3);
            this._flpAvailableTests.Name = "_flpAvailableTests";
            this._flpAvailableTests.Size = new System.Drawing.Size(256, 376);
            this._flpAvailableTests.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Available Tests:";
            // 
            // btnRunBoolArrayKeyTest
            // 
            this.btnRunBoolArrayKeyTest.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRunBoolArrayKeyTest.Location = new System.Drawing.Point(3, 20);
            this.btnRunBoolArrayKeyTest.Name = "btnRunBoolArrayKeyTest";
            this.btnRunBoolArrayKeyTest.Size = new System.Drawing.Size(197, 42);
            this.btnRunBoolArrayKeyTest.TabIndex = 1;
            this.btnRunBoolArrayKeyTest.Text = "BoolArrayKey";
            this.btnRunBoolArrayKeyTest.UseVisualStyleBackColor = true;
            this.btnRunBoolArrayKeyTest.Click += new System.EventHandler(this.btnRunBoolArrayKeyTest_Click);
            // 
            // _rtbxTestResults
            // 
            this._rtbxTestResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rtbxTestResults.Location = new System.Drawing.Point(265, 3);
            this._rtbxTestResults.Name = "_rtbxTestResults";
            this._rtbxTestResults.ReadOnly = true;
            this._rtbxTestResults.Size = new System.Drawing.Size(538, 376);
            this._rtbxTestResults.TabIndex = 1;
            this._rtbxTestResults.Text = "";
            // 
            // frmPerformanceTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 382);
            this.Controls.Add(this._tlpMainPanel);
            this.Name = "frmPerformanceTesting";
            this.Text = "Performance Testing";
            this._tlpMainPanel.ResumeLayout(false);
            this._flpAvailableTests.ResumeLayout(false);
            this._flpAvailableTests.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tlpMainPanel;
        private System.Windows.Forms.FlowLayoutPanel _flpAvailableTests;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRunBoolArrayKeyTest;
        private System.Windows.Forms.RichTextBox _rtbxTestResults;
    }
}

