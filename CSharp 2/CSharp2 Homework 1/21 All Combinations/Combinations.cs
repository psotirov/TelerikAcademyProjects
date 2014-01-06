using System;

class Combinations
{
    static void Main()
    {
        Console.WriteLine("Task 21 - Prints all combinations C of N elements chosen as subset of K of them\n\n");
        Console.Write("Please enter number of elements N: ");
        int inputN = 0;
        if (!int.TryParse(Console.ReadLine(), out inputN) || inputN < 2)
        {
            Console.WriteLine("Wrong number for N");
            return;
        }

        Console.Write("\nPlease enter length of subsets K for combinations: ");

        int inputK = 0;
        if (!int.TryParse(Console.ReadLine(), out inputK) || inputK < 2 || inputK > inputN)
        {
            Console.WriteLine("Wrong number for K");
            return;
        }

        int[] combination = new int[inputK];

        // fills-in first combination {1, 2,...., K}
        for (int i = 0; i < inputK; i++)
        {
            combination[i] = i + 1;
        }

        do
        {
            PrintCombination(combination, inputK); // prints last combination
        } while (NextCombination(combination, inputK, inputN)); // goes to the next one, until finish all combinations (method returns false) 

        Console.Write("\nPress Enter to finish");
        Console.ReadLine();
    }

    static void PrintCombination(int[] comb, int k) // prints each combination on a separate line, divided by comma and closed in { }
    {
        Console.Write("\n{");
        for (int i = 0; i < k; i++)
        {
            Console.Write(" " + comb[i] + ((i<k-1)?",":" "));
        }
        Console.WriteLine("}");
    }

    static bool NextCombination(int[] comb, int k, int n)
    {
        // C (n,k) = n*(n-1)*...*(n-k+1) / 1*2*...*K (number of elements both in nominator and denominator are equal)
        // Every combination is an array of k elements. Next, the first digit in every set is every digit between 1 and n.
        // Other digits always are between 1 and n and they are always in ascending order. So, the algorithm is:
        // 1. Start of with (1, 2, ..., k); this is the first combination.
        // 2. Print it.
        // 3. Given the combination (C0, C1, ..., Ck), start from the back and for Ci, if it is larger than n - k + 1 + i
        //    then increment it and go on to the next indice i. 
        // 4. if C0 > n - k, then this is not a valid combination so we stop (return false).
        // 5. Otherwise give (Ci+1), (Ci+2), ... the values of (Ci) + 1, (Ci+1) + 1, ....
        // 6. Go to point 2

        int i = k - 1; // index of last element
        comb[i]++; // increases the last element
        while (i > 0 && comb[i] > (n - k + 1 + i)) // checks the elements from right to left for overflow
        {
            i--; // if yes increases previous element
            comb[i]++;
        }
        if (comb[0] > n - k + 1) return false; // first element oveflowed - end of the algorithm

        for (i += 1; i < k; i++) // updates the oveflowed elements with correct values
        {
            comb[i] = comb[i - 1] + 1;            
        }
     
        return true;
    }
}