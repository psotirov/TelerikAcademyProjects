using System;

class BinSearchNearestK
{
    static void Main()
    {
        Console.WriteLine("Task 04 - Find nearest to given number in array\n\n");

        int dimN = 0;
        Console.Write("Please enter array dimension N [2, 100]: ");
        if (!int.TryParse(Console.ReadLine(), out dimN) || dimN < 2 || dimN > 100)
        {
            Console.WriteLine("Bad input agrument!");
            return;
        }

        int[] array = new int[dimN];
        Console.Write("\nPlease enter array values:\n");
        for (int i = 0; i < dimN; i++)
        {
            Console.Write("Array[{0}] = ", i);
            if (!int.TryParse(Console.ReadLine(), out array[i]))
            {
                Console.WriteLine("Bad input agrument!");
                return;
            }
        }

        int numK = 0;
        Console.Write("Please enter number K to look for: ");
        if (!int.TryParse(Console.ReadLine(), out numK))
        {
            Console.WriteLine("Bad input agrument!");
            return;
        }

        Array.Sort(array);
        int idx = Array.BinarySearch(array, numK);
        if (idx < 0) idx = (~idx) - 1;
        // if the key K was not found, idx < 0 and it contains complement bitwise value of the nearest greater number
        // in that case ~idx - 1 will return previous one - the nearest less than K element, if idx takes value of -1, then we don't have solution

        if (idx >=0 ) Console.WriteLine("The result is - Array[{0}] = {1}", idx, array[idx]);
        else Console.WriteLine("There is no less element");

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}