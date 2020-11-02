using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ProjectGrade10._1.Shapes;

namespace ProjectGrade10._1
{
    public partial class Form1 : Form
    {
        List<Shape> listOfTops = new List<Shape>(); //shapes

        private int shapeType;
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            circleToolStripMenuItem.Checked = true;
            
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
             if (listOfTops.Count >= 3)
             {
                 for (int i = 0; i < listOfTops.Count-1; i++)
                 {
                     for (int j = i + 1; j < listOfTops.Count; j++)
                     {
                         if ((listOfTops[i].XCoordinate == listOfTops[j].XCoordinate) &&
                             (listOfTops[i].YCoordinate == listOfTops[j].YCoordinate))
                         {
                             listOfTops.RemoveAt(j);
                         }
                     }
                 }
                 
                 for (int i = 0; i < listOfTops.Count; i++)
                 {
                    for (int j = i + 1; j < listOfTops.Count; j++)
                    {
                        var top1 = listOfTops[i];
                        var top2 = listOfTops[j];
                        var a = true;
                        
                        if (listOfTops[j].XCoordinate == listOfTops[i].XCoordinate)
                        {
                            for (int f = 0; f < listOfTops.Count; f++)
                            {
                                if (f == i || f == j) continue;
                                if (listOfTops[f].XCoordinate >= listOfTops[i].XCoordinate)
                                {
                                    a = false;
                                    break;
                                }
                            }

                            if (!a)
                            {
                                a = true;
                                for (int f = 0; f < listOfTops.Count; f++)
                                {
                                    if (f == i || f == j) continue;
                                    if (listOfTops[f].XCoordinate <= listOfTops[i].XCoordinate)
                                    {
                                        a = false;
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            double k = ((double) top1.YCoordinate - top2.YCoordinate) /
                                       (top1.XCoordinate - top2.XCoordinate);
                            double b = top1.YCoordinate - k * top1.XCoordinate;
                            for (int f = 0; f < listOfTops.Count; f++)
                            {
                                if (f == i || f == j) continue;
                                if (listOfTops[f].YCoordinate >= listOfTops[f].XCoordinate * k + b)
                                {
                                    a = false;
                                    break;
                                }
                            }
                            if (!a)
                            {
                                a = true;
                                for (int f = 0; f < listOfTops.Count; f++)
                                {
                                    if (f == i || f == j) continue;
                                    if (listOfTops[f].YCoordinate <= listOfTops[f].XCoordinate * k + b)
                                    {
                                        a = false;
                                        break;
                                    }
                                }
                            }
                        }

                        

                        if (a)
                        {
                            listOfTops[i].IsTop = true;
                            listOfTops[j].IsTop = true;
                            e.Graphics.DrawLine(new Pen(Color.Black), top1.XCoordinate, top1.YCoordinate, top2.XCoordinate, top2.YCoordinate);
                        }
                    }
                 }
                 for (int f = 0; f < listOfTops.Count; f++)
                 {
                    if (!listOfTops[f].IsTop && !listOfTops[f].IsDrag)
                    {
                        listOfTops.RemoveAt(f);
                        continue;
                    }

                    listOfTops[f].Draw(e.Graphics);
                    listOfTops[f].IsTop = false;
                 }
             }
             else
             {
                 foreach (var sp in listOfTops)
                 {
                     sp.Draw(e.Graphics);
                 }
             }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    foreach (var sp in listOfTops)
                    {
                        if (sp.IsInside(e.X, e.Y))
                        {
                            if (sp.IsInside(e.X, e.Y))
                            {
                                sp.IsDrag = true;
                                sp.Dif = (e.X - sp.XCoordinate, e.Y - sp.YCoordinate);
                            }
                        }
                    }

                    switch (shapeType)
                    {
                        case 1:
                            listOfTops.Add(new Triangle(e.X, e.Y));
                            break;
                        case 2:
                            listOfTops.Add(new Square(e.X, e.Y));
                            break;
                        default:
                            listOfTops.Add(new Circle(e.X, e.Y));
                            break;
                    }
                    Refresh();
                    break;

                case MouseButtons.Right:
                    for (int i = 0; i <listOfTops.Count; i++)
                    {
                        if (listOfTops[i].IsInside(e.X, e.Y))
                        {
                            listOfTops.RemoveAt(i);
                        }
                    }
                    Refresh();
                    break;
            }      
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (var el in listOfTops)
            {
                if (el.IsDrag)
                {
                    (el.XCoordinate, el.YCoordinate) = (e.X - el.Dif.dx, e.Y - el.Dif.dy);
                }
            }
            Refresh();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (var el in listOfTops)
            {
                if (el.IsDrag)
                {
                    el.IsDrag = false;
                }
            }
        }


        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeType = 1;
            circleToolStripMenuItem.Checked = false;
            triangleToolStripMenuItem.Checked = true;
            squareToolStripMenuItem.Checked = false;
        }

        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeType = 2;
            circleToolStripMenuItem.Checked = false;
            triangleToolStripMenuItem.Checked = false;
            squareToolStripMenuItem.Checked = true;
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeType = 0;
            circleToolStripMenuItem.Checked = true;
            triangleToolStripMenuItem.Checked = false;
            squareToolStripMenuItem.Checked = false;
        }
    }
}