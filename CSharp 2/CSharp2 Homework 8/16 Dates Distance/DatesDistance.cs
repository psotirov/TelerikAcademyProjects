using System;
using System.Globalization;

class DatesDistance
{
    static void Main()
    {
        Console.WriteLine("Task 16 - Calculate distance in days between two given dates\n\n");

        DateTime date1 = new DateTime(); 
        Console.Write("Please enter first date (DD.MM.YYYY): ");
        // Parses date with custom format (day and month could be one or two digits, separator is '.'
        if (!DateTime.TryParseExact(Console.ReadLine().Trim(), "d.M.yyyy", new CultureInfo("bg-BG"), DateTimeStyles.None, out date1))
        {
            Console.WriteLine("Wrong date format!");
            return;
        }

        DateTime date2 = new DateTime();
        Console.Write("Please enter second date (DD.MM.YYYY): ");
        if (!DateTime.TryParseExact(Console.ReadLine().Trim(), "d.M.yyyy", new CultureInfo("bg-BG"), DateTimeStyles.None, out date2)
             || date2 < date1)
        {
            Console.WriteLine("Wrong date format!");
            return;
        }

        TimeSpan diff = date2 - date1; // the difference is calculated as TimeSpan Object
        Console.WriteLine("\nDistance: {0} days ", diff.Days); // shows only the number of whole days

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}