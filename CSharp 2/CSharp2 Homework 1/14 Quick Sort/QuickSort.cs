using System;

class QuickSort
{
    static void Main()
    {
        Console.WriteLine("Task 14 - Quick sort algorithm\n\n");
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

        // The algorithm is recursive and applies "divide and conquer" technology
        // If the input list(array) is one (or zero) elements long the method returns this value. 
        // Otherwise it divides a large list into two smaller sub-lists: the low elements and the high elements.
        // Quicksort can then recursively sort the sub-lists.
        // The steps are:
        // Pick an element, called a pivot, from the list.
        // Reorder the list so that all elements with values less than the pivot come before the pivot, 
        // while all elements with values greater than the pivot come after it (equal values can go either way). 
        // After this partitioning, the pivot is in its final position. This is called the partition operation.
        // Recursively sort the sub-list of lesser elements and the sub-list of greater elements.
        // finally the result array is passed above to the calling method.
        // The first recursively invoked method returns the sorted array.

        array = QuickSorting(array); // see below the methods
        
        Console.WriteLine("\n\nThe sorted array:");
        for (int i = 0; i < inputN; i++)
        {
            Console.WriteLine("Array[{0}] = {1}", i, array[i]);
        }

        Console.Write("\nPress Enter to finish");
        Console.ReadLine();
    }

    static int[] QuickSorting(int[] array)
    {
        if (array.Length <= 1) return array; // return on single element array
        int idxPivot = array.Length / 2; // divide current array to two (almost) equal parts - less elements to the left and greater to the right 
        int idxLess = 0; // starting index of less elements (up to pivot) 
        int idxGreater = array.Length-1; // starting index of greater elements (below to pivot)

        while (idxLess != idxGreater) // if less index == greater index = pivot index - this sort step is finished
        {
            if (array[idxLess] <= array[idxPivot] && idxLess < idxPivot) idxLess++; // if the element is already less than pivot just move index
            else if (array[idxGreater] >= array[idxPivot] && idxGreater > idxPivot) idxGreater--; // the same for the greater
            else // now we have two elements that sould be swapped (greater in left region and less in right region)
            {
                int temp = array[idxGreater]; // swap
                array[idxGreater] = array[idxLess];
                array[idxLess] = temp;
                if (idxLess == idxPivot) idxPivot = idxGreater; // but one of them could be pivot -> update its position
                else if (idxGreater == idxPivot) idxPivot = idxLess;
            }
        }
        int[] less = new int[idxPivot];
        Array.Copy(array, less, idxPivot); // copies the less than pivot elements into temp array
        less = QuickSorting(less); // send it recursively for sorting
        Array.Copy(less, array, idxPivot); // and the update the initial less elements array with sorted sequence

        int[] greater = new int[array.Length - idxPivot]; // the same for greater than pivot elements
        Array.Copy(array, idxPivot, greater, 0, greater.Length);
        greater = QuickSorting(greater);
        Array.Copy(greater, 0, array, idxPivot, greater.Length);

        return array; // returns sorted array(sub-array) to the caller 
    }
}