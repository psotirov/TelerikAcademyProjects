using System;

namespace Abstraction
{
    class Circle : Figure
    {
        // circle's diameter is its width/height while circle's radius is half of its dimension 
        public double Radius { get { return this.Width / 2; } }

        public Circle(double radius)
            : base(2 * radius)
        {
        }

        public override double CalcPerimeter()
        {
            double perimeter = Math.PI * this.Width;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Width / 4;
            return surface;
        }
    }
}
