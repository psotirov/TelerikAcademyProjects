using System;

namespace _01_04_3DPoints
{
    public struct Point3D
    {
        private static readonly Point3D o; // start of the cooradinate system (by default {0,0,0})
        public static Point3D O { get { return o; } }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point3D(int x, int y, int z) : this() // point3D constructor
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString() // shows Point3D object in the format {x, y, z}
        {
            return String.Format("{{ {0}, {1}, {2} }}", this.X, this.Y, this.Z);
        }
    }
}
