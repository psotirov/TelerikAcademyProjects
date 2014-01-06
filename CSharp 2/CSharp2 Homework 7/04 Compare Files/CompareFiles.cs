using System;
using System.IO;

class Comparefiles
{
    static void Main()
    {
        Console.WriteLine("Task 04 - Compare two text files\n\n");

        Console.Write("Please enter the name and path to the First text file: ");
        string filename1 = Console.ReadLine();
        Console.Write("Please enter the name and path to the Second text file: ");
        string filename2 = Console.ReadLine();
        int count = 0;
        int equal = 0;

        try
        {
            using (StreamReader reader1 = new StreamReader(filename1))
            {
                using (StreamReader reader2 = new StreamReader(filename2))
                {
                    while (!reader1.EndOfStream)
                    {
                        string str1 = reader1.ReadLine();
                        string str2 = null;
                        if (!reader2.EndOfStream) str2 = reader2.ReadLine();
                        count++;
                        if (str1 == str2) equal++;
                    }
                }
            }
        }
        catch (SystemException se)
        {
            Console.WriteLine("Exception: " + se);
            return;
        }

        Console.WriteLine("\n\nComparison of {0} with {1} has result:", filename1, filename2);
        Console.WriteLine("   {0} lines total", count);
        Console.WriteLine("   {0} lines of text are equal", equal);
        Console.WriteLine("   {0} lines of text are not equal", count - equal);

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}