using System;

class FindBiggerNeighbour
{
    static void Main()
    {
        Console.WriteLine("Task 06 - Finds first number in an array that is greater than its neighbours\n\n");

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

        int pos = GetBigger(ints);
        if (pos >=0) Console.WriteLine("The number {0} at position {1} is bigger than its neighbours", ints[pos], pos); // we have solution
        else Console.WriteLine("There is no such number");

        Console.WriteLine("\nPlease hit Enter to finish");
        Console.ReadLine();
    }

    static int GetBigger(int[] arr)
    {
        int pos = -1; // initially there is no number in the array that fulfills condition
        for (int i = 1; i < arr.Length-1; i++) // iterates through array (the first and last elements are not considered as correct answers 
        {
            if (isBigger(arr, i)) // if found
            {
                pos = i; // saves its position
                break; // and stops the loop
            }
        }

        return pos; // returns the answer
    }

    static bool isBigger(int[] arr, int pos)
    {
        bool isBigger = true; // assumes that the number is bigger
        if (pos > 0 && arr[pos - 1] >= arr[pos]) isBigger = false; // checks wiht previous element
        if (pos < arr.Length - 1 && arr[pos + 1] >= arr[pos]) isBigger = false; // checks wiht next element
        return isBigger; // returns condition 
    }
}
