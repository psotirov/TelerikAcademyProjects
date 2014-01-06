using System;

/// <summary>
/// Task 1 - Binary Passwords - BGCoder 100/100 
/// </summary>
class BinaryPasswords
{
    static void Main()
    {
        string input = Console.ReadLine();
        int emptyPlaces = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '*')
            {
                emptyPlaces++;
            }
        }

        // each place has two possible combinations (0 and 1) = 2 = 2^1
        // two places has four possible combinations (0 and 1) and (0 and 1) = 4 = 2^2
        // ...
        // n places has 2^n possible combinations

        long result = (1L << emptyPlaces);
        Console.WriteLine(result);
    }
}

