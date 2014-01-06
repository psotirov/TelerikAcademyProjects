using System;

class GetMaxInteger
{
    static void Main()
    {
        Console.WriteLine("Task 02 - Selects maximal of three integers using GetMax() method\n\n");

        int[] ints = new int[3];
        for (int i = 0; i < 3; i++)
        {
            Console.Write("Please enter Integer[{0}] = ", i);
            if (!int.TryParse(Console.ReadLine(), out ints[i])) // wrong integer
            {
                Console.WriteLine("Not valid integer");
                i--;
            }
        }

        Console.WriteLine("The biggest integer is {0}", GetMax(GetMax(ints[0], ints[1]), ints[2]));
        // in inner GetMax selects the bigger integer from indices 0 and 1, and after compares the result fith index 3

        Console.WriteLine("\nPlease hit Enter to finish");
        Console.ReadLine();
    }

    static int GetMax(int first, int second)
    {
        return ((first > second)?first:second); // compares two integers and returns the bigger one 
    }
}
