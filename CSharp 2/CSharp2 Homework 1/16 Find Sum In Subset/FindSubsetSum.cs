using System;

class FindSubsetSum
{
    static void Main()
    {
        Console.WriteLine("Task 16 - Searching for a subset of integers in Array with given sum S\n\n");
        Console.Write("Please enter length of the array [2,63]: ");
        int len = 0;
        if (!int.TryParse(Console.ReadLine(), out len) || len < 2 || len > 63)
        {
            Console.WriteLine("Wrong array length");
            return;
        }

        int[] array = new int[len];

        Console.WriteLine("\nPlease enter integer values of the array");
        for (int i = 0; i < len; i++)
        {
            Console.Write("Array[{0}] = ", i);
            if (!int.TryParse(Console.ReadLine(), out array[i]))
            {
                Console.WriteLine("Wrong array number");
                return;
            }
        }

        Console.Write("\nPlease enter sum S for the search: ");

        int inputS = 0;
        if (!int.TryParse(Console.ReadLine(), out inputS))
        {
            Console.WriteLine("Wrong number for sum S");
            return;
        }

        ulong subset = 0;
        ulong maxCombinations = (ulong)(1 << len) - 1;
        // total number of element combinations are 2^N -1 (N is the array length), each bit position p represents if array[p] participates in sum

        for (ulong i = 1; i < maxCombinations; i++) // iterates through each combination
        {
            int sum = 0; // initial sum is zero
            for (int j = 0; j < len; j++) // iterates through each bit position of the current combination number 
            {
                if ((i & (ulong)(1 << j)) != 0) // if j-th bit is set, then j-th array element prticipates into the sum 
                    sum += array[j];
            }

            if (sum == inputS) // we have a subset of elements that has equal sum
            {
                subset = i; // saves the combination number
                break; // exits the loop
            }
        }

        if (subset == 0) // there is no solution
        {
            Console.WriteLine("\n\nThere is no such subset!");
        }
        else // there is solution
        {
            Console.WriteLine("\n\nThe sequence in the Array that has sum of {0} is:", inputS);
            for (int j = 0; j < len; j++) // iterates through each bit position of the current combination number 
            {
                if ((subset & (ulong)(1 << j)) != 0) // if j-th bit is set, then j-th array element prticipates into the sum 
                    Console.WriteLine("Array[{0}] = {1}", j, array[j]);
            } 
        }

        Console.Write("\nPress Enter to finish");
        Console.ReadLine();
    }
}