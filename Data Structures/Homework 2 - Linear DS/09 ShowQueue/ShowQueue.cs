using System;
using System.Collections.Generic;
using System.Text;

class ShowQueue
{
    static void Main()
    {
        const int MembersCount = 50;
        Console.WriteLine("Task 9 - Shows first {0} members of a queue\n", MembersCount);

        Console.Write("First element N = ");
        int firstMember = int.Parse(Console.ReadLine());
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(firstMember);
        int count = 0;
        StringBuilder output = new StringBuilder("The result queue = { ");
        while (count < MembersCount)
        {
            int member = queue.Dequeue();
            if (count > 0)
            {
                output.Append(", ");
            }

            output.Append(member);
            count++;
            queue.Enqueue(member + 1);
            queue.Enqueue(member * 2 + 1);
            queue.Enqueue(member + 2);
        }

        output.AppendLine(" }");
        Console.WriteLine(output);

        Console.WriteLine("Press Enter to finish");
        Console.ReadLine();
    }
}
