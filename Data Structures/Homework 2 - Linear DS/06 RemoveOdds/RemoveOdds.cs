using System;
using System.Collections.Generic;
using System.Linq;

class LongestSubsequence
{
    static void Main()
    {
        Console.WriteLine("Task 6 - Removes all members in a list that occurs odd times\n");

        List<int> list = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2, 2, 2, 6, 2, 2 };
        List<int> result = RemoveOddCountElements(list);

        Console.WriteLine("List = { " + string.Join<int>(", ", list) + " }");
        Console.WriteLine("Removed all elements that occur odd times = { " + string.Join<int>(", ", result) + " }");

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }

    static List<int> RemoveOddCountElements(List<int> list)
    {
        if (list == null || list.Count == 0)
        {
            return list;
        }

        List<int> result = new List<int>();
        foreach (var item in list)
        {
            if (list.Count(x => (x == item)) % 2 == 0) // counts how many times item occurs into the list
            {
                result.Add(item);
            }
        }

        return result;
    }
}