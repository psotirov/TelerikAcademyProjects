using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryAPI
{
    public class Circle : Figure, IFlat, IAreaMeasurable
    {
        public Vector3D Center
        {
            get { return this.vertices[0]; }
            set { this.vertices[0] = value; }
        }

        public double Radius { get; set; }
        
        public Circle(Vector3D c, double r)
            : base(c)
        {
            this.Radius = r;
        }

        public Vector3D GetNormal()
        {
            // the circle's normal vector is a cross product of the radius by axle x and the radius by axle y, i.e. (-R,0,0) and (0,-R,0)

            Vector3D normal = Vector3D.CrossProduct(new Vector3D(-this.Radius, 0, 0), new Vector3D(0,-this.Radius, 0));
            normal.Normalize();
            return normal;
        }

        public double GetArea()
        {
            // Area = 3.14 * R ^ 2
            return Math.PI * this.Radius * this.Radius;
        }

        public override double GetPrimaryMeasure()
        {
            // area is the primary measure of a  circle
            return this.GetArea();
        }
    }
}
