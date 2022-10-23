using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public List<Polygon> polygons;
        public Polygon? polygonToEdit, polygon1, polygon2;
        public Point? pointToEdit;
        public Edge? edgeToEdit;
        public Edge? perpEdge1;
        public Edge? perpEdge2;
        public static Point? mouseClickPoint;
        //Pen edgePen = new Pen(Brushes.Black, 2);
        public static int radius = 20;
        Font vertexFont = new Font("Arial", 5);
        Font edgeFont = new Font("Arial", 7, FontStyle.Bold);
        StringFormat drawFormat = new StringFormat();
        public bool beginPolygon = false;
        public bool moveVertex = false;
        public bool moveEdge = false;
        public bool movePolygon = false;
        public static int pictureBoxWidth = 0;
        public static int pictureBoxHeight = 0;
        enum Algorithm { Default, Bresenham}
        public (Color color, bool isFree)[] colors = new (Color color, bool isFree)[]
        {
            (Color.Gold, true),
            (Color.HotPink, true),
            (Color.GreenYellow, true),
            (Color.Orange, true),
            (Color.Yellow, true),
            (Color.Crimson, true),
            (Color.DarkCyan, true),
            (Color.DarkGoldenrod, true),
            (Color.DarkGreen, true),
            (Color.DarkMagenta, true),
            (Color.DarkRed, true),
            (Color.DarkSalmon, true),
        };

        Algorithm whichAlgorithm = Algorithm.Default;

        public Form1()
        {
            InitializeComponent();
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            MinimumSize = new Size(screen.Width / 2, screen.Height / 2);
            MaximumSize = MinimumSize;
            drawArea = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            polygons = new List<Polygon>();
            polygons.Add(new Polygon(new List<Point>() { 
                new Point(pictureBox1.Width / 4, pictureBox1.Height / 3), 
                new Point(pictureBox1.Width / 4, pictureBox1.Height / 3 + 150), 
                new Point(pictureBox1.Width / 4 + 150, pictureBox1.Height / 3 + 150) }));
            polygons.Add(new Polygon(new List<Point>() { 
                new Point(pictureBox1.Width / 2, pictureBox1.Height / 3), 
                new Point(pictureBox1.Width / 2 + 300, pictureBox1.Height / 3), 
                new Point(pictureBox1.Width / 2 + 300, pictureBox1.Height / 3 + 150), 
                new Point(pictureBox1.Width / 2, pictureBox1.Height / 3 + 150) }));
            pictureBox1.Image = drawArea;
            pictureBoxWidth = pictureBox1.Width;
            pictureBoxHeight = pictureBox1.Height;
            RedrawBitmap();
        }
    }
}
