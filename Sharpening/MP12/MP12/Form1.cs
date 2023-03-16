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
            Bitmap HinhGoc = new Bitmap(@"F:\OneDrive - hcmute.edu.vn\Hocc\HK6\ThiGiacMay\lena_color.jpg");
            picboxGoc.Image = HinhGoc;
            picboxSharpen.Image = SharpenImage(HinhGoc);
        }
        public Bitmap SharpenImage(Bitmap hinhgoc)
        {
            Bitmap SharpImage = new Bitmap(hinhgoc.Width, hinhgoc.Height);
            float[,] laplacian = new float[,] { { 0, -1, 0 },
                                           { -1, 4, -1 },
                                           { 0, -1, 0 } };
            for (int x = 1; x < hinhgoc.Width - 1; x++)
                for (int y = 1; y < hinhgoc.Height - 1; y++)
                {
                    Color pixel = hinhgoc.GetPixel(x, y);
                    float R = pixel.R;
                    float G = pixel.G;
                    float B = pixel.B;
                    float red = R;
                    float green = G;
                    float blue = B;
                    for (int i = 0; i <= 2; i++)
                        for (int j = 0; j <= 2; j++)
                        {
                            int pixelX = x - 1 + i;
                            int pixelY = y - 1 + j;
                            pixel = hinhgoc.GetPixel(pixelX, pixelY);
                            R = pixel.R;
                            G = pixel.G;
                            B = pixel.B;

                            red += laplacian[i, j] * R;
                            green += laplacian[i, j] * G;
                            blue += laplacian[i, j] * B;
                        }
                    int Rs = (int)Math.Max(0, Math.Min(255, red));
                    int Gs = (int)Math.Max(0, Math.Min(255, green));
                    int Bs = (int)Math.Max(0, Math.Min(255, blue));

                    SharpImage.SetPixel(x, y, Color.FromArgb(Rs, Gs, Bs));
                }
            return SharpImage;
        }
    }
}
