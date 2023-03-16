using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string FileHinh = @"F:\OneDrive - hcmute.edu.vn\Hocc\HK6\ThiGiacMay\lena_color.jpg";
            Bitmap HinhRGB = new Bitmap(FileHinh);
            picboxRGB.Image = HinhRGB;
            List<Bitmap> XYZ_arr = RGBtoXYZ(HinhRGB);
            picboxX.Image = XYZ_arr[0];
            picboxY.Image = XYZ_arr[1];
            picboxZ.Image = XYZ_arr[2];
            picboxXYZ.Image = XYZ_arr[3];

        }
        public List<Bitmap> RGBtoXYZ(Bitmap HinhGoc)
        {
            List<Bitmap> XYZ = new List<Bitmap>();
            Bitmap imgX = new Bitmap(HinhGoc.Width, HinhGoc.Height);
            Bitmap imgY = new Bitmap(HinhGoc.Width, HinhGoc.Height);
            Bitmap imgZ = new Bitmap(HinhGoc.Width, HinhGoc.Height);
            Bitmap imgXYZ = new Bitmap(HinhGoc.Width, HinhGoc.Height);

            double [,] cf = new double[,]{{0.4124564, 0.3575761, 0.01804375},
                                        {0.2126729, 0.7151522, 0.0721750},
                                        {0.0193339, 0.1191920, 0.9503041}};
                                       

            for (int x = 0; x < HinhGoc.Width; x++)
                for (int y = 0; y < HinhGoc.Height; y++)
                {
                    Color Pixel = HinhGoc.GetPixel(x, y);
                    byte R = Pixel.R;
                    byte G = Pixel.G;
                    byte B = Pixel.B;

                    double X = 0.4124564 * R + 0.3575761 * G + 0.01804375 * B;
                    double Y = 0.2126729 * R + 0.7151522 * G + 0.0721750 * B;
                    double Z = 0.0193339 * R + 0.1191920 * G + 0.9503041 * B;

                    imgX.SetPixel(x, y, Color.FromArgb((byte)X, (byte)X, (byte)X));
                    imgY.SetPixel(x, y, Color.FromArgb((byte)Y, (byte)Y, (byte)Y));
                    imgZ.SetPixel(x, y, Color.FromArgb((byte)Z, (byte)Z, (byte)Z));
                    imgXYZ.SetPixel(x, y, Color.FromArgb((byte)X, (byte)Y, (byte)Z));
                }
            XYZ.Add(imgX);
            XYZ.Add(imgY);
            XYZ.Add(imgZ);
            XYZ.Add(imgXYZ);
            return XYZ;
    }
    }
}
