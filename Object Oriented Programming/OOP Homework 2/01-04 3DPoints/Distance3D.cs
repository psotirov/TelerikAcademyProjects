using System;

namespace _01_04_3DPoints
{
    public static class Distance3D
    {
        public static double Calc(Point3D p1, Point3D p2) // calculates the distance between 2 points in the 3D universe
        {
            int dX = p1.X - p2.X;
            int dY = p1.Y - p2.Y;
            int dZ = p1.Z - p2.Z;
            return Math.Sqrt(dX*dX + dY*dY + dZ*dZ);
        }
    }
}
