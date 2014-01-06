using System;

class PointInCircleAndRectangle
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
                bool result = (((x-1) * (x-1) + (y-1) * (y-1)) > 9); // isInsideTheCircle
                result = result && ((x < -1) || (x > (6-1)) || (y < 1) || (y > (1+2))); // AND isOutsideRectangle
                Console.WriteLine("The point lays inside the circle K((1,1),3) and outside the rectangle P((-1,1), 6, 2) -> " + result);
                return;
            }
        }
        Console.WriteLine("Wrong coordinates!");
    }
}
