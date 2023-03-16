using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace MP5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string filehinh = @"F:\OneDrive - hcmute.edu.vn\Hocc\HK6\ThiGiacMay\bird_small.jpg";
            Bitmap hinhgoc = new Bitmap(filehinh);
            picBoxGoc.Image = hinhgoc;

            Bitmap HinhMucXam = RGBtoGrayScale_Luminance(hinhgoc);
            picBoxXam.Image = HinhMucXam;

            double[] histogram = TinhHistogram(HinhMucXam);

            PointPairList points = ChuyenDoiHistogram(histogram);

            zgHistogram.GraphPane = BieudoHistogram(points);
        }
        
        public Bitmap RGBtoGrayScale_Luminance(Bitmap HinhGoc)
        {
            Bitmap luminance = new Bitmap(HinhGoc.Width, HinhGoc.Height);
            for (int y = 0; y < luminance.Height; y++)
                for (int x = 0; x < luminance.Width; x++)
                {
                    Color pixel = HinhGoc.GetPixel(x, y);
                    byte A = pixel.A;
                    byte R = pixel.R;
                    byte G = pixel.G;
                    byte B = pixel.B;

                    byte gray = (byte)(0.2126 * R + 0.7152 * G + 0.0722 * B);
                    luminance.SetPixel(x, y, Color.FromArgb(A, gray, gray, gray));
                }
            return luminance;
        }

        public double[] TinhHistogram(Bitmap anhmucxam)
        {
            double[] histogram = new double[256];
            for (int y = 0; y < anhmucxam.Height; y++)
                for (int x = 0; x < anhmucxam.Width; x++)
                {
                    Color color = anhmucxam.GetPixel(x, y);
                    byte gray = color.R;
                    histogram[gray] ++;
                }
            return histogram;
        }

        PointPairList ChuyenDoiHistogram(double[] histogram)
        {
            PointPairList points = new PointPairList();

            for (int i = 0; i < histogram.Length; i++)
            {
                points.Add(i, histogram[i]);
            }
            return points;
        }

        public GraphPane BieudoHistogram(PointPairList histogram)
        {
            GraphPane gp = new GraphPane();

            gp.Title.Text = @"Biểu đồ Histogram";
            gp.Rect = new Rectangle(0, 0, 700, 500);

            gp.XAxis.Title.Text = @"Giá trị mức xám của các điểm ảnh";
            gp.XAxis.Scale.Min = 0;
            gp.XAxis.Scale.Max = 255;
            gp.XAxis.Scale.MajorStep = 5;
            gp.XAxis.Scale.MinorStep = 1;

            gp.YAxis.Title.Text = @"Số điểm ảnh có cùng mức xám";
            gp.YAxis.Scale.Max = 15000;
            gp.YAxis.Scale.Min = 0;
            gp.YAxis.Scale.MajorStep = 5;
            gp.YAxis.Scale.MinorStep = 1;

            gp.AddBar("Histogram", histogram, Color.OrangeRed);

            return gp;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void picBoxXam_Click(object sender, EventArgs e)
        {

        }

        private void picBoxGoc_Click(object sender, EventArgs e)
        {

        }
    }
}
