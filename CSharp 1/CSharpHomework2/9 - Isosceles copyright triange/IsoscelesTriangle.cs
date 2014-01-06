using System;

class IsoscelesTriangle
{
    static void Main()
    {
        char sign ='\u00A9';
        int lines = 3;
        for (int i = 0; i < lines; i++)
        {
            string line = new String(sign, i*2 + 1).PadLeft(lines+i+1);
            Console.WriteLine(line);
        }
    }
}
