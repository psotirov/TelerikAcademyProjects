using System;
using System.Text.RegularExpressions;

class SubstringCount
{
    static void Main()
    {
        Console.WriteLine("Task 04 - Couts how many times as substring is found in a given text\n\n");

        string text = "We are living in a yellow submarine. \nWe don't have anything else. \nInside the submarine is very tight. \nSo we are drinking all the day. \nWe will move out of it in 5 days.\n";
        Console.WriteLine("The text is:\n" + text);

        Console.Write("Please enter a searh substring: ");
        string str = Console.ReadLine().Trim(); // enters the string and removes whitespace chars from its start and end
        int count = 0; // initially there is no substrings found

        Match found = Regex.Match(text,str, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant); // looks for the substring
        while (found.Success) // if a substring has been found
        {
            count++; // counts it
            found = found.NextMatch(); // and goes further
        }
 
        Console.WriteLine("The substring is found {0} times.", count);

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}
