using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WinFormsApp1
{
    public partial class Form1
    {
        public abstract class Property 
        {
            public Edge e;
            public double length;
            public abstract bool Check();
            public Property(Edge _e) { e = _e; }
            public abstract string Info();
        }
        public class LengthLimitProperty : Property
        {
            public double minLength;
            public double maxLength;

            public override bool Check()
            {
                if (minLength <= e.length && e.length <= maxLength) return true;
                if (Math.Abs(e.length - minLength) <= 1) length = minLength;
                else if (Math.Abs(e.length - maxLength) <= 1) length = maxLength;
                return false;
            }
            public LengthLimitProperty(Edge e, double _min, double _max) : base(e) { minLength = _min; maxLength = _max; }
            public LengthLimitProperty(Edge e, LengthLimitProperty p) : base(e) { minLength = p.minLength; maxLength = p.maxLength; }
            public override string ToString() => "Length Limit Property";
            public override string Info() => $"Min: {Math.Round(minLength, 2)}, Max: {Math.Round(maxLength, 2)}";
        }
        public class LengthProperty : Property
        {
            public override bool Check()
            {
                if (Math.Abs(e.length - length) <= 1) return true;
                return false;
            }
            public LengthProperty(Edge e, double _length) : base(e) { length = _length; }
            public LengthProperty(Edge e, LengthProperty p) : base(e) { length = p.length; }
            public override string ToString() => "Length Property";
            public override string Info() => $"Length: {Math.Round(length, 2)}";
        }
        public class PerpendicularityProperty : Property
        {
            public Edge perpendicularTo;
            public Color color;

            public override bool Check()
            {
                (int x, int y) v1 = (e.v.X - e.u.X, e.v.Y - e.u.Y);
                (int x, int y) v2 = (perpendicularTo.v.X - perpendicularTo.u.X, perpendicularTo.v.Y - perpendicularTo.u.Y);
                if (Math.Abs(v1.x * v2.x + v1.y * v2.y) / (e.length + perpendicularTo.length) <= 1) return true;
                return false;
            }
            public PerpendicularityProperty(Edge e1, Edge e2, Color _color) : base(e1) { perpendicularTo = e2; color = _color; length = e.length; }
            public override string ToString() => "Perpendicularity Property";
            public override string Info() => $"Perpendicular to ({perpendicularTo.u.X}, {perpendicularTo.u.Y}) -> ({perpendicularTo.v.X}, {perpendicularTo.v.Y})";
        }

        public class Point
        {
            public int X;
            public int Y;

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
            public Point(Point p)
            {
                X = p.X;
                Y = p.Y;
            }
            public bool Equals(Point p) => X == p.X && Y == p.Y;

            public bool IsMovable()
            {
                if (X <= radius / 2 ||
                    X >= pictureBoxWidth - radius / 2 ||
                    Y <= radius / 2 ||
                    Y >= pictureBoxHeight - radius / 2) 
                    return false;
                
                return true;
            }
            public static Point operator +(Point p1, Point p2) => new Point(p1.X + p2.X, p1.Y + p2.Y);
            public static Point operator -(Point p1, Point p2) => new Point(p1.X - p2.X, p1.Y - p2.Y);
            public static Point operator *(Point p, double n) => new Point((int)(p.X * n), (int)(p.Y  * n));
        }
        public class Edge
        {
            public Point u;
            public Point v;
            public List<Property> properties;
            public double length { get => Math.Sqrt((v.X - u.X) * (v.X - u.X) + (v.Y - u.Y) * (v.Y - u.Y)); }
            public Edge(Point _u, Point _v)
            {
                u = _u;
                v = _v;
                properties = new List<Property>();
            }
            public bool IsToRepair()
            {
                if (properties.Count == 0) return false;
                foreach (Property property in properties)
                {
                    if (!property.Check()) return true;
                }
                return false;
            }
            public bool Equals(Edge e) => u.Equals(e.u) && v.Equals(e.v);
        }
        public class Polygon 
        {
            public List<Point> vertices;
            public List<Edge> edges;
            /*public Point? center
            {
                get
                {
                    if (vertices.Count < 3) return null;

                    float accumulatedArea = 0;
                    float centerX = 0;
                    float centerY = 0;

                    for (int i = 0, j = vertices.Count - 1; i < vertices.Count; j = i++)
                    {
                        float temp = vertices[i].X * vertices[j].Y - vertices[j].X * vertices[i].Y;
                        accumulatedArea += temp;
                        centerX += (vertices[i].X + vertices[j].X) * temp;
                        centerY += (vertices[i].Y + vertices[j].Y) * temp;
                    }

                    accumulatedArea *= 3f;
                    return new Point((int)(centerX / accumulatedArea), (int)(centerY / accumulatedArea));
                }
            }*/

            
            /*public bool IsPointInsidePolygon(Point p)
            {
                double minX = vertices[0].X;
                double maxX = vertices[0].X;
                double minY = vertices[0].Y;
                double maxY = vertices[0].Y;
                for (int i = 1; i < vertices.Count; i++)
                {
                    Point q = vertices[i];
                    minX = Math.Min(q.X, minX);
                    maxX = Math.Max(q.X, maxX);
                    minY = Math.Min(q.Y, minY);
                    maxY = Math.Max(q.Y, maxY);
                }

                if (p.X < minX || p.X > maxX || p.Y < minY || p.Y > maxY)
                {
                    return false;
                }

                bool inside = false;
                for (int i = 0, j = vertices.Count - 1; i < vertices.Count; j = i++)
                {
                    if ((vertices[i].Y > p.Y) != (vertices[j].Y > p.Y) &&
                         p.X < (vertices[j].X - vertices[i].X) * (p.Y - vertices[i].Y) / (vertices[j].Y - vertices[i].Y) + vertices[i].X)
                    {
                        inside = !inside;
                    }
                }

                return inside;
            }*/
            public bool IsPointInsidePolygon(Point p)
            {
                double minX = vertices[0].X;
                double maxX = vertices[0].X;
                double minY = vertices[0].Y;
                double maxY = vertices[0].Y;
                for (int i = 1; i < vertices.Count; i++)
                {
                    Point q = vertices[i];
                    minX = Math.Min(q.X, minX);
                    maxX = Math.Max(q.X, maxX);
                    minY = Math.Min(q.Y, minY);
                    maxY = Math.Max(q.Y, maxY);
                }

                if (p.X < minX || p.X > maxX || p.Y < minY || p.Y > maxY)
                {
                    return false;
                }
                return true;
            }

            /*public void Repair(Point startPoint, int xDiff, int yDiff, Point endPoint)
            {
                Edge? e1 = edges.Find(e => e.u.Equals(startPoint));
                Edge? e2 = startPoint == endPoint ?
                    edges.Find(e => e.v == startPoint) :
                    edges.Find(e => (!(e.u == startPoint) && e.v == endPoint) || (!(e.v == startPoint) && e.u == endPoint));
                if (e1 == null || e2 == null) return;

                Point prev1 = startPoint, prev2 = startPoint, next1 = startPoint, next2 = startPoint;
                Edge? toRepair1, toRepair2;
                toRepair1 = e1;
                toRepair2 = e2;
                bool needsRepair1 = true, needsRepair2 = true;
                int edgesVisited = 0;
                do
                {
                    if (toRepair1 != null) needsRepair1 = toRepair1.IsToRepair();
                    else needsRepair1 = false;
                    if (toRepair2 != null) needsRepair2 = toRepair2.IsToRepair();
                    else needsRepair2 = false;
                    if (needsRepair1)
                    {
                        next1 = prev1.Equals(toRepair1.u) ? toRepair1.v : toRepair1.u;
                        next1.X += xDiff;
                        next1.Y += yDiff;
                        toRepair1 = edges.Find(e => (e.u.Equals(next1) && !e.v.Equals(prev1)) || (e.v.Equals(next1) && !e.u.Equals(prev1)));
                        prev1 = next1;
                        edgesVisited++;
                    }
                    if (needsRepair2)
                    {
                        next2 = prev2.Equals(toRepair2.u) ? toRepair2.v : toRepair2.u;
                        next2.X += xDiff;
                        next2.Y += yDiff;
                        toRepair2 = edges.Find(e => (e.u.Equals(next2) && !e.v.Equals(prev2)) || (e.v.Equals(next2) && !e.u.Equals(prev2)));
                        prev2 = next2;
                        edgesVisited++;
                    }

                    if (needsRepair1 && needsRepair2 && next1 == next2) // case when both edges meet in the end
                    {
                        next1.X -= xDiff;
                        next1.Y -= yDiff;
                    }
                }
                while (toRepair1 != toRepair2 && (needsRepair1 || needsRepair2) && edgesVisited < edges.Count);
            }*/


            public void Repair(Point startPoint, int xDiff, int yDiff, Point endPoint)
            {
                Edge? e1 = edges.Find(e => e.u.Equals(startPoint));
                Edge? e2 = startPoint == endPoint ?
                    edges.Find(e => e.v == startPoint) :
                    edges.Find(e => (!(e.u == startPoint) && e.v == endPoint) || (!(e.v == startPoint) && e.u == endPoint));
                if (e1 == null || e2 == null) return;

                Point prev1 = new Point(startPoint), prev2 = new Point(startPoint), next1 = new Point(startPoint), next2 = new Point(startPoint);
                Edge? toRepair1, toRepair2;
                int xDiff1 = xDiff, yDiff1 = yDiff, xDiff2 = xDiff, yDiff2 = yDiff;
                toRepair1 = e1;
                toRepair2 = e2;
                bool needsRepair1 = true, needsRepair2 = true;
                int edgesVisited = 0;
                do
                {
                    if (toRepair1 != null) needsRepair1 = toRepair1.IsToRepair();
                    else needsRepair1 = false;
                    if (toRepair2 != null) needsRepair2 = toRepair2.IsToRepair();
                    else needsRepair2 = false;
                    if (needsRepair1) repairEdge(ref toRepair1, ref prev1, ref next1, ref xDiff1, ref yDiff1);
                    if (needsRepair2) repairEdge(ref toRepair2, ref prev2, ref next2, ref xDiff2, ref yDiff2);

                    if (needsRepair1 && needsRepair2 && next1 == next2) // case when both edges meet in the end (not entirelly proper)
                    {
                        next1.X -= xDiff2;
                        next1.Y -= yDiff2;
                    }
                }
                while (toRepair1 != toRepair2 && (needsRepair1 || needsRepair2) && edgesVisited < edges.Count);

                void repairEdge(ref Edge? toRepair, ref Point prev, ref Point next, ref int xDiff, ref int yDiff)
                {
                    if (toRepair == null) return;

                    next = prev.Equals(toRepair.u) ? toRepair.v : toRepair.u;

                    if (toRepair.properties.Exists(p => p is PerpendicularityProperty))
                    {
                        next.X += xDiff;
                        next.Y += yDiff;
                    }
                    else
                    {
                        Point oldPrev = new Point(prev.X - xDiff, prev.Y - yDiff);
                        Property? propertyToFix = toRepair.properties.Find(p => p is LengthProperty || p is LengthLimitProperty);
                        if (propertyToFix != null)
                        {
                            Point newNext = ClosestIntersection(prev.X, prev.Y, propertyToFix.length, oldPrev, next);

                            xDiff = newNext.X - next.X;
                            yDiff = newNext.Y - next.Y;

                            next.X = newNext.X;
                            next.Y = newNext.Y;
                        }
                    }

                    Point nextCopy = next;
                    Point prevCopy = prev;
                    toRepair = edges.Find(e => (e.u.Equals(nextCopy) && !e.v.Equals(prevCopy)) || (e.v.Equals(nextCopy) && !e.u.Equals(prevCopy)));
                    prev = next;

                    edgesVisited++;
                }
            }



            public Point ClosestIntersection(int cx, int cy, double radius,
                                              Point lineStart, Point lineEnd)
            {
                Point intersection1;
                Point intersection2;
                int intersections = FindLineCircleIntersections(cx, cy, radius, lineStart, lineEnd, out intersection1, out intersection2);

                double dist1 = Distance(intersection1, lineEnd);
                double dist2 = Distance(intersection2, lineEnd);

                if (dist1 < dist2)
                    return intersection1;
                else
                    return intersection2;
            }
            public bool PointOnEdge(Point p, Point lineStart, Point lineEnd) => lineStart.X <= p.X && p.X <= lineEnd.X && lineStart.Y <= p.Y && p.Y <= lineEnd.Y;
            private double Distance(Point p1, Point p2)
            {
                return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
            }

            // Find the points of intersection.
            private int FindLineCircleIntersections(int cx, int cy, double radius,
                                                    Point point1, Point point2, out
                                                    Point intersection1, out Point intersection2)
            {
                double dx, dy, A, B, C, det, t;

                dx = point2.X - point1.X;
                dy = point2.Y - point1.Y;

                A = dx * dx + dy * dy;
                B = 2 * (dx * (point1.X - cx) + dy * (point1.Y - cy));
                C = (point1.X - cx) * (point1.X - cx) + (point1.Y - cy) * (point1.Y - cy) - radius * radius;

                det = B * B - 4 * A * C;
                if ((A <= 0.0000001) || (det < 0))
                {
                    // No real solutions.
                    intersection1 = new Point(int.MaxValue, int.MaxValue);
                    intersection2 = new Point(int.MaxValue, int.MaxValue);
                    return 0;
                }
                else if (det == 0)
                {
                    // One solution.
                    t = -B / (2 * A);
                    intersection1 = new Point((int)(point1.X + t * dx), (int)(point1.Y + t * dy));
                    intersection2 = new Point(int.MaxValue, int.MaxValue);
                    return 1;
                }
                else
                {
                    // Two solutions.
                    t = (float)((-B + Math.Sqrt(det)) / (2 * A));
                    intersection1 = new Point((int)(point1.X + t * dx), (int)(point1.Y + t * dy));
                    t = (float)((-B - Math.Sqrt(det)) / (2 * A));
                    intersection2 = new Point((int)(point1.X + t * dx), (int)(point1.Y + t * dy));
                    return 2;
                }
            }

            public void SetVertices(Polygon polygon)
            {
                for(int i = 0; i < vertices.Count; i++)
                {
                    vertices[i].X = polygon.vertices[i].X;
                    vertices[i].Y = polygon.vertices[i].Y;
                }
            }

            public Polygon(Point p)
            {
                vertices = new List<Point>();
                vertices.Add(p);
                edges = new List<Edge>();
            }
            public Polygon(List<Point> points)
            {
                vertices = points;
                edges = new List<Edge>();
                for (int i = 0; i < points.Count; i++) 
                    edges.Add(new Edge(points[i], points[(i + 1) % points.Count]));
            }
            public Polygon(Polygon polygon)
            {
                vertices = polygon.vertices.ConvertAll(v => new Point(v));
                edges = new List<Edge>();
                foreach(Edge e in polygon.edges)
                {
                    Point? u = vertices.Find(_u => _u.Equals(e.u));
                    Point? v = vertices.Find(_v => _v.Equals(e.v));
                    edges.Add(new Edge(u, v));
                }
                foreach(Edge e in polygon.edges)
                {
                    foreach (Property p in e.properties)
                    {
                        Edge? _e = edges.Find(edge => edge.Equals(e));

                        if(_e != null)
                        {
                            if (p is LengthLimitProperty) _e.properties.Add(new LengthLimitProperty(_e, (LengthLimitProperty)p));
                            if (p is LengthProperty) _e.properties.Add(new LengthProperty(_e, (LengthProperty)p));
                            if (p is PerpendicularityProperty)
                            {
                                Edge e1 = ((PerpendicularityProperty)p).perpendicularTo;
                                Edge? _e1 = edges.Find(edge => edge.Equals(e1));
                                if (_e1 != null) _e.properties.Add(new PerpendicularityProperty(_e, _e1, ((PerpendicularityProperty)p).color)); 
                                else _e.properties.Add(new PerpendicularityProperty(_e, e1, ((PerpendicularityProperty)p).color));
                            }
                        }
                    }
                }
            }
        }

    }
}
