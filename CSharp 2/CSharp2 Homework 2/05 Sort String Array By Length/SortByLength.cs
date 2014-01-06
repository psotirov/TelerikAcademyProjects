using System;
using System.Collections.Generic;

public class StringLengthComparer : IComparer<string>
{
    public int Compare(string first, string second)
    {
        int result = first.Length - second.Length; // compare by length
        if (result == 0) result = first.CompareTo(second); // if the length is the same then compare lexicographically
        return result;
    }
}
class SortStringsByLength
{
    static void Main()
    {
        Console.WriteLine("Task 05 - Sort string elements by their length\n\n");

        Console.Write("Please enter Array of strings dimension N [2, 100]: ");

        int inputN = 0;
        StringLengthComparer compLen = new StringLengthComparer();

        if (!int.TryParse(Console.ReadLine(), out inputN) || inputN < 2 || inputN > 100)
        {
            Console.WriteLine("Wrong dimension N");
            return;
        }

        string[] array = new string[inputN];

        Console.WriteLine("\nPlease enter array values:\n");
        for (int row = 0; row < inputN; row++)
        {
            Console.Write("Array[{0}]= ", row);
            array[row] = Console.ReadLine();
        }

        Array.Sort(array, compLen);

        Console.WriteLine("\nThe sorted array is:\n");
        for (int row = 0; row < inputN; row++)
        {
            Console.WriteLine("Array[{0}]= {1}", row, array[row]);
        }

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}

