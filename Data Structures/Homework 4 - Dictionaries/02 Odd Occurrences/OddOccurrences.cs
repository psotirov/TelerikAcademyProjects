using System;
using System.Collections.Generic;
using System.Linq;

class OddOccurrences
{
    static void Main()
    {
        string[] array = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
        Console.WriteLine("Extracts all elements from the array that occurr odd number of times");
        Console.WriteLine("\nArray = { " + string.Join(", ", array) + " }");

        Dictionary<string, int> counts = new Dictionary<string, int>();
        foreach (var element in array)
        {
            if (counts.ContainsKey(element))
            {
                counts[element]++;
            }
            else
            {
                counts.Add(element, 1);
            }
        }

        var elements = from kvp in counts
                       where kvp.Value % 2 != 0
                       select kvp.Key;
        Console.WriteLine("\nResult = { " + string.Join(", ", elements) + " }");
    }
}
