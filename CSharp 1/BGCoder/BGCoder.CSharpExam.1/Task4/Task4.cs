using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class UKFlag
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int width = N / 2;
        for (int i = 0; i < width; i++)
        {
            string line = new string('.', i) + "\\" + new string('.', width - i - 1) + "|"
                            + new string('.', width - i - 1) + "/" + new string('.', i);
            Console.WriteLine(line);            
        }
        string middle = new string('-', width) + "*" + new string('-', width);
        Console.WriteLine(middle);
        for (int i = width-1; i >= 0; i--)
        {
            string line = new string('.', i) + "/" + new string('.', width - i - 1) + "|"
                            + new string('.', width - i - 1) + "\\" + new string('.', i);
            Console.WriteLine(line);
        }
    }
}

