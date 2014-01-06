using System;

namespace _01_Shapes
{
    class Rectangle : Shape
    {
        public Rectangle(int width, int height)
            : base(width, height)
        {
        }

        public override double CalculateSurface()
        {
            return (double)(Width * Height); // the surface of rectangle
        }
    }
}
