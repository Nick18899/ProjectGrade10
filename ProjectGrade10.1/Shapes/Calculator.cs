using System;

namespace ProjectGrade10._1.Shapes
{
    static class Calculator
    {
        public static double CosinusBetweenVectors(DoublePoint a, DoublePoint b)
        {
            return (a.X * b.X + a.Y * b.Y) / (Math.Sqrt(a.X*a.X + a.Y*a.Y)*Math.Sqrt(b.X*b.X + b.Y*b.Y));
        }
    }
}