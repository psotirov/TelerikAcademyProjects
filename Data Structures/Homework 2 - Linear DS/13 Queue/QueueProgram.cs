using System;

namespace _13_Queue
{
    class QueueProgram
    {
        static LinkedQueue<int> queue1 = new LinkedQueue<int>();
        static LinkedQueue<int> queue2 = new LinkedQueue<int>();

        static void Main(string[] args)
        {
            Console.WriteLine("Task 13 - Implements own LinkedQueue structure");


            for (int i = 1; i < 10; i++)
            {
                queue1.Enqueue(i);
            }

            PrintQueues();

            while (queue1.Count > 0)
            {
                queue2.Enqueue(queue1.Dequeue());
                if (queue2.Count == 4)
                {
                    PrintQueues();
                }
            }

            PrintQueues();
            
            Console.WriteLine("\nPress Enter to finish");
            Console.ReadLine();
        }

        static void PrintQueues()
        {
            Console.WriteLine("\nLinkedQueue1 values = { " + string.Join(", ", queue1) + " }");
            Console.WriteLine("LinkedQueue2 values = { " + string.Join(", ", queue2) + " }"); 
        }
    }
}
