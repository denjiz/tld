namespace TLD.View
{
    partial class frmCascadedClassifier
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
            this._gbxVarianceClassifier = new System.Windows.Forms.GroupBox();
            this._gbxEnsembleClassifier = new System.Windows.Forms.GroupBox();
            this._gbxNnClassifier = new System.Windows.Forms.GroupBox();
            this._tlpMainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tlpMainPanel
            // 
            this._tlpMainPanel.ColumnCount = 1;
            this._tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpMainPanel.Controls.Add(this._gbxNnClassifier, 0, 2);
            this._tlpMainPanel.Controls.Add(this._gbxVarianceClassifier, 0, 0);
            this._tlpMainPanel.Controls.Add(this._gbxEnsembleClassifier, 0, 1);
            this._tlpMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpMainPanel.Location = new System.Drawing.Point(0, 0);
            this._tlpMainPanel.Name = "_tlpMainPanel";
            this._tlpMainPanel.RowCount = 3;
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tlpMainPanel.Size = new System.Drawing.Size(282, 351);
            this._tlpMainPanel.TabIndex = 0;
            // 
            // _gbxVarianceClassifier
            // 
            this._gbxVarianceClassifier.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gbxVarianceClassifier.Location = new System.Drawing.Point(3, 3);
            this._gbxVarianceClassifier.Name = "_gbxVarianceClassifier";
            this._gbxVarianceClassifier.Size = new System.Drawing.Size(276, 81);
            this._gbxVarianceClassifier.TabIndex = 0;
            this._gbxVarianceClassifier.TabStop = false;
            this._gbxVarianceClassifier.Text = "Variance Classifier";
            // 
            // _gbxEnsembleClassifier
            // 
            this._gbxEnsembleClassifier.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gbxEnsembleClassifier.Location = new System.Drawing.Point(3, 90);
            this._gbxEnsembleClassifier.Name = "_gbxEnsembleClassifier";
            this._gbxEnsembleClassifier.Size = new System.Drawing.Size(276, 169);
            this._gbxEnsembleClassifier.TabIndex = 1;
            this._gbxEnsembleClassifier.TabStop = false;
            this._gbxEnsembleClassifier.Text = "Ensemble Classifier";
            // 
            // _gbxNnClassifier
            // 
            this._gbxNnClassifier.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gbxNnClassifier.Location = new System.Drawing.Point(3, 265);
            this._gbxNnClassifier.Name = "_gbxNnClassifier";
            this._gbxNnClassifier.Size = new System.Drawing.Size(276, 83);
            this._gbxNnClassifier.TabIndex = 0;
            this._gbxNnClassifier.TabStop = false;
            this._gbxNnClassifier.Text = "NN Classifier";
            // 
            // frmCascadedClassifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 351);
            this.Controls.Add(this._tlpMainPanel);
            this.Name = "frmCascadedClassifier";
            this.Text = "frmZdenekCascadedClassifier";
            this._tlpMainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tlpMainPanel;
        private System.Windows.Forms.GroupBox _gbxVarianceClassifier;
        private System.Windows.Forms.GroupBox _gbxEnsembleClassifier;
        private System.Windows.Forms.GroupBox _gbxNnClassifier;
    }
}