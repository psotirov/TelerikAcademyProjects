using System;
using System.Text;

namespace _10_Shortest_reach
{
    static class ShortestReach
    {
        static private readonly CustomLinkedList<int> list = new CustomLinkedList<int>();

        static void Main()
        {
            Console.Write("Start number N: ");
            int start = int.Parse(Console.ReadLine());

            Console.Write("End number M: ");
            int end = int.Parse(Console.ReadLine());

            if (start <= 0 || end < start)
            {
                throw new ArgumentOutOfRangeException("start N should be positive and less than end M");
            }

            list.Add(start);
            int current = list.Count-1;

            while (current < list.Count)
            {
                if (list[current] == end) // solution has been found
                {
                    Console.WriteLine(Environment.NewLine + "Total objects created: " + list.Count);
                    Console.WriteLine(Environment.NewLine + "Solution: " + ShowResult(current));

                    Console.WriteLine("Press Enter to finish");
                    Console.ReadLine();
                    return;
                }

                // for each new member checks if it is within range and it not exists already
                if (list[current] + 1 <= end && !list.Contains(list[current] + 1))
                {
                    list.Add(list[current] + 1, current);
                }

                if (list[current] + 2 <= end && !list.Contains(list[current] + 2))
                {
                    list.Add(list[current] + 2, current);
                }

                if (list[current] * 2 <= end && !list.Contains(list[current] * 2))
                {
                    list.Add(list[current] * 2, current);
                }

                current++;
            }

            // this should not be reached as there is always a solution
            throw new ApplicationException("No solution");
        }

        /// <summary>
        /// Returns the list of all values of the soluton from start to end
        /// Actually it reveses the saved order from last to first using parents
        /// </summary>
        /// <param name="last">Last value</param>
        /// <returns>string of solution path (for example "1 -> 5 -> 7 -> 8 -> 16")</returns>
        static string ShowResult(int last)
        {
            StringBuilder output = new StringBuilder(list[last].ToString());
            while (list.GetParent(last) >= 0)
            {
                last = list.GetParent(last);
                output.Insert(0, list[last] + " -> ");
            }

            return output.ToString();
        }
    }
}

