using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


class CountWords
{
    static void Main()
    {
        Console.WriteLine("Counts words in a text file");

        string inputFile = @"..\..\words.txt";
        Dictionary<string, int> counts = new Dictionary<string, int>();

        try
        {
            using (StreamReader reader = new StreamReader(inputFile, Encoding.ASCII))
            {
                while (!reader.EndOfStream)
                {
                    string buffer = reader.ReadLine();
                    // selects every word from input line with length of at least 1 (case insensitive)
                    Regex reg = new Regex(@"\b\w+\b", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

                    foreach (Match match in reg.Matches(buffer))
                    {
                        if (counts.ContainsKey(match.Value))
                        {
                            counts[match.Value]++;
                        }
                        else
                        {
                            counts.Add(match.Value, 1);
                        } 
                    }
                }
            }
        }
        catch (IOException ioe)
        {
            Console.WriteLine("Input file IO Exception: " + ioe);
            return;
        }

        int totalOccurrences = 0;
        Console.WriteLine("Occurrences:");
        foreach (var item in counts)
        {
            Console.WriteLine("{0} - {1} times", item.Key, item.Value);
            totalOccurrences += item.Value;
        }
        Console.WriteLine("Total {0} words found.", totalOccurrences);
    }
}