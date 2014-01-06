using System;
using System.Collections.Generic;

class SumOfIntegers
{
    static private readonly List<int> list = new List<int>();

    static void Main()
    {
        Console.WriteLine("Task 1 - Sum of List of Integers\n");
        string inputLine;
        int countN = 1;
        int number;
        do
        {
            Console.Write("Positive integer {0} > ", countN);
            inputLine = Console.ReadLine().Trim();
            if (int.TryParse(inputLine, out number) && number > 0)
            {
                list.Add(number);
                countN++;
            }
            else if (inputLine.Length > 0)
            {
                Console.WriteLine("Input should be a positive integer number\n");
            }
        } while (inputLine.Length > 0);

        int sum = 0;
        foreach (var item in list)
        {
            sum += item;
        }

        Console.WriteLine("\nThe sum is " + sum);
        Console.WriteLine("The average is " + sum / list.Count);

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine(); 
    }
}

