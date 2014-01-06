using System;

namespace SimpleServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SimpleServiceReference.SimpleServiceClient();
            Console.WriteLine("Today is {0}", client.GetDayOfWeekInBulgarian(DateTime.Now));
            client.Close();
        }
    }
}
