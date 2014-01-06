using System;

class Trianglesurface
{
    static void Main()
    {
        Console.WriteLine("Task 04 - Calculates the surface of a triangle\n\n");

        Console.WriteLine("Method 1 - by one side and altitude");
        double side = 20.0;
        double altitude = 10.0;
        Console.WriteLine("\nSide = {0:f1}, Altitude = {1:f1}\nSurface = {2:f3}\n", side, altitude, TriangleSurface(side, altitude));

        Console.WriteLine("\nMethod 2 - by one three sides (Heron equation)");
        double side2 = 10.0;
        double side3 = 15.0;
        Console.WriteLine("\nSide1 = {0:f1}, Side2 = {1:f1}, Side3 = {2:f1}\nSurface = {3:f3}\n", side2, side, side3, TriangleSurface(side2, side, side3));

        Console.WriteLine("\nMethod 3 - by two sides and adjacent angle");
        int angle = 35; // in degrees
        Console.WriteLine("\nSide1 = {0:f1}, Side2 = {1:f1}, Angle = {2:f0} deg\nSurface = {3:f3}\n", side2, side, angle, TriangleSurface(side2, side, angle));

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }

    static double TriangleSurface(double s, double a)
    {
        double surface = a * s / 2;
        return surface;
    }

    static double TriangleSurface(double s1, double s2, double s3)
    {
        double sp = (s1 + s2 + s3) / 2;
        double surface = Math.Sqrt(sp*(sp-s1)*(sp-s2)*(sp-s3));
        return surface;
    }

    static double TriangleSurface(double s1, double s2, int a)
    {
        double surface = s1 * s2 * Math.Sin(a*Math.PI/180) / 2;
        return surface;
    }
}
