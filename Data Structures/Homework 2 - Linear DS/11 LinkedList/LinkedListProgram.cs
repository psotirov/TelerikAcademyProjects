using System;

namespace _11_LinkedList
{
    class LinkedListProgram
    {
        static void Main()
        {
            Console.WriteLine("Task 11 - Implements own LinkedList structure\n");
            LinkedList<int> list = new LinkedList<int>();

            for (int i = 1; i < 10; i++)
            {
                list.Add(i);
                list.InsertAtStart(i);
            }

            Console.WriteLine("LinkedList Count = " + list.Count);
            Console.WriteLine("LinkedList values = { " + string.Join(", ", list) + " }");

            Console.WriteLine("\nPress Enter to finish");
            Console.ReadLine();
        }
    }
}
