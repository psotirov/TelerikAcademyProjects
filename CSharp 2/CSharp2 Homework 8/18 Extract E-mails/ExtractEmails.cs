using System;
using System.Text.RegularExpressions;

class ExtractEmails
{
    static void Main()
    {
        Console.WriteLine("Task 18 - Extract all valid e-mail addresses from a given text\n\n");

        Console.Write("\nPlease enter text: ");
        string text = Console.ReadLine().Trim(); // enters the string and removes whitespace chars from its start and end

        MatchCollection foundEmails = Regex.Matches(text, "\\b[\\w._%+-]+@(?:[\\w-]+\\.)+[a-z]{2,4}\\b", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        // finds a complete e-mail address, consisting of three parts
        // 1. indentifier - one or more alphanumeric characters plus '+','%','+','-'
        // 2. host - one or more subdomains, cosists of alphanumeric characters plus '-', and finishing with '.' each
        // 3. domain - a sequence of alphabet characters with length betwee 2 and 2 chars
        for (int i = 0; i < foundEmails.Count; i++) // prints each e-mail found
        {
            Console.WriteLine(foundEmails[i].Value);
        }

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}