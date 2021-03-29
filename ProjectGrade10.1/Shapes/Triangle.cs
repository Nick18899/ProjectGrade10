using System;
using System.Drawing;
using ProjectGrade10;

namespace ProjectGrade10._1.Shapes
{
    [Serializable]
    public class Triangle : Shape
    {
        private const double angular = 1.0472;
        private double x1;
        private double x2;
        private double x3;
        private double y1;
        private double y2;
        private double y3;

        public Triangle(int x, int y)
            : base(x, y)
        {
            x1 = x - R * Math.Sin(angular);
            x2 = x;
            x3 = x + R * Math.Sin(angular);
            y1 = y - R * Math.Cos(angular);
            y2 = y + R;
            y3 = y1;
        }

        public override void Draw(Graphics graphics)
        {
            PointF[] plist = new PointF[3];
            plist[0] = new PointF(X, Y - R);
            plist[1] = new PointF(X - R * (float) Math.Sin(1.0472), Y + R / 2);
            plist[2] = new PointF(X + R * (float) Math.Sin(1.0472), Y + R / 2);
            graphics.DrawPolygon(new Pen(lineC), plist);
        }


        public override bool IsInside(int xx, int yy)
        {
            double[] pointA = new[] {x1, y1};
            double[] pointB = new[] {x2, y2};
            double[] pointC = new[] {x3, y3};
            double[] checkingPoint = new[] {(double)xx, (double)yy};
            double S = ProjectGrade10.Calculator.AreaCaluclator(pointA, pointB, pointC);
            double S1 = Calculator.AreaCaluclator(pointA, pointB, checkingPoint);
            double S2 = Calculator.AreaCaluclator(pointB, pointC, checkingPoint);
            double S3 = Calculator.AreaCaluclator(pointA, pointC, checkingPoint);
            return S >= S1 + S2 + S3;
        }
    }
}