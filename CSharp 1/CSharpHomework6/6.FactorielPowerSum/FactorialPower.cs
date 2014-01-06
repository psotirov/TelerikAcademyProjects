using System;

class FactorialAndPowerExpression
{
    static void Main()
    {
        int N = 0;
        int X = 0;

        Console.WriteLine("Calculates S = 1 + 1!/X + 2!/X^2 + ... + N!/X^N");
        Console.Write("Please enter the number of elements N: ");
        if (!int.TryParse(Console.ReadLine(), out N) || N < 1) return;

        Console.Write("Please enter the divisor number X: ");
        if (!int.TryParse(Console.ReadLine(), out X) || X < 1) return;
        double result = 1.0;
        long iFactorial = 1; // first factorial element
        long iX = X; // first power element

        for (int i = 1; i <= N; i++)
        {
            result += iFactorial / (double)iX;
            iFactorial *= i + 1; // prepares the next factorial element
            iX *= X; // prepares the next power element
        }

        Console.WriteLine("The sum S is " + result);
    }
}
