using System;

class PrintNNumbers
{
    static void Main()
    {
        int N = 0;
        string input = Console.ReadLine();
        if (!int.TryParse(input, out N) || N <= 0) return;

        for (int i = 0; i < N; i++)
        {
            Console.WriteLine(i+1);
        }
    }
}
