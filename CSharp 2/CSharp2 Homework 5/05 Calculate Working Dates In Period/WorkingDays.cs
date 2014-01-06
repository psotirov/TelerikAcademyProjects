using System;
using System.Globalization;
using System.Threading;

class WorkingDays
{
    static string[] offHolidays = new string[]
    { "01/01/2013",
      "05/01/2013", "05/02/2013", "05/03/2013", "05/06/2013", "05/24/2013",
      "09/06/2013",
      "11/01/2013",
      "12/24/2013", "12/25/2013", "12/26/2013", "12/30/2013", "12/31/2013"
    };

    static void Main()
    {
        Console.WriteLine("Task 05 - Calculate working days in a period\n\n");

        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture; // sets invariant culture
        DateTime current = new DateTime();
        current = DateTime.Now;
        DateTime future = new DateTime();
        Console.WriteLine("Please enter a future date (MM/DD/YYYY): ");
        if (!DateTime.TryParse(Console.ReadLine(), out future) || future <= current)
        {
            Console.WriteLine("Wrong date format");
            return;
        }

        int days = future.Subtract(current).Days; // calculates total number of days, contained into the period
        days -= (days / 7) * 2; // for each full week in the period we have exactly 2 holidays per week

        for (int i = 0; i < days % 7; i++) // iterates through the days exceeding exact number of weeks 
        {
            DayOfWeek d = future.AddDays(-i).DayOfWeek; // decreases temporary the days in the future date
            if (d == DayOfWeek.Sunday || d == DayOfWeek.Saturday) days--; // makes correction for each holiday of them 
        }

 
        // Checks if some members of the list of official holidays falls inside the period
        foreach (string dts in offHolidays)
        {
            DateTime hol = DateTime.Parse(dts);
            if (hol > current && hol <= future) days--; // takes into account about official holidays in the period
        }

        System.Console.WriteLine("The number of working days between {0:d} and {1:d} is {2}", current, future, days);

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }


}
