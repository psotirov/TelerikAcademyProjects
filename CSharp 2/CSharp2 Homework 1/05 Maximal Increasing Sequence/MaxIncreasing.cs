using System;

class MaxIncreasing
{
    static void Main()
    {
                    Console.WriteLine("Task 05 - Searching for maximal sequence of increasing integers in Array\n\n");
        Console.Write("Please enter length of the array [2,100]:");
        int len = 0;
        if (!int.TryParse(Console.ReadLine(), out len) || len < 2 || len > 100)
        {
            Console.WriteLine("Wrong array length");
            return;
        }

        int[] array = new int[len];
            
        Console.WriteLine("Please enter integer values of the array\n");
        for (int i = 0; i < len; i++)
        {
            Console.Write("Array[{0}] = ", i);
            if (!int.TryParse(Console.ReadLine(), out array[i]))
            {
                Console.WriteLine("Wrong array number");
                return;
            }
        }

        int countMax = 1;
        int number = array[0];
        int count = 1;
        int posMax = 0;
        int pos = 0;

        for (int i = 1; i < len; i++)
        {
            if ((array[i] - number) == 1) // if the difference with previous element is 1 - we have increasing sequence
            {
                count++; // counts it
                number = array[i]; // puts the element as previous
            }
            else // if the sequence has been broken
            {
                if (count > countMax) // checks if current sequence is greatest to the moment
                {
                    countMax = count; // saves its count and starting position
                    posMax = pos;
                }
                number = array[i]; // and resets the current sequence
                count = 1;
                pos = i;
            }
        }

        Console.WriteLine("\n\nThe maximum increasing sequence in the Array contains {0} elements.", countMax);
        for (int i = 0; i < countMax; i++)
        {
            Console.WriteLine("Array[{0}] = {1}", posMax + i, array[posMax + i]);
        }

        Console.Write("\nPress Enter to finish");
        Console.ReadLine();
    }
}