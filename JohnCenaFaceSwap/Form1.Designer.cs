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
            this.ScaleBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.LoadPicture = new System.Windows.Forms.Button();
            this.OpenCamera = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.XBar = new System.Windows.Forms.TrackBar();
            this.YBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SourceBox)).BeginInit();
            this.SourcePanel.SuspendLayout();
            this.ResultPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YBar)).BeginInit();
            this.SuspendLayout();
            // 
            // SourceBox
            // 
            this.SourceBox.Location = new System.Drawing.Point(3, 3);
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
            this.SourcePanel.Location = new System.Drawing.Point(8, 8);
            this.SourcePanel.Margin = new System.Windows.Forms.Padding(2);
            this.SourcePanel.Name = "SourcePanel";
            this.SourcePanel.Size = new System.Drawing.Size(421, 453);
            this.SourcePanel.TabIndex = 2;
            this.SourcePanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SourcePanel_Scroll);
            // 
            // ResultPanel
            // 
            this.ResultPanel.AutoScroll = true;
            this.ResultPanel.Controls.Add(this.ResultBox);
            this.ResultPanel.Location = new System.Drawing.Point(447, 8);
            this.ResultPanel.Margin = new System.Windows.Forms.Padding(2);
            this.ResultPanel.Name = "ResultPanel";
            this.ResultPanel.Size = new System.Drawing.Size(421, 453);
            this.ResultPanel.TabIndex = 3;
            this.ResultPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ResultPanel_Scroll);
            // 
            // ResultBox
            // 
            this.ResultBox.Location = new System.Drawing.Point(3, 3);
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.Size = new System.Drawing.Size(197, 195);
            this.ResultBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ResultBox.TabIndex = 0;
            this.ResultBox.TabStop = false;
            // 
            // ScaleBar
            // 
            this.ScaleBar.Location = new System.Drawing.Point(241, 466);
            this.ScaleBar.Maximum = 30;
            this.ScaleBar.Minimum = 1;
            this.ScaleBar.Name = "ScaleBar";
            this.ScaleBar.Size = new System.Drawing.Size(188, 45);
            this.ScaleBar.TabIndex = 4;
            this.ScaleBar.Value = 15;
            this.ScaleBar.ValueChanged += new System.EventHandler(this.FaceAdjested);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 478);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Scale";
            // 
            // LoadPicture
            // 
            this.LoadPicture.Location = new System.Drawing.Point(8, 466);
            this.LoadPicture.Name = "LoadPicture";
            this.LoadPicture.Size = new System.Drawing.Size(75, 23);
            this.LoadPicture.TabIndex = 6;
            this.LoadPicture.Text = "讀取圖片";
            this.LoadPicture.UseVisualStyleBackColor = true;
            this.LoadPicture.Click += new System.EventHandler(this.LoadPicture_Click);
            // 
            // OpenCamera
            // 
            this.OpenCamera.Location = new System.Drawing.Point(89, 466);
            this.OpenCamera.Name = "OpenCamera";
            this.OpenCamera.Size = new System.Drawing.Size(75, 23);
            this.OpenCamera.TabIndex = 7;
            this.OpenCamera.Text = "開啟相機";
            this.OpenCamera.UseVisualStyleBackColor = true;
            this.OpenCamera.Click += new System.EventHandler(this.OpenCamera_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(448, 477);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "X-offset";
            // 
            // XBar
            // 
            this.XBar.Location = new System.Drawing.Point(497, 466);
            this.XBar.Maximum = 20;
            this.XBar.Minimum = -20;
            this.XBar.Name = "XBar";
            this.XBar.Size = new System.Drawing.Size(104, 45);
            this.XBar.TabIndex = 9;
            this.XBar.ValueChanged += new System.EventHandler(this.FaceAdjested);
            // 
            // YBar
            // 
            this.YBar.Location = new System.Drawing.Point(656, 465);
            this.YBar.Maximum = 20;
            this.YBar.Minimum = -20;
            this.YBar.Name = "YBar";
            this.YBar.Size = new System.Drawing.Size(104, 45);
            this.YBar.TabIndex = 11;
            this.YBar.ValueChanged += new System.EventHandler(this.FaceAdjested);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(607, 477);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "Y-offset";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 508);
            this.Controls.Add(this.YBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.XBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OpenCamera);
            this.Controls.Add(this.LoadPicture);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ScaleBar);
            this.Controls.Add(this.ResultPanel);
            this.Controls.Add(this.SourcePanel);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.SourceBox)).EndInit();
            this.SourcePanel.ResumeLayout(false);
            this.SourcePanel.PerformLayout();
            this.ResultPanel.ResumeLayout(false);
            this.ResultPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox SourceBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel SourcePanel;
        private System.Windows.Forms.Panel ResultPanel;
        private System.Windows.Forms.PictureBox ResultBox;
        private System.Windows.Forms.TrackBar ScaleBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LoadPicture;
        private System.Windows.Forms.Button OpenCamera;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar XBar;
        private System.Windows.Forms.TrackBar YBar;
        private System.Windows.Forms.Label label3;
    }
}

