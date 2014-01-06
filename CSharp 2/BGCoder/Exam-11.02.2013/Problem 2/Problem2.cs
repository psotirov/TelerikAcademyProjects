using System;

class Problem2
{
    static int[][] values = null;
    static int maxC = 0;

    static void Main()
    {
        // temporary console input redirection
        //Console.SetIn(new System.IO.StreamReader("test.001.in.txt"));

        int lines = int.Parse(Console.ReadLine());
        values = new int[lines][];
        for (int i = 0; i < lines; i++)
        {
            string[] line = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int c = line.Length;
            if (c > maxC) maxC = c;
            values[i] = new int[c];
            for (int j = 0; j < c; j++)
            {
                values[i][j] = int.Parse(line[j]); 
            }            
        }

        int maxSpecialValue = 0;
        for (int i = 0; i < values[0].Length; i++)
        {
            int specialValue = GetValue(i);
            if (specialValue > maxSpecialValue) maxSpecialValue = specialValue;
        }

        Console.WriteLine(maxSpecialValue);
        //Console.ReadLine();
    }

    static int GetValue(int idx)
    {
        int val = 1;
        int currLine = 0;
        bool[,] isVisited = new bool[values.Length, maxC];

        while (values[currLine][idx] >= 0) // walks through
        {
            if (isVisited[currLine, idx]) return 0;
            isVisited[currLine, idx] = true;
            idx = values[currLine][idx];
            currLine++;
            val++;
            if (currLine == values.Length) currLine = 0;
        }
        val = val - values[currLine][idx];
        return val;
    }
}
