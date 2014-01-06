using System;

class RemovalSort
{
    static void Main()
    {
        Console.WriteLine("Task 18 - Removal Sort\nFinds solution such that after removal of some elements from the array\n" +
                          " we can obtain sorted array with most elements in it\n\n");
        Console.Write("Please enter length N of the array [2,63]:");
        int inputN = 0;
        if (!int.TryParse(Console.ReadLine(), out inputN) || inputN < 2 || inputN > 63)
        {
            Console.WriteLine("Wrong array length N");
            return;
        }

        int[] array = new int[inputN];

        Console.WriteLine("\nPlease enter integer values of the array");
        for (int i = 0; i < inputN; i++)
        {
            Console.Write("Array[{0}] = ", i);
            if (!int.TryParse(Console.ReadLine(), out array[i]))
            {
                Console.WriteLine("Wrong array number");
                return;
            }
        }

        // The algorithm implements a simple idea:
        // It iterates through all possible element configurations and for each of them that results in a sorted array
        // choses the one with greatest number elements.

        ulong subset = 0;
        int maxCount = 0;
        ulong maxCombinations = (ulong)(1 << inputN) - 1;
        // total number of element combinations are 2^N -1 (N is the array length), each bit position p represents if array[p] participates in sum

        for (ulong i = 1; i < maxCombinations; i++) // iterates through each combination
        {
            int count = 0; // initial number of elements in current configuration is zero
            int previous = int.MinValue; // each number, comared to int.MinValue will be greater or equal
            for (int j = 0; j < inputN; j++) // iterates through each bit position of the current combination number 
            {
                if ((i & (ulong)(1 << j)) != 0) // if j-th bit is set, then j-th array element prticipates into the configuration 
                {
                    if (array[j] >= previous) // if current element is greater than or equal to the previous one
                    {
                        previous = array[j]; // increases number of elements that are in sorted order
                        count++;
                    }
                    else break; // we have successor in the sequence that is less than last element -> not valid configuraion -> brake inner loop 
                }
            }

            if (count > maxCount) // we have a subset of elements that has asscending order and has greater number of elements than last selection
            {
                subset = i; // saves the combination number
                maxCount = count; // exits the loop
            }
        }

        Console.WriteLine("\n\nThe sequence in the Array that has sorted order is:");
        for (int j = 0; j < inputN; j++) // iterates through each bit position of the current combination number 
        {
            if ((subset & (ulong)(1 << j)) != 0) // if j-th bit is set, then j-th array element prticipates into the sum 
                Console.WriteLine("Array[{0}] = {1}", j, array[j]);
        }
        Console.WriteLine("Total number of extracted elements: " + maxCount);
        Console.WriteLine("Total length of sorted array: " + (inputN - maxCount));

        Console.Write("\nPress Enter to finish");
        Console.ReadLine();
    }
}