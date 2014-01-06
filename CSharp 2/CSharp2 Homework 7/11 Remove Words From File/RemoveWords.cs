using System;
using System.IO;
using System.Text.RegularExpressions;

class RemoveWords
{
    static void Main()
    {
        Console.WriteLine("Task 11 - Remove words in a given text file\n\n");
        string[] dict = new string[] {"test"}; // remove substrings dictionary

        Console.Write("Please enter the name and path to the text file: ");
        string filename1 = Console.ReadLine();
        string filename2 = filename1 + ".new";

        try
        {
            using (StreamReader reader = new StreamReader(filename1))
            {
                using (StreamWriter writer = new StreamWriter(filename2))
                {
                    while (!reader.EndOfStream)
                    {
                        string buffer = reader.ReadLine(); // reads a line from input file
                        for (int i = 0; i < dict.Length; i++) // for each word in dictionary
                        {
                            // uses a regular expression instead: \b(begins and end at word boundary) + dict[i] + \w*(zero or more characters) + \b 
                            Regex reg = new Regex("\\b" + dict[i] + "\\w*\\b");
                            buffer = reg.Replace(buffer, ""); // remove all matches
                         }
                        writer.WriteLine(buffer); // writes the buffer to output file
                    }
                }
            }
            File.Replace(filename2, filename1, filename1 + ".bak"); // replaces the initial file with newly created temp file and makes backup
        }
        catch (SystemException se)
        {
            Console.WriteLine("Exception: " + se);
            return;
        }

        Console.WriteLine("\n\n{0} was copied to {1} with requested changes", filename1, filename2);

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}