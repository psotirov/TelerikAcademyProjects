using System;
using System.Text.RegularExpressions;
using System.Globalization;


class ExtractDates
{
    static void Main()
    {
        Console.WriteLine("Task 19 - Extract all valid dates from a given text\n\n");

        Console.Write("\nPlease enter text: ");
        string text = Console.ReadLine().Trim(); // enters the string and removes whitespace chars from its start and end

        MatchCollection foundEmails = Regex.Matches(text, "\\b\\d{1,2}.\\d{1,2}.\\d{4}\\b", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        // finds a complete date string, corresponding to the format DD.MM.YYYY

        for (int i = 0; i < foundEmails.Count; i++) // checks each further and prints it if correct
        {
            DateTime date = new DateTime();
            if (DateTime.TryParseExact(foundEmails[i].Value, "d.M.yyyy", new CultureInfo("bg-BG"), DateTimeStyles.None, out date))
            {
                Console.WriteLine(date.ToString(new CultureInfo("en-CA")));
            }
        }

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}