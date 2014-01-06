using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class CountWords
{
    static void Main()
    {
        Console.WriteLine("Task 22 - Count words in a given text\n\n");

        Dictionary<string, int> words = new Dictionary<string, int>(); // creates holder for words and their count

        Console.Write("\nPlease enter text: ");
        string text = Console.ReadLine().Trim().ToLower(); // enters the string and removes whitespace chars from its start and end

        MatchCollection foundWords = Regex.Matches(text, "\\b[a-z]+\\b", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        // finds all words that consists only of alphabet letters

        for (int i = 0; i < foundWords.Count; i++) 
        {
            // checks for each word found if it is already into the dictionary
            if (words.ContainsKey(foundWords[i].Value)) words[foundWords[i].Value]++; // if yes increments its count
            else words.Add(foundWords[i].Value, 1); // otherwise adds it to the dictionary
        }

        foreach (KeyValuePair<string, int> pair in words) // prints all pairs word->count
        {
            Console.WriteLine("Word \"{0}\" - {1} times met", pair.Key, pair.Value);
        }

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}