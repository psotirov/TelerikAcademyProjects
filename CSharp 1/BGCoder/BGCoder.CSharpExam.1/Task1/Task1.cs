using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class TrippleDigits
{
    static void Main()
    {
        string N = Console.ReadLine();
        for (int i = 0; i < 3; i++)
        {
            char last = N[N.Length - 1];
            N = N.Substring(0, N.Length -1);
            if (last != '0')
            {
                N = last + N;
            }            
        }
        Console.WriteLine(N);
    }
}
