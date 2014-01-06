using System;

class MaxSumSequence
{
    static void Main()
    {
        Console.WriteLine("Task 08 - Searching for sequence of integers in Array with max sum\n\n");
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


        int sumMax = array[0]; // initial current sum and initial current sumMax
        int countMax = 1; // both consists of only first array element
        int posMax = 0;
        int sum = array[0];
        int count = 1;
        int pos = 0;

        // one loop solution - the algorithm has two partial sums, initial positions and their elements counters
        // first - candidate for sunMax, posMax, countMax - keeps the maximal sum of elements until current position in the array
        // second - current sum, pos, count - adds elements until the sum (both with element) is greater than the element.
        // In this case it means that the previous sum is negative and we can start again.  
        // After that compares the current sum with sumMax and selects the greater as sumMax.
        // The algorithm is invented first by Joseph B. Kadane in 1984 and innitially 

        for (int i = 1; i < len; i++)
        {
            sum += array[i]; // adds next element to the sum
            count++;
            if (sum < array[i]) // if this element is greater than the sum - throw away the sum and start from here
            {
                sum = array[i];
                pos = i;
                count=1;
            }
            if (sum > sumMax) // checks if we have better sum sequence
            {
                sumMax = sum; // updates sumMax, its position and counter
                posMax = pos;
                countMax = count;
            }
        }

        Console.WriteLine("\n\nThe maximum sum sequence in the Array contains {0} elements.", countMax);
        for (int i = 0; i < countMax; i++)
        {
            Console.WriteLine("Array[{0}] = {1}", posMax + i, array[posMax + i]);
        }

        Console.Write("\nPress Enter to finish");
        Console.ReadLine();
    }
}