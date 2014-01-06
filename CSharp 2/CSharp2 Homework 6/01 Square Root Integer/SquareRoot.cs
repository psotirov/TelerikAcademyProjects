using System;

class SquareRoot
{
    static void Main()
    {
        Console.WriteLine("Task 01 - Calculate square root of an integer\n\n");

        Console.Write("Please enter number: ");
        try
        {
            int value = int.Parse(Console.ReadLine());
            if (value < 0) throw new ArgumentOutOfRangeException();
            double result = Math.Sqrt(value);
            Console.WriteLine("The square root is " + result);
        }
        catch (SystemException se)
        {
            Console.WriteLine("Invalid Number");
            Console.WriteLine("Exception: " + se.Message);
        }
        finally
        {
            Console.WriteLine("Good bye.");
            Console.WriteLine("\nPress Enter to finish");
            Console.ReadLine();
        }


    }
}

