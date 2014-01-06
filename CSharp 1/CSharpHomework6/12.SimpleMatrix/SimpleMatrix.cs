using System;

class SimpleMatrix
{
    static void Main()
    {
        int N = 0;

        Console.BufferWidth = Console.WindowWidth = 100;
        Console.Write("Please enter the dimension of a matrix N: ");
        if (!int.TryParse(Console.ReadLine(), out N) || N < 1 || N > 19) return;

        string separator = "+";
        for (int i = 0; i < N; i++)
            separator = separator + "----+";
            
        Console.WriteLine(separator);
        for (int row = 0; row < N; row++)
        {
            Console.Write("|");
            for (int col = 1; col <= N; col++)
            {
                Console.Write(" {0,2} |", row + col);
            }
            Console.WriteLine("\n" + separator);
        }
    }
}
