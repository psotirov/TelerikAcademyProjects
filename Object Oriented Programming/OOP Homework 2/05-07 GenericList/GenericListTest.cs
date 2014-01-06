using System;

namespace _05_07_GenericList
{
    class GenericListTest
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GenericList Task\r\n");

            GenericList<string> list = new GenericList<string>("first", "second", "third", "fourth", "fifth", "sixth", "seventh", "eight");
            Console.WriteLine(list);

            list[3] = "fourth changed";
            list.Add("nineth");
            list.Insert(0, "zero");
            list.Remove(5);
            Console.WriteLine("Modified list(indexed access, add, insert, remove):\r\n" + list);

            int found = list.Find("second");
            Console.WriteLine("Search for 'second': index={0}, element={1}", found, list[found]);
            found = list.Find("bla");
            Console.WriteLine("Search for 'bla': index={0}", found);

            Console.WriteLine("Min element: " + list.Min());
            Console.WriteLine("Max element: " + list.Max());

            list.Clear();
            Console.WriteLine("Clearing list: " + list);

            Console.WriteLine("\r\nPress Enter to finish");
            Console.ReadLine();
        }
    }
}
