using System;

namespace _04_HashTable
{
    class HashTableProgram
    {
        static void Main(string[] args)
        {
            HashTable<string, int> table = new HashTable<string, int>();

            table.Add("Pesho", 35);
            table["Somebody"] = 555;
            table.Add("Gosho", -8);
            table.Add("Tisho", 128);
            table.Add("ToRemove", 128);
            table.Add("Petko", 3);
            table.Remove("ToRemove");
            table["Somebody"] = 444;

            foreach (var item in table)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Total count = " + table.Count);
        }
    }
}
