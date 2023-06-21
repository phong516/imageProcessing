using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string FileHinh = @"F:\OneDrive - hcmute.edu.vn\Hocc\HK6\imageProcessing\lena_color.jpg";
            Bitmap HinhGoc = new Bitmap(FileHinh);
            picboxGoc.Image = HinhGoc;
            picbox3x3.Image = SmoothingImg(HinhGoc, 3);
            picbox5x5.Image = SmoothingImg(HinhGoc, 5);
            picbox7x7.Image = SmoothingImg(HinhGoc, 7);
            picbox9x9.Image = SmoothingImg(HinhGoc, 9);

        }
        public Bitmap SmoothingImg(Bitmap hinhgoc, Byte mask)
        {
            Bitmap Img = new Bitmap(hinhgoc.Width, hinhgoc.Height);
            int K = mask * mask;
            int offset = mask / 2;
            for (int x = offset; x < (hinhgoc.Width - offset); x++)
                for (int y = offset; y < (hinhgoc.Height - offset); y++)
                {
                    int Rs = 0, Gs = 0, Bs = 0;
                    for (int i = (x - offset); i <= (x + offset); i++)
                        for (int j = (y - offset); j <= (y + offset); j++)
                        {
                            Color pixel = hinhgoc.GetPixel(i, j);
                            byte R = pixel.R;
                            byte G = pixel.G;
                            byte B = pixel.B;

                            Rs += R;
                            Gs += G;
                            Bs += B;
                        }
                    Rs = (int)(Rs / K);
                    Gs = (int)(Gs / K);
                    Bs = (int)(Bs / K);
                    Img.SetPixel(x, y, Color.FromArgb((byte)Rs, (byte)Gs, (byte)Bs));
                }
            return Img;
        }
    }
}
