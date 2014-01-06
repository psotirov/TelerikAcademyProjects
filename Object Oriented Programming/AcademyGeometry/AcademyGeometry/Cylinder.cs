using System;

namespace GeometryAPI
{
    public class Cylinder : Figure, IAreaMeasurable, IVolumeMeasurable
    {
        public Vector3D Bottom // first (bottom) center
        {
            get { return this.vertices[0]; }
            set { this.vertices[0] = value; }
        }

        public Vector3D Top // second (top) center
        {
            get { return this.vertices[1]; }
            set { this.vertices[1] = value; }
        }

        public double Radius { get; set; } // cylinder's radius

        public Cylinder(Vector3D bottom, Vector3D top, double radius)
            : base(top, bottom)
        {
            this.Radius = radius;
        }

        public double GetVolume()
        {
            // cylinder's volume is Height (top - bottom) * cirlce's area (3.14 * R * R)
            return (this.Top - this.Bottom).Magnitude * Math.PI * this.Radius * this.Radius;
        }

        public double GetArea()
        {
            // cylinder's area is 2 * cirlce's area (3.14 * R * R) + Height (top - bottom) * cirlce's perimeter (2 * 3.14 * R)

            double area = 2 * Math.PI * this.Radius * this.Radius; // area of top and bottom circles
            area += (this.Top - this.Bottom).Magnitude * 2 * Math.PI * this.Radius; // + area of side wall
            return area;
        }
        
        public override double GetPrimaryMeasure()
        {
            // cylinder volume is primary measure
            return this.GetVolume();
        }
    }

}
