using System;

class Trapezoid
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        Console.WriteLine(new string('.',N) + new string('*',N));
        for (int i = 1; i < N; i++)
        {
            Console.WriteLine(new string('.', N-i) + "*" + new string('.', N-2+i)+"*");            
        }
        Console.WriteLine(new string('*',2 * N));

    }
}

