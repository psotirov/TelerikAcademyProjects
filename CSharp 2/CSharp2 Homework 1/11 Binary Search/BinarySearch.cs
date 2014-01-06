using System;

class BinarySearch
{
    static int[] array;

    static void Main()
    {
        Console.WriteLine("Task 11 - Binary search of given value in sorted array\n\n");
        Console.Write("Please enter length of the array [2,100]:");
        int len = 0;
        if (!int.TryParse(Console.ReadLine(), out len) || len < 2 || len > 100)
        {
            Console.WriteLine("Wrong array length");
            return;
        }

        array = new int[len];

        Console.WriteLine("\nPlease enter integer values of the array\n(the program will sort the array after)");
        for (int i = 0; i < len; i++)
        {
            Console.Write("Array[{0}] = ", i);
            if (!int.TryParse(Console.ReadLine(), out array[i]))
            {
                Console.WriteLine("Wrong array number");
                return;
            }
        }

        Console.Write("\nPlease enter the value for the search: ");

        int inValue = 0;
        if (!int.TryParse(Console.ReadLine(), out inValue))
        {
            Console.WriteLine("Wrong number for value");
            return;
        }

        // sorts the array just for insurance
        Array.Sort(array);
        Console.WriteLine("\nThe sorted array is:\n");
        for (int i = 0; i < len; i++)
        {
            Console.WriteLine("Array[{0}] = {1}", i, array[i]);
        }

        // calls the BinarySearch Method (see below)
        int pos = BinSearch(inValue, 0, len);

        if (pos < 0) // there is no solution
        {
            Console.WriteLine("There is no such element!");
        }
        else // there is solution
        {
            Console.WriteLine("\n\nThe element is found - Array[{0}] = {1}", pos, array[pos]);
        }

        Console.Write("\nPress Enter to finish");
        Console.ReadLine();
    }

    static int BinSearch(int value, int start, int end)
    {
        int mid = (start + end) / 2; // calculates the middle element of the array
        if (value == array[mid]) return mid; // if the element is found return its index
        if (start == end) return -1; // otherwise if the array is one element return "not found" message (-1) 
        if (value < array[mid]) end = mid-1; // if the search value is less than middle element search the left half of the array
        else start = mid+1; // otherwise the right half
        return BinSearch(value, start, end); // invokes recursive call with updated parameters
    }
}