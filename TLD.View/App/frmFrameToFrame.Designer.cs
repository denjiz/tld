namespace TLD.View
{
    partial class frmFrameToFrame
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
            this._tlpFrames = new System.Windows.Forms.TableLayoutPanel();
            this._pnlFrames = new System.Windows.Forms.Panel();
            this._flpControls = new System.Windows.Forms.FlowLayoutPanel();
            this._cbxShowPrevOutput = new System.Windows.Forms.CheckBox();
            this._cbxShowCurrentOutput = new System.Windows.Forms.CheckBox();
            this._cbxShowValidShifts = new System.Windows.Forms.CheckBox();
            this._cbxShowReliableShifts = new System.Windows.Forms.CheckBox();
            this._tlpFrames.SuspendLayout();
            this._flpControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tlpFrames
            // 
            this._tlpFrames.ColumnCount = 1;
            this._tlpFrames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpFrames.Controls.Add(this._pnlFrames, 0, 0);
            this._tlpFrames.Controls.Add(this._flpControls, 0, 1);
            this._tlpFrames.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpFrames.Location = new System.Drawing.Point(0, 0);
            this._tlpFrames.Name = "_tlpFrames";
            this._tlpFrames.RowCount = 2;
            this._tlpFrames.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this._tlpFrames.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tlpFrames.Size = new System.Drawing.Size(1284, 566);
            this._tlpFrames.TabIndex = 0;
            // 
            // _pnlFrames
            // 
            this._pnlFrames.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlFrames.Location = new System.Drawing.Point(3, 3);
            this._pnlFrames.Name = "_pnlFrames";
            this._pnlFrames.Size = new System.Drawing.Size(1278, 418);
            this._pnlFrames.TabIndex = 0;
            this._pnlFrames.Paint += new System.Windows.Forms.PaintEventHandler(this._pnlFrames_Paint);
            // 
            // _flpControls
            // 
            this._flpControls.Controls.Add(this._cbxShowPrevOutput);
            this._flpControls.Controls.Add(this._cbxShowCurrentOutput);
            this._flpControls.Controls.Add(this._cbxShowValidShifts);
            this._flpControls.Controls.Add(this._cbxShowReliableShifts);
            this._flpControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flpControls.Location = new System.Drawing.Point(3, 427);
            this._flpControls.Name = "_flpControls";
            this._flpControls.Size = new System.Drawing.Size(1278, 136);
            this._flpControls.TabIndex = 1;
            // 
            // _cbxShowPrevOutput
            // 
            this._cbxShowPrevOutput.AutoSize = true;
            this._cbxShowPrevOutput.Location = new System.Drawing.Point(3, 3);
            this._cbxShowPrevOutput.Name = "_cbxShowPrevOutput";
            this._cbxShowPrevOutput.Size = new System.Drawing.Size(170, 21);
            this._cbxShowPrevOutput.TabIndex = 2;
            this._cbxShowPrevOutput.Text = "Show Previous Output";
            this._cbxShowPrevOutput.UseVisualStyleBackColor = true;
            this._cbxShowPrevOutput.CheckedChanged += new System.EventHandler(this._cbxShowPrevOutput_CheckedChanged);
            // 
            // _cbxShowCurrentOutput
            // 
            this._cbxShowCurrentOutput.AutoSize = true;
            this._cbxShowCurrentOutput.Location = new System.Drawing.Point(179, 3);
            this._cbxShowCurrentOutput.Name = "_cbxShowCurrentOutput";
            this._cbxShowCurrentOutput.Size = new System.Drawing.Size(162, 21);
            this._cbxShowCurrentOutput.TabIndex = 3;
            this._cbxShowCurrentOutput.Text = "Show Current Output";
            this._cbxShowCurrentOutput.UseVisualStyleBackColor = true;
            this._cbxShowCurrentOutput.CheckedChanged += new System.EventHandler(this._cbxShowCurrentOutput_CheckedChanged);
            // 
            // _cbxShowValidShifts
            // 
            this._cbxShowValidShifts.AutoSize = true;
            this._cbxShowValidShifts.Location = new System.Drawing.Point(347, 3);
            this._cbxShowValidShifts.Name = "_cbxShowValidShifts";
            this._cbxShowValidShifts.Size = new System.Drawing.Size(138, 21);
            this._cbxShowValidShifts.TabIndex = 0;
            this._cbxShowValidShifts.Text = "Show Valid Shifts";
            this._cbxShowValidShifts.UseVisualStyleBackColor = true;
            this._cbxShowValidShifts.CheckedChanged += new System.EventHandler(this._cbxShowValidShifts_CheckedChanged);
            // 
            // _cbxShowReliableShifts
            // 
            this._cbxShowReliableShifts.AutoSize = true;
            this._cbxShowReliableShifts.Location = new System.Drawing.Point(491, 3);
            this._cbxShowReliableShifts.Name = "_cbxShowReliableShifts";
            this._cbxShowReliableShifts.Size = new System.Drawing.Size(158, 21);
            this._cbxShowReliableShifts.TabIndex = 1;
            this._cbxShowReliableShifts.Text = "Show Reliable Shifts";
            this._cbxShowReliableShifts.UseVisualStyleBackColor = true;
            this._cbxShowReliableShifts.CheckedChanged += new System.EventHandler(this._cbxShowReliableShifts_CheckedChanged);
            // 
            // frmFrameToFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1284, 566);
            this.Controls.Add(this._tlpFrames);
            this.Name = "frmFrameToFrame";
            this.Text = "Frame-To-Frame View";
            this._tlpFrames.ResumeLayout(false);
            this._flpControls.ResumeLayout(false);
            this._flpControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tlpFrames;
        private System.Windows.Forms.Panel _pnlFrames;
        private System.Windows.Forms.FlowLayoutPanel _flpControls;
        private System.Windows.Forms.CheckBox _cbxShowValidShifts;
        private System.Windows.Forms.CheckBox _cbxShowReliableShifts;
        private System.Windows.Forms.CheckBox _cbxShowPrevOutput;
        private System.Windows.Forms.CheckBox _cbxShowCurrentOutput;
    }
}