using System;
using System.Collections.Generic;
using System.Linq;

class RemoveNegatives
{
    static void Main()
    {
        Console.WriteLine("Task 5 - Removes negative numbers in a list\n");

        List<int> list = new List<int>() { 4, -2, 2, -5, 2, -3, -2, -3, 0, 1, 5, -2, -2, 2, 6, -2, 2 };
        var result = from item in list
                     where item >= 0
                     select item;

        Console.WriteLine("List = { " + string.Join<int>(", ", list) + " }");
        Console.WriteLine("Removed all negative elements = { " + string.Join<int>(", ", result) + " }");

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }

 
}