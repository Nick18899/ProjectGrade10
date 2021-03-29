using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using ProjectGrade10._1.Shapes;

namespace ProjectGrade10._1
{
    public delegate void Rad(int newRadius);
    public delegate void OnClose();
    
    [Serializable]
    public partial class Form1 : Form
    {
        List<Shape> listOfTops = new List<Shape>(); //shapes
        private int dynamicInterval;
        private string attachedFile;
        private int shapeType;
        private static System.Timers.Timer dynamicTimer;
        private Random random;
        private bool save;
        private int algorithm;
        private RadiusChanging radiusChanging;
        private bool closeR; //if RadiusChanging window is closed, this flag == true
        private bool play; //if play function is using, this flag is true
        public Rad rad; //Radius changing deligate
        public OnClose closeRadius; //radius close deligate
        private bool changed;
        private Color lineColor;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            save = true;
            attachedFile = "";
            trackBar1.Visible = false;
            circleToolStripMenuItem.Checked = true;
            jarvisAlgorithmToolStripMenuItem.Checked = true;
            rad = RadiusChanging;
            closeRadius = RClose;
            closeR = true;
            dynamicInterval = 1;
            play = false;
            Shape.LineC = Color.Aqua;
            lineColor = Color.Blue;
            Invalidate();
        }

