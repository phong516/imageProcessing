using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MP4
{
    public partial class Form1 : Form
    {
        Bitmap hinhgoc;
        public Form1()
        {
            InitializeComponent();
            hinhgoc = new Bitmap(@"F:\OneDrive - hcmute.edu.vn\Hocc\HK6\ThiGiacMay\lena_color.jpg");
            picBoxRGB.Image = hinhgoc;
            picBoxXam.Image = RGBtoGrayScale(hinhgoc);
            picBoxBinary.Image = RGBtoBinary(hinhgoc, 100);
        }
        public Bitmap RGBtoBinary(Bitmap HinhGoc, byte threshold)
        {
            Bitmap binary = new Bitmap(HinhGoc.Width, HinhGoc.Height);
            for (int y = 0; y < HinhGoc.Height; y++)
                for (int x = 0; x < HinhGoc.Width; x++)
                {
                    Color pixel = HinhGoc.GetPixel(x, y);
                    byte R = pixel.R;
                    byte G = pixel.G;
                    byte B = pixel.B;
                    byte A = pixel.A;

                    byte Gray = (byte)(0.2126 * R + 0.7152 * G + 0.0722 * B);
                    if (Gray < threshold) Gray = 0;
                    else Gray = 255;
                    binary.SetPixel(x, y, Color.FromArgb(A, Gray, Gray, Gray));
                }
            return binary;
        }

        public Bitmap RGBtoGrayScale(Bitmap HinhGoc)
        {
            Bitmap grayscale = new Bitmap(HinhGoc.Width, HinhGoc.Height);
            for (int y = 0; y < HinhGoc.Height; y++)
                for (int x = 0; x < HinhGoc.Width; x++)
                {
                    Color pixel = HinhGoc.GetPixel(x, y);
                    byte R = pixel.R;
                    byte G = pixel.G;
                    byte B = pixel.B;
                    byte A = pixel.A;

                    byte Gray = (byte)(0.2126 * R + 0.7152 * G + 0.0722 * B);
                    grayscale.SetPixel(x, y, Color.FromArgb(A, Gray, Gray, Gray));
                }
            return grayscale;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ScrollBar_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void lblThreshold_Click(object sender, EventArgs e)
        {

        }

        private void ScrollBar_ValueChanged(object sender, EventArgs e)
        {
            byte Nguong = (byte)ScrollBar.Value;
            lblThresholdDisplay.Text = Nguong.ToString();
            picBoxBinary.Image = RGBtoBinary(hinhgoc, Nguong);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
