using System;

class PrintNumberSequence
{
    static void Main()
    {
        for (int i=1; i<11; i++)
        {
            if (i > 1) Console.Write(", ");
            Console.Write("{0}", (i%2>0)?i+1:-i-1);
        }
        Console.WriteLine();
    }
}
