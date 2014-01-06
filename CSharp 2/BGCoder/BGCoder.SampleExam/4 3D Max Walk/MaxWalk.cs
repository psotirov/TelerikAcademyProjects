using System;

class MaxWalk
{
    static void Main()
    {
        // reads dimensions of cuboid
        string[] dims = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int dimW = int.Parse(dims[0]);
        int dimH = int.Parse(dims[1]);
        int dimD = int.Parse(dims[2]);

        // creates cuboid array / each cell can contain cuboid[W,H,D] e [-1000, 1000]
        // but also e [-11000, 11000], and when -10000 < cell OR cell > 10000 then the cell has been visited
        int[,,] cuboid = new int[dimW, dimH, dimD];

        // reads cuboid values
        for (int iH = 0; iH < dimH; iH++)
        {
            string[] line = Console.ReadLine().Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
            for (int iD = 0; iD < dimD; iD++)
            {
                for (int iW = 0; iW < dimW; iW++)
                {
                    cuboid[iW, iH, iD] = int.Parse(line[iD*dimW+iW]);
                }
            }
        }

        int currW = dimW / 2; // the coordinates of current cell in 3D Max Walk
        int currH = dimH / 2; // initially is the center point of the cuboid
        int currD = dimD / 2;

        bool hasMaxMany = false; // indicates if there is many equal max values
        bool isMaxVisited = false; // indicates if current max cell is already visited

        int sumMaxWalk = cuboid[currW, currH, currD]; // the sum of the moves, initially only the value of center cell
        cuboid[currW, currH, currD] += (cuboid[currW, currH, currD] < 0)?-10000:10000; // mark center cell as visited

        // then makes 3D max walk
        while (!hasMaxMany && !isMaxVisited) 
        {
            int maxVal = -12000; // initially the max value is out of range (the minimal value)
            int maxW = currW; // the coordinates of max cell relative to current position
            int maxH = currH; // initially is the current point of the cuboid
            int maxD = currD;
             
            // finds max cell in width direction (to left and to right)
            for (int iW = 0; iW < dimW; iW++)
            {
                if (iW == currW) continue; // the current cell is out the scope
                if (cuboid[iW, currH, currD] % 10000 > maxVal)
                {
                    maxW = iW; // sets the coordinate of current cell as max value postion
                    maxH = currH; // initially is the current point of the cuboid
                    maxD = currD;
                    maxVal = cuboid[iW, currH, currD] % 10000; // takes the value oof th cell (but not visited "flag")
                    isMaxVisited = (cuboid[iW, currH, currD] / 10000 != 0);  // checks if curr positon has been visited
                    hasMaxMany = false; // until now only one max vaue has been found
                }
                else if (cuboid[iW, currH, currD] % 10000 == maxVal) hasMaxMany = true; // one more max value has been found
            }

            // finds max cell in height direction (up and down)
            for (int iH = 0; iH < dimH; iH++)
            {
                if (iH == currH) continue; // the current cell is out the scope
                if (cuboid[currW, iH, currD] % 10000 > maxVal)
                {
                    maxW = currW; // sets the coordinate of current cell as max value postion
                    maxH = iH; // initially is the current point of the cuboid
                    maxD = currD;
                    maxVal = cuboid[currW, iH, currD] % 10000; // takes the value oof th cell (but not visited "flag")
                    isMaxVisited = (cuboid[currW, iH, currD] / 10000 != 0);  // checks if curr positon has been visited
                    hasMaxMany = false; // until now only one max vaue has been found
                }
                else if (cuboid[currW, iH, currD] % 10000 == maxVal) hasMaxMany = true; // one more max value has been found
            }

            // finds max cell in depth direction (deeper and shallower)
            for (int iD = 0; iD < dimD; iD++)
            {
                if (iD == currD) continue; // the current cell is out the scope
                if (cuboid[currW, currH, iD] % 10000 > maxVal)
                {
                    maxW = currW; // sets the coordinate of current cell as max value postion
                    maxH = currH; // initially is the current point of the cuboid
                    maxD = iD;
                    maxVal = cuboid[currW, currH, iD] % 10000; // takes the value oof th cell (but not visited "flag")
                    isMaxVisited = (cuboid[currW, currH, iD] / 10000 != 0);  // checks if curr positon has been visited
                    hasMaxMany = false; // until now only one max vaue has been found
                }
                else if (cuboid[currW, currH, iD] % 10000 == maxVal) hasMaxMany = true; // one more max value has been found
            }

            if (maxVal == -12000) isMaxVisited = true; // we have one element cuboid that causes endless loop otherwise

            if (!hasMaxMany && !isMaxVisited) // if max value is a single and not visited cell
            {
                cuboid[maxW, maxH, maxD] += (cuboid[maxW, maxH, maxD] < 0) ? -10000 : 10000; // mark max cell as visited
                currW = maxW; // sets max cell as new current cell
                currH = maxH;
                currD = maxD;
                sumMaxWalk += maxVal; // add its value to the sum
            }
        }

        //outputs the result
        Console.WriteLine(sumMaxWalk);
        //Console.ReadLine();
    }
}

