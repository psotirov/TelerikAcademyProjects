using System;

class NumbersNotDivisibleTo3And7
{
    static void Main()
    {
        int N = 0;
        string input = Console.ReadLine();
        if (!int.TryParse(input, out N) || N <= 0) return;

        for (int i = 1; i <= N; i++)
        {
            if (i % 21 != 0) Console.WriteLine(i); // i % 3 && i % 7 = i % (3*7)
        }
    }
}
