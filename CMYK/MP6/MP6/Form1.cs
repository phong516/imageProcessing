using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string FileHinh = @"F:\OneDrive - hcmute.edu.vn\Hocc\HK6\ThiGiacMay\lena_color.jpg";
            Bitmap AnhRGB = new Bitmap(FileHinh);
            picboxRGB.Image = AnhRGB;
            List<Bitmap> CMYK = RGBtoCMYK(AnhRGB);
            picboxCyan.Image = CMYK[0];
            picboxMagenta.Image = CMYK[1];
            picboxYellow.Image = CMYK[2];
            picboxblacK.Image = CMYK[3];

        }
        public List<Bitmap> RGBtoCMYK(Bitmap HinhGoc)
        {
            List<Bitmap> AnhCMYK = new List<Bitmap>();
            Bitmap Cyan = new Bitmap(HinhGoc.Width, HinhGoc.Height);
            Bitmap Magenta = new Bitmap(HinhGoc.Width, HinhGoc.Height);
            Bitmap Yellow = new Bitmap(HinhGoc.Width, HinhGoc.Height);
            Bitmap blacK = new Bitmap(HinhGoc.Width, HinhGoc.Height);

            for (int x = 0; x < HinhGoc.Width; x++)
                for (int y = 0; y < HinhGoc.Height; y++)
                {
                    Color Pixel = HinhGoc.GetPixel(x, y);
                    byte R = Pixel.R;
                    byte G = Pixel.G;
                    byte B = Pixel.B;

                    Cyan.SetPixel(x, y, Color.FromArgb(0, G, B));
                    Magenta.SetPixel(x, y, Color.FromArgb(R, 0, B));
                    Yellow.SetPixel(x, y, Color.FromArgb(R, G, 0));

                    byte K = Math.Min(R, Math.Min(G, B));
                    blacK.SetPixel(x, y, Color.FromArgb(K, K, K));
                }
            AnhCMYK.Add(Cyan);
            AnhCMYK.Add(Magenta);
            AnhCMYK.Add(Yellow);
            AnhCMYK.Add(blacK);
            return AnhCMYK;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void picboxYellow_Click(object sender, EventArgs e)
        {

        }

        private void picboxblacK_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void picboxMagenta_Click(object sender, EventArgs e)
        {

        }

        private void picboxCyan_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void picboxRGB_Click(object sender, EventArgs e)
        {

        }
    }
}
