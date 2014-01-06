using System;

class DivisionFactorials
{
    static void Main()
    {
        int N = 0;
        int K = 0;

        Console.Write("Please enter the number of first factorial N: ");
        if (!int.TryParse(Console.ReadLine(), out N) || N < 1) return;

        Console.Write("Please enter the number of second factorial K (K<N): ");
        if (!int.TryParse(Console.ReadLine(), out K) || K < 1 || K >= N) return;
        ulong result = 1;
        for (int i = K+1; i <= N; i++)
        {
            result *= (uint)i; // N! / K! = 1.2.3...K.K+1.....N / 1.2.3....K = K+1.....N
        }
        Console.WriteLine("N! / K! is " + result);
    }
}
