using System;

class Sort3Integers
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

        Console.Write("Please enter third integer c= ");
        input = Console.ReadLine();
        int c = 0;
        if (!int.TryParse(input, out c)) return;

        int temp = a;
                
        if (b < a)
        {
            a = b;
            b = temp;
        }
        if (c < b)
        {
            temp = b;
            b = c;
            c = temp;
            if (b < a)
            {
                temp = a;
                a = b;
                b = temp;
            }
        }

        Console.WriteLine("The sorted integers are a = {0}; b = {1}; c = {2}", a, b, c);
    }
}