        private void colorChangerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.Color = Shape.lineC;
            //MyDialog.ShowDialog();
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                Shape.LineC = MyDialog.Color;
            }
            save = false;
            Refresh();
        }

        public void radiusChangerToolStripMenuItem_Click(object sender, EventArgs e) //RadiusChanging window making
        {
            if (closeR)
            {
                radiusChanging = new RadiusChanging(rad, closeRadius, Shape.R);
                radiusChanging.Show();
                closeR = false;
            }
            else
            {
                radiusChanging.Activate();
                radiusChanging.WindowState = FormWindowState.Normal;
            }
        }

        public void RClose() => closeR = true;

        public void RadiusChanging(int newRadius) //radius changing method
        {
            Shape.R = newRadius;
            save = false;
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (listOfTops.Count >= 3)
            {
                if (algorithm == 1 || byDefinitionAlgorithmToolStripMenuItem.Checked)
                {
                    ByDefinition(e.Graphics);
                }
                else
                {
                    ByJarvis(e.Graphics);
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
                                save = false;
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
                    for (int i = 0; i < listOfTops.Count; i++)
                    {
                        if (listOfTops[i].IsInside(e.X, e.Y))
                        {
                            listOfTops.RemoveAt(i);
                            save = false;
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

        private void jarvisAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            algorithm = 0;
            jarvisAlgorithmToolStripMenuItem.Checked = true;
            byDefinitionAlgorithmToolStripMenuItem.Checked = false;
            save = false;
        }

        private void byDefinitionAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            algorithm = 1;
            byDefinitionAlgorithmToolStripMenuItem.Checked = true;
            jarvisAlgorithmToolStripMenuItem.Checked = false;
            save = false;
        }

        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeType = 1;
            circleToolStripMenuItem.Checked = false;
            triangleToolStripMenuItem.Checked = true;
            squareToolStripMenuItem.Checked = false;
            save = false;
        }

        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeType = 2;
            circleToolStripMenuItem.Checked = false;
            triangleToolStripMenuItem.Checked = false;
            squareToolStripMenuItem.Checked = true;
            save = false;
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeType = 0;
            circleToolStripMenuItem.Checked = true;
            triangleToolStripMenuItem.Checked = false;
            squareToolStripMenuItem.Checked = false;
        }

        private void ByJarvis(Graphics e)
        {
            Shape A = listOfTops[0];
            foreach (var x in listOfTops)
            {
                if (x.YCoordinate > A.YCoordinate)
                {
                    A = x;
                }

                if (x.YCoordinate == A.YCoordinate)
                {
                    if (x.XCoordinate < A.XCoordinate)
                    {
                        A = x;
                    }
                }
            }

            Shape F = A; //нашли самую левую вершину
            Shape M = new Circle(A.XCoordinate - 10, A.YCoordinate);
            double minCos = 1;
            Shape P;
            if (listOfTops[0] == A)
            {
                P = listOfTops[1];
            }
            else
            {
                P = listOfTops[0];
            }

            foreach (var p3 in listOfTops)
            {
                if (p3 != A && p3 != M)
                {
                    DoublePoint a = new DoublePoint(M.XCoordinate - A.XCoordinate, M.YCoordinate - A.YCoordinate);
                    DoublePoint b = new DoublePoint(p3.XCoordinate - A.XCoordinate, p3.YCoordinate - A.YCoordinate);
                    if (Calculator.CosinusBetweenVectors(a, b) < minCos)
                    {
                        minCos = Calculator.CosinusBetweenVectors(a, b);
                        P = p3;
                    }
                }
            }

            e.DrawLine(new Pen(lineColor), A.XCoordinate, A.YCoordinate, P.XCoordinate, P.YCoordinate);
            M = A;
            A = P;
            while (P != F) //начало третьего шага
            {
                minCos = 1;
                if (listOfTops[0] == A)
                    P = listOfTops[1];
                else
                    P = listOfTops[0];
                foreach (var p3 in listOfTops)
                {
                    if (p3 != A && p3 != M)
                    {
                        DoublePoint a = new DoublePoint(M.XCoordinate - A.XCoordinate, M.YCoordinate - A.YCoordinate);
                        DoublePoint b = new DoublePoint(p3.XCoordinate - A.XCoordinate, p3.YCoordinate - A.YCoordinate);
                        if (Calculator.CosinusBetweenVectors(a, b) < minCos)
                        {
                            minCos = Calculator.CosinusBetweenVectors(a, b);
                            P = p3;
                        }
                    }
                }

                e.DrawLine(new Pen(lineColor), A.XCoordinate, A.YCoordinate, P.XCoordinate, P.YCoordinate);
                A.IsTop = true;
                P.IsTop = true;
                M = A;
                A = P;
            }
        }

        private void ByDefinition(Graphics e)
        {
            for (int i = 0; i < listOfTops.Count - 1; i++)
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
                        e.DrawLine(new Pen(lineColor), top1.XCoordinate, top1.YCoordinate, top2.XCoordinate,
                            top2.YCoordinate);
                    }
                }
            }
        }
        
       /* private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            FileStream fs = null;
            BinaryFormatter bf = new BinaryFormatter();
            switch (e.KeyCode)
            {
                case Keys.F5:
                    fs = new FileStream("saves/saveAlpha.psh", FileMode.Open, FileAccess.Read);
                    bf.Serialize(fs, shapeType);
                    bf.Serialize(fs, Shape.R);
                    bf.Serialize(fs, Shape.lineC);
                    bf.Serialize(fs, listOfTops);
                    bf.Serialize(fs, algorithm);
                    bf.Serialize(fs, lineColor);
                    fs.Close();
                    changed = false;
                    break;
                case Keys.F6:
                    try
                    {
                        fs = new FileStream("saves/saveAlpha.psh", FileMode.Open, FileAccess.Read);
                    }
                    catch (Exception ex)
                    {
                        return;
                    }

                    listOfTops = (List<Shape>) bf.Deserialize(fs);
                    Shape.R = (int) bf.Deserialize(fs);
                    Shape.lineC = (Color) bf.Deserialize(fs);
                    shapeType = (int) bf.Deserialize(fs);
                    algorithm = (int) bf.Deserialize(fs);
                    lineColor = (Color) bf.Deserialize(fs);
                    Invalidate();
                    switch (shapeType)
                    {
                        case (0):
                            circleToolStripMenuItem.Checked = true;
                            triangleToolStripMenuItem.Checked = false;
                            squareToolStripMenuItem.Checked = false;
                            break;
                        case (1):
                            circleToolStripMenuItem.Checked = false;
                            triangleToolStripMenuItem.Checked = true;
                            squareToolStripMenuItem.Checked = false;
                            break;
                        case (2):
                            circleToolStripMenuItem.Checked = false;
                            triangleToolStripMenuItem.Checked = false;
                            squareToolStripMenuItem.Checked = true;
                            break;
                    }

                    switch (algorithm)
                    {
                        case (0):
                            jarvisAlgorithmToolStripMenuItem.Checked = true;
                            byDefinitionAlgorithmToolStripMenuItem.Checked = false;
                            break;
                        case (1):
                            byDefinitionAlgorithmToolStripMenuItem.Checked = true;
                            jarvisAlgorithmToolStripMenuItem.Checked = false;
                            break;
                    }

                    fs.Close();
                    changed = false;
                    Refresh();
                    break;
            }
        }*/

       private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //Debug.WriteLine(dynamicInterval);
            foreach (Shape shape in listOfTops)
            {
                shape.XCoordinate = shape.XCoordinate + 1;//random.Next(-10,10);
                shape.YCoordinate = shape.YCoordinate + random.Next(-10,10); 
            }
            Debug.WriteLine("something");
            Refresh();
        }

        private void playToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            save = false;
            Debug.WriteLine(play);
            //if (!play)
            //{
                dynamicTimer = new System.Timers.Timer(dynamicInterval);
                dynamicTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                dynamicTimer.Enabled = true;
                play = true;
            //}
            
        }

        private void speedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save = false;
            if (!trackBar1.Visible)
                trackBar1.Visible = true;
            else
                trackBar1.Visible = false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            dynamicInterval = trackBar1.Value;
            save = false;
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save = false;
            if (dynamicTimer != null)
            {
                dynamicTimer.Enabled = false;
                play = false;
            }
        }


        private void saveAsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {    
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            save = true;
            saveFileDialog1.Filter = "Polygons saves|*.plg";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, listOfTops);
                formatter.Serialize(fs, Shape.R);
                formatter.Serialize(fs, algorithm);
                formatter.Serialize(fs, Shape.LineC);
                formatter.Serialize(fs, shapeType);
                formatter.Serialize(fs, play);
                fs.Close();
                attachedFile = saveFileDialog1.FileName;
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            save = true;
            if (attachedFile == "")
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "Polygons saves|*.plg";

                if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                attachedFile = saveFileDialog1.FileName;
            }

            FileStream fs = new FileStream(attachedFile, FileMode.Create, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, listOfTops);
            formatter.Serialize(fs, Shape.R);
            formatter.Serialize(fs, algorithm);
            formatter.Serialize(fs, Shape.LineC);
            formatter.Serialize(fs, shapeType);
            formatter.Serialize(fs, play);
            fs.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save = true;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Polygons saves|*.plg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                BinaryFormatter formatter = new BinaryFormatter();
                listOfTops = (List<Shape>) formatter.Deserialize(fs);
                Shape.R = (int) formatter.Deserialize(fs);
                algorithm = (int) formatter.Deserialize(fs);
                Shape.LineC = (Color) formatter.Deserialize(fs);
                shapeType = (int) formatter.Deserialize(fs);
                play = (bool) formatter.Deserialize(fs);

                switch (shapeType)
                {
                    case 0:
                        circleToolStripMenuItem_Click(null, null);
                        break;
                    case 1:
                        squareToolStripMenuItem_Click(null,null);
                        break;
                    case 2:
                        triangleToolStripMenuItem_Click(null,null);
                        break;
                }

                if (algorithm == 1)
                {
                    byDefinitionAlgorithmToolStripMenuItem.Checked = true;
                    jarvisAlgorithmToolStripMenuItem.Checked = false;
                }
                else if (algorithm==0)
                {
                    byDefinitionAlgorithmToolStripMenuItem.Checked = false;
                    jarvisAlgorithmToolStripMenuItem.Checked = true;
                }

                /*if (play)
                {
                    toolStripButton2_Click(null,null);
                    toolStripButton1_Click(null,null);
                }*/
                
                radiusChanging?.Invalidate();
                
                Refresh();
                fs.Close();
                attachedFile = openFileDialog.FileName;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (attachedFile != "")
            {
                FileStream fs = new FileStream(attachedFile, FileMode.Open, FileAccess.Read);
                BinaryFormatter formatter = new BinaryFormatter();
                var newTops = (List<Shape>) formatter.Deserialize(fs);
                fs.Close();
                //bool fl;
                if (listOfTops.Count == newTops.Count)
                {
                    save = true;
                    if (listOfTops.SequenceEqual(newTops))
                    {
                        save = false;
                    }
                    /*for (int i = 0; i < listOfTops.Count; i++)
                    {
                        if (listOfTops[i] != newTops[i])
                        {
                            save = false;
                            break;
                        }
                    }*/
                }
                else
                {
                    save = false;
                }

                if (!save)
                {
                    DialogResult result= MessageBox.Show("Данные не сохранены, сохранить?", "Подтвердить", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                        return;
                    }
                    else if (result == DialogResult.Yes)
                    {
                        e.Cancel = false;
                        saveToolStripMenuItem1_Click(null,null);
                    }
                    else
                    {
                        e.Cancel = false;
                    }
                    return;
                }
                else
                {
                    e.Cancel = false;
                    return;
                }
            }
            DialogResult res= MessageBox.Show("Данные не сохранены, сохранить?", "Подтвердить", MessageBoxButtons.YesNoCancel);
            if (res == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
            else if (res == DialogResult.Yes)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                save = true;
                saveFileDialog1.Filter = "Polygons saves|*.plg";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write);
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, listOfTops);
                    formatter.Serialize(fs, Shape.R);
                    formatter.Serialize(fs, algorithm);
                    formatter.Serialize(fs, Shape.LineC);
                    formatter.Serialize(fs, shapeType);
                    formatter.Serialize(fs, play);
                    fs.Close();
                    attachedFile = saveFileDialog1.FileName;
                }
                e.Cancel = false;
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}