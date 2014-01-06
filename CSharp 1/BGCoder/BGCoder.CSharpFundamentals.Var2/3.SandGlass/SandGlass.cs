using System;

class SandGlass
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int limit = N;
        int factor = -2;
        string fullLine = new string('*', N); // first (and last) line
        Console.WriteLine(fullLine);
        N -= 2;
        while (N < limit) // when N == limit that is the time for the last line
        {
            string emptySpaces = new string('.', (limit - N)/2); // creates empty spaces '.' in both ends
            Console.WriteLine(emptySpaces + new string('*', N) + emptySpaces); // prints the current line
            if (N < 3) factor = 2; // if single (or double) '*' is reached it is time to change direction - '*''s must grow now on
            N += factor; // calculates next value 
        }
        Console.WriteLine(fullLine); // last line

    }
}

