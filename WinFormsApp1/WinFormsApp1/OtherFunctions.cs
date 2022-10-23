using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public partial class Form1
    {
        public void DrawVertex(Point p)
        {
            using(Graphics g = Graphics.FromImage(drawArea))
            {
                g.FillEllipse(Brushes.Black, p.X - radius / 2, p.Y - radius / 2, radius, radius);
                string coordinates = $"({p.X}, {p.Y})";
                g.DrawString(coordinates, vertexFont, Brushes.Black, p.X - 5, p.Y - 25, drawFormat);
            }
        }
        /*public void DrawCenter(Point p)
        {
            using (Graphics g = Graphics.FromImage(drawArea))
            {
                using(Pen centerPen = new Pen(Brushes.Gray, 5))
                {
                    centerPen.DashPattern = new float[] {2, 1};
                    g.DrawEllipse(centerPen, p.X - radius / 2, p.Y - radius / 2, radius, radius);
                }
            }
        }*/
        public void DrawEdge(Edge e, Color c)
        {
            switch (whichAlgorithm)
            {
                case Algorithm.Default:
                    using (Graphics g = Graphics.FromImage(drawArea))
                    {
                        using (Pen p = new Pen(c, 2))
                        {
                            g.DrawLine(p, e.u.X, e.u.Y, e.v.X, e.v.Y);
                        }
                        int i = 0;
                        foreach (PerpendicularityProperty property in e.properties.Where(_property => _property is PerpendicularityProperty))
                        {
                            using (Pen p = new Pen(property.color, 2))
                            {
                                if(e.u.Y == e.v.Y ) g.DrawLine(p, e.u.X, e.u.Y + i, e.v.X, e.v.Y + i);
                                else g.DrawLine(p, e.u.X + i, e.u.Y, e.v.X + i, e.v.Y);
                            }
                            i *= -1;
                            if (i >= 0) i += 3;
                        } 
                    }
                    break;
                case Algorithm.Bresenham:
                    if (e.properties.Exists(p => p is PerpendicularityProperty)) c = Color.Red;

                    int dx = e.v.X - e.u.X;
                    int dy = e.v.Y - e.u.Y;
                                                                                                                   // \ 6 | 7 /
                    if (dx >  0 &&  dy >= 0 &&  dx >=  dy) BresenhamAlgorithm1(e.u.X, e.u.Y, e.v.X, e.v.Y, c);     //  \  |  /
                    if (dx >= 0 &&  dy >  0 &&  dx <   dy) BresenhamAlgorithm2(e.u.X, e.u.Y, e.v.X, e.v.Y, c);     //   \ | /
                    if (dx <  0 &&  dy >  0 && -dx <   dy) BresenhamAlgorithm3(e.u.X, e.u.Y, e.v.X, e.v.Y, c);     // 5  \|/  8
                    if (dx <  0 &&  dy >= 0 && -dx >=  dy) BresenhamAlgorithm4(e.u.X, e.u.Y, e.v.X, e.v.Y, c);     //- - -|- - ->
                    if (dx <  0 &&  dy <  0 && -dx >= -dy) BresenhamAlgorithm5(e.u.X, e.u.Y, e.v.X, e.v.Y, c);     //    /|\
                    if (dx <  0 &&  dy <  0 && -dx <  -dy) BresenhamAlgorithm6(e.u.X, e.u.Y, e.v.X, e.v.Y, c);     // 4 / | \ 1
                    if (dx >= 0 &&  dy <  0 &&  dx <  -dy) BresenhamAlgorithm7(e.u.X, e.u.Y, e.v.X, e.v.Y, c);     //  /  |  \
                    if (dx >  0 &&  dy <  0 &&  dx >= -dy) BresenhamAlgorithm8(e.u.X, e.u.Y, e.v.X, e.v.Y, c);     // / 3 | 2 \
                    break;                                                                                         //     v
                default:
                    break;
            }
            using (Graphics g = Graphics.FromImage(drawArea))
            {
                using (Pen p = new Pen(c, 2))
                {
                    string length = $"{Math.Round(e.length, 2)}";
                    g.DrawString(length, edgeFont, Brushes.CornflowerBlue, (e.u.X + e.v.X) / 2 - 5, ((e.u.Y + e.v.Y)) / 2 - 5, drawFormat);
                }
            }
        }
        public void BresenhamAlgorithm1(int x1, int y1, int x2, int y2, Color c)
        {            
            int dx = x2 - x1;
            int dy = y2 - y1;
            int d = 2 * dy - dx;            // initial value of d
            int incrE = 2 * dy;             // increment used for move to E
            int incrNE = 2 * (dy - dx);     // increment used for move to NE
            int x = x1;
            int y = y1;
            drawArea.SetPixel(x, y, c);
            while (x < x2)
            {
                if (d < 0) //choose E
                {
                    d += incrE;
                }
                else      //choose NE
                {
                    d += incrNE;
                    y++;
                }
                x++;
                drawArea.SetPixel(x, y, c);
                drawArea.SetPixel(x, y + 1, c);
            }
        }
        public void BresenhamAlgorithm2(int x1, int y1, int x2, int y2, Color c)
        {
            int dx = y2 - y1;
            int dy = x2 - x1;
            int d = 2 * dy - dx;            // initial value of d
            int incrE = 2 * dy;             // increment used for move to E
            int incrNE = 2 * (dy - dx);     // increment used for move to NE
            int x = x1;
            int y = y1;
            drawArea.SetPixel(x, y, c);
            while (y < y2)
            {
                if (d < 0) //choose E
                {
                    d += incrE;
                }
                else      //choose NE
                {
                    d += incrNE;
                    x++;
                }
                y++;
                drawArea.SetPixel(x, y, c);
                drawArea.SetPixel(x + 1, y, c);
            }
        }
        public void BresenhamAlgorithm3(int x1, int y1, int x2, int y2, Color c)
        {
            int dx = y2 - y1;
            int dy = x1 - x2;
            int d = 2 * dy - dx;            // initial value of d
            int incrE = 2 * dy;             // increment used for move to E
            int incrNE = 2 * (dy - dx);     // increment used for move to NE
            int x = x1;
            int y = y1;
            drawArea.SetPixel(x, y, c);
            while (y < y2)
            {
                if (d < 0) //choose E
                {
                    d += incrE;
                }
                else      //choose NE
                {
                    d += incrNE;
                    x--;
                }
                y++;
                drawArea.SetPixel(x, y, c);
                drawArea.SetPixel(x + 1, y, c);
            }
        }
        public void BresenhamAlgorithm4(int x1, int y1, int x2, int y2, Color c)
        {
            int dx = x1 - x2;
            int dy = y2 - y1;
            int d = 2 * dy - dx;            // initial value of d
            int incrE = 2 * dy;             // increment used for move to E
            int incrNE = 2 * (dy - dx);     // increment used for move to NE
            int x = x1;
            int y = y1;
             drawArea.SetPixel(x, y, c);
            while (x > x2)
            {
                if (d < 0) //choose E
                {
                    d += incrE;
                }
                else      //choose NE
                {
                    d += incrNE;
                    y++;
                }
                x--;
                drawArea.SetPixel(x, y, c);
                drawArea.SetPixel(x, y + 1, c);
            }
        }
        public void BresenhamAlgorithm5(int x1, int y1, int x2, int y2, Color c)
        {
            int dx = x1 - x2;
            int dy = y1 - y2;
            int d = 2 * dy - dx;            // initial value of d
            int incrE = 2 * dy;             // increment used for move to E
            int incrNE = 2 * (dy - dx);     // increment used for move to NE
            int x = x1;
            int y = y1;
            drawArea.SetPixel(x, y, c);
            while (x > x2)
            {
                if (d < 0) //choose E
                {
                    d += incrE;
                }
                else      //choose NE
                {
                    d += incrNE;
                    y--;
                }
                x--;
                drawArea.SetPixel(x, y, c);
                drawArea.SetPixel(x, y + 1, c);
            }
        }
        public void BresenhamAlgorithm6(int x1, int y1, int x2, int y2, Color c)
        {
            int dx = y1 - y2;
            int dy = x1 - x2;
            int d = 2 * dy - dx;            // initial value of d
            int incrE = 2 * dy;             // increment used for move to E
            int incrNE = 2 * (dy - dx);     // increment used for move to NE
            int x = x1;
            int y = y1;
            drawArea.SetPixel(x, y, c);
            while (y > y2)
            {
                if (d < 0) //choose E
                {
                    d += incrE;
                }
                else      //choose NE
                {
                    d += incrNE;
                    x--;
                }
                y--;
                drawArea.SetPixel(x, y, c);
                drawArea.SetPixel(x + 1, y, c);
            }
        }
        public void BresenhamAlgorithm7(int x1, int y1, int x2, int y2, Color c)
        {
            int dx = y1 - y2;
            int dy = x2 - x1;
            int d = 2 * dy - dx;            // initial value of d
            int incrE = 2 * dy;             // increment used for move to E
            int incrNE = 2 * (dy - dx);     // increment used for move to NE
            int x = x1;
            int y = y1;
            drawArea.SetPixel(x, y, c);
            while (y > y2)
            {
                if (d < 0) //choose E
                {
                    d += incrE;
                }
                else      //choose NE
                {
                    d += incrNE;
                    x++;
                }
                y--;
                drawArea.SetPixel(x, y, c);
                drawArea.SetPixel(x + 1, y, c);
            }
        }
        public void BresenhamAlgorithm8(int x1, int y1, int x2, int y2, Color c)
        {
            int dx = x2 - x1;
            int dy = y1 - y2;
            int d = 2 * dy - dx;            // initial value of d
            int incrE = 2 * dy;             // increment used for move to E
            int incrNE = 2 * (dy - dx);     // increment used for move to NE
            int x = x1;
            int y = y1;
            drawArea.SetPixel(x, y, c);
            while (x < x2)
            {
                if (d < 0) //choose E
                {
                    d += incrE;
                }
                else      //choose NE
                {
                    d += incrNE;
                    y--;
                }
                x++;
                drawArea.SetPixel(x, y, c);
                drawArea.SetPixel(x, y + 1, c);
            }
        }
        public void AddPolygon(Point p)
        {
            polygons.Add(new Polygon(p));
            DrawVertex(p);
        }
        public void AddVertex(Point p)
        {
            Polygon polygon = polygons.Last();
            polygon.edges.Add(new Edge(polygon.vertices.Last(), p));
            polygons.Last().vertices.Add(p);
            if(polygon.vertices.Count >= 3)
            {
                polygon.edges.RemoveAll(e => e.v == polygon.vertices.First());
                polygon.edges.Add(new Edge(p, polygon.vertices.First()));
            }
            DrawVertex(p);
        }
        public int DistFromEdge(Edge e, Point p)
        {
            if (!((e.u.X < p.X && p.X < e.v.X) || (e.v.X < p.X && p.X < e.u.X) ||
                (Math.Abs(e.u.X - e.v.X) <= radius / 10 && ((e.u.Y < p.Y && p.Y < e.v.Y) || (e.v.Y < p.Y && p.Y < e.u.Y)))) ||
                Math.Sqrt(Math.Pow(e.u.X - p.X, 2) + Math.Pow(e.u.Y - p.Y, 2)) < radius / 2 ||
                Math.Sqrt(Math.Pow(e.v.X - p.X, 2) + Math.Pow(e.v.Y - p.Y, 2)) < radius / 2) return Int32.MaxValue;
            int A = -(e.v.Y - e.u.Y);
            int B = (e.v.X - e.u.X);
            int C = -B * e.u.Y - A * e.u.X;
            return (int)(Math.Abs(A * p.X + B * p.Y + C) / Math.Sqrt(A * A + B * B));
        }
        public Point ProjectOnLine(Edge e, Point p)
        {
            int A = -(e.v.Y - e.u.Y);
            int B = (e.v.X - e.u.X);
            int C = -B * e.u.Y - A * e.u.X;
            int den = A * A + B * B;
            return new Point((B * B * p.X - A * B * p.Y - A * C) / den, (-A * B * p.X + A * A * p.Y - B * C) / den);
        }
        public void AddVertexToEdge(Point p)
        {
            foreach(Polygon polygon in polygons)
            {
                for(int i = 0; i < polygon.edges.Count; i++)
                {
                    Edge e = polygon.edges[i];
                    if(DistFromEdge(e, p) < radius / 2 )
                    {
                        Point newPoint = ProjectOnLine(e, p);
                        polygon.vertices.Add(newPoint);

                        foreach (PerpendicularityProperty property in e.properties.Where(_p => _p is PerpendicularityProperty))
                        {
                            property.perpendicularTo.properties.RemoveAll(
                                _property => _property is PerpendicularityProperty && 
                                ((PerpendicularityProperty)_property).perpendicularTo == e);
                            int? colorIndex = Array.IndexOf(colors, Array.Find(colors, c => c.color == property.color));
                            if (colorIndex != null) colors[(int)colorIndex].isFree = true;
                        }

                        polygon.edges.Remove(e);
                        polygon.edges.Add(new Edge(e.u, newPoint));
                        polygon.edges.Add(new Edge(newPoint, e.v));
                        break;
                    }
                }
            }
        }
        public void MarkEdge(Point p)
        {
            foreach (Polygon polygon in polygons)
            {
                for (int i = 0; i < polygon.edges.Count; i++)
                {
                    Edge e = polygon.edges[i];
                    if (DistFromEdge(e, p) < radius / 2)
                    {
                        DrawEdge(e, Color.LightBlue);
                        DrawVertex(e.u);
                        DrawVertex(e.v);
                        break;
                    }
                }
            }
        }
        public void SetEdgeLength(Edge? e)
        {
            if (e == null || polygonToEdit == null) return;
            WarnIfChangeMayCauseDamage(polygonToEdit);
            if(e.properties.Exists(p => p is LengthProperty || p is LengthLimitProperty))
            {
                MessageBox.Show("Can't add relation - edge already has a length type relation!");
                return;
            }

            ChangeLengthForm changeLengthForm = new ChangeLengthForm(e);
            changeLengthForm.StartPosition = FormStartPosition.CenterParent;
            changeLengthForm.ShowDialog(this);
            if (changeLengthForm.length != -1)
            {
                Polygon backupCopy = new Polygon(polygonToEdit);

                double newLength = changeLengthForm.length;
                double scale = newLength / e.length;
                Point newV = e.u + ((e.v - e.u) * scale);
                //if(!newV.IsMovable())
                //{
                //    MessageBox.Show("Can't add relation - edge gets outside the bitmap!");
                //    return;
                //}
                int xDiff = newV.X - e.v.X, yDiff = newV.Y - e.v.Y;
                MoveVertex(e.v, newV);
                polygonToEdit.Repair(e.v, xDiff, yDiff, e.u);

                if(polygonToEdit.edges.Exists(_e => _e.IsToRepair()))
                {
                    polygonToEdit.SetVertices(backupCopy);
                    MessageBox.Show("Can't add relation - may ruin other relations!");
                }
                else e.properties.Add(new LengthProperty(e, e.length));
            }

            e = null;
        }
        public void ViewRelations(Edge? e)
        {
            if (e == null) return;
            ViewRelationsForm viewRelationsForm = new ViewRelationsForm(e, colors);
            viewRelationsForm.StartPosition = FormStartPosition.CenterParent;
            viewRelationsForm.ShowDialog(this);
        }
        public void SetEdgeLength(Polygon polygon, Edge? e, double newLength, double minLength, double maxLength)
        {
            if (e == null) return;

            Polygon backupCopy = new Polygon(polygon);

            double scale = newLength / e.length;
            Point newV = e.u + ((e.v - e.u) * scale);
            //if (!newV.IsMovable())
            //{
            //    MessageBox.Show("Can't add relation - edge gets outside the bitmap!");
            //    return;
            //}
            int xDiff = newV.X - e.v.X, yDiff = newV.Y - e.v.Y;
            MoveVertex(e.v, newV);
            polygon.Repair(e.v, xDiff, yDiff, e.u);

            if (polygon.edges.Exists(_e => _e.IsToRepair()))
            {
                polygon.SetVertices(backupCopy);
                MessageBox.Show("Can't add relation - may ruin other relations!");
            }
            else e.properties.Add(new LengthLimitProperty(e, minLength, maxLength));
        }
        public void SetEdgeLength(Edge? e, double newLength)
        {
            if (e == null) return;

            double scale = newLength / e.length;
            Point newV = e.u + ((e.v - e.u) * scale);
            MoveVertex(e.v, newV);
        }
        public void LimitEdgeLength(Edge? e)
        {
            if (e == null || polygonToEdit == null) return;
            WarnIfChangeMayCauseDamage(polygonToEdit);
            if (e.properties.Exists(p => p is LengthProperty || p is LengthLimitProperty))
            {
                MessageBox.Show("Can't add relation - edge already has a length type relation!");
                return;
            }

            LimitLengthForm limitLengthForm = new LimitLengthForm(e);
            limitLengthForm.StartPosition = FormStartPosition.CenterParent;
            limitLengthForm.ShowDialog(this);
            if(limitLengthForm.minLength != -1 && limitLengthForm.maxLength != -1)
            {
                if (!(limitLengthForm.minLength <= e.length && e.length <= limitLengthForm.maxLength))
                {
                    SetEdgeLength(polygonToEdit, e, (limitLengthForm.maxLength + limitLengthForm.minLength) / 2, 
                        limitLengthForm.minLength, limitLengthForm.maxLength);
                }
                else e.properties.Add(new LengthLimitProperty(e, limitLengthForm.minLength, limitLengthForm.maxLength));
            }
        }
        public void SetPerpendicularEdges(Edge? e1, Edge? e2)
        {
            if (polygon1 == null || polygon2 == null || e1 == e2 || e1 == null || e2 == null) return;
            WarnIfChangeMayCauseDamage(polygon1);
            WarnIfChangeMayCauseDamage(polygon2);
            Polygon? tester1 = null, tester2 = null;
            Edge? _e1 = null, _e1_ = null; // edge equivalent to e1 
            Edge? _e2 = null, _e2_ = null; // edge equivalent to e2
            Edge? edgeToChange = null;
             Point? pointToChange = null, pointNotToChange = null; 
            Polygon? candidate1 = null, candidate2 = null;
            int maxAdjustment = int.MaxValue;

            (int x, int y) ve1 = (e1.v.X - e1.u.X, e1.v.Y - e1.u.Y);
            (int x, int y) ve2 = (e2.v.X - e2.u.X, e2.v.Y - e2.u.Y);
            (int x, int y)[] perpV = new (int x, int y)[] { (ve1.y, -ve1.x), (-ve1.y, ve1.x), (ve2.y, -ve2.x), (-ve2.y, ve2.x) };
            (Point oldP, Point newP)[] option = new (Point, Point)[8];
            option[0] = (e2.u, new Point(e2.v.X + perpV[0].x, e2.v.Y + perpV[0].y));
            option[1] = (e2.u, new Point(e2.v.X + perpV[1].x, e2.v.Y + perpV[1].y));
            option[2] = (e2.v, new Point(e2.u.X + perpV[0].x, e2.u.Y + perpV[0].y));
            option[3] = (e2.v, new Point(e2.u.X + perpV[1].x, e2.u.Y + perpV[1].y));
            option[4] = (e1.u, new Point(e1.v.X + perpV[2].x, e1.v.Y + perpV[2].y));
            option[5] = (e1.u, new Point(e1.v.X + perpV[3].x, e1.v.Y + perpV[3].y));
            option[6] = (e1.v, new Point(e1.u.X + perpV[2].x, e1.u.Y + perpV[2].y));
            option[7] = (e1.v, new Point(e1.u.X + perpV[3].x, e1.u.Y + perpV[3].y));

            for (int i = 0; i < 8; i++)
            {
                if (polygon1 == polygon2) // both edges are in the same polygon
                {
                    tester1 = new Polygon(polygon1);
                    _e1 = tester1.edges.Find(e => e.Equals(e1));
                    _e2 = tester1.edges.Find(e => e.Equals(e2));

                    edgeToChange = i < 4 ? _e2 : _e1;
                    pointToChange = tester1.vertices.Find(p => p.Equals(option[i].oldP));
                    pointNotToChange = edgeToChange.u.Equals(pointToChange) ? edgeToChange.v : edgeToChange.u;

                    (int xDiff, int yDiff) d = makeMove(i);

                    if (!validateMove(tester1, d.xDiff, d.yDiff)) continue;

                    int adjustment = countAdjustment(tester1.edges);

                    if (candidate1 == null || adjustment < maxAdjustment)
                    {
                        candidate1 = new Polygon(tester1);
                        if (_e1 != null && _e2 != null)
                        {
                            _e1_ = candidate1.edges.Find(e => e.Equals(_e1));
                            _e2_ = candidate1.edges.Find(e => e.Equals(_e2));
                        }
                        maxAdjustment = adjustment;
                    }
                }
                else
                {
                    tester1 = new Polygon(polygon1);
                    tester2 = new Polygon(polygon2);
                    _e1 = tester1.edges.Find(e => e.Equals(e1));
                    _e2 = tester2.edges.Find(e => e.Equals(e2));

                    edgeToChange = i < 4 ? _e2 : _e1;
                    pointToChange = i < 4 ? tester2.vertices.Find(p => p.Equals(option[i].oldP)) : tester1.vertices.Find(p => p.Equals(option[i].oldP));
                    pointNotToChange = edgeToChange.u.Equals(pointToChange) ? edgeToChange.v : edgeToChange.u;

                    (int xDiff, int yDiff) d = makeMove(i);

                    if (i >= 4 && !validateMove(tester1, d.xDiff, d.yDiff)) continue;
                    if (i < 4 && !validateMove(tester2, d.xDiff, d.yDiff)) continue;

                    int adjustment = countAdjustment(tester1.edges.Union(tester2.edges));

                    if ((candidate1 == null && candidate2 == null) || adjustment < maxAdjustment)
                    {
                        candidate1 = new Polygon(tester1);
                        candidate2 = new Polygon(tester2);
                        if (_e1 != null && _e2 != null)
                        {
                            _e1_ = candidate1.edges.Find(e => e.Equals(_e1));
                            _e2_ = candidate2.edges.Find(e => e.Equals(_e2));
                        }
                        maxAdjustment = adjustment;
                    }
                }

            }

            if (candidate1 != null) polygon1.SetVertices(candidate1);
            else MessageBox.Show("Can't add relation - may ruin other relations!");
            if (candidate2 != null) polygon2.SetVertices(candidate2);
            if (_e1_ != null && _e2_ != null)
            {
                e1 = polygon1.edges.Find(e => e.Equals(_e1_));
                e2 = polygon2.edges.Find(e => e.Equals(_e2_));
                if(e1 != null && e2 != null)
                {
                    int? colorIndex = Array.IndexOf(colors, Array.Find(colors, c => c.isFree == true));
                    if (colorIndex == null) colorIndex = 0;
                    colors[(int)colorIndex].isFree = false;
                    e1.properties.Add(new PerpendicularityProperty(e1, e2, colors[(int)colorIndex].color));
                    e2.properties.Add(new PerpendicularityProperty(e2, e1, colors[(int)colorIndex].color));
                }
            }

            polygon1 = null;
            polygon2 = null;
            perpEdge1 = null;
            perpEdge2 = null;

            (int, int) makeMove(int i)
            {
                if (pointToChange == null || edgeToChange == null) return (int.MaxValue, int.MaxValue);
                int xDiff = option[i].newP.X - pointToChange.X, yDiff = option[i].newP.Y - pointToChange.Y;
                double oldLength = edgeToChange.length;
                MoveVertex(pointToChange, option[i].newP);
                SetEdgeLength(edgeToChange, oldLength);
                return (xDiff, yDiff);
            }
            bool validateMove(Polygon tester, int xDiff, int yDiff)
            {
                if (pointToChange == null) return false;
                if (tester.vertices.FindAll(v => v.Equals(pointToChange)).Count != 1) return false; // tester has duplicate vertices
                _e1.properties.Add(new PerpendicularityProperty(_e1, _e2, Color.Red));
                _e2.properties.Add(new PerpendicularityProperty(_e2, _e1, Color.Red));
                tester.Repair(pointToChange, xDiff, yDiff, pointNotToChange);
                if (tester.edges.Exists(e => e.IsToRepair())) return false; // after repairing tester still has invalid edge
                return true;
            }
            int countAdjustment(IEnumerable<Edge> sequence)
            {
                if (edgeToChange == null) return int.MaxValue;

                int coolinearEdges = 0;
                int crossingEdges = 0;
                int generalPointDiffrence = 0;

                foreach (Edge e in sequence)
                {
                    if (e == edgeToChange) continue;
                    if (coolinear(e, edgeToChange)) coolinearEdges++;
                    if (doIntersect(e.u, e.v, edgeToChange.u, edgeToChange.v)) crossingEdges++;
                }

                if (tester1 != null && polygon1 != null)
                {
                    for (int k = 0; k < polygon1.vertices.Count; k++)
                        generalPointDiffrence += Math.Abs(tester1.vertices[k].X - polygon1.vertices[k].X) + Math.Abs(tester1.vertices[k].Y - polygon1.vertices[k].Y);
                }
                if (tester2 != null && polygon2 != null && tester1 != tester2)
                {
                    for (int k = 0; k < polygon2.vertices.Count; k++)
                        generalPointDiffrence += Math.Abs(tester2.vertices[k].X - polygon2.vertices[k].X) + Math.Abs(tester2.vertices[k].Y - polygon2.vertices[k].Y);
                }

                return coolinearEdges * 1000 + crossingEdges * 500 + generalPointDiffrence;
            }

            bool coolinear(Edge e1, Edge e2)
            {
                int A1 = -(e1.v.Y - e1.u.Y), A2 = -(e2.v.Y - e2.u.Y);
                int B1 = (e1.v.X - e1.u.X), B2 = (e2.v.X - e2.u.X);
                int C1 = -B1 * e1.u.Y - A1 * e1.u.X, C2 = -B2 * e2.u.Y - A2 * e2.u.X; ;

                return A1 * B2 == A2 * B1 && C1 * B2 == C2 * B1;
            }
            bool onSegment(Point p, Point q, Point r)
            {
                if (q.X <= Math.Max(p.X, r.X) && q.X >= Math.Min(p.X, r.X) &&
                    q.Y <= Math.Max(p.Y, r.Y) && q.X >= Math.Min(p.Y, r.Y))
                    return true;

                return false;
            }
            int orientation(Point p, Point q, Point r)
            {
                int val = (q.Y - p.Y) * (r.X - q.X) -
                        (q.X - p.X) * (r.Y - q.Y);

                if (val == 0) return 0; // collinear

                return (val > 0) ? 1 : 2; // clock or counterclock wise
            }
            bool doIntersect(Point p1, Point q1, Point p2, Point q2)
            {
                if (p1.Equals(p2) ^ p1.Equals(q2) ^ q1.Equals(p2) ^ q1.Equals(q2)) return false;

                int o1 = orientation(p1, q1, p2);
                int o2 = orientation(p1, q1, q2);
                int o3 = orientation(p2, q2, p1);
                int o4 = orientation(p2, q2, q1);

                if (o1 != o2 && o3 != o4)
                    return true;

                if (o1 == 0 && onSegment(p1, p2, q1)) return true;

                if (o2 == 0 && onSegment(p1, q2, q1)) return true;

                if (o3 == 0 && onSegment(p2, p1, q2)) return true;

                if (o4 == 0 && onSegment(p2, q1, q2)) return true;

                return false;
            }
        }
        public void RemoveVertex(Point p)
        {
            for(int j = 0; j < polygons.Count; j++)
            {
                Polygon polygon = polygons[j];
                int n = polygon.vertices.Count;
                for (int i = 0; polygons.Count > 0 && i < n; i++)
                {
                    Point v = polygon.vertices[i];
                    if (IsVertexChecked(p, v))
                    {
                        Edge? e1 = polygon.edges.Find(e => e.v == v);
                        Edge? e2 = polygon.edges.Find(e => e.u == v);
                        if (e1 == null || e2 == null) return;
                        foreach (PerpendicularityProperty property in e1.properties.Union(e2.properties).Where(_p => _p is PerpendicularityProperty))
                        {
                            property.perpendicularTo.properties.RemoveAll(
                                _property => _property is PerpendicularityProperty &&
                                (((PerpendicularityProperty)_property).perpendicularTo == e1 || ((PerpendicularityProperty)_property).perpendicularTo == e2));
                            int? colorIndex = Array.IndexOf(colors, Array.Find(colors, c => c.color == property.color));
                            if (colorIndex != null) colors[(int)colorIndex].isFree = true;
                        }

                        if (n - 1 < 3) polygons.Remove(polygon);
                        else
                        {
                            Point? vPrev = polygon.edges.Find(e => e.v == v)?.u;
                            Point? vNext = polygon.edges.Find(e => e.u == v)?.v;

                            polygon.edges.RemoveAll(e => e.u == v || e.v == v);
                            if(vPrev != null && vNext != null) polygons[j].edges.Add(new Edge(vPrev, vNext));
                            polygons[j].vertices.Remove(v);
                        }
                        break;
                    }
                }
            }    
        }
        public void MoveVertex(Point? v, Point p)
        {
            if (v == null || polygonToEdit == null) return;
            //if (polygonToEdit.vertices.Exists(_v => !(_v + p - v).IsMovable()))
            //{
            //    MessageBox.Show("Can't add relation - edge gets outside the bitmap!");
            //    return;
            //}

            v.X = p.X;
            v.Y = p.Y;
        }
        public void MoveVertexAndRepair(Point? v, Point p)
        {
            if (v == null || polygonToEdit == null) return;
            //if (polygonToEdit.vertices.Exists(_v => !(_v + p - v).IsMovable()))
            //{
            //    MessageBox.Show("Can't add relation - edge gets outside the bitmap!");
            //    return;
            //}

            int xDiff = p.X - v.X, yDiff = p.Y - v.Y;
            v.X = p.X;
            v.Y = p.Y;
            polygonToEdit.Repair(v, xDiff, yDiff, v);
        }
        public void MoveEdge(Edge? e, Point p)
        {
            if (e == null || mouseClickPoint == null || polygonToEdit == null) return;
            WarnIfChangeMayCauseDamage(polygonToEdit);
            MoveVertex(e.u, new Point(e.u.X + (p.X - mouseClickPoint.X), e.u.Y + (p.Y - mouseClickPoint.Y)));
            MoveVertex(e.v, new Point(e.v.X + (p.X - mouseClickPoint.X), e.v.Y + (p.Y - mouseClickPoint.Y)));
            polygonToEdit.Repair(e.v, p.X - mouseClickPoint.X, p.Y - mouseClickPoint.Y, e.u);
            mouseClickPoint = p;
        }
        public void MovePolygon(Polygon? polygon, Point p)
        {
            if (polygon == null || mouseClickPoint == null) return;
            foreach(Point v in polygon.vertices)
            {
                MoveVertex(v, new Point(v.X + (p.X - mouseClickPoint.X), v.Y + (p.Y - mouseClickPoint.Y)));
            }
            mouseClickPoint = p;
        }
        public bool IsVertexChecked(Point p, Point v)
        {
            if ((p.X - v.X) * (p.X - v.X) + (p.Y - v.Y) * (p.Y - v.Y) < radius * radius) return true;
            return false;
        }
        public void RedrawBitmap()
        {
            using (Graphics g = Graphics.FromImage(drawArea))
            {
                g.Clear(Color.White);
            }
            foreach (Polygon polygon in polygons)
            {
                for (int i = 0; i < polygon.edges.Count; i++)
                {
                    DrawEdge(polygon.edges[i], Color.Black);
                }
                for (int i = 0; i < polygon.vertices.Count; i++)
                {
                    DrawVertex(polygon.vertices[i]);
                }
                //if(polygon.center != null) DrawCenter(polygon.center);
            }
        }
        public void RemoveInvalidPolygons()
        {
            for (int i = 0; i < polygons.Count; i++)
            {
                if (polygons[i].vertices.Count < 3) polygons.Remove(polygons[i]);
            }
        }
        public void WarnIfChangeMayCauseDamage(Polygon polygon)
        {
            int edgesWithRelations = 0;
            foreach(Edge e in polygon.edges)
            {
                if (e.properties.Count > 0) edgesWithRelations++;
            }
            if(edgesWithRelations >= polygon.edges.Count - 1)
            {
                MessageBox.Show("This change may cause problems!");
            }
        }
    }
}
