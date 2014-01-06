using System;
using System.Text.RegularExpressions;

class ExtractPalindromes
{
    static void Main()
    {
        Console.WriteLine("Task 20 - Extract all palindromes from a given text\n\n");

        Console.Write("\nPlease enter text: ");
        string text = Console.ReadLine().Trim(); // enters the string and removes whitespace chars from its start and end

        MatchCollection foundWords = Regex.Matches(text, "\\b[a-z][a-z]+\\b", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        // finds all words that have at least two characters
 
        for (int i = 0; i < foundWords.Count; i++) // checks for each word found if it is palindrome
        {
            bool palindrome = true; // assumes that current word is palindrome
            for (int j = 0; j < foundWords[i].Value.Length / 2; j++)
            {
                if (foundWords[i].Value[j] != foundWords[i].Value[foundWords[i].Value.Length - 1 - j])
                // compares each pair of characters on equal distance from the middle of the word (first - last, first+1 - last-1, etc)  
                {
                    palindrome = false; // if not equal the word is not plindrome
                    break;
                }
            }
            if (palindrome) Console.WriteLine(foundWords[i].Value); // if palindrome, prints it
        }

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}