﻿using System;

namespace CohesionAndCoupling
{
    static class Distance
    {
        public static double Calc2D(double x1, double y1, double x2, double y2)
        {
            return Calc3D(x1, y1, 0, x2, y2, 0);
        }

        public static double Calc3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
            return distance;
        }
    }
}
