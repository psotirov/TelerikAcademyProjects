using System;

namespace _03_BiDictionary
{
    class TestBidictionary
    {
        static void Main()
        {
            var bidictionary = new BiDictionary<string, int, string>();

            bidictionary.Add("pesho", 1, "JavaScript");
            bidictionary.Add("gosho", 2, "Java");
            bidictionary.Add("nakov", 3, "C# Part 1");
            bidictionary.Add("nakov", 3, "C# Part 2");
            bidictionary.Add("gosho", 3, "Coffee");
            bidictionary.Add("nakov", 1, "Python");

            Console.WriteLine("Key1 {0} : Values {{{1}}}", "nakov", string.Join(", ", bidictionary["nakov"]));
            Console.WriteLine("Key2 {0} : Values {{{1}}}", 3, string.Join(", ", bidictionary[3]));
            Console.WriteLine("Keys {{{0}, {1}}} : Values {{{2}}}", "nakov", 3, string.Join(", ", bidictionary["nakov", 3]));
            Console.WriteLine("Total elements: " + bidictionary.Count);
        }
    }
}
