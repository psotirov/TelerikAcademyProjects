using System;

class FactorialExpression
{
    static void Main()
    {
        int N = 0;
        int K = 0;

        Console.Write("Please enter the number of first factorial K: ");
        if (!int.TryParse(Console.ReadLine(), out K) || K < 1) return;

        Console.Write("Please enter the number of second factorial N (N<K): ");
        if (!int.TryParse(Console.ReadLine(), out N) || N < 1 || N >= K) return;
        ulong result = 1;
        // N! * K! / (K-N)! =
        // = 1.2.3...K-N.K-N+1.....N * 1.2.3....K-N.K-N+1.....N.N+1......K / 1.2.3....K-N = 
        // = 1.2.3...N * (K-N+1).(K-N+2)..K

        for (int i = 2; i <= N; i++) // 1.2.3...K-N
        {
            result *= (uint)i; 
        }
        for (int i = K-N+1; i <= K; i++) // * K-N+1.K-N+2....K
        {
            result *= (uint)i;
        }

        Console.WriteLine("N! * K! / (K-N)! is " + result);
    }
}
