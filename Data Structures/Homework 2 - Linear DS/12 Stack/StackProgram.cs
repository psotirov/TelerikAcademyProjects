using System;

namespace _12_Stack
{
    class StackProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 12 - Implements own Stack structure\n");
            Stack<int> stack = new Stack<int>();
            for (int i = 1; i < 10; i++)
            {
                stack.Push(i);
                Console.WriteLine("Push " + stack.Peek());
            }

            Console.WriteLine("Current stack depth is " + stack.Count);
            while (stack.Count > 0)
            {
                Console.WriteLine("Pop " + stack.Pop());
            }

            Console.WriteLine("\nPress Enter to finish");
            Console.ReadLine();
        }
    }
}
