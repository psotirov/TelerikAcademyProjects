using System;
using System.Globalization;
using System.Threading;

class DayOfWeek
{
    static void Main()
    {
        Console.WriteLine("Task 03 - Inform about current day of week\n\n");

        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        System.Console.WriteLine("Today is {0:d} and the day of the week is {1}",DateTime.Now.Date ,DateTime.Now.DayOfWeek);       
 
        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}
