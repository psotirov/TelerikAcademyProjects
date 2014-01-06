using System;
using System.Collections.Generic;
using System.IO;

class SortLines
{
    static void Main()
    {
        Console.WriteLine("Task 06 - Sort all lines in a given text file\n\n");

        Console.Write("Please enter the name and path to the text file: ");
        string filename1 = Console.ReadLine();
        Console.Write("Please enter the name and path to the output text file: ");
        string filename2 = Console.ReadLine();
        int count = 0;

        List<string> lines = new List<string>();

        try
        {
            using (StreamReader reader = new StreamReader(filename1))
            {
                while (!reader.EndOfStream)
                {
                   lines.Add(reader.ReadLine());
                } 
            }
        }
        catch (SystemException se)
        {
            Console.WriteLine("Exception: " + se);
            return;
        }

        lines.Sort();

        try
        {
            using (StreamWriter writer = new StreamWriter(filename2))
            {
                foreach (var line in lines)
                {
                    writer.WriteLine(line);  
                }
            }
        }
        catch (SystemException se)
        {
            Console.WriteLine("Exception: " + se);
        }

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}