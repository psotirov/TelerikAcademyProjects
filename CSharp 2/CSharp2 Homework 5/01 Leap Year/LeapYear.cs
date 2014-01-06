using System;

class LeapYear
{
    static void Main()
    {
        Console.WriteLine("Task 01 - Check for a leap year\n\n");

        Console.Write("Please enter a year [YYYY]: ");
        int year = 0;
        if (!int.TryParse(Console.ReadLine(), out year) || year < 1 || year > 9999)
        {
            Console.WriteLine("Invalid year");
            return;
        }
        if (DateTime.DaysInMonth(year, 2) == 29) Console.WriteLine("The year {0} is leap!", year);
        else Console.WriteLine("The year {0} is standard", year);

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}

