using System;
using System.IO;
using System.Text;

class FileRemoveTags
{
    static void Main()
    {
        Console.WriteLine("Task 10 - Removes all XML tags from a given text file\n\n");

        Console.Write("Please enter the name and path to a text file: ");
        string filename = Console.ReadLine();
        string tempfile = filename + ".new";

        try
        {
            using (StreamWriter writer = new StreamWriter(tempfile))
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    while (!reader.EndOfStream)
                    {
                        string inputLine = reader.ReadLine();
                        StringBuilder outputLine = new StringBuilder();
                        bool inTag = false;
                        for (int i = 0; i < inputLine.Length; i++)
                        {
                            if (inputLine[i] == '<') inTag = true;
                            else if (inputLine[i] == '>') inTag = false;
                            else if (!inTag) outputLine.Append(inputLine[i]);
                        }
                        writer.WriteLine(outputLine);
                    }
                }
            }

            File.Replace(tempfile, filename, filename + ".bak"); // replaces the initial file with newly created temp file and makes backup
        }
        catch (SystemException se)
        {
            Console.WriteLine("Exception: " + se);
        }

        Console.WriteLine("Press Enter to finish");
        Console.ReadLine();
    }
}

