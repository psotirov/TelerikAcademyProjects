using System;

class TrapezoidArea
{
    static void Main()
    {
        Console.Write("Enter trapezoid first side: ");
        string input = Console.ReadLine();
        int width1 = 0;
        if (int.TryParse(input, out width1) && (width1 > 0))
        {
            Console.Write("Enter trapezoid second side: ");
            input = Console.ReadLine();
            int width2 = 0;
            if (int.TryParse(input, out width2) && (width2 > 0))
            {
                Console.Write("Enter trapezoid height: ");
                input = Console.ReadLine();
                int height = 0;
                if (int.TryParse(input, out height) && (height > 0))
                {
                    Console.WriteLine("The trapezoid area is " + ((width1+width2)/2.0 * height));
                    return;
                }
            }

        }
        Console.WriteLine("Wrong input parameters!");
    }
}
