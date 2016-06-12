using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;

namespace JohnCenaFaceSwap
{
    public partial class Form1 : Form
    {
        private Image<Bgr, Byte> Source_frame = null;   //呈現Load圖片的畫面
        private Image<Bgr, Byte> Result_frame = null;
        //private Image<Bgr, Byte> Result_frame = null;  //最後呈現的畫面(RGB專用)
        private Image<Bgra, Byte> Cena = null;
        private Capture webCam = null;//擷取攝影機影像
        private bool isCamOpen = false;
        private Rectangle[] faces;
        private Rectangle[] eyes;
        private List<double> facesAngle;
        private Point offset = new Point(0, 0);
        private double scale = 1.5;
        private Size avgFaceSize = new Size(0, 0);
        public Form1()
        {
            InitializeComponent();
            Cena = new Image<Bgra, byte>(Application.StartupPath + "/cena.png");
        }

        private void LoadPicture_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Source_frame = new Image<Bgr, byte>(openFileDialog.FileName);     //將圖片資訊存到Source_frame
            }
            SourceBox.Image = Source_frame.ToBitmap();
            FaceDetection();
        }

        private void OpenCamera_Click(object sender, EventArgs e)
        {
            //Source_frame = new Image<Bgr, byte>(new Size(10, 10));
            webCam = new Capture();
            Application.Idle += Application_Idle;
            Source_frame = webCam.QueryFrame().Convert<Bgr, byte>();
        }

        void Application_Idle(object sender, EventArgs e)
        {
            Source_frame = webCam.QueryFrame().Convert<Bgr, byte>();
            SourceBox.Image = Source_frame.ToBitmap();
            FaceDetection();
        }

        private void FaceDetection()
        {
            EyeDetection();
            CascadeClassifier cascadeClassifier = new CascadeClassifier(Application.StartupPath + "/haarcascade_frontalface_default.xml");//路徑不知對不對
            if (Source_frame != null)
            {
                facesAngle = new List<double>();
                var grayframe = Source_frame.Convert<Gray, byte>();
                faces = cascadeClassifier.DetectMultiScale(grayframe, 1.2, 3, Size.Empty, Size.Empty); //the actual face detection happens here
                double faceWidthSum = 0;
                double faceHeightSum = 0;
                foreach (var face in faces)
                {
                    faceWidthSum += face.Width;
                    faceHeightSum += face.Height;
                    //refine process
                    List<Rectangle> foundEye = new List<Rectangle>();
                    foreach (Rectangle eye in eyes)
                    {
                        //Source_frame.Draw(eye, new Bgr(Color.Blue), 2);
                        if (face.Contains(eye))
                        {
                            foundEye.Add(eye);
                        }
                    }
                    if (foundEye.Count == 2)
                    {
                        Point eyeOneCenter = new Point((int)((double)foundEye[0].X + 0.5 * (double)foundEye[0].Width), (int)((double)foundEye[0].Y + 0.5 * (double)foundEye[0].Height));
                        Point eyeTwoCenter = new Point((int)((double)foundEye[1].X + 0.5 * (double)foundEye[1].Width), (int)((double)foundEye[1].Y + 0.5 * (double)foundEye[1].Height));
                        double length = Math.Pow(Math.Pow((double)(eyeOneCenter.X - eyeTwoCenter.X), 2) + Math.Pow((double)(eyeOneCenter.Y - eyeTwoCenter.Y), 2), 0.5);
                        double xLength = (double)(Math.Abs(eyeOneCenter.X - eyeTwoCenter.X));
                        facesAngle.Add(-(Math.Acos(xLength / length) * 180) / Math.PI);
                    }
                    else
                    {
                        facesAngle.Add(0);
                    }
                }
                avgFaceSize = new Size((int)(faceWidthSum / (double)faces.Length), (int)(faceHeightSum / (double)faces.Length));
                XBar.Maximum = avgFaceSize.Width;
                YBar.Maximum = avgFaceSize.Height;
                XBar.Minimum = -avgFaceSize.Width;
                YBar.Minimum = -avgFaceSize.Height;
            }
            DrawFaces();
        }

        private void EyeDetection()
        {
            CascadeClassifier cascadeClassifier = new CascadeClassifier(Application.StartupPath + "/haarcascade_eye.xml");
            if (Source_frame != null)
            {
                var grayframe = Source_frame.Convert<Gray, byte>();
                eyes = cascadeClassifier.DetectMultiScale(grayframe, 1.1, 2, Size.Empty, Size.Empty); //把偵測的眼睛存到全域變數
            }
        }

        private void DrawFaces()
        {
            if(Source_frame != null)
            {
                Result_frame = Source_frame.Clone();
                for (int i = 0; i < faces.Length; i++)
                {
                    PasteImageToImage(new Rectangle(faces[i].X + offset.X, faces[i].Y + offset.Y, faces[i].Width, faces[i].Height), facesAngle[i], scale);
                }
                ResultBox.Image = Result_frame.ToBitmap();
            }
        }

        private void PasteImageToImage(Rectangle rect, double rotateAngle, double scale)
        {
            int heightScale = Cena.Width / rect.Width;
            int tempImgWidth = (int)(rect.Width * scale);
            int tempImgHeight = (int)(Cena.Height / heightScale * scale);

            int xCenter = rect.X + rect.Width / 2 - rect.Width / 15;  // John Center John Center John Center 
            int yCenter = rect.Y + rect.Height / 2 - rect.Height / 8; // John Center John Center John Center 

            Image<Bgra, Byte> temp = Cena.Resize(tempImgWidth, tempImgHeight, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR)
                                         .Rotate(rotateAngle, new Bgra(0, 0, 0, 0));

            int x1 = 0;
            int y1 = 0;
            if (xCenter - tempImgWidth / 2 < 0)
                x1 = 0;
            else
                x1 = xCenter - tempImgWidth / 2;
            if (yCenter - tempImgHeight / 2 < 0)
                y1 = 0;
            else
                y1 = yCenter - tempImgHeight / 2;

            for (int x = x1; (x < xCenter - tempImgWidth / 2 + tempImgWidth) && (x < Result_frame.Width) && (x >= 0); x++)
            {
                for (int y = y1; (y < yCenter - tempImgHeight / 2 + tempImgHeight) && (y < Result_frame.Height) && (y >= 0); y++)
                {                    
                    if (temp.Data[y - (yCenter - tempImgHeight / 2), x - (xCenter - tempImgWidth / 2), 3] != 0)
                    {
                        Result_frame.Data[y, x, 0] = temp.Data[y - (yCenter - tempImgHeight / 2), x - (xCenter - tempImgWidth / 2), 0];
                        Result_frame.Data[y, x, 1] = temp.Data[y - (yCenter - tempImgHeight / 2), x - (xCenter - tempImgWidth / 2), 1];
                        Result_frame.Data[y, x, 2] = temp.Data[y - (yCenter - tempImgHeight / 2), x - (xCenter - tempImgWidth / 2), 2];                      
                    }
                }
            }
        }

        private void SourcePanel_Scroll(object sender, ScrollEventArgs e)
        {
            ResultPanel.VerticalScroll.Value = SourcePanel.VerticalScroll.Value;
            ResultPanel.HorizontalScroll.Value = SourcePanel.HorizontalScroll.Value;
        }

        private void ResultPanel_Scroll(object sender, ScrollEventArgs e)
        {
            SourcePanel.VerticalScroll.Value = ResultPanel.VerticalScroll.Value;
            SourcePanel.HorizontalScroll.Value = ResultPanel.HorizontalScroll.Value;
        }

        //改變scale跟xy offset時觸發
        private void FaceAdjested(object sender, EventArgs e)
        {
            scale = (double)ScaleBar.Value / 10.0;
            offset = new Point(XBar.Value, YBar.Value);
            DrawFaces();
        }
    }
}
