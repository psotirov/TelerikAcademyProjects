using System;
using System.Collections.Generic;
using System.Linq;

class FindMajorant
{
    static void Main()
    {
        Console.WriteLine("Task 8 - Finds array's Majorant, if any\n");

        int[] array = new int[] {8, 4, 4, 8, 3, 8, 4, 3, 2, 8, 7, 8, 8, 4, 7, 8, 8, 8, 8};
        Console.WriteLine("Initial array = { " + string.Join(", ", array) + " }");
        Console.WriteLine("Array's length - " + array.Length + "\n");

        var queryMajorant = from item in GetNumbersCount(array)
                            where item.Value > array.Length / 2
                            select item;

        if (queryMajorant.Count() > 0)
        {
            Console.WriteLine("Majorant Number {0} - {1} times", queryMajorant.First().Key, queryMajorant.First().Value);
        }
        else
        {
            Console.WriteLine("There is no majorant in the array");
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

