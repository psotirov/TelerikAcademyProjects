using System;

class NestedLoops
{
    static void Main()
    {
        Console.WriteLine("N Nested Loop using recursion\n");
        Console.Write("PLease enter loops depth N: ");
        int depth = 0;
        if (int.TryParse(Console.ReadLine(), out depth) && depth > 0)
        {
            string output = "";
            NestedLoop(output, depth, depth);
        }
    }

    static void NestedLoop(string output, int index, int depth)
    {
        if (index == 0)
        {
            Console.WriteLine(output);
            return;
        }

        for (int i = 1; i <= depth; i++)
        {
            NestedLoop(output + " " + i, index - 1, depth);
        }
    }
}
