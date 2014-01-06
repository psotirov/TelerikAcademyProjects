using System;

class GreatestInteger
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

        int max = a;
        string name = "a";

        if (b > a)
        {
            max = b;
            name = "b";
            if (c > b)
            {
                max = c;
                name = "c";
            }
        }
        else if (c > a)
        {
            max = c;
            name = "c";
        }

        Console.WriteLine("The geatest integer is {0} = {1}", name, max);
    }
}

