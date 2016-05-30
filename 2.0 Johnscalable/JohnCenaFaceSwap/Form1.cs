using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
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
            Source_frame = new Image<Bgr, byte>(Application.StartupPath + "..\\..\\..\\people.png");
            SourceBox.Image = Source_frame.ToBitmap();
            FaceDetection();
        }

        void Application_Idle(object sender, EventArgs e)
        {
            Source_frame = webCam.QueryFrame().Convert<Bgr, byte>();
            SourceBox.Image = Source_frame.ToBitmap();
            FaceDetection();
        }

        private void FaceDetection()
        {
            CascadeClassifier cascadeClassifier = new CascadeClassifier(Application.StartupPath + "/haarcascade_frontalface_default.xml");//路徑不知對不對
            if (Source_frame != null)
            {
                var grayframe = Source_frame.Convert<Gray, byte>();
                var faces = cascadeClassifier.DetectMultiScale(grayframe, 1.1, 3, Size.Empty, Size.Empty); //the actual face detection happens here
                foreach (var face in faces)
                {
                    //Source_frame.Draw(face, new Bgr(Color.Red), 3); //the detected face(s) is highlighted here using a box that is drawn around it/them
                    //Cena.ROI = face;
                    //CvInvoke.cvCopy(Source_frame, Cena, IntPtr.Zero);
                    //MessageBox.Show(face.ToString());
                    //try
                    //{
                    //    Cena.ROI = face;
                    //CvInvoke.cvCopy(Source_frame, Cena, IntPtr.Zero);
                    //MessageBox.Show("???");
                    //}
                    //catch
                    //{
                    //    MessageBox.Show("WHY???");
                    //}
                    //Cena.CopyTo(Source_frame);
                    PasteImageToImage(ref Source_frame, Cena, face);
                }
            }
            ResultBox.Image = Source_frame.ToBitmap();
        }

        private void PasteImageToImage(ref Image<Bgr,byte> bigImg, Image<Bgra, byte> smallImg, Rectangle rect)
        {
            
            const double SCALE = 1.5;  // John Scale John Scale John Scale John Scale John Scale
            
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
    }
}
