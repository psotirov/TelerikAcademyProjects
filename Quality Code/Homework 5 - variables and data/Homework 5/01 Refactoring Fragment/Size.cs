using System;

namespace _01_Size
{
    class Size
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public static Size GetSizeRotated(Size originalSize, double rotationAngle)
        {
            double positiveCos = Math.Abs(Math.Cos(rotationAngle));
            double positiveSin = Math.Abs(Math.Sin(rotationAngle));
            double rotatedWidth = positiveCos * originalSize.Width + positiveSin * originalSize.Height;
            double rotatedHeight = positiveSin * originalSize.Width + positiveCos * originalSize.Height;
            Size rotatedSize = new Size (rotatedWidth, rotatedHeight);

            return rotatedSize;
        }

        static void Main(string[] args)
        {
        }
    }
}
