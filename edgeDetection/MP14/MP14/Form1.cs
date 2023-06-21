using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP14
{
    public partial class Form1 : Form
    {
        public static Bitmap hinhGoc = new Bitmap(@"F:\OneDrive - hcmute.edu.vn\Hocc\HK6\imageProcessing\lena_color.jpg");
        public static Bitmap xam = GrayScale(hinhGoc);


        public Form1()
        {
            InitializeComponent();
            
            picboxGray.Image = xam;
        }
        public static Bitmap GrayScale(Bitmap hinh)
        {
            Bitmap imgGray = new Bitmap(hinh.Width, hinh.Height);
            for (int x = 0; x < hinh.Width; x++) 
                for (int y = 0; y < hinh.Height; y++)
                {
                    Color pixel = hinh.GetPixel(x, y);
                    byte R = pixel.R;
                    byte G = pixel.G;
                    byte B = pixel.B;

                    byte gray = (byte)((R + G + B) / 3);
                    imgGray.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            return imgGray;
        }

        public Bitmap edgeGray(Bitmap hinhXam, byte threshold)
        {
            Bitmap imgEdgeGray = new Bitmap(hinhXam.Width, hinhXam.Height);
            int[,] sobelX = new int[,] { {-1, -2, -1},
                                         {0, 0, 0},
                                         {1, 2, 1}};
            int[,] sobelY = new int[,] { {-1, 0, 1},
                                         {-2, 0, 2},
                                         {-1, 0, 1}};
            for (int x = 1; x < hinhXam.Width - 1; x++)
                for (int y = 1; y < hinhXam.Height - 1; y++)
                {
                    int gx = 0;
                    int gy = 0;
                  
                    for (int i = 0; i <= 2; i++)
                        for (int j = 0; j <= 2; j++)
                        {
                            int pixelX = x - 1 + i;
                            int pixelY = y - 1 + j;
                            byte gray = hinhXam.GetPixel(pixelX, pixelY).R;
                            gx += sobelX[i, j] * gray;
                            gy += sobelY[i, j] * gray;                   
                        }
                    int Mxy = Math.Abs(gx) + Math.Abs(gy);
                    if (Mxy <= threshold) imgEdgeGray.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    else imgEdgeGray.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                }
            return imgEdgeGray;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            lblThreshold.Text = trackBar1.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte threshold = (byte)trackBar1.Value;
            picBoxEdgeGray.Image = edgeGray(xam, threshold);

        }

    }
}
