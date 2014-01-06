using System;

class ProductSign
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

        bool plusSign = true; // we assume that the product is positive
        if (a < 0) plusSign = !plusSign; // each negative value changes the sign of the product
        if (b < 0) plusSign = !plusSign; // but each pair of them NOT!
        if (c < 0) plusSign = !plusSign;
        

        Console.WriteLine("The sign of product is {0}", (plusSign)?"+":"-");
    }
}

