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
            this.ResultBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SourceBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SourceBox
            // 
            this.SourceBox.Location = new System.Drawing.Point(12, 12);
            this.SourceBox.Name = "SourceBox";
            this.SourceBox.Size = new System.Drawing.Size(421, 453);
            this.SourceBox.TabIndex = 0;
            this.SourceBox.TabStop = false;
            // 
            // ResultBox
            // 
            this.ResultBox.Location = new System.Drawing.Point(439, 12);
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.Size = new System.Drawing.Size(421, 453);
            this.ResultBox.TabIndex = 1;
            this.ResultBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 477);
            this.Controls.Add(this.ResultBox);
            this.Controls.Add(this.SourceBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.SourceBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox SourceBox;
        private System.Windows.Forms.PictureBox ResultBox;
    }
}

