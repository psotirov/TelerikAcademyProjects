using System;

namespace _01_Shapes
{
    public class Triangle : Shape
    {
        public Triangle(int width, int height)
            : base(width, height)
        {
        }

        public override double CalculateSurface()
        {
            return (Width * Height / 2.0); // the surface of triangle
        }
    }
}
