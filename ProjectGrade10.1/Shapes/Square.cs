using System;
using System.Drawing;

namespace ProjectGrade10._1.Shapes
{
    [Serializable]
    public class Square : Shape
    {
        public double a;
        private double x1;
        private double x2;
        private double x3;
        private double y1;
        private double y2;
        private double y3;
        private double x4;
        private double y4;
        
        public Square(int x, int y)
            : base(x, y)
        {
            a = Math.Sqrt(2 * Math.Pow(R, 2));
            x1 = x - a / 2;
            x2 = x + a / 2;
            x3 = x2;
            x4 = x1;
            y1 = y + a / 2;
            y2 = y1;
            y3 = y - a / 2;
            y4 = y3;
        }

        public override void Draw(Graphics graphics)
        {
            double len = Math.Sqrt(2 * R * R);
            PointF[] plist = new PointF[4];
            plist[0] = new PointF((float) (X - len / 2), (float) (Y + len / 2));
            plist[1] = new PointF((float) (X + len / 2), (float) (Y + len / 2));
            plist[2] = new PointF((float) (X + len / 2), (float) (Y - len / 2));
            plist[3] = new PointF((float) (X - len / 2), (float) (Y - len / 2));
            graphics.DrawPolygon(new Pen(lineC), plist);
        }

        public override bool IsInside(int xx, int yy)
        {
            double SDef = a * a;
            double S1 = Math.Abs(y1 - yy) * Math.Abs(x1 - xx);
            double S2 = Math.Abs(y2 - yy) * Math.Abs(x2 - xx);
            double S3 = Math.Abs(y3 - yy) * Math.Abs(x3 - xx);
            double S4 = Math.Abs(y4 - yy) * Math.Abs(x4 - xx);
            return (S1 + S2 + S3 + S4) <= SDef;
        }
    }
}