using System;

namespace Abstraction
{
    abstract class Figure
    {
        // each figure has both width and height dimensions nevetheless they can be equal (square or even circle for example)
        private double width;
        private double height;

        public double Width
        {
            get { return this.width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Figure width can not be negative");
                }
                this.width = value;
            }
        }
        public double Height
        {
            get { return this.height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Figure height can not be negative");
                }
                this.height = value;
            }
        }

        // single dimension is copied to the other one
        public Figure(double width) : this(width, width)
        {
        }

        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public abstract double CalcPerimeter();
        public abstract double CalcSurface();
    }
}
