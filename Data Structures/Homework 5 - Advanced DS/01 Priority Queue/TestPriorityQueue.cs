using System;

namespace _01_Priority_Queue
{
    public class TestPriorityQueue
    {
        public static void Main()
        {
            int[] items = new[] { 7, -5, 12, 34, 9, 88, 145, 2, 11, 256, 0};
            PriorityQueue<int> queue = new PriorityQueue<int>();

            foreach (var item in items)
            {
                queue.Enqueue(item);
            }

            Console.WriteLine("Initial array: " + string.Join(" ", items));
            Console.WriteLine("\nPriority Queue: " + string.Join(" ", queue) + "\n");

            while (queue.Count > 0)
            {
                Console.WriteLine("Dequeued Item: " + queue.Dequeue() + ", Queue: " + string.Join(" ", queue));
            }
        }
    }
}