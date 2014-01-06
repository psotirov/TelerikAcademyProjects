using System;
using System.IO;

class ReadFile
{
    static void Main()
    {
        Console.WriteLine("Task 03 - Read file with given filename and prints to console\n\n");

        Console.Write("Please enter full filename: ");
        string filename = Console.ReadLine();
        try
        {
            Console.WriteLine();
            Console.WriteLine(File.ReadAllText(filename));
        }
        catch (SystemException se)
        {
             Console.WriteLine("Exception: " + se.Message);
        }

 
        Console.WriteLine("\n\nPress Enter to finish");
        Console.ReadLine();
    }
}

