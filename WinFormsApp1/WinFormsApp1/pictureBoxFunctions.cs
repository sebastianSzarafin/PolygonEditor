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
    public partial class Form1
    {
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (polygonCreateButton.Checked && e.Button == MouseButtons.Left)
            {
                if (!beginPolygon)
                {
                    beginPolygon = true;
                    AddPolygon(new Point(e.X, e.Y));
                }
                else
                {
                    AddVertex(new Point(e.X, e.Y));
                }

            }
            if (vertexAddButton.Checked && e.Button == MouseButtons.Left)
            {
                AddVertexToEdge(new Point(e.X, e.Y));
            }
            if (vertexRemoveButton.Checked && e.Button == MouseButtons.Left)
            {
                RemoveVertex(new Point(e.X, e.Y));
            }
            if (lengthChangeButton.Checked && !vertexAddButton.Checked && e.Button == MouseButtons.Left)
            {
                SetEdgeLength(edgeToEdit);
            }
            if(lengthLimitButton.Checked && !vertexAddButton.Checked && e.Button == MouseButtons.Left)
            {
                LimitEdgeLength(edgeToEdit);
            }
            if (perpendicularityButton.Checked && !vertexAddButton.Checked && e.Button == MouseButtons.Left && perpEdge1 != null && perpEdge2 != null && perpEdge1 != perpEdge2)
            {
                SetPerpendicularEdges(perpEdge1, perpEdge2);
            }
            if (viewRelationsButton.Checked && !vertexAddButton.Checked && e.Button == MouseButtons.Left)
            {
                ViewRelations(edgeToEdit);
            }
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            RedrawBitmap();
            if (polygonCreateButton.Checked && beginPolygon)
            {
                DrawEdge(new Edge(polygons.Last().vertices.Last(), new Point(e.X, e.Y)), Color.Black);
            }
            if (!polygonCreateButton.Checked)
            {
                beginPolygon = false;
                RemoveInvalidPolygons();
            }
            if (moveVertex && !polygonCreateButton.Checked && !vertexAddButton.Checked && !vertexRemoveButton.Checked)
            {
                MoveVertexAndRepair(pointToEdit, new Point(e.X, e.Y));
            }
            if (moveEdge && !polygonCreateButton.Checked && !vertexAddButton.Checked && !vertexRemoveButton.Checked)
            {
                MoveEdge(edgeToEdit, new Point(e.X, e.Y));
            }
            if (movePolygon && !polygonCreateButton.Checked && !vertexAddButton.Checked && !vertexRemoveButton.Checked)
            {
                MovePolygon(polygonToEdit, new Point(e.X, e.Y));
            }
            if(lengthChangeButton.Checked || lengthLimitButton.Checked || perpendicularityButton.Checked || viewRelationsButton.Checked)
            {
                MarkEdge(new Point(e.X, e.Y));
            }
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!moveVertex && e.Button == MouseButtons.Left)
            {
                Point p = new Point(e.X, e.Y);
                //mouseClickPoint = p;
                foreach (Polygon polygon in polygons)
                {
                    polygonToEdit = polygon;
                    foreach (Point v in polygon.vertices)
                    {
                        if (IsVertexChecked(p, v))
                        {
                            pointToEdit = v;
                            moveVertex = true;
                            break;
                        }
                    }
                    if (moveVertex) break;
                }
            }
            if (!moveVertex && !moveEdge && e.Button == MouseButtons.Left)
            {
                Point p = new Point(e.X, e.Y);
                mouseClickPoint = p;
                foreach (Polygon polygon in polygons)
                {
                    polygonToEdit = polygon;
                    foreach(Edge edge in polygon.edges)
                    {
                        if(DistFromEdge(edge, p) < radius / 2)
                        {
                            if (perpendicularityButton.Checked == true)
                            {
                                if (perpEdge1 == null)
                                {
                                    perpEdge1 = edge;
                                    polygon1 = polygon;
                                }
                                else
                                {
                                    perpEdge2 = edge;
                                    polygon2 = polygon;
                                }
                            }

                            edgeToEdit = edge;
                            if(!lengthChangeButton.Checked && !lengthLimitButton.Checked && !perpendicularityButton.Checked && !viewRelationsButton.Checked) moveEdge = true;
                            break;
                        }
                    }
                    if (moveEdge) break;
                    if ((lengthChangeButton.Checked || lengthLimitButton.Checked || viewRelationsButton.Checked) && edgeToEdit != null)
                    {
                        perpEdge1 = null;
                        perpEdge2 = null;
                        break;
                    }
                }
            }
            if (!moveVertex && !moveEdge && !movePolygon && (e.Button == MouseButtons.Middle))
            {
                Point p = new Point(e.X, e.Y);
                mouseClickPoint = p;
                foreach (Polygon polygon in polygons)
                {
                    if (polygon.IsPointInsidePolygon(p))
                    {
                        polygonToEdit = polygon;
                        movePolygon = true;
                        break;
                    }
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            polygonToEdit = null;
            edgeToEdit = null;
            pointToEdit = null;
            if (e.Button == MouseButtons.Left)
            {
                moveVertex = false;
                moveEdge = false;
            }
            if (e.Button == MouseButtons.Middle) movePolygon = false;
        }
    }


}


