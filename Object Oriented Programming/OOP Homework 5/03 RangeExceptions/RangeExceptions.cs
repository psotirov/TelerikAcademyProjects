using System;

namespace _03_RangeExceptions
{
    class RangeExceptions
    {
        static void Main()
        {
            Console.WriteLine("Task 03 - Custom Exception Class\r\n");

            int val = 110; // wrong int number
            DateTime future = DateTime.Now.AddYears(1); // wrong date

            try
            {
                if (val < 0 || val > 100) throw new InvalidRangeException<int>();
            }
            catch (InvalidRangeException<int> e)
            {

                Console.WriteLine(e);
            }

            try
            {
                if (future < new DateTime(1980, 1, 1) || future > new DateTime(2013, 12, 31))
                    throw new InvalidRangeException<DateTime>("Cannot accept date after 31.12.2013");
            }
            catch (InvalidRangeException<DateTime> e)
            {

                Console.WriteLine(e);
            }

            Console.WriteLine("\r\nPress Enter to finish");
            Console.ReadLine();
        }
    }
}
