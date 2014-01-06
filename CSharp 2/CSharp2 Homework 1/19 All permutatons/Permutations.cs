using System;

class Permutations
{
    static void Main()
    {
        Console.WriteLine("Task 19 - Prints all permutations P of N elements without repetition\n\n");
        Console.Write("Please enter number of elements N: ");
        int inputN = 0;
        if (!int.TryParse(Console.ReadLine(), out inputN) || inputN < 2)
        {
            Console.WriteLine("Wrong number for N");
            return;
        }


        int[] permutation = new int[inputN];

        // fills-in first permutation {1, 2,...., N}
        for (int i = 0; i < inputN; i++)
        {
            permutation[i] = i + 1;
        }

        do
        {
            PrintPermutation(permutation); // prints last variation
        } while (NextPermutation(permutation)); // goes to the next one, until finish all variations (method returns false) 

        Console.Write("\nPress Enter to finish");
        Console.ReadLine();
    }

    static void PrintPermutation(int[] perm) // prints each variation on a separate line, divided by comma and closed in { }
    {
        Console.Write("\n{");
        for (int i = 0; i < perm.Length; i++)
        {
            Console.Write(" " + perm[i] + ((i < perm.Length - 1) ? "," : " "));
        }
        Console.WriteLine("}");
    }

    static bool NextPermutation(int[] perm)
    {
        // Permutation (wihtout repetition) P(n) = n*(n-1)*...*2*1 = n!
        // Every permutation is an array of n elements. Next, every digit in the set is between 1 and n and none of them could be equal.
        // So, we have exactly one digit i between 1 and n per permutation. The algorithm is:
        // 1. Start with (1, 2, ..., n); this is the first permutation.
        // 2. Print it.
        // 3. Given the permutation (P0, P1, ..., Pn). Find the highest index, i1 such that P(i1) is the first of a pair of elements 
        //    in ascending order. If there isn't one, the sequence is the highest permutation, so stop the algorithm.
        // 4. Find the highest index i2, such that i2 > i1 and P(i2) > P(i1).
        // 5. Swap P(i1) and P(i2). The elements from P(i1 + 1) to the end are now in descending order (a later permutation), so reverse them.
        // 6. Go to point 2

        int n = perm.Length;
        int i1 = n - 2;
        while (perm[i1] >= perm[i1+1] && i1 > 0) i1--; // Find the rightmost element that is the first in a pair in ascending order

        if (perm[i1] >= perm[i1+1]) return false; // Not found, array is highest permutation, exit

        int i2 = n - 1;
        while (i2 > i1 && perm[i2] <= perm[i1]) i2--; // Find the rightmost element to the right of i1 that is greater than ar[i1]

        // Swap i1 and i2
        int temp = perm[i1];
        perm[i1] = perm[i2];
        perm[i2] = temp;

        // Reverse the remainder [i1+1, n]
        for (int i = 1; i <= (n-i1)/2; i++)
        {
            temp = perm[i1+i];
            perm[i1+i] = perm[n - i];
            perm[n - i] = temp;
        }
 
        return true; // we have the next permutation 
    }
}