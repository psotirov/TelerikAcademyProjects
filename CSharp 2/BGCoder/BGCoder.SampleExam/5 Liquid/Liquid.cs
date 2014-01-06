using System;

class Liquid
{
    static int[, ,] cuboid;

    static void Main()
    {
        // temporary console input redirection
        //Console.SetIn(new System.IO.StreamReader("test.008.in.txt"));

        // reads dimensions of cuboid
        string[] dims = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int dimW = int.Parse(dims[0]);
        int dimD = int.Parse(dims[1]);
        int dimH = int.Parse(dims[2]);


        // creates cuboid array / each cell can contain: cuboid[W,H,D] e [0, 100]
        cuboid = new int[dimW, dimD, dimH];

        // reads cuboid values
        for (int iD = 0; iD < dimD; iD++)
        {
            string[] line = Console.ReadLine().Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
            for (int iH = 0; iH < dimH; iH++)
            {
                for (int iW = 0; iW < dimW; iW++)
                {
                    cuboid[iW, iD, iH] = int.Parse(line[iH * dimW + iW]);
                }
            }
        }

        int liquidOut = 0; // initially there is no output liquid amount
        for (int iW = 0; iW < dimW; iW++)
        {
            for (int iD = 0; iD < dimD; iD++)
            {
                if (cuboid[iW, iD, 0] > 0) // walks through all top cells that have some capacity
                {
                    liquidOut += PourLiquid(iW, iD, 0); // and takes the liquid amount that could be poured through it
                }
            }
        }

        //outputs the result
        Console.WriteLine(liquidOut);
    }

    static int PourLiquid(int cellW, int cellD, int cellH, int reqAmount = 101)
    {
        // if current cell has no capacity exits immediately 
        if (cuboid[cellW, cellD, cellH] == 0) return 0;

        // initially we don't have any pouring capacity
        int outAmount = 0;

        // the total flow could not exceed current cell capacity
        if (reqAmount > cuboid[cellW, cellD, cellH]) reqAmount = cuboid[cellW, cellD, cellH];
 
        // if the cell is at the bottom then returns its full capacity
        if (cellH == cuboid.GetLength(2) - 1)
        {
            outAmount = cuboid[cellW, cellD, cellH]; // output capacity is unlimited 
            if (reqAmount < outAmount)
            {
                outAmount = reqAmount; // ensures pouring only of requested amount if it is enough
            }
            cuboid[cellW, cellD, cellH] -= outAmount; // and uses its total capacity
        }

        // otherwise we have to pour all requested capacity through all neighbour cells
        else
        {
            cuboid[cellW, cellD, cellH] -= reqAmount; // using requested capacity (or less) from current cell
            //cuboid[cellW, cellD, cellH] = 0; // using requested capacity (or less) from current cell

            // bottom cell first
            outAmount = PourLiquid(cellW, cellD, cellH + 1, reqAmount);

            // checks for all other neighbours if they can supply the requested capacity 
            // to left
            if (outAmount < reqAmount && cellW > 0) outAmount += PourLiquid(cellW - 1, cellD, cellH, reqAmount - outAmount);
            // to shallower
            if (outAmount < reqAmount && cellD > 0) outAmount += PourLiquid(cellW, cellD - 1, cellH, reqAmount - outAmount);
            // to right
            if (outAmount < reqAmount && cellW < cuboid.GetLength(0) - 1) outAmount += PourLiquid(cellW + 1, cellD, cellH, reqAmount - outAmount);
            // to deeper
            if (outAmount < reqAmount && cellD < cuboid.GetLength(1) - 1) outAmount += PourLiquid(cellW, cellD + 1, cellH, reqAmount - outAmount);
        }

        return outAmount; // returns possible capacity
    }
}