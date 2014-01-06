using System;
using System.IO;

class FileRemoveOddLines
{
    static void Main()
    {
        Console.WriteLine("Task 09 - Removes all odd lines of a given text file\n\n");

        Console.Write("Please enter the name and path to a text file: ");
        string filename = Console.ReadLine();
        string tempfile = filename + ".new";
        int lineCounter = 1;

        try
        {
            using (StreamWriter writer = new StreamWriter(tempfile))
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (lineCounter++ % 2 == 0) writer.WriteLine(line);
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

