using System;
using System.Collections.Generic;

namespace Point_In_Triangle
{
    public class Triangle
    {
        private List<Point> edges;

        public Triangle(Point a, Point b, Point c)
        {
            this.edges = new List<Point>();
            this.edges.Add(a);
            this.edges.Add(b);
            this.edges.Add(c);
        }

        public bool IsInside(Point point)
        {

            bool side1 = VectorDistancePointToLine(point, this.edges[0], this.edges[1]) < 0.0;
            bool side2 = VectorDistancePointToLine(point, this.edges[1], this.edges[2]) < 0.0;
            bool side3 = VectorDistancePointToLine(point, this.edges[2], this.edges[0]) < 0.0;

            return ((side1 == side2) && (side2 == side3));
        }

        private double VectorDistancePointToLine(Point point, Point lineStart, Point lineEnd)
        {
            return (point.X - lineEnd.X) * (lineStart.Y - lineEnd.Y) - (lineStart.X - lineEnd.X) * (point.Y - lineEnd.Y);
        }

        public override string ToString()
        {
            return "Triangle { " + string.Join(", ", this.edges) + " } ";
        }


    }
}
