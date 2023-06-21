using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Bitmap HinhGoc = new Bitmap(@"F:\OneDrive - hcmute.edu.vn\Hocc\HK6\imageProcessing\lena_color.jpg");
            picboxGoc.Image = HinhGoc;
            picboxSharpen.Image = SharpenImage(HinhGoc);
        }
        public Bitmap SharpenImage(Bitmap hinhgoc)
        {
            Bitmap SharpImage = new Bitmap(hinhgoc.Width, hinhgoc.Height);
            float[,] laplacian = new float[,] { { 0, -1, 0 },
                                           { -1, 4, -1 },       //mặt nạ với c = -1
                                           { 0, -1, 0 } };
            for (int x = 1; x < hinhgoc.Width - 1; x++)
                for (int y = 1; y < hinhgoc.Height - 1; y++)
                {
                    Color pixel = hinhgoc.GetPixel(x, y);
                    float aR = pixel.R;
                    float aG = pixel.G;
                    float aB = pixel.B;
                    float R = aR;
                    float G = aG;
                    float B = aB;
                    for (int i = 0; i <= 2; i++)
                        for (int j = 0; j <= 2; j++)
                        {
                            int pixelX = x - 1 + i;
                            int pixelY = y - 1 + j;
                            pixel = hinhgoc.GetPixel(pixelX, pixelY);
                            aR = pixel.R;
                            aG = pixel.G;
                            aB = pixel.B;

                            R += laplacian[i, j] * aR;
                            G += laplacian[i, j] * aG;
                            B += laplacian[i, j] * aB;
                        }
                    int Rs = (int)Math.Max(0, Math.Min(255, R));
                    int Gs = (int)Math.Max(0, Math.Min(255, G));
                    int Bs = (int)Math.Max(0, Math.Min(255, B));

                    SharpImage.SetPixel(x, y, Color.FromArgb(Rs, Gs, Bs));
                }
            return SharpImage;
        }
    }
}