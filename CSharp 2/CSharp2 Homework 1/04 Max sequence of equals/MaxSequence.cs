using System;

class MaxSequence
{
    static void Main()
    {
        Console.WriteLine("Task 04 - Searching for maximal sequence of equal integers in Array\n\n");
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

        int numberMax = array[0]; // takes the first element (with count 1) as start sequence
        int countMax = 1;
        int number = array[0];
        int count = 1;
        int posMax = 0;
        int pos = 0;

        for (int i = 1; i < len; i++)
        {
            if (array[i] == number) // if current element is equal to previous element - we have equal sequence
            {
                count++; // counts it
            }
            else // if the sequence has been broken
            {
                if (count > countMax || (count == countMax && number > numberMax)) // checks if current sequence is greatest to the moment
                {
                    numberMax = number; // saves its number, count and starting position
                    countMax = count;
                    posMax = pos;
                }
                number = array[i]; // and resets the current sequence
                count = 1;
                pos = i;
            }
        }

        Console.WriteLine("\n\nThe maximum sequence of equals in the Array contains {0} elements of number {1}.", countMax, numberMax);
        for (int i = 0; i < countMax; i++)
        {
            Console.WriteLine("Array[{0}] = {1}", posMax + i, array[posMax + i]);
        }

        Console.Write("\nPress Enter to finish");
        Console.ReadLine();
    }
}