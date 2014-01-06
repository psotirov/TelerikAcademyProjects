using System;
using System.IO;

class FileOddLines
{
    static void Main()
    {
        Console.WriteLine("Task 01 - Print to Console all odd lines of a given text file\n\n");

        Console.Write("Please enter the name and path to a text file: ");
        string filename = Console.ReadLine();
        int lineCounter = 1;

        try
        {            
            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (lineCounter++ % 2 != 0) Console.WriteLine(line);
                }
            }
        }
        catch (SystemException se)
        {
            Console.WriteLine("Exception: "+ se);
        }

        Console.WriteLine("Press Enter to finish");
        Console.ReadLine();
    }
}

