namespace ProjectGrade10
{
    public class DoublePoint
    {
        private double x;
        private double y;
        public DoublePoint(double x1, double y1)
        {
            x = x1;
            y = y1;
        }

        public double X
        {
            get => x;
            set => x = value;
        }

        public double Y
        {
            get => y;
            set => y = value;
        }
    }
}