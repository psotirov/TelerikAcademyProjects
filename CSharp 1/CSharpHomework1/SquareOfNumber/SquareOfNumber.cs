using System;

class SquareOfNumber
{
    static void Main()
    {
        int number = 12345;
        Console.WriteLine("The square of {0} is {1:N0}", number, Math.Pow(number, 2));
    }
}

