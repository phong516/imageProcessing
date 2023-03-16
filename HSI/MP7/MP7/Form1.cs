using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string FileHinh = @"F:\OneDrive - hcmute.edu.vn\Hocc\HK6\ThiGiacMay\lena_color.jpg";
            Bitmap HinhRGB = new Bitmap(FileHinh);
            picboxRGB.Image = HinhRGB;
            List<Bitmap> HSV_arr = RGBtoHSI(HinhRGB);
            picboxHue.Image = HSV_arr[0];
            picboxSaturation.Image = HSV_arr[1];
            picboxIntensity.Image = HSV_arr[2];
            picboxHSI.Image = HSV_arr[3];

        }
        public List<Bitmap> RGBtoHSI(Bitmap HinhGoc)
        {
            List<Bitmap> HSI = new List<Bitmap>();
            Bitmap imgH = new Bitmap(HinhGoc.Width, HinhGoc.Height);
            Bitmap imgS = new Bitmap(HinhGoc.Width, HinhGoc.Height);
            Bitmap imgI = new Bitmap(HinhGoc.Width, HinhGoc.Height);
            Bitmap imgHSI = new Bitmap(HinhGoc.Width, HinhGoc.Height);


            for (int x = 0; x < HinhGoc.Width; x++)
                for (int y = 0; y < HinhGoc.Height; y++)
                {
                    Color Pixel = HinhGoc.GetPixel(x, y);
                    byte R = Pixel.R;
                    byte G = Pixel.G;
                    byte B = Pixel.B;
                    
                    double theta1 = (double)((R - G) + (R - B)) * 0.5;
                    double theta2 = (double)(Math.Sqrt((R - G) * (R - G) + (R - B) * (G - B)));
                    double theta = Math.Acos(theta1 / theta2);

                    double H;
                    if (B <= G) H = theta;
                    else H = 2.0 * Math.PI - theta;
                    H *= 180.0 / Math.PI;

                    double S = 1.0 - 3.0 * Math.Min(R, Math.Min(G, B)) / (R + G + B);
                    S *= 255.0;
                    double I = (double)((R + G + B) / 3);

                    imgH.SetPixel(x, y, Color.FromArgb((byte)H, (byte)H, (byte)H));
                    imgS.SetPixel(x, y, Color.FromArgb((byte)S, (byte)S, (byte)S));
                    imgI.SetPixel(x, y, Color.FromArgb((byte)I, (byte)I, (byte)I));
                    imgHSI.SetPixel(x, y, Color.FromArgb((byte)H, (byte)S, (byte)I));
                }
            HSI.Add(imgH);
            HSI.Add(imgS);
            HSI.Add(imgI);
            HSI.Add(imgHSI);
            return HSI;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void picboxS_Click(object sender, EventArgs e)
        {

        }

        private void picboxHue_Click(object sender, EventArgs e)
        {

        }

        private void picboxIntensity_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
