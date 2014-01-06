using System;

class MaxSumOfK
{
    static void Main()
    {
        Console.WriteLine("Task 06 - Searching for K integer elements of Array that have maximal sum\n\n");
        Console.Write("Please enter length N of the array [2,100]:");
        int inputN = 0;
        if (!int.TryParse(Console.ReadLine(), out inputN) || inputN < 2 || inputN > 100)
        {
            Console.WriteLine("Wrong array length N");
            return;
        }

        Console.Write("\nPlease enter count of elements K for the search [2,{0}]:", inputN);

        int inputK = 0;
        if (!int.TryParse(Console.ReadLine(), out inputK) || inputK < 2 || inputK > inputN)
        {
            Console.WriteLine("Wrong number of elements K");
            return;
        }

        int[] array = new int[inputN];
        int maxSum = 0;

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

        // in order to find K elements that have greatest sum, obviously we have to find just K greatest elements
        // the most simple to do is to sort the array and take the last K elements
        // i.e. Array.Sort(array), and after -> sum = array[N]+array[N-1]+...+array[N-K+1]
        // here is implemented different solution with limitation not to touch the initial array

        // creating list of flags if the element in corresponding input array is one of those K max numbers
        bool[] isMaxElement = new bool[inputN]; 
        // the default value is false

        for (int idxK = 0; idxK < inputK; idxK++) // iterates K times in order to find all K max numbers
        {
            int maxNumber = int.MinValue; // at the begining the max candidate is minimal possible value 
            int maxIdx = 0;
            for (int idxN = 0; idxN < inputN; idxN++) // each iteration through the input array locates one of the max elements 
            {
                if (!isMaxElement[idxN] && array[idxN] >= maxNumber) // looking only at values that are not selected as max element previously 
                {
                    maxNumber = array[idxN];
                    maxIdx = idxN;
                }                   
            }
            // now we have the max element
            isMaxElement[maxIdx] = true; // mark its position in flags array
            maxSum += array[maxIdx]; // calcuates the sum up to the moment
        }


        Console.WriteLine("\n\nThe maximum sum of {0} elements in the Array is {1}.", inputK, maxSum);
        for (int i = 0, count = 1; i < inputN; i++)
        {
            if (isMaxElement[i]) // prints only max elements of the original array
            {
                Console.WriteLine("{0} - Array[{1}] = {2}",count++, i, array[i]);
            }
        }

        Console.Write("\nPress Enter to finish");
        Console.ReadLine();
    }
}
