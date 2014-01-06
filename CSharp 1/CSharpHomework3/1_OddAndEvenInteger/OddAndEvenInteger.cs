using System;

class OddAndEvenInteger
{
    static void Main()
    {
        string input = Console.ReadLine();
        int number = 0;
        if (int.TryParse(input, out number) && (number != 0))
	    {
            if (number % 2 == 0) Console.WriteLine("The number is even");
            else Console.WriteLine("The number is odd");
	    }
    }
}
