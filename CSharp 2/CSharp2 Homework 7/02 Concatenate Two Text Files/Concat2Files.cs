using System;
using System.IO;

class ConcatenateTwoFiles
{
    static void Main()
    {
        Console.WriteLine("Task 02 - Concatenates two given text files into third one\n\n");

        Console.Write("Please enter the name and path to First text file: ");
        string filename1 = Console.ReadLine();
        Console.Write("Please enter the name and path to Second text file: ");
        string filename2 = Console.ReadLine();
        Console.Write("Please enter the name and path to Final text file: ");
        string filename3 = Console.ReadLine();
        
        try
        {            
            using (StreamWriter writer = new StreamWriter(filename3))
            {
                using (StreamReader reader = new StreamReader(filename1))
                {
                    while (!reader.EndOfStream)
                    {
                        writer.WriteLine(reader.ReadLine());
                    }
                }

                using (StreamReader reader = new StreamReader(filename2))
                {
                    while (!reader.EndOfStream)
                    {
                        writer.WriteLine(reader.ReadLine());
                    }
                }
            }
        }
        catch (SystemException se)
        {
            Console.WriteLine("Exception: " + se);
            return;
        }

        Console.WriteLine("{0} and {1} were copied to {2}", filename1, filename2, filename3);

        Console.WriteLine("Press Enter to finish");
        Console.ReadLine();
    }
}