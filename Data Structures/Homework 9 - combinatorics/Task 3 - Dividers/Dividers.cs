using System;
using System.Collections.Generic;

/// <summary>
/// Task 3 - Dividers - BGCoder 100/100
/// </summary>
class Dividers
{
    static int[] digits; 
    static readonly SortedDictionary<int, int> numbers = new SortedDictionary<int, int>(); // number -> count of dividers
    static int minCountDividers;

    static void Main()
    {
        int digitsCount = int.Parse(Console.ReadLine());
        digits = new int[digitsCount];
        for (int i = 0; i < digitsCount; i++)
        {
            digits[i] = int.Parse(Console.ReadLine());
        }

        // we are looking for all permutations of given digits
        minCountDividers = int.MaxValue;
        Permutation(0, 0, 0);
        // as a result we have sorted numbers and counts of their dividers
        // we have to found first item that have minimal count of dividers

        foreach (var item in numbers)
        {
            if (item.Value == minCountDividers)
            {
                Console.WriteLine(item.Key);
                return;
            }
        }
    }

    /// <summary>
    /// Generates all permutations of the given digits
    /// </summary>
    /// <param name="number">the result number, built from all digits </param>
    /// <param name="mask"> bit mask to avoid duplicates, for each used digit a corresponding bit into the mask is set</param>
    static void Permutation(int number, int index, int mask)
    {
        if (index == digits.Length) // single permutation is generated
        {
            if (!numbers.ContainsKey(number)) // avoid duplicates
            {
                int countDividers = 0;
                // count number of dividers
                for (int i = 1; i < number; i++)
                {
                    if (number % i == 0) // divider
                    {
                        countDividers++;
                    }
                }

                numbers.Add(number, countDividers);
                // checks for minimal count of dividers
                if (minCountDividers > countDividers)
                {
                    minCountDividers = countDividers;
                }
            }
        }

        for (int i = 0; i < digits.Length; i++)
        {
            if (((mask >> i) & 1) == 0) // checks if digit is already used
            {
                Permutation(number * 10 + digits[i], index + 1, mask | (1 << i));
            }   
        }
    }
}
