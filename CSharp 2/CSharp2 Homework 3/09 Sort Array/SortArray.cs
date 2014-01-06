using System;

class SortArray
{
    static void Main()
    {
        Console.WriteLine("Task 09 - Sorts Array in ascending or descending order\n\n");

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

        int sortDir = 0;
        Console.Write("Please enter Sort direction (0 - ascending, 1 - descending): ");
        if (!int.TryParse(Console.ReadLine(), out sortDir) || sortDir < 0 || sortDir > 1) // wrong sort direction
        {
            Console.WriteLine("Wrong Sort direction");
            return;
        }

        // Sorts using selection sort
        for (int i = 0; i < ints.Length-1; i++)
        {
            // for sorting in ascending order(0) we are swaping x E {last, last-1, .... , 1} with max element in {0, ... , x}
            // for sorting in descending order(1) we are swaping x E {0,1, .... , last-1} with max element in {x, ... , last}

            int maxPos = GetMaxPos(ints, ints.Length - i, ((sortDir == 0)?0:i)); // get max element position 
            int currPos = (sortDir == 0)?ints.Length - 1 - i:i; // selects the position of current element according to sortDir 
            int temp = ints[currPos]; // swaps cuurent and max elements
            ints[currPos] = ints[maxPos];
            ints[maxPos] = temp;
        }


        Console.WriteLine("\nThe sorted array:");
        for (int i = 0; i < dimN; i++)
        {
            Console.WriteLine("Array[{0}] = {1}", i, ints[i]);
        }

        Console.WriteLine("\nPlease hit Enter to finish");
        Console.ReadLine();
    }

    static int GetMaxPos(int[] arr, int length, int start)
    {
        int pos = start; // initially the max element is first one
        int max = arr[start];

        for (int i = start+1; i < start+length; i++) // iterates through all subset of elements
            if (arr[i] > max) // and finds the biggest one
            {
                max = arr[i];
                pos = i;
            }
         
        return pos; // returns position of max element 
    }
}
