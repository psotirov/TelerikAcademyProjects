using System;
using System.Collections.Generic;

namespace Point_In_Triangle
{
    class PointInTrianlge
    {
        static void Main()
        {
            Console.WriteLine("Checks if point is inside a triangle\n\n");

            Triangle triangle = new Triangle(new Point(1, 1), new Point(11, 1), new Point(11, 11));
            Console.WriteLine(triangle);
            Console.WriteLine();

            List<Point> points = new List<Point> {
                new Point(5,1),
                new Point(11,5),
                new Point(9,2),
                new Point(2,9),
                new Point(5,0),
                new Point(12,5),
            };

            foreach (var point in points)
            {
                Console.WriteLine("{0} is {1} the triangle", point, (triangle.IsInside(point)?"inside":"outside"));
            }
        }
    }
}
