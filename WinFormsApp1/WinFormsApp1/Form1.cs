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

            SetPredefineScene();

            pictureBox1.Image = drawArea;
            pictureBoxWidth = pictureBox1.Width;
            pictureBoxHeight = pictureBox1.Height;
            RedrawBitmap();
        }


        public void SetPredefineScene()
        {
            polygons.Add(new Polygon(new List<Point>() {
                new Point(pictureBox1.Width / 10, pictureBox1.Height * 2 / 10),
                new Point(pictureBox1.Width / 10, pictureBox1.Height * 4 / 10),
                new Point(pictureBox1.Width  * 3 / 10, pictureBox1.Height * 4 / 10) }));
            polygons.Add(new Polygon(new List<Point>() {
                new Point(pictureBox1.Width * 65 / 100, pictureBox1.Height * 2 / 10),
                new Point(pictureBox1.Width * 9 / 10, pictureBox1.Height * 2 / 10),
                new Point(pictureBox1.Width * 85 / 100, pictureBox1.Height  * 4 / 10),
                new Point(pictureBox1.Width * 6 / 10, pictureBox1.Height * 4 / 10) }));
            polygons.Add(new Polygon(new List<Point>() {
                new Point (pictureBox1.Width / 2, pictureBox1.Height * 6 / 10),
                new Point (pictureBox1.Width * 7 / 10, pictureBox1.Height / 2),
                new Point (pictureBox1.Width * 6 / 10, pictureBox1.Height * 7 / 10),
                new Point (pictureBox1.Width * 7 / 10, pictureBox1.Height * 9 / 10),
                new Point (pictureBox1.Width / 2, pictureBox1.Height * 8 / 10),
                new Point (pictureBox1.Width * 4 / 10, pictureBox1.Height * 9 / 10),
                new Point (pictureBox1.Width * 4 / 10, pictureBox1.Height / 2) }));

            polygon1 = polygons[0];
            polygon2 = polygons[2];
            SetPerpendicularEdges(
                polygon1.edges.Find(e => e.u.Equals(polygon1.vertices[1]) && e.v.Equals(polygon1.vertices[2])),
                polygon2.edges.Find(e => e.u.Equals(polygon2.vertices[5]) && e.v.Equals(polygon2.vertices[6])));

            polygon1 = polygons[1];
            polygon2 = polygons[2];
            SetPerpendicularEdges(
                polygon1.edges.Find(e => e.u.Equals(polygon1.vertices[2]) && e.v.Equals(polygon1.vertices[3])),
                polygon2.edges.Find(e => e.u.Equals(polygon2.vertices[5]) && e.v.Equals(polygon2.vertices[6])));

            polygon1 = polygons[2];
            polygon2 = polygons[2];
            polygonToEdit = polygon2;
            SetPerpendicularEdges(
                polygon1.edges.Find(e => e.u.Equals(new Point(pictureBox1.Width * 6 / 10, pictureBox1.Height * 7 / 10)) && e.v.Equals(new Point(pictureBox1.Width * 7 / 10, pictureBox1.Height * 9 / 10))),
                polygon2.edges.Find(e => e.u.Equals(new Point(pictureBox1.Width * 7 / 10, pictureBox1.Height / 2)) && e.v.Equals(new Point(pictureBox1.Width * 6 / 10, pictureBox1.Height * 7 / 10))));

            List<Edge?> edges = new List<Edge?>();
            edges.Add(polygonToEdit.edges.Find(_e => _e.u.Equals(polygonToEdit.vertices[6]) && _e.v.Equals(polygonToEdit.vertices[0])));
            edges.Add(polygonToEdit.edges.Find(_e => _e.u.Equals(polygonToEdit.vertices[0]) && _e.v.Equals(polygonToEdit.vertices[1])));
            polygonToEdit = polygons[1];
            edges.Add(polygonToEdit.edges.Find(_e => _e.u.Equals(polygonToEdit.vertices[3]) && _e.v.Equals(polygonToEdit.vertices[0])));
            edges.Add(polygonToEdit.edges.Find(_e => _e.u.Equals(polygonToEdit.vertices[0]) && _e.v.Equals(polygonToEdit.vertices[1])));
            polygonToEdit = polygons[0];
            edges.Add(polygonToEdit.edges.Find(_e => _e.u.Equals(polygonToEdit.vertices[1]) && _e.v.Equals(polygonToEdit.vertices[2])));
            edges.Add(polygonToEdit.edges.Find(_e => _e.u.Equals(polygonToEdit.vertices[2]) && _e.v.Equals(polygonToEdit.vertices[0])));
            foreach (Edge? e in edges)
            {
                if (e != null)
                {
                    SetEdgeLength(e, e.length);
                    e.properties.Add(new LengthProperty(e, e.length));
                }
            }
            polygonToEdit = null;
        }
    }
}
