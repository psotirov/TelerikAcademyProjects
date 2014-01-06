using System;

namespace Point_In_Triangle
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return "(" + this.X + ", " + this.Y + ")";
        }
    }
}
