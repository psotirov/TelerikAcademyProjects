using System;

class CompareNumberAndNeighbours
{
    static void Main()
    {
        Console.WriteLine("Task 05 - Checks if number in an array is greater than its neighbours\n\n");

        int dimN = 0;
        Console.Write("Please enter array length N [2, 100]: ");
        if (!int.TryParse(Console.ReadLine(), out dimN) || dimN < 2 || dimN > 100) // wrong array dimension
        {
            Console.WriteLine("Not a valid array dimension");
            return;
        }

        int[] ints = new int[dimN];
        for (int i = 0; i < dimN; i++)
        {
            Console.Write("Please enter Array[{0}] = ", i);
            if (!int.TryParse(Console.ReadLine(), out ints[i])) // wrong integer
            {
                Console.WriteLine("Not a valid integer");
                i--;
            }
        }

        int pos = 0;
        Console.Write("Please enter number position in array: ");
        if (!int.TryParse(Console.ReadLine(), out pos)) // wrong array dimension
        {
            Console.WriteLine("Not a valid number");
            return;
        }

        Console.WriteLine("The number {0} at position {1} is {2}bigger than its neighbours", ints[pos], pos, (isBigger(ints, pos)?"":"NOT "));

        Console.WriteLine("\nPlease hit Enter to finish");
        Console.ReadLine();
    }

    static bool isBigger(int[] arr, int pos)
    {
        bool isBigger = true; // assumes that the number is bigger
        if (pos > 0 && arr[pos - 1] >= arr[pos]) isBigger = false; // checks wiht previous element
        if (pos < arr.Length - 1 && arr[pos + 1] >= arr[pos]) isBigger = false; // checks wiht next element
        return isBigger; // returns condition 
    }
}
