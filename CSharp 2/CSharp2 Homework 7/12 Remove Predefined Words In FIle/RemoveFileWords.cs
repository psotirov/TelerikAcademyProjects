using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class RemoveWordsOfFileInAnother
{
    static void Main()
    {
        Console.WriteLine("Task 12 - Remove words in a given text file\n\n");

        Console.Write("Please enter the name and path to the text file with words: ");
        string wordsfile = Console.ReadLine();

        List<string> words = new List<string>(); // list of words to remove
        try
        {
            using (StreamReader wReader = new StreamReader(wordsfile, Encoding.ASCII))
            {
                while (!wReader.EndOfStream)
                {
                    string line = wReader.ReadLine();
                    if (line.Length > 0) words.Add(line); // reads a line from words file. it must contain a single word
                }
            }
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Words file - wrong filename!");
            return;
        }
        catch (IOException ioe)
        {
            Console.WriteLine("Words file IO Exception: " + ioe);
            return;
        } 
        
        Console.Write("Please enter the name and path to the text file: ");
        string filename1 = Console.ReadLine();
        string filename2 = filename1 + ".new";

        try
        {
            using (StreamReader reader = new StreamReader(filename1, Encoding.ASCII))
            {
                using (StreamWriter writer = new StreamWriter(filename2, false,Encoding.ASCII))
                {
                    while (!reader.EndOfStream)
                    {
                        String buffer = reader.ReadLine(); // reads a line from input file
                        for (int i = 0; i < words.Count; i++) // for each word in dictionary
                        {
                            // uses a regular expression instead: \b(begins and end at word boundary) + dict[i] + \b 
                            Regex reg = new Regex("\\b" + words[i] + "\\b");
                            buffer = reg.Replace(buffer, ""); // remove all matches
                        }
                        writer.WriteLine(buffer); // writes the buffer to output file
                    }
                }
            }
            File.Replace(filename2, filename1, filename1 + ".bak"); // replaces the initial file with newly created temp file and makes backup
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Input file - wrong filename!");
            return;
        }
        catch (IOException ioe)
        {
            Console.WriteLine("Input file IO Exception: " + ioe);
            return;
        } 

        Console.WriteLine("\n\n{0} was copied to {1} with requested changes", filename1, filename2);

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}