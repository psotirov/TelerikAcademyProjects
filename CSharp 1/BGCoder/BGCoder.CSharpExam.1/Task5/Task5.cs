using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class AngryBirds
{
    static void Main()
    {
        int[,] field = new int[8, 16];
        int[] birdsPos = {-1, -1, -1, -1, -1, -1, -1, -1};
        int pigsNr = 0;
        int score = 0;

        for (int i = 0; i < 8; i++)
        {
            int line = int.Parse(Console.ReadLine());
            for (int j = 0; j < 16; j++)
            {
                if (((line >> j) & 1) == 1)
                {
                    if (j > 7) birdsPos[j - 8] = i;
                    else
                    {
                        pigsNr++;
                        field[i, j] = 1;
                    }
                }
            }
        }

        for (int i = 0; i < 8; i++)
        {
            if (birdsPos[i] >= 0)
            {
                int distance = 0;
                int posX = i + 8;
                int posY = birdsPos[i];
                int direction = -1;
                if (posY == 0) direction = 1;
                bool hasFinished = false;
                while (!hasFinished)
                {
                    posX--;
                    posY += direction;
                    if (posX == 0 || posY == 7) hasFinished = true;
                    if (posY == 0) direction = 1;
                    distance++;
                    if (field[posY, posX] > 0) //impact
                    {
                        int pigsCount = 0;
                        for (int y = posY-1; y < posY+2; y++)
                            for (int x = posX-1; x < posX+2; x++)
                            {
                                if (x < 0 || x > 7 || y < 0 || y > 7) continue;
                                if (field[y, x] > 0)
                                {
                                    field[y, x] = 0;
                                    pigsCount++;
                                } 
                            }
                        score += distance * pigsCount;
                        pigsNr -= pigsCount;
                        hasFinished = true;
                    }
                }
            }
        }

        Console.WriteLine("{0} {1}", score, (pigsNr > 0)?"No":"Yes");
    }
}
