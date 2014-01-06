using System;

class GreaterInteger
{
    static void Main()
    {
        Console.Write("Please enter first integer a= ");
        string input = Console.ReadLine();
        int a = 0;
        if (!int.TryParse(input, out a)) return;

        Console.Write("Please enter second integer b= ");
        input = Console.ReadLine();
        int b = 0;
        if (!int.TryParse(input, out b)) return;

        if (a > b)
        {
            int temp = b;
            b = a;
            a = temp;
        }

        Console.WriteLine("a = {0}; b = {1}", a, b);
    }
}

