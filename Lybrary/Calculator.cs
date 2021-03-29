using System;

namespace ProjectGrade10._1.Shapes
{
    static class Calculator
    {
        public static double CosinusBetweenVectors(DoublePoint a, DoublePoint b)
        {
            return (a.X * b.X + a.Y * b.Y) / (Math.Sqrt(a.X*a.X + a.Y*a.Y)*Math.Sqrt(b.X*b.X + b.Y*b.Y));
        }
        public static double AreaCaluclator(double[] PointA, double[] PointB, double[] PointC)
        {
            double side1 = Distance(PointA, PointB);
            double side2 = Distance(PointB, PointC);
            double side3 = Distance(PointC, PointA);
            double p = (side1 + side2 + side3) / 2.0d;
            return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
        }
        public static double Distance(double[] PointA, double[] PointB)
        {
            return Math.Sqrt(Math.Pow(PointA[0]-PointB[0],2)+Math.Pow(PointA[1] - PointB[1],2));
        }
    }
}