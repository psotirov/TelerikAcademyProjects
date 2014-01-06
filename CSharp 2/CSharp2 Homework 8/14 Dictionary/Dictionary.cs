using System;
using System.Text.RegularExpressions;

class Dictionary
{
    static void Main()
    {
        Console.WriteLine("Task 14 - Dictionary\n\n");

        string[] dict = {
                            ".NET - platform for applications from Microsoft",
                            "CLR - managed execution environment for .NET",
                            "namespace - hierarchical organization of classes"
                        };
        Console.WriteLine("The dictionary contains: \n");
        foreach (string item in dict)
        {
            Console.WriteLine(item);
        }

        Console.Write("\nPlease enter a word to search: ");
        string word = Console.ReadLine().Trim(); // enters the string and removes whitespace chars from its start and end
        string translation = "";

        foreach (var item in dict)
        {
            Match dictEntry = Regex.Match(item, "(\\S*) - (.*)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
            // divides the dictonary entry into two groups
            // Group[1] - word (a sequence of any nonspace character)
            // Group[2] - translation

            if (word.ToLower() == dictEntry.Groups[1].Value.ToLower()) translation = dictEntry.Groups[2].Value;
            // compares word with dict entry while not taking into account their case    
        }
 
        if (translation.Length > 0) // we have match
            Console.WriteLine("The translation is:\n" + translation);
        else Console.WriteLine("There is no translation!");

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}