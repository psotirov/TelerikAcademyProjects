using System;

namespace _02_Duplicated_Combinations
{
    class Combinatorics
    {
        static void Main()
        {
            Console.WriteLine("Combinations, Permutations\n");
            Console.Write("Please enter elements length (depth) K: ");
            int depth = 0;
            if (int.TryParse(Console.ReadLine(), out depth) && depth > 0)
            {
                Console.Write("Please enter elements number N: ");
                int count = 0;
                if (int.TryParse(Console.ReadLine(), out count) && count >= depth)
                {
                    Console.WriteLine("\nTask 2. Combinations with repetitions:\n");
                    string output = "";
                    CombinationsWithRepetition(output, 0, 0, depth, count);
                    Console.WriteLine("\n\nTask 3. Combinations:\n");
                    output = "";
                    Combinations(output, 0, 0, depth, count);
                    Console.WriteLine("\n\nTask 4. Permutations:\n");
                    output = "";
                    Permutations(output, 0, count);
                }
            }
        }

        static void CombinationsWithRepetition(string output, int currentDepth, int start, int maxDepthK, int countN)
        {
            if (currentDepth == maxDepthK)
            {
                Console.WriteLine(output);
                return;
            }

            for (int i = start; i < countN; i++)
            {
                CombinationsWithRepetition(output + " " + (i+1), currentDepth + 1, i, maxDepthK, countN);
            }
        }

        static void Combinations(string output, int currentDepth, int start, int maxDepthK, int countN)
        {
            if (currentDepth == maxDepthK)
            {
                Console.WriteLine(output);
                return;
            }

            for (int i = start; i < countN; i++)
            {
                Combinations(output + " " + (i + 1), currentDepth + 1, i+1, maxDepthK, countN);
            }
        }

        static void Permutations(string output, int index, int countN)
        {
            if (index == countN)
            {
                Console.WriteLine(output);
                return;
            }

            for (int i = 0; i < countN; i++)
            {
                if (output.IndexOf(i.ToString()) == -1) 
                {
                    Permutations(output + " " + i, index + 1, countN);                    
                }
            }
        }
    }
}
