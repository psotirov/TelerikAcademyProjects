using System;

class GreatestCommonDivisor
{
    static int GCDbyDifferences(int a, int b) // Using iterations method
    {
        while (a != b)
            if (a > b) a = a - b;
            else b = b - a;
        return a;
    }

    static int GCDbyDivisions(int a, int b) // Using recursive method
    {
        if (b == 0) return a;
        else return GCDbyDivisions(b, a % b);
    }

    static void Main()
    {
        int X = 0;
        int Y = 0;

        Console.WriteLine("Calculates Greatest Common Divisor of two integers");
        Console.Write("Please enter the first number X: ");
        if (!int.TryParse(Console.ReadLine(), out X) || X < 1) return;

        Console.Write("Please enter the second number Y: ");
        if (!int.TryParse(Console.ReadLine(), out Y) || Y < 1) return;

        Console.WriteLine("The GCD (using differences in iterative procedure) is " + GCDbyDifferences(X, Y));
        Console.WriteLine("The GCD (using divisions in recursive procedure) is " + GCDbyDivisions(X, Y));
    }
}
