using System;

class Read10Numbers
{
    static void Main()
    {
        Console.WriteLine("Task 02 - Reads 10 numbers from Console in range [2, 99]\n\n");

        int[] a = new int[10];
        int start = 1;
        
        try
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("Please enter {0}-th number: ", i+1);
                a[i] = ReadNumber(start, 100);
                start = a[i];
            }

            foreach (var num in a)
            {
                Console.Write("{0} ", num);
            }
        }
        catch (SystemException se)
        {
            Console.WriteLine("Invalid Number");
            Console.WriteLine("Exception: " + se.Message);
        }

        Console.WriteLine("\n\nPress Enter to finish");
        Console.ReadLine();
    }

    static int ReadNumber(int start, int end)
    {
        int result = int.Parse(Console.ReadLine());
        if (result <= start || result >= end) throw new ArgumentOutOfRangeException();
        return result;
    }
}
