using System;

class RectangleArea
{
    static void Main()
    {
        Console.Write("Enter rectangle width: ");
        string input = Console.ReadLine();
        int width = 0;
        if (int.TryParse(input, out width) && (width > 0))
	    {
            Console.Write("Enter rectangle height: "); 
            input = Console.ReadLine();
            int height = 0;
            if (int.TryParse(input, out height) && (height > 0))
            {
                Console.WriteLine("The rectangle area is " + (width*height));
                return;
            }
	    }
        Console.WriteLine("Wrong input parameters!");
    }
}
