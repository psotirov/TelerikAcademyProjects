using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class CountWordsOfFileInAnother
{
    static void Main()
    {
        Console.WriteLine("Task 13 - Count words in a given text file\n\n");

        string wordsfile = "words.txt";

        List<string> words = new List<string>(); // list of words to remove
        List<int> counts = new List<int>(); // equal list with word's quantity into the input file
        try
        {
            using (StreamReader wReader = new StreamReader(wordsfile, Encoding.ASCII))
            {
                while (!wReader.EndOfStream)
                {
                    string line = wReader.ReadLine(); 
                    // assumes that each word is on separate line (otherwise additional loop and .Split(' ') or even RegEx pattern should be used
                    if (line.Length > 0)
                    {
                        words.Add(line); // reads a line from words file. it must contain a single word
                        counts.Add(0); // and  its initial count is 0 
                    }
                }
            }
        }
        catch (IOException ioe)
        {
            Console.WriteLine("Words file IO Exception: " + ioe);
            return;
        }

        string testfile = "test.txt";
        string resultfile = "result.txt";

        try
        {
            using (StreamReader reader = new StreamReader(testfile, Encoding.ASCII))
            {
                while (!reader.EndOfStream)
                {
                    String buffer = reader.ReadLine(); // reads a line from input file
                    for (int i = 0; i < words.Count; i++) // for each word in dictionary
                    {
                        // uses a regular expression: \b(begins and end at word boundary) + dict[i] + \b 
                        Regex reg = new Regex("\\b" + words[i] + "\\b");
                        counts[i] += reg.Matches(buffer).Count; // adds number of matches of the word in a current line
                    }
                }
            }
        }
        catch (IOException ioe)
        {
            Console.WriteLine("Input file IO Exception: " + ioe);
            return;
        }

        // sorts both lists over counts data using Selection Sort on both lists at aeach step
        for (int i = 0; i < words.Count - 1; i++) // iterates through each element
        {
            int min = i; // assumes i-th element has minimal value
            for (int j = i; j < words.Count; j++)
            {
                if (counts[j] <= counts[min]) min = j; // if no - saves current minimal value
            }
            if (min > i) // if swap is needed
            {
                int tempC = counts[i];
                string tempW = words[i];
                counts[i] = counts[min];
                words[i] = words[min];
                counts[min] = tempC;
                words[min] = tempW;
            }
        }

        try
        {
            using (StreamWriter writer = new StreamWriter(resultfile, false, Encoding.ASCII))
            {
                for (int i = 0; i < words.Count; i++)
                {
                    string line = String.Format("{0} - {1}", words[i], counts[i]); // prepares the output line, i.e. a word and its count
                    writer.WriteLine(line); // writes the buffer to output file
                }
            }
        }
        catch (IOException ioe)
        {
            Console.WriteLine("Input file IO Exception: " + ioe);
        }

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}