using System;
using System.Numerics;

class CatalanNumber
{
    static void Main()
    {
        int N = 0;

        Console.WriteLine("Catalan number Cn = (2*N)! / (N+1)!*N!");
        Console.Write("Please enter the number N: ");
        if (!int.TryParse(Console.ReadLine(), out N) || N < 0) return;

        if (N < 2)
        {
            Console.WriteLine("Catalan number is 1");
            return;
        }

        BigInteger nominator = 1;
        BigInteger denominator = 1;
        for (int i = 2; i <= N; i++)
        {
            nominator *= N + i;
            denominator *= i;
            // (2*N)! / (N+1)!*N! = 1.2...N.N+1.N+2...N+N / 1.2...N.N+1 * 1.2...N = N+2.N+3...N+N / 2.3...N
        }
        nominator = nominator / denominator; // the result is always an integer number
        Console.WriteLine("Catalan number is " + nominator);
    }
}
