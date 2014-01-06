using System;

namespace _01_12_GSM
{
    class Launcher
    {
        static void Main()
        {
            // Sets specific culture - "en-US" looks better than others
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            // Test GSM class
            Console.WriteLine(new GSMTest());

            // Test CallHistory features of GSM class
            GSMCallHistoryTest test = new GSMCallHistoryTest();
            Console.WriteLine(test);
            Console.WriteLine("Total phone bill: {0:C2}\r\n", test.phone.Bill(0.37m));

            Console.WriteLine("Removing the longest call...");
            test.phone.RemoveCall(test.phone.FindLongestCall());
            Console.WriteLine(test);
            Console.WriteLine("Total phone bill: {0:C2}\r\n", test.phone.Bill(0.37m));

            Console.WriteLine("Removing all call history...");
            test.phone.ClearHistory();
            Console.WriteLine(test);
            Console.WriteLine("Total phone bill: {0:C2}\r\n", test.phone.Bill(0.37m));

            // Exits application
            Console.WriteLine("Press any key to finish");
            Console.ReadLine();
        }
    }
}
