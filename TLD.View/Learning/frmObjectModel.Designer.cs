namespace TLD.View.Learning
{
    partial class frmObjectModel
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
            this._gbxNegativeExamples = new System.Windows.Forms.GroupBox();
            this._flpNegativePatches = new System.Windows.Forms.FlowLayoutPanel();
            this._gbxPositivePatches = new System.Windows.Forms.GroupBox();
            this._flpPositivePatches = new System.Windows.Forms.FlowLayoutPanel();
            this._tlpMainPanel.SuspendLayout();
            this._gbxNegativeExamples.SuspendLayout();
            this._gbxPositivePatches.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tlpMainPanel
            // 
            this._tlpMainPanel.ColumnCount = 1;
            this._tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpMainPanel.Controls.Add(this._gbxNegativeExamples, 0, 1);
            this._tlpMainPanel.Controls.Add(this._gbxPositivePatches, 0, 0);
            this._tlpMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpMainPanel.Location = new System.Drawing.Point(0, 0);
            this._tlpMainPanel.Name = "_tlpMainPanel";
            this._tlpMainPanel.RowCount = 2;
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpMainPanel.Size = new System.Drawing.Size(282, 255);
            this._tlpMainPanel.TabIndex = 0;
            // 
            // _gbxNegativeExamples
            // 
            this._gbxNegativeExamples.Controls.Add(this._flpNegativePatches);
            this._gbxNegativeExamples.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gbxNegativeExamples.Location = new System.Drawing.Point(3, 130);
            this._gbxNegativeExamples.Name = "_gbxNegativeExamples";
            this._gbxNegativeExamples.Size = new System.Drawing.Size(276, 122);
            this._gbxNegativeExamples.TabIndex = 0;
            this._gbxNegativeExamples.TabStop = false;
            this._gbxNegativeExamples.Text = "Negative Examples";
            // 
            // _flpNegativePatches
            // 
            this._flpNegativePatches.BackColor = System.Drawing.SystemColors.Control;
            this._flpNegativePatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flpNegativePatches.Location = new System.Drawing.Point(3, 18);
            this._flpNegativePatches.Name = "_flpNegativePatches";
            this._flpNegativePatches.Size = new System.Drawing.Size(270, 101);
            this._flpNegativePatches.TabIndex = 0;
            // 
            // _gbxPositivePatches
            // 
            this._gbxPositivePatches.Controls.Add(this._flpPositivePatches);
            this._gbxPositivePatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gbxPositivePatches.Location = new System.Drawing.Point(3, 3);
            this._gbxPositivePatches.Name = "_gbxPositivePatches";
            this._gbxPositivePatches.Size = new System.Drawing.Size(276, 121);
            this._gbxPositivePatches.TabIndex = 0;
            this._gbxPositivePatches.TabStop = false;
            this._gbxPositivePatches.Text = "Positive Examples";
            // 
            // _flpPositivePatches
            // 
            this._flpPositivePatches.BackColor = System.Drawing.SystemColors.Control;
            this._flpPositivePatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flpPositivePatches.Location = new System.Drawing.Point(3, 18);
            this._flpPositivePatches.Margin = new System.Windows.Forms.Padding(10);
            this._flpPositivePatches.Name = "_flpPositivePatches";
            this._flpPositivePatches.Size = new System.Drawing.Size(270, 100);
            this._flpPositivePatches.TabIndex = 0;
            // 
            // frmObjectModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 255);
            this.Controls.Add(this._tlpMainPanel);
            this.Name = "frmObjectModel";
            this.Text = "frmObjectModel";
            this._tlpMainPanel.ResumeLayout(false);
            this._gbxNegativeExamples.ResumeLayout(false);
            this._gbxPositivePatches.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tlpMainPanel;
        private System.Windows.Forms.GroupBox _gbxNegativeExamples;
        private System.Windows.Forms.GroupBox _gbxPositivePatches;
        private System.Windows.Forms.FlowLayoutPanel _flpNegativePatches;
        private System.Windows.Forms.FlowLayoutPanel _flpPositivePatches;
    }
}