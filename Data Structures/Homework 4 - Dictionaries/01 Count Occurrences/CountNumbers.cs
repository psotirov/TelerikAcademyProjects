using System;
using System.Collections.Generic;

class CountNumbers
{
    static void Main()
    {
        double[] array = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5};
        Console.WriteLine("Count occurrences of each number in double array");
        Console.WriteLine("\nArray = { "+ string.Join(", ", array) + " }");

        Dictionary<double, int> counts = new Dictionary<double, int>();
        foreach (var number in array)
        {
            if (counts.ContainsKey(number))
	        {
		        counts[number]++;
	        }
            else
            {
                counts.Add(number, 1);
            }
        }

        Console.WriteLine("Occurrences:");
        foreach (var item in counts)
        {
            Console.WriteLine("Number {0:N2} - {1} times", item.Key, item.Value);
        }
    }
}

