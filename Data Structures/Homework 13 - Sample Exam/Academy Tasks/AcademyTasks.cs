using System;
using System.Collections.Generic;

namespace Academy_Tasks
{
    /// <summary>
    /// BG Coder 100/100 - after implementing BottomUp solution
    /// Recursive solution has reached 45/100
    /// Queue modificaton has reached 65/100
    /// </summary>
    class AcademyTasks
    {
        static int[] pleasantness;
        static int variety;
        static int minProblems;

        static void Main()
        {
            string[] inputLine = Console.ReadLine().Split(new char[] { ',',' ' }, StringSplitOptions.RemoveEmptyEntries);
            pleasantness = new int[inputLine.Length];
            for (int i = 0; i < inputLine.Length; i++)
			{
		        pleasantness[i] = int.Parse(inputLine[i]);
	        }

            variety = int.Parse(Console.ReadLine());
            minProblems = pleasantness.Length;

            SolveBottomUp();
            // SolveInQueue();
            // SolveRecursive(0, 0, pleasantness[0], pleasantness[0]);
            Console.WriteLine(minProblems);
        }

        static void SolveBottomUp()
        {
            // 1. Find the first possible pair of tasks that has required variety ( first in 0..length-2, second in first+1..length-1)
            // 2. Find the fastest way to reach first task in the selected pair
            // 3. Find the fastest way to reach second task in the selected pair
            // obviously for p.2 and p.3 - fastest way is (Greedy) n*2 steps + k (k = 0 or 1)

            for (int firstIndex = 0; firstIndex < pleasantness.Length - 1; firstIndex++)
            {
                for (int secondIndex = firstIndex + 1; secondIndex < pleasantness.Length; secondIndex++)
                {
                    int pairVariety = Math.Abs(pleasantness[firstIndex] - pleasantness[secondIndex]);
                    if (pairVariety >= variety) // found solution
                    {
                        int pathToFirst = firstIndex / 2 + firstIndex % 2 + 1; // including index 0 as 1 problem solved
                        int pathFirstToSecond = (secondIndex - firstIndex) / 2 + (secondIndex - firstIndex) % 2;
                        int totalPath = pathToFirst + pathFirstToSecond;
                        if (totalPath < minProblems)
                        {
                            minProblems = totalPath;
                            // after that going further since a better solution could be found
                            // for example larger path to first but smaller path first to second
                        }
                    }
                }
            }
        }

        //static void SolveInQueue()
        //{
        //    Queue<Problem> queue = new Queue<Problem>();
        //    queue.Enqueue(new Problem(0, 0, pleasantness[0], pleasantness[0]));

        //    while (queue.Count > 0)
        //    {
        //        Problem current = queue.Dequeue();
        //        current.solvedProblems++;

        //        if (current.minPleasantness > pleasantness[current.currentIndex])
        //        {
        //            current.minPleasantness = pleasantness[current.currentIndex];
        //        }

        //        if (current.maxPleasantness < pleasantness[current.currentIndex])
        //        {
        //            current.maxPleasantness = pleasantness[current.currentIndex];
        //        }

        //        if (current.maxPleasantness - current.minPleasantness >= variety)
        //        {
        //            if (minProblems > current.solvedProblems)
        //            {
        //                minProblems = current.solvedProblems;
        //            }

        //            return;
        //        }

        //        current.currentIndex++;
        //        queue.Enqueue(current);
        //        current.currentIndex++;
        //        queue.Enqueue(current);
        //    }
        //}

        //static void SolveRecursive(int currentIndex, int solvedProblems, int minPleasantness, int maxPleasantness)
        //{
        //    if (currentIndex >= pleasantness.Length)
        //    {
        //        return;
        //    }

        //    solvedProblems++;

        //    if (minPleasantness > pleasantness[currentIndex])
        //    {
        //        minPleasantness = pleasantness[currentIndex];
        //    }

        //    if (maxPleasantness < pleasantness[currentIndex])
        //    {
        //        maxPleasantness = pleasantness[currentIndex];
        //    }

        //    if (maxPleasantness-minPleasantness >= variety)
        //    {
        //        if (minProblems > solvedProblems)
        //        {
        //            minProblems = solvedProblems;
        //        }

        //        return;
        //    }

        //    SolveRecursive(currentIndex + 1, solvedProblems, minPleasantness, maxPleasantness);
        //    SolveRecursive(currentIndex + 2, solvedProblems, minPleasantness, maxPleasantness);
        //}
    }
}
