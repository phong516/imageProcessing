using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string FileHinh = @"F:\OneDrive - hcmute.edu.vn\Hocc\HK6\ThiGiacMay\lena_color.jpg";
            Bitmap HinhRGB = new Bitmap(FileHinh);
            picboxRGB.Image = HinhRGB;
            List<Bitmap> YCrCb_arr = RGBtoYCrCb(HinhRGB);
            picboxY.Image = YCrCb_arr[0];
            picboxCr.Image = YCrCb_arr[1];
            picboxCb.Image = YCrCb_arr[2];
            picboxYCrCb.Image = YCrCb_arr[3];
        }
        public List<Bitmap> RGBtoYCrCb(Bitmap HinhGoc)
        {
            List<Bitmap> YCrCb = new List<Bitmap>();
            Bitmap imgY = new Bitmap(HinhGoc.Width, HinhGoc.Height);
            Bitmap imgCr = new Bitmap(HinhGoc.Width, HinhGoc.Height);
            Bitmap imgCb = new Bitmap(HinhGoc.Width, HinhGoc.Height);
            Bitmap imgYCrCb = new Bitmap(HinhGoc.Width, HinhGoc.Height);

            for (int x = 0; x < HinhGoc.Width; x++)
                for (int y = 0; y < HinhGoc.Height; y++)
                {
                    Color Pixel = HinhGoc.GetPixel(x, y);
                    byte R = Pixel.R;
                    byte G = Pixel.G;
                    byte B = Pixel.B;

                    double Y = (double)(16.0 + (65.738 / 256.0) * R + (129.057 / 256.0) * G + (25.064 / 256.0) * B);
                    double Cb = (double)(128.0 - (37.945 / 256.0) * R - (74.494 / 256.0) * G + (112.439 / 256.0) * B);
                    double Cr = (double)(128.0 + (112.439 / 256.0) * R - (94.154 / 256.0) * G - (18.285 / 256.0) * B);

                    imgY.SetPixel(x, y, Color.FromArgb((byte)Y, (byte)Y, (byte)Y));
                    imgCr.SetPixel(x, y, Color.FromArgb((byte)Cr, (byte)Cr, (byte)Cr));
                    imgCb.SetPixel(x, y, Color.FromArgb((byte)Cb, (byte)Cb, (byte)Cb));
                    imgYCrCb.SetPixel(x, y, Color.FromArgb((byte)Y, (byte)Cb, (byte)Cr));
                }
            YCrCb.Add(imgY);
            YCrCb.Add(imgCr);
            YCrCb.Add(imgCb);
            YCrCb.Add(imgYCrCb);
            return YCrCb;
        }
    }
}
