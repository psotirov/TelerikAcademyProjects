using System;

class MostFrequentElement
{
    static void Main()
    {
        Console.WriteLine("Task 09 - Searching for a most frequent element in an Array\n\n");
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
        
        // the simplest algorithm is to sort the array and after to count for each element how many times it was met inside.

        Array.Sort(array);

        int number = array[0]; //initial number is in the first array element and counts to 1; 
        int count = 1;
        int numberMax = array[0];
        int countMax = 1;

        for (int i = 1; i < len; i++)
        {
            if (array[i] == number)
            {
                count++;
            }
            else
            {
                if (count > countMax)
                {
                    numberMax = number;
                    countMax = count;
                }
                number = array[i];
                count = 1;
            }
        }

        Console.WriteLine("\n\nThe most frequent number in array is {0} and it was met {1} times.", numberMax, countMax);
 
        Console.Write("\nPress Enter to finish");
        Console.ReadLine();
    }
}