using System;

class PointInCircle
{
    static void Main()
    {
        Console.Write("Enter X coordinate: ");
        string input = Console.ReadLine();
        int x = 0;
        if (int.TryParse(input, out x))
        {
            Console.Write("Enter Y coordinate: ");
            input = Console.ReadLine();
            int y = 0;
            if (int.TryParse(input, out y))
            {
                Console.WriteLine("The point lays {0} the circle K((0,0),5).", ((x*x + y*y) > 25) ? "outside" : "inside");
                return;
            }
        }
        Console.WriteLine("Wrong coordinates!");
    }
}
