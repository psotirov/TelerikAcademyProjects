using System;

namespace _01_Shapes
{
    class Circle : Shape
    {
        public Circle(int width)
            : base(width, width)
        {
        }

        public override double CalculateSurface()
        {
            return (double)(Math.PI * Width * Width / 4.0); // the surface of circle
        }

        public override string ToString()
        {
            // different virtual method since the circle has only radius
            string shapeType = this.GetType().ToString();
            if (shapeType.IndexOf('.') >= 0) shapeType = shapeType.Substring(shapeType.LastIndexOf('.') + 1);
            return String.Format("{0} {{ radius={1}, surface={2:N2} }}", shapeType, this.Width, this.CalculateSurface());
        }
    }
}
