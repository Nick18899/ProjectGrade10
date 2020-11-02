using System;
using System.Drawing;

namespace ProjectGrade10._1.Shapes
{
    public class Circle : Shape
    {
        public Circle(int x, int y)
            : base(x, y)
        {
            
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(new Pen(lineC), X - R, Y - R, 2 * R, 2 * R);
        }

        public override bool IsInside(int xx, int yy)
        {
            int x1 = Math.Abs(xx - X);
            int y1 = Math.Abs(yy - Y);
            if ((Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2))) <= R)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}