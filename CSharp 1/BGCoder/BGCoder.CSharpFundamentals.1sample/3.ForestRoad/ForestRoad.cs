using System;

class ForestRoad
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine()); // reads map width
        int i = 0; // iterator
        int direction = 1; // initially the direction is to the right positive

        while (i >= 0) // Loop until Telerik position has been found
        {
            if (i > 0) Console.Write(new string('.', i)); // leading points
            Console.WriteLine("*"+ new string('.', N-i-1)); // path symbol ("*") and trailing points
            if (i == (N-1)) direction = -1; // if right corner has been reached, reverses the direction
            i += direction;
        }
    }
}

