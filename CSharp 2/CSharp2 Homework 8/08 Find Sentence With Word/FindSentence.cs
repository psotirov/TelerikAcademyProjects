using System;
using System.Text.RegularExpressions;

class FindSentence
{
    static void Main()
    {
        Console.WriteLine("Task 08 - Find all sentences in a given text that contains a certain word\n\n");

        string text = "We are living in a yellow submarine. \nWe don't have anything else. \nInside the submarine is very tight. \nSo we are drinking all the day. \nWe will move out of it in 5 days.\n";
        Console.WriteLine("The text is:\n" + text);

        Console.Write("Please enter a searh word: ");
        string str = Console.ReadLine().Trim(); // enters the string and removes whitespace chars from its start and end

        Match found = Regex.Match(text, "[^\\.]*\\b"+str+"\\b.*?\\.", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        // looks for the sequence of charaters that not have '.' inside, has zero or more characters,
        // has the entered string as a word, after it has zero or more characters and finishes with '.'
        while (found.Success) // if a substring has been found
        {
            Console.WriteLine(text.Substring(found.Index, found.Length).Trim()); // removes any whitespace characters in both ends and prints it

            found = found.NextMatch(); // and goes further
        }

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}
