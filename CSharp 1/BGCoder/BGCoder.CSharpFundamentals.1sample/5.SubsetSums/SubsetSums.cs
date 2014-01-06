using System;

class SubsetSums
{
    static void Main()
    {
        long S = long.Parse(Console.ReadLine()); // the sum to look
        int N = int.Parse(Console.ReadLine()); // quantity of numbers
        int count = 0; // Subset Sums counter

        long[] numbers = new long[N];
        for (int i = 0; i < N; i++) // Loop to enter  numbers 
        {
            numbers[i] = long.Parse(Console.ReadLine()); // reads from the console
        }

        int combinations = (1 << N)-1; // number of different combinations of the numbers is 2^N-1 (excluding 0) 
        for (int i = 1; i <= combinations; i++) // iterates through each combination 
        {
            long Sum = 0;
            for (int j = 0; j < N; j++) // checks each bit in i-th combination
                if (((i >> j) & 1) == 1) Sum += numbers[j]; // and if bit is set includes corresponding number into the sum 
            if (Sum == S) count++; // each sum equal to S increases the counter
        }

        Console.WriteLine(count);
    }
}