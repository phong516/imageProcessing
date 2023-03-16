using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace MP3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Bitmap HinhGoc = new Bitmap(@"F:\Hocc\HK6\ThiGiacMay\lena_color.jpg");
            picBoxGoc.Image= HinhGoc;
            picBoxXamAverage.Image = RGBtoGrayScale_Average(HinhGoc);
            picBoxXamLightness.Image = RGBtoGrayScale_Lightness(HinhGoc);
            picBoxXamLuminance.Image = RGBtoGrayScale_Luminance(HinhGoc);
        }

        public Bitmap RGBtoGrayScale_Average(Bitmap hinhgoc)
        {
            Bitmap GrayScale = new Bitmap(hinhgoc.Width, hinhgoc.Height);
            for (int x = 0; x < hinhgoc.Width; x++)
                for (int y = 0; y < hinhgoc.Height; y++)
                {
                    Color pixel = hinhgoc.GetPixel(x, y);
                    byte r = pixel.R;
                    byte g = pixel.G;
                    byte b = pixel.B;
                    byte a = pixel.A;
                    byte gray = (byte)((r + g + b) / 3);
                    GrayScale.SetPixel(x, y, Color.FromArgb(a, gray, gray, gray));
                }
            return GrayScale;
        }

        public Bitmap RGBtoGrayScale_Lightness(Bitmap hinhgoc)
        {
            Bitmap GrayScale = new Bitmap(hinhgoc.Width, hinhgoc.Height);
            for (int x = 0; x < hinhgoc.Width; x++)
                for (int y = 0; y < hinhgoc.Height; y++)
                {
                    Color pixel = hinhgoc.GetPixel(x, y);
                    byte r = pixel.R;
                    byte g = pixel.G;
                    byte b = pixel.B;
                    byte a = pixel.A;

                    byte max = Math.Max(r, Math.Max(g, b));
                    byte min = Math.Min(r, Math.Min(g, b));

                    byte gray = (byte)((max + min) / 2);
                    GrayScale.SetPixel(x, y, Color.FromArgb(a, gray, gray, gray));
                }
            return GrayScale;
        }

        public Bitmap RGBtoGrayScale_Luminance(Bitmap hinhgoc)
        {
            Bitmap GrayScale = new Bitmap(hinhgoc.Width, hinhgoc.Height);
            for (int x = 0; x < hinhgoc.Width; x++)
                for (int y = 0; y < hinhgoc.Height; y++)
                {
                    Color pixel = hinhgoc.GetPixel(x, y);
                    byte r = pixel.R;
                    byte g = pixel.G;
                    byte b = pixel.B;
                    byte a = pixel.A;
                    byte gray = (byte)(0.2126 * r + 0.7152 * g + 0.0722 * b);
                    GrayScale.SetPixel(x, y, Color.FromArgb(a, gray, gray, gray));
                }
            return GrayScale;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
