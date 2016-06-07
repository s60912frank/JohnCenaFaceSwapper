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
        //private Image<Bgr, Byte> Result_frame = null;  //最後呈現的畫面(RGB專用)
        private Image<Bgra, Byte> Cena = null;
        private Capture webCam = null;//擷取攝影機影像
        public Form1()
        {
            InitializeComponent();
            Cena = new Image<Bgra, byte>(Application.StartupPath + "/cena.png");
            //Source_frame = new Image<Bgr, byte>(new Size(10, 10));
            //webCam = new Capture();
            //Application.Idle += Application_Idle;
            //Source_frame = new Image<Bgr, byte>(Application.StartupPath + "..\\..\\..\\people.png");
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Source_frame = new Image<Bgr, byte>(openFileDialog.FileName);     //將圖片資訊存到Source_frame
            }
            SourceBox.Image = Source_frame.ToBitmap();
            FaceDetection();
            //EyeDetection();
        }

        void Application_Idle(object sender, EventArgs e)
        {
            Source_frame = webCam.QueryFrame().Convert<Bgr, byte>();
            SourceBox.Image = Source_frame.ToBitmap();
            FaceDetection();
        }

        private void FaceDetection()
        {
            Rectangle[] eyes = EyeDetection();
            CascadeClassifier cascadeClassifier = new CascadeClassifier(Application.StartupPath + "/haarcascade_frontalface_default.xml");//路徑不知對不對
            if (Source_frame != null)
            {
                var grayframe = Source_frame.Convert<Gray, byte>();
                var faces = cascadeClassifier.DetectMultiScale(grayframe, 1.1, 3, Size.Empty, Size.Empty); //the actual face detection happens here
                foreach (var face in faces)
                {
                    Source_frame.Draw(face, new Bgr(Color.Red), 2);
                    
                    //refine process
                    List<Rectangle> foundEye = new List<Rectangle>();
                    foreach (Rectangle eye in eyes)
                    {
                        Source_frame.Draw(eye, new Bgr(Color.Blue), 2);
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
                        PasteImageToImage(ref Source_frame, Cena, face, ((Math.Asin(xLength / length) * 180) / Math.PI) - 90);
                    }
                    else
                    {
                        PasteImageToImage(ref Source_frame, Cena, face);
                    }
                }
            }
            ResultBox.Image = Source_frame.ToBitmap();
        }

        private Rectangle[] EyeDetection()
        {
            CascadeClassifier cascadeClassifier = new CascadeClassifier(Application.StartupPath + "/haarcascade_eye.xml");//路徑不知對不對
            if (Source_frame != null)
            {
                var grayframe = Source_frame.Convert<Gray, byte>();
                return cascadeClassifier.DetectMultiScale(grayframe, 1.1, 2, Size.Empty, Size.Empty); //the actual face detection happens here
                //foreach (var eye in eyes)
                //{
                //    Source_frame.Draw(eye, new Bgr(Color.Blue), 2);
                //}
            }
            //ResultBox.Image = Source_frame.ToBitmap();
            return null;
        }

        private void PasteImageToImage(ref Image<Bgr, byte> bigImg, Image<Bgra, byte> smallImg, Rectangle rect, double rotateAngle)
        {
            //smallImg.Rotate(rotateAngle, new Bgra(0, 0, 0, 0));
            PasteImageToImage(ref bigImg, smallImg.Rotate(rotateAngle, new Bgra(0, 0, 0, 0)), rect);
        }

        private void PasteImageToImage(ref Image<Bgr,byte> bigImg, Image<Bgra, byte> smallImg, Rectangle rect)
        {
            
            const double SCALE = 1.2;  // John Scale John Scale John Scale John Scale John Scale
            
            int heightScale = smallImg.Width / rect.Width;
            int tempImgWidth = (int)(rect.Width*SCALE);
            int tempImgHeight = (int)(smallImg.Height / heightScale*SCALE);

            int xCenter = rect.X + rect.Width / 2 - rect.Width / 15;  // John Center John Center John Center 
            int yCenter = rect.Y + rect.Height / 2 - rect.Height / 8; // John Center John Center John Center 

            Image<Bgra, Byte> temp = smallImg.Resize(tempImgWidth, tempImgHeight, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);

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

            for (int x = x1; (x < xCenter - tempImgWidth / 2 + tempImgWidth) && (x < bigImg.Width) && (x >= 0); x++)
            {
                for (int y = y1; (y < yCenter - tempImgHeight / 2 + tempImgHeight) && (y < bigImg.Height) && (y >= 0); y++)
                {                    
                    if (temp.Data[y - (yCenter - tempImgHeight / 2), x - (xCenter - tempImgWidth / 2), 3] != 0)
                    {
                        bigImg.Data[y, x, 0] = temp.Data[y - (yCenter - tempImgHeight / 2), x - (xCenter - tempImgWidth / 2), 0];
                        bigImg.Data[y, x, 1] = temp.Data[y - (yCenter - tempImgHeight / 2), x - (xCenter - tempImgWidth / 2), 1];
                        bigImg.Data[y, x, 2] = temp.Data[y - (yCenter - tempImgHeight / 2), x - (xCenter - tempImgWidth / 2), 2];                      
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
    }
}
