using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

class LongestSubsequence
{
    static void Main()
    {
        Console.WriteLine("Task 4 - Finds longest subsequence of equal integers in a list\n");

        List<int> list = new List<int>() {4, 5, 5, 4, 4, 4, 6, 4, 5, 6, 2, 2, 2, 2, 6, 2, 2 };
        List<int> expected = new List<int>() { 2, 2, 2, 2 };
        List<int> result = LongestSubListEquals(list);

        Console.WriteLine("List = { " + string.Join<int>(", ", list) + " }");
        Console.WriteLine("Longest subsequence of equals = { " + string.Join<int>(", ", result) + " }");
        Trace.Assert(result.SequenceEqual(expected), "The result and expected lists are different");

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }

    static List<int> LongestSubListEquals(List<int> list)
    {
        if (list == null || list.Count == 0)
        {
            return list;
        }

        int maxCount = 0;
        int maxPosition = 0;
        int count = 1;
        int position = 0;
        int lastValue = list[0];
        for (int i = 1; i < list.Count; i++)
        {
            if (lastValue == list[i])
            {
                count++;
            }
            else
            {
                if (count > maxCount)
                {
                    maxCount = count;
                    maxPosition = position;
                }

                count = 1;
                lastValue = list[i];
                position = i;
            }
        }

        return list.GetRange(maxPosition, maxCount);
    }
}
