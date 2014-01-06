using System;
using System.Collections.Generic;

class CountNumbers
{
    static void Main()
    {
        Console.WriteLine("Task 7 - Counts Numbers in array\n");

        int[] array = new int[] {3, 4, 4, 2, 3, 3, 4, 3, 2, 8, 7, 9, 1, 1, 4, 7, 8, 8, 8, 8};
        Console.WriteLine("Initial array = { " + string.Join(", ", array) + " }\n");

        Dictionary<int, int> counts = GetNumbersCount(array);
        foreach (var item in counts)
        {
            Console.WriteLine("Number {0} - {1} times", item.Key, item.Value);
        }

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }

    static Dictionary<int, int> GetNumbersCount(int[] array)
    {
        Dictionary<int, int> result = new Dictionary<int,int>();
        foreach (var item in array)
        {
            if (result.ContainsKey(item))
            {
                result[item]++;
            }
            else
            {
                result.Add(item, 1);
            }
        }

        return result;
    }
}

