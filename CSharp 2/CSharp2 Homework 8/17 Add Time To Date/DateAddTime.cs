using System;
using System.Globalization;

class DateAddTime
{
    static void Main()
    {
        Console.WriteLine("Task 17 - Adds 6 hour and 30 minutes to a given date/time\n\n");

        DateTime date = new DateTime();
        Console.Write("Please enter date/time (DD.MM.YYYY HH:MM:SS): ");
        // Parses date with custom format (day and month could be one or two digits, separator is '.'
        if (!DateTime.TryParseExact(Console.ReadLine().Trim(), "d.M.yyyy H:m:s", new CultureInfo("bg-BG"), DateTimeStyles.None, out date))
        {
            Console.WriteLine("Wrong date format!");
            return;
        }

        date=date.AddHours(6.5); // adds 6 and a half hours to the date entered


        Console.WriteLine("\nThe result is: " + date.ToString("dddd, dd.MM.yyyy HH:mm:ss", new CultureInfo("bg-BG")));
        // shows the date/time in the required format

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}