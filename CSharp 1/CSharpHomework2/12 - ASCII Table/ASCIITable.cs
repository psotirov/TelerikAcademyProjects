using System;

class ASCIITable
{
    static void Main()
    {
        for (int i = 0; i < 256; i++)
        {
            char ASCIIsymbol = ((i<32) || (i==255))?'.':(char)i;
            Console.Write("{0:D3} {0:X2} \'{1}\'     ", i, ASCIIsymbol);
            if (i % 4 == 3) Console.WriteLine(); 
        }
        Console.WriteLine(); 
    }
}

