using System;

class SequenceSum
{
    static void Main()
    {
        Console.WriteLine("Task 10 - Searching for sequence of integers in Array with given sum S\n\n");
        Console.Write("Please enter length of the array [2,100]:");
        int len = 0;
        if (!int.TryParse(Console.ReadLine(), out len) || len < 2 || len > 100)
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

        Console.Write("\nPlease enter sum S for the search:");

        int inputS = 0;
        if (!int.TryParse(Console.ReadLine(), out inputS))
        {
            Console.WriteLine("Wrong number for sum S");
            return;
        }


        int sum = array[0]; // initial candidate sum
        int end = 1; // consists only of first array element
        int start = 0;
        int pos = -1; // negative index - no solution

        // one loop solution - the algorithm has a partial sum, initial position and element counter
        // adds elements until the sum is greater than the desired sum S.
        // if sum is equal to S exits with positive result.
        // otherwise extracts elements from the begining of sequence until the sum is less than the desired sum S.  
        // exits if the end of array is reached

        while (pos<0 && start <= end && end <= len) // checks if there is solution or the array's end was reached
        {
            if (sum < inputS) // adding first
            {
                sum += array[end];
                end++;
            }
            if (sum > inputS) // then substracting if needed
            {
                sum -= array[start];
                start++;
            }
            if (sum == inputS) // and finally comparison with S but only if sequence is not empty 
            {
                if ((end - start) > 0) pos = start; // we have non empty solution
                else if (++end <= len) sum = array[start]; // otherwise we are looking for S=0 and go ahead'if we can (we could have 0 as array element)
            }
        }

        if (pos < 0) // there is no solution
        {
            Console.WriteLine("There is no such sequence!");
        }
        else // there is solution
        {
            Console.WriteLine("\n\nThe sequence in the Array that has sum of {0} contains {1} elements.", sum, end-start);
            for (int i = start; i < end; i++)
            {
                Console.WriteLine("Array[{0}] = {1}", i, array[i]);
            }
        }

        Console.Write("\nPress Enter to finish");
        Console.ReadLine();
    }
}