using System;
using System.IO;

class PutLineNumbers
{
    static void Main()
    {
        Console.WriteLine("Task 03 - Add line numbers at the begining of each line in a given text file\n\n");

        Console.Write("Please enter the name and path to the text file: ");
        string filename1 = Console.ReadLine();
        Console.Write("Please enter the name and path to the output text file: ");
        string filename2 = Console.ReadLine();
        int count  = 0;

        try
        {           
            using ( StreamReader reader = new StreamReader(filename1))
            {                
                using (StreamWriter writer = new StreamWriter(filename2))
                {
                    while (!reader.EndOfStream)
                    {
                        writer.WriteLine("Line {0}: {1}", ++count, reader.ReadLine());
                    }
                }
            }
        }
        catch (SystemException se)
        {
            Console.WriteLine("Exception: " + se);
            return;
        }

        Console.WriteLine("\n\n{0} was copied to {1} with {2} line numbers", filename1, filename2, count);

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}