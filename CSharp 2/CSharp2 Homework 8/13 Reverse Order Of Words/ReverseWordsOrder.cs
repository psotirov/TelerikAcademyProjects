using System;
using System.Text;
using System.Text.RegularExpressions;

class ReverseWordsOrder
{
    static void Main()
    {
        Console.WriteLine("Task 13 - Reverse the words order in a given sentence\n\n");

        Console.Write("Please enter a sentence: ");
        StringBuilder str = new StringBuilder(Console.ReadLine().Trim()); // enters the string and removes whitespace chars from its start and end

        MatchCollection words = Regex.Matches(str.ToString(), "[^\\s.!?,]+", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        // finds a list of words - any non-empty character sequence until first occurence of whitespace or punctuation character

        for (int i = 0; i < words.Count; i++)
        {
            str.Remove(words[words.Count - 1 - i].Index, words[words.Count - 1 - i].Length);
            // removes words consecutivelyfrom back to start of string     
            str.Insert(words[words.Count - 1 - i].Index, words[i].Value);
            // and in its places inserts words from start to back of string     
        }
 
        Console.WriteLine("The sentence in a reverse order is:\n" + str);

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}