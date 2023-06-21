using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP15
{
    public partial class Form1 : Form
    {
        public static Bitmap hinhGoc = new Bitmap(@"F:\OneDrive - hcmute.edu.vn\Hocc\HK6\imageProcessing\lena_color.jpg");

        public Form1()
        {
            InitializeComponent();

            picBoxRGB.Image = hinhGoc;
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
        public Bitmap EdgeRGB(Bitmap hinhRGB, byte threshold)
        {
            Bitmap imgEdgeRGB = new Bitmap(hinhRGB.Width, hinhRGB.Height);
            int[,] sobelX = new int[,] { {-1, -2, -1},
                                         {0, 0, 0},
                                         {1, 2, 1}};
            int[,] sobelY = new int[,] { {-1, 0, 1},
                                         {-2, 0, 2},
                                         {-1, 0, 1}};
            for (int x = 1; x < hinhRGB.Width - 1; x++)
                for (int y = 1; y < hinhRGB.Height - 1; y++)
                {

                    int gxR, gyR, gxG, gyG, gxB, gyB;
                    gxR = gyR = gxG = gyG = gxB = gyB = 0;

                    for (int i = 0; i <= 2; i++)
                        for (int j = 0; j <= 2; j++)
                        {
                            int pixelX = x - 1 + i;
                            int pixelY = y - 1 + j;
                            Color pixel = hinhRGB.GetPixel(pixelX, pixelY);

                            gxR += sobelX[i, j] * pixel.R;
                            gyR += sobelY[i, j] * pixel.R;

                            gxG += sobelX[i, j] * pixel.G;
                            gyG += sobelY[i, j] * pixel.G;

                            gxB += sobelX[i, j] * pixel.B;
                            gyB += sobelY[i, j] * pixel.B;
                        }
                    int gxX = gxR * gxR + gxG * gxG + gxB * gxB;
                    int gyY = gyR * gyR + gyG * gyG + gyB * gyB;
                    int gXY = gxR * gyR + gxG * gyG + gxB * gyB;

                    double theta = Math.Atan2(2 * gXY, gxX - gyY) / 2;
                    double f0 = Math.Sqrt(0.5 * ((gxX + gyY) + (gxX - gyY) * Math.Cos(2 * theta) + 2 * gXY * Math.Sin(2 * theta)));

                    if (f0 <= threshold) imgEdgeRGB.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    else imgEdgeRGB.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                }
            return imgEdgeRGB;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            lbl.Text = trackBar1.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte threshold = (byte)trackBar1.Value;
            picBoxEdgeRGB.Image = EdgeRGB(hinhGoc, threshold);

        }

    }
}
