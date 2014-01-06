using System;

class Lines3D
{
    static void Main()
    {
        // temporary console input redirection
        //Console.SetIn(new System.IO.StreamReader("test.000.004.in.txt"));
        
        // reads dimensions of cuboid
        string[] dims = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int dimW = int.Parse(dims[0]);
        int dimH = int.Parse(dims[1]);
        int dimD = int.Parse(dims[2]);

        // creates cuboid array / each cell can contain single character
        char[, ,] cuboid = new char[dimW, dimH, dimD];

        // reads cuboid values
        for (int iH = 0; iH < dimH; iH++)
        {
            string[] line = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            for (int iD = 0; iD < dimD; iD++)
            {
                for (int iW = 0; iW < dimW; iW++)
                {
                    cuboid[iW, iH, iD] = line[iD][iW];
                }
            }
        }
        int maxLineLen = -1; // the length of the longest 3D line initially is one cell long
        int lineCount = 0; // number of lines found in the cuboid with longest length

        int [,] directions = new int[,] { // an aray that defines all searching paths
            // shares common side - movement only in one direction forward (backward is equal)
            {  0,  0,  1 }, //0
            {  0,  1,  0 },
            {  1,  0,  0 },

            // shares common edge - movement in two directions simultaneolsy forward and backward
            {  1,  1,  0 }, //3
            {  1, -1,  0 }, 
            {  1,  0,  1 },
            {  1,  0, -1 },
            {  0,  1,  1 },
            {  0,  1, -1 },

            // shares common edge point - movement in three directions simultaneolsy forward and backward
            {  1,  1,  1 }, //9
            {  1,  1, -1 },
            {  1, -1,  1 },
            { -1,  1,  1 }};

        for (int currW = 0; currW < dimW; currW++) // iterates through all cuboid dimensions 
		{
            for (int currH = 0; currH < dimH; currH++)
            {
                for (int currD = 0; currD < dimD; currD++)
                {
                    for (int currComb = 0; currComb < directions.GetLength(0); currComb++) // iterates through all possible 3D line directions
                    {
                        int currLen = 0; 
                        bool isEqual = false;
                        do
                        {
                            currLen++;
                            isEqual = false;
                            int finalW = currW + currLen * directions[currComb, 0];
                            if (finalW < 0 || finalW >= dimW) break; // out of limits
                            int finalH = currH + currLen * directions[currComb, 1];
                            if (finalH < 0 || finalH >= dimH) break; // out of limits
                            int finalD = currD + currLen * directions[currComb, 2];
                            if (finalD < 0 || finalD >= dimD) break; // out of limits
                            isEqual = (cuboid[currW, currH, currD] == cuboid[finalW, finalH, finalD] );
                        }
                        while (isEqual); // counts line length until a different element has been found or the would leave the cuboid
                        if (currLen > 1 && currLen > maxLineLen) // if we found a better line length
                        {
                            maxLineLen = currLen; // saves it
                            lineCount = 1; // and reset line counter 
                            //Console.WriteLine("{{{0}, {1}, {2} }},{{ {3}, {4}, {5}}}, {6} - '{7}'@{8}", currW, currH, currD, currW + currLen * directions[currComb, 0], currH + currLen * directions[currComb, 1], currD + currLen * directions[currComb, 2], currComb, cuboid[currW, currH, currD], maxLineLen);
                        }
                        else if (currLen == maxLineLen) // if we found one more line with current max lengths
                        {
                            lineCount++; // updates the counter 
                            //Console.WriteLine("{{{0}, {1}, {2} }},{{ {3}, {4}, {5}}}, {6} - '{7}'@{8}", currW, currH, currD, currW + currLen * directions[currComb, 0], currH + currLen * directions[currComb, 1], currD + currLen * directions[currComb, 2], currComb, cuboid[currW, currH, currD], maxLineLen);
                        }
                    }                    
                }
            }
		}

        //outputs the result
        if (maxLineLen > 0) Console.WriteLine("{0} {1}", maxLineLen, lineCount);
        else Console.WriteLine("-1");
    }
}

