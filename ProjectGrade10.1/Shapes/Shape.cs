using System;
using System.Drawing;

namespace ProjectGrade10._1.Shapes
{
    [Serializable]
    public abstract class Shape
    {
        public static int R;
        protected int X;
        protected int Y;
        protected bool isTop;
        protected bool isDrag;
        protected (int dx, int dy) dif;
        public static Color lineC;
        public static Color fillC;

        public Shape(int x, int y)
        {
            X = x;
            Y = y;
            isDrag = false;
            //lineC = Color.Aqua;
            isTop = false;
        }

        static Shape()
        {
            lineC = Color.Linen;
            fillC = Color.Aqua;
            R = 10;
        }

        /*protected double Distance(double[] PointA, double[] PointB)
        {
            return Math.Sqrt(Math.Pow(PointA[0]-PointB[0],2)+Math.Pow(PointA[1] - PointB[1],2));
        }

        protected double AreaCaluclator(double[] PointA, double[] PointB, double[] PointC)
        {
            double side1 = Distance(PointA, PointB);
            double side2 = Distance(PointB, PointC);
            double side3 = Distance(PointC, PointA);
            double p = (side1 + side2 + side3) / 2.0d;
            return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
        }*/
        public abstract void Draw(Graphics graphics);
        
        public abstract bool IsInside(int xx, int yy);

        public int Radius
        {
            get
            {
                return R;
            }
            set
            {
                R = value;
            }
        }

        public static Color LineC
        {
            get => lineC;
            set => lineC = value;
        }

        public bool IsTop
        {
            get
            {
                return isTop;
            }
            set
            {
                isTop = value;
            }
        }
        public int XCoordinate
        {
            get { return X; }
            set { X = value; }
        }
        
        public (int dx, int dy) Dif
        {
            get { return dif; }
            set
            {
                dif = value;
            } 
        }
        
        public int YCoordinate
        {
            get { return Y; }
            set { Y = value; }
        }

        public bool IsDrag
        {
            get { return isDrag; }
            set { isDrag = value; }
        }
    }
}