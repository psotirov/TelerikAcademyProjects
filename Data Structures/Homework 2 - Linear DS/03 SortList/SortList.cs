using System;
using System.Collections.Generic;

class SortList
{
    static private readonly List<int> list = new List<int>();

    static void Main()
    {
        Console.WriteLine("Task 3 - Sorting List of Integers\n");

        string inputLine;
        int countN = 1;
        int number;
        do
        {
            Console.Write("Integer {0} > ", countN);
            inputLine = Console.ReadLine().Trim();
            if (int.TryParse(inputLine, out number))
            {
                list.Add(number);
                countN++;
            }
            else if (inputLine.Length > 0)
            {
                Console.WriteLine("Input should be an integer number\n");
            }
        } while (inputLine.Length > 0);

        list.Sort();
        countN = 0;
        Console.WriteLine("\nThe sorted list is");
        foreach (var item in list)
        {
            Console.WriteLine("The {0} integer is {1}", countN++, item);
        }

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}
