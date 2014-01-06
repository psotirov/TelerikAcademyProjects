using System;

class FactorialTrailingZeros
{
    static void Main()
    {
        int N = 0;
        bool hasMore = true;
        int index = 5;
        int trailingZeros = 0;

        Console.Write("Please enter the factorial dimension N: ");
        if (!int.TryParse(Console.ReadLine(), out N) || N < 2) return;

        while (hasMore)
        {
            if ((N / index) == 0) hasMore = false;
            else
            {
                trailingZeros += N / index; // number of trailing zeros is sum of integer divisions of N by 5, i.e. N/5 + N/5*5 + ... + N/5*...*5 
                index *= 5; //goes to the next power of 5
            }
        }

        Console.WriteLine("The number of trailing zeros in {0}! is {1}", N, trailingZeros);           
    }
}
