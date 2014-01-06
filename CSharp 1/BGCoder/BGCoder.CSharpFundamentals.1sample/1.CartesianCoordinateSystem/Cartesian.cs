using System;

class CartesianCoordinateSystem
{
    static void Main()
    {
        double x = double.Parse(Console.ReadLine()); // reads coordinates
        double y = double.Parse(Console.ReadLine());

        int result = 0;
        if (x > 0 && y > 0) result = 1;
        if (x < 0 && y > 0) result = 2;
        if (x < 0 && y < 0) result = 3;
        if (x > 0 && y < 0) result = 4;
        if (x == 0 && y != 0) result = 5;
        if (x != 0 && y == 0) result = 6;
        Console.WriteLine(result);
    }
}

