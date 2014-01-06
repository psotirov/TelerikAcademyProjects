using System;

class CountNumber
{
    static void Main()
    {
        Console.WriteLine("Task 04 - Counts how many times a given number is found in an array\n\n");

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

        int num = 0;
        Console.Write("Please enter number to count: ");
        if (!int.TryParse(Console.ReadLine(), out num)) // wrong array dimension
        {
            Console.WriteLine("Not a valid number");
            return;
        } 
        
        Console.WriteLine("The number {0} is found {1} times in the array", num, GetCount(ints, num));

        Console.WriteLine("\nPlease hit Enter to finish");
        Console.ReadLine();
    }

    static int GetCount(int[] arr, int num)
    {
        int count = 0;
        for (int i = 0; i < arr.Length; i++) // iterates through the array
        {
            if (arr[i] == num) count++; // if number has been found increses counter
        }
        return count; // returns counter value 
    }
}
