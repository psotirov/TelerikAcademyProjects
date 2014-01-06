using System;
using System.Collections.Generic;

class SortWords
{
    static void Main()
    {
        Console.WriteLine("Task 24 - Print a list of words in alphabetical order\n\n");

        Console.Write("\nPlease enter list (separated by spaces): ");
        string[] input = Console.ReadLine().Trim().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries); // enters the string and removes whitespace chars from its start and end

        List<string> words = new List<string>();
        for (int i = 0; i < input.Length; i++)
        {
            words.Add(input[i]);
        }
        words.Sort();

        Console.WriteLine("\nResult: ");
        foreach (string word in words)
        {
            Console.WriteLine(word);
        }
 
        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}