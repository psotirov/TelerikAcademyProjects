using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Quadronacci
{
    static void Main()
    {
        long[] Q = new long[400];
        for (int i = 0; i < 4; i++)
        {
            Q[i] = long.Parse(Console.ReadLine());
        }
        int R = int.Parse(Console.ReadLine());
        int C = int.Parse(Console.ReadLine());

        int total = R * C; 
        for (int i = 4; i < total; i++)
        {
            Q[i] = Q[i - 1] + Q[i - 2] + Q[i - 3] + Q[i - 4];
        }

        for (int i = 0; i < R; i++)
        {
            for (int j = 0; j < C; j++)
            {
                Console.Write(Q[i*C+j]);
                if (C - j > 1) Console.Write(" ");
                else Console.WriteLine();
            }        
        }
    }
}
