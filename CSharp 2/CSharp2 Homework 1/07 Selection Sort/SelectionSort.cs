using System;

class SelectionSort
{
    static void Main()
    {
        Console.WriteLine("Task 07 - Selection sort algorithm\n\n");
        Console.Write("Please enter length N of the array [2,100]:");
        int inputN = 0;
        if (!int.TryParse(Console.ReadLine(), out inputN) || inputN < 2 || inputN > 100)
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

        // The algorithm divides the input list into two parts: the sublist of items already sorted, which is built up from left to right 
        // at the front (left) of the list, and the sublist of items remaining to be sorted that occupy the rest of the list. 
        // Initially, the sorted sublist is empty and the unsorted sublist is the entire input list. The algorithm proceeds by finding 
        // the smallest (or largest, depending on sorting order) element in the unsorted sublist, exchanging it with the leftmost unsorted 
        // element (putting it in sorted order), and moving the sublist boundaries one element to the right.
 

        for (int idx = 0; idx < inputN-1; idx++) // iterates N-1 times in order to find each min number (idx is number of sorted elements)
        {
            int min = idx; // at the begining the min candidate is the last element in sorted portion 
            for (int i = idx+1; i < inputN; i++) // iterates through unsorted portion of the array 
            {
                if (array[i] < array[min]) // looking for minimal array value only at values that are not selected as max element previously 
                {
                    min = i;
                }
            }
            // now we have the min element of the unsorted portion
            if (min > idx) // if there is a smaller element in the unsorted portion compared with the last element of sorted portion
            {
                int temp = array[idx]; // swaps those elements
                array[idx] = array[min];
                array[min] = temp;
            }
        }


        Console.WriteLine("\n\nThe sorted array:");
        for (int i = 0; i < inputN; i++)
        {
            Console.WriteLine("Array[{0}] = {1}", i, array[i]);
        }

        Console.Write("\nPress Enter to finish");
        Console.ReadLine();
    }
}
