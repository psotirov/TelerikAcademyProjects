using System;
using System.Text.RegularExpressions;

class ParseURL
{
    static void Main()
    {
        Console.WriteLine("Task 12 - Parse URL\n\n");

        Console.Write("Please enter an URL: ");
        string str = Console.ReadLine().Trim(); // enters the string and removes whitespace chars from its start and end

        Match found = Regex.Match(str, "(\\w+)://([^/]*)(.*)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        // divides the string into three groups
        // Group(1) - looks for the sequence of one or more characters until pattern ://.
        // Group(2) - after it looks for zero or more characters that are not equal to '/'
        // Group(3) - takes all the rest characters
        // Remark: Group(0) holds the entire string

        if (found.Groups.Count > 1) // we have protocol at least
        {
            Console.WriteLine("Protocol: " + found.Groups[1].Value);
            if (found.Groups.Count > 2) // we have server at least
            {
                Console.WriteLine("Server: " + found.Groups[2].Value);
                if (found.Groups.Count > 3) Console.WriteLine("Resource: " + found.Groups[3].Value);
            }
        }
        else Console.WriteLine("Nothing!"); // there is no any URL information

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}
