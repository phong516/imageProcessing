using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP13
{
    public partial class Form1 : Form
    {
        Bitmap hinhGoc = new Bitmap(@"F:\OneDrive - hcmute.edu.vn\Hocc\HK6\ThiGiacMay\lena_color.jpg");
        int X1, Y1, X2, Y2;
        Graphics g;
        Pen pen = new Pen(Color.Red, width: 5);

        public Form1()
        {
            InitializeComponent();
            
            Bitmap hinhPhanDoan = Segmentation(hinhGoc, 80, 400, 150, 500, 45);
            //picBoxSegment.Image = hinhPhanDoan;
            picBoxGoc.Image = hinhGoc;

        }
        public Bitmap Segmentation(Bitmap hinh, int x1, int y1, int x2, int y2, int threshold)
        {
            Bitmap imgSegment = new Bitmap(hinh.Width, hinh.Height);

            int size = Math.Abs(x1 - x2) * Math.Abs(y1 - y2);

            int aR = 0;
            int aG = 0;
            int aB = 0;

            for (int i = x1; i <= x2; i++)
                for (int j = y1; j <= y2; j++)
                {
                    Color pixel = hinh.GetPixel(i, j);
                    aR += pixel.R;
                    aG += pixel.G;
                    aB += pixel.B;             
                }
            aR /= size;
            aG /= size;
            aB /= size;

            for (int x = 0; x < hinh.Width; x++)
                for (int y = 0; y < hinh.Height; y++)
                {
                    Color pixel = hinh.GetPixel(x, y);
                    int zR = pixel.R;
                    int zG = pixel.G;
                    int zB = pixel.B;

                    double Dza = Math.Sqrt(Math.Pow(zR - aR, 2) + Math.Pow(zG - aG, 2) + Math.Pow(zB - aB, 2));

                    if (Dza <= threshold) imgSegment.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    else imgSegment.SetPixel(x, y, Color.FromArgb(zR, zG, zB));
                }
            return imgSegment;
        }

        private void bSegment_Click(object sender, EventArgs e)
        {
            if ((tbX1.Text == "") | (tbY1.Text == "") | (tbX2.Text == "") | (tbY2.Text == ""))
            {
                MessageBox.Show("Please enter coordinates!");
            }
            byte nguong = (byte)trbarThreshold.Value;
            g = picBoxGoc.CreateGraphics();
            picBoxGoc.Refresh();
            g.DrawRectangle(pen, X1, Y1, X2 - X1, Y2 - Y1);
            picBoxSegment.Image = Segmentation(hinhGoc, X1, Y1, X2, Y2, nguong);
        }

        private void trbarThreshold_Scroll(object sender, EventArgs e)
        {
            lblThreshold.Text = trbarThreshold.Value.ToString();
        }



        private void picBoxGoc_MouseUp(object sender, MouseEventArgs e)
        {
            X2 = e.X;
            Y2 = e.Y;
            tbX2.Text = Convert.ToString(X2);
            tbY2.Text = Convert.ToString(Y2);

            g = picBoxGoc.CreateGraphics();


            g.DrawRectangle(pen, X1, Y1, X2 - X1, Y2 - Y1);
        }

        private void picBoxGoc_MouseDown(object sender, MouseEventArgs e)
        {
            picBoxGoc.Refresh();
            X1 = e.X;
            Y1 = e.Y;
            tbX1.Text = Convert.ToString(X1);
            tbY1.Text = Convert.ToString(Y1);

        }
    }
}
