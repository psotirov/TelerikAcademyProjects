using System;

namespace _01_Shapes
{
    public abstract class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public abstract double CalculateSurface(); // abstract method to calculate shape surface

        protected Shape(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override string ToString()
        {
            // extracts only the class name (deletes leading data such as project name, etc.)
            string shapeType = this.GetType().ToString();
            if (shapeType.IndexOf('.') >= 0) shapeType = shapeType.Substring(shapeType.LastIndexOf('.') + 1);

            // returns whole structure data
            return String.Format("{0} {{ width={1}, height={2}, surface={3:N2} }}", shapeType, this.Width, this.Height, this.CalculateSurface());
        }
    }
}
