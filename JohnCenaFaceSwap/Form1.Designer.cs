namespace JohnCenaFaceSwap
{
    partial class Form1
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
            this.SourceBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SourcePanel = new System.Windows.Forms.Panel();
            this.ResultPanel = new System.Windows.Forms.Panel();
            this.ResultBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SourceBox)).BeginInit();
            this.SourcePanel.SuspendLayout();
            this.ResultPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SourceBox
            // 
            this.SourceBox.Location = new System.Drawing.Point(4, 4);
            this.SourceBox.Margin = new System.Windows.Forms.Padding(4);
            this.SourceBox.Name = "SourceBox";
            this.SourceBox.Size = new System.Drawing.Size(197, 195);
            this.SourceBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.SourceBox.TabIndex = 0;
            this.SourceBox.TabStop = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // SourcePanel
            // 
            this.SourcePanel.AutoScroll = true;
            this.SourcePanel.Controls.Add(this.SourceBox);
            this.SourcePanel.Location = new System.Drawing.Point(12, 12);
            this.SourcePanel.Name = "SourcePanel";
            this.SourcePanel.Size = new System.Drawing.Size(632, 680);
            this.SourcePanel.TabIndex = 2;
            this.SourcePanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SourcePanel_Scroll);
            // 
            // ResultPanel
            // 
            this.ResultPanel.AutoScroll = true;
            this.ResultPanel.Controls.Add(this.ResultBox);
            this.ResultPanel.Location = new System.Drawing.Point(670, 12);
            this.ResultPanel.Name = "ResultPanel";
            this.ResultPanel.Size = new System.Drawing.Size(632, 680);
            this.ResultPanel.TabIndex = 3;
            this.ResultPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ResultPanel_Scroll);
            // 
            // ResultBox
            // 
            this.ResultBox.Location = new System.Drawing.Point(4, 4);
            this.ResultBox.Margin = new System.Windows.Forms.Padding(4);
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.Size = new System.Drawing.Size(197, 195);
            this.ResultBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ResultBox.TabIndex = 0;
            this.ResultBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 716);
            this.Controls.Add(this.ResultPanel);
            this.Controls.Add(this.SourcePanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.SourceBox)).EndInit();
            this.SourcePanel.ResumeLayout(false);
            this.SourcePanel.PerformLayout();
            this.ResultPanel.ResumeLayout(false);
            this.ResultPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox SourceBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel SourcePanel;
        private System.Windows.Forms.Panel ResultPanel;
        private System.Windows.Forms.PictureBox ResultBox;
    }
}

