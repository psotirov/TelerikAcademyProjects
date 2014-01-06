using System;

class FirTree
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        string firstLine = new string('.', N - 2) + "*" + new string('.', N - 2);
        Console.WriteLine(firstLine);
        for (int i = 1; i < N-1; i++)
        {
            Console.WriteLine(new string('.', N - i - 2) + new string('*', 2 * i + 1) + new string('.', N - i - 2));
        }
        Console.WriteLine(firstLine);
    }
}
