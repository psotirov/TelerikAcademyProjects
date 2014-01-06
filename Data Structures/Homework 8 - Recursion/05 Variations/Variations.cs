using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Variations
{
    class Variations
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Variations, Subsets of elements\n");
            Console.Write("Please enter elements, separated by spaces: ");
            string[] elements = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            // string[] elements = new string[] {"hi", "a", "b"};
            if (elements.Length > 1)
            {
                Console.Write("Please enter depth of variations K: ");
                int depth = 0;
                if (int.TryParse(Console.ReadLine(), out depth) && depth <= elements.Length)
                {
                    Console.WriteLine("\n\nTask5. Variations:\n");
                    string output = "";
                    Variation(output, 0, depth, elements);

                    Console.WriteLine("\n\nTask6. Subsets ot K elements:\n");
                    output = "";
                    Subsets(output, 0, 0, depth, elements);
                }
            }
        }

        static void Variation(string output, int index, int depth, string[] elements)
        {
            if (index == depth)
            {
                Console.WriteLine(output);
                return;
            }

            for (int i = 1; i <= elements.Length; i++)
            {
                Variation(output + " " + elements[i-1], index + 1, depth, elements);
            }
        }


        static void Subsets(string output, int index, int start, int depth, string[] elements)
        {
            if (index == depth)
            {
                Console.WriteLine(output);
                return;
            }

            for (int i = start; i < elements.Length; i++)
            {
                Subsets(output + " " + elements[i], index + 1, i+1, depth, elements);
            }
        }
    }
}
