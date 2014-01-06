using System;

class Variations
{
    static void Main()
    {
        Console.WriteLine("Task 20 - Prints all variations V of N elements chosen as subset of K of them\n\n");
        Console.Write("Please enter number of elements N: ");
        int inputN = 0;
        if (!int.TryParse(Console.ReadLine(), out inputN) || inputN < 2)
        {
            Console.WriteLine("Wrong number for N");
            return;
        }

        Console.Write("\nPlease enter length of subsets K for variations: ");

        int inputK = 0;
        if (!int.TryParse(Console.ReadLine(), out inputK) || inputK < 2 || inputK > inputN)
        {
            Console.WriteLine("Wrong number for K");
            return;
        }

        int[] variation = new int[inputK];

        // fills-in first variation {1, 1,...., 1}
        for (int i = 0; i < inputK; i++)
        {
            variation[i] = 1;
        }

        do
        {
            PrintVariation(variation, inputK); // prints last variation
        } while (NextVariation(variation, inputK, inputN)); // goes to the next one, until finish all variations (method returns false) 

        Console.Write("\nPress Enter to finish");
        Console.ReadLine();
    }

    static void PrintVariation(int[] variat, int k) // prints each variation on a separate line, divided by comma and closed in { }
    {
        Console.Write("\n{");
        for (int i = 0; i < k; i++)
        {
            Console.Write(" " + variat[i] + ((i < k - 1) ? "," : " "));
        }
        Console.WriteLine("}");
    }

    static bool NextVariation(int[] variat, int k, int n)
    {
        // Variation (multicombination, i.e. combination with repetition) V (n,k) = n*(n-1)*...*(n-k+1)
        // Every variation is an array of k elements. Next, every digit in the set is between 1 and n.
        // So, the algorithm is:
        // 1. Start with (1, 1, ..., 1); this is the first variation.
        // 2. Print it.
        // 3. Given the variation (V0, V1, ..., Vk), start from the back and for Vi increment it, if it is larger than n
        //    then set to 1 and go on to the next indice i. 
        // 4. if V0 > n, then this is not a valid variation so we stop (return false).
        // 5. Go to point 2

        int i = k - 1; // index of last element
        variat[i]++; // increases the last element
        while (i > 0 && variat[i] > n) // checks the elements from right to left for overflow
        {
            variat[i] = 1;
            i--; // if yes increases previous element
            variat[i]++;
        }
        return !(variat[0] > n); // if first element oveflowed - end of the algorithm (false), otherwise returns true
    }
}