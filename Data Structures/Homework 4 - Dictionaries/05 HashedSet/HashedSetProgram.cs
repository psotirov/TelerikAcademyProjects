using System;

namespace _05_HashedSet
{
    class HashedSetProgram
    {
        static void Main()
        {
            HashedSet<string> set = new HashedSet<string>();

            set.Add("Pesho");
            set.Add("Gosho");
            set.Add("Tisho", true);
            set.Add("ToRemove");
            set.Add("Petko");
            set.Remove("ToRemove");

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Total count = " + set.Count);
        }
    }
}
