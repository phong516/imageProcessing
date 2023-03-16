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

namespace MP5_RGB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string FileHinh = @"F:\OneDrive - hcmute.edu.vn\Hocc\HK6\ThiGiacMay\bird_small.jpg";
            Bitmap HinhRGB = new Bitmap(FileHinh);
            picBoxRGB.Image = HinhRGB;
            Double[,] His = TinhHistogram(HinhRGB);
            List <PointPairList> Points = ChuyenDoiHistogram(His);
            zgHistogram.GraphPane = BieuDoHistogram(Points);
        }

        public Double[,] TinhHistogram(Bitmap hinhrgb)
        {
            double[,] Histogram = new double[3, 256];
            for (int y = 0; y < hinhrgb.Height; y++)
                for (int x = 0; x < hinhrgb.Width; x++)
                {
                    Color Pixel = hinhrgb.GetPixel(x, y);
                    byte r = Pixel.R;
                    byte g = Pixel.G;
                    byte b = Pixel.B;
                    Histogram[2, r]++;
                    Histogram[1, g]++;
                    Histogram[0, b]++;
                }
            return Histogram;
        }

        List <PointPairList> ChuyenDoiHistogram(double[,] histogram)
        {
            List <PointPairList> points = new List <PointPairList>();
            PointPairList RedPoints = new PointPairList();
            PointPairList GreenPoints = new PointPairList();
            PointPairList BluePoints = new PointPairList();

            for (int i = 0; i < 256; i++)
            {
                RedPoints.Add(i, histogram[2, i]);
                GreenPoints.Add(i, histogram[1, i]);
                BluePoints.Add(i, histogram[0, i]);
            }
            points.Add(RedPoints);
            points.Add(BluePoints);
            points.Add(GreenPoints);

            return points;
        }

        public GraphPane BieuDoHistogram(List <PointPairList> his)
        {
            GraphPane gp = new GraphPane();

            gp.Title.Text = @"Biểu đồ Histogram";
            gp.Rect = new Rectangle(0, 0, 600, 400);

            gp.XAxis.Title.Text = @"Giá trị mức của các điểm ảnh";
            gp.XAxis.Scale.Min = 0;
            gp.XAxis.Scale.Max = 255;
            gp.XAxis.Scale.MajorStep = 5;
            gp.XAxis.Scale.MinorStep = 1;

            gp.YAxis.Title.Text = @"Số điểm ảnh có cùng mức";
            gp.YAxis.Scale.Min = 0;
            gp.YAxis.Scale.Max = 15000;
            gp.YAxis.Scale.MajorStep = 5;
            gp.YAxis.Scale.MinorStep = 1;

            gp.AddBar("Histogram R", his[2], Color.Red);
            gp.AddBar("Histogram G", his[1], Color.Green);
            gp.AddBar("Histogram B", his[0], Color.Blue);
            return gp;
        }
    }
}
