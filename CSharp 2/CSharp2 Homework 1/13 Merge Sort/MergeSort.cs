using System;

class MergeSort
{
    static void Main()
    {
        Console.WriteLine("Task 13 - Merge sort algorithm\n\n");
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
        // Otherwise it divides the input list into two almost equal parts: left and right.
        // Then it calls itself recursively first for the left array and then for the right array.   
        // The the merging part takes place:
        // it compares the first elements from the left and right results - the least is put into the result array first and then the other one
        // the same operatiom is performed for each of the next elements upon finishing of the shorter array
        // the rest of the elements from the longer array then is added to the result array
        // finally the result array is passed above to the calling method.
        // The first recursively invoked method returns the sorted array.

        array = MergeSorting(array); // see below the methods
 
        Console.WriteLine("\n\nThe sorted array:");
        for (int i = 0; i < inputN; i++)
        {
            Console.WriteLine("Array[{0}] = {1}", i, array[i]);
        }

        Console.Write("\nPress Enter to finish");
        Console.ReadLine();
    }

    static int[] MergeSorting(int[] array)
    {
        if (array.Length <= 1) return array; // return on single element array
        int halfLen = array.Length / 2; // divide current array to two (almost) equal parts - left and right
        int[] left = new int[halfLen];
        int[] right = new int[array.Length - halfLen];

        Array.Copy(array, left, halfLen); // copies elements of the bigger array to each of the parts (sub-arrays)
        Array.Copy(array, halfLen, right, 0, array.Length - halfLen);
        left = MergeSorting(left); // invokes the method recursively for each of the sub-arrays
        right = MergeSorting(right); // and receive the sorted ones
        return MergeArrays(left, right); // merges two parts into a single array and passes it to the caller 
    }

    static int[] MergeArrays(int[] left, int[] right)
    {
        int[] result = new int[left.Length + right.Length]; // creates resulting array that can hold both input arrays

        int idxLeft = 0; // walk-through index for left array
        int idxRight = 0; // and for right one
        while (idxLeft < left.Length && idxRight < right.Length) // iterates until both arrays (left and right) have elements that are not copied 
        {
            if (left[idxLeft] <= right[idxRight]) // compares each element in the order from left and right sub-arrays
            {
                result[idxLeft+idxRight] = left[idxLeft]; // if left is smaller put it into the result array
                idxLeft++; // and increases its index
            }
            else // the same for the right element (in this way all elements into the result array should be sorted
            {
                result[idxLeft+idxRight] = right[idxRight];
                idxRight++;
            }
        }

        // finally copies the rest of elements of the longer array (if any - Array.Copy can receive also 0 elements length to copy)
        Array.Copy(left, idxLeft, result, idxLeft+idxRight, left.Length - idxLeft);
        Array.Copy(right, idxRight, result, idxLeft + idxRight, right.Length - idxRight);
        return result; // passes the sorted and merged array to the caller
    }
}
