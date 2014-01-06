using System;

class LeapYear
{
    static void Main()
    {
        Console.WriteLine("Task 02 - Generate 10 random values in the range [100,200]\n\n");

        Random gen = new Random();

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("{0,2} - {1}", i+1, gen.Next(100,201));
        }
 
        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}

