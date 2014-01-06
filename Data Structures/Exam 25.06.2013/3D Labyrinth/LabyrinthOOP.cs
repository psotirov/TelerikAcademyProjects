using System;
using System.IO;

namespace _3D_Labyrinth
{
    public struct Position
    {
        public int X;
        public int Y;
        public int Z;

        public Position Left()
        {
            return new Position(this.X, this.Y, this.Z - 1);
        }

        public Position Right()
        {
            return new Position(this.X, this.Y, this.Z + 1);
        }

        public Position Top()
        {
            return new Position(this.X, this.Y - 1, this.Z);
        }

        public Position Bottom()
        {
            return new Position(this.X, this.Y + 1, this.Z);
        }

        public Position Upstairs()
        {
            return new Position(this.X + 1, this.Y, this.Z);
        }

        public Position Downstairs()
        {
            return new Position(this.X - 1, this.Y, this.Z);
        }

        public Position(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }

    class Labyrinth
    {
        static char[, ,] labyrinth;
        static Position start;
        static int minMoves;

        static void Main()
        {
            // Console.SetIn(new StreamReader(@"..\..\input.txt"));
            GetInput();
            minMoves = int.MaxValue;
            FindPath(start.X, start.Y, start.Z, 0);
            Console.WriteLine(minMoves);
        }

        static void GetInput()
        {
            string[] positionLine = Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int xPos = int.Parse(positionLine[0]);
            int yPos = int.Parse(positionLine[1]);
            int zPos = int.Parse(positionLine[2]);
            start = new Position(xPos, yPos, zPos);

            string[] dimensionsLine = Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int xLength = int.Parse(dimensionsLine[0]);
            int yLength = int.Parse(dimensionsLine[1]);
            int zLength = int.Parse(dimensionsLine[2]);

            labyrinth = new char[xLength, yLength, zLength];
            for (int x = 0; x < xLength; x++)
            {
                for (int y = 0; y < yLength; y++)
                {
                    string row = Console.ReadLine().Trim();
                    for (int z = 0; z < zLength; z++)
                    {
                        labyrinth[x, y, z] = row[z];
                    }
                }
            }
        }

        static void FindPath(int currentX, int currentY, int currentZ, int movesDone)
        {
            // Check if we have found the exit
            if (currentX < 0 || currentX >= labyrinth.GetLength(0))
            {
                if (movesDone < minMoves)
                {
                    minMoves = movesDone;
                }

                return;
            }

            if (!InRange(currentX, currentY, currentZ) || movesDone >= minMoves)
            {
                // We are out of the labyrinth -> can't find a path
                // or we have a better solution already
                return;
            }

            //if (labyrinth[current.X, current.Y, current.Z] == '#' ||
            //    labyrinth[current.X, current.Y, current.Z] == 'v' || 
            //    labyrinth[current.X, current.Y, current.Z] == 'd' ||
            //    labyrinth[current.X, current.Y, current.Z] == 'u')
            //{
            //    // The current cell is not free -> can't find a path
            //    return;
            //}


            if (labyrinth[currentX, currentY, currentZ] == '.')
            {
                // Temporary mark the current cell as visited to avoid cycles
                labyrinth[currentX, currentY, currentZ] = 'v';

                // Invoke recursion the explore all possible directions on current level
                FindPath(currentX, currentY, currentZ + 1, movesDone + 1); // bottom
                FindPath(currentX, currentY, currentZ - 1, movesDone + 1); // top
                FindPath(currentX, currentY + 1, currentZ, movesDone + 1); // right
                FindPath(currentX, currentY - 1, currentZ, movesDone + 1); // left

                // Mark back the current cell as free
                labyrinth[currentX, currentY, currentZ] = '.';
            }
            else if (labyrinth[currentX, currentY, currentZ] == 'D')
            {
                // Temporary mark the current cell as visited to avoid cycles
                labyrinth[currentX, currentY, currentZ] = 'd';
                // The current cell is downstairs ladder -> go downstairs
                FindPath(currentX - 1, currentY, currentZ, movesDone + 1);
                // Mark back the current cell as free
                labyrinth[currentX, currentY, currentZ] = 'D';
            }
            else if (labyrinth[currentX, currentY, currentZ] == 'U')
            {
                // Temporary mark the current cell as visited to avoid cycles
                labyrinth[currentX, currentY, currentZ] = 'u';
                // The current cell is upstairs ladder -> go upstairs
                FindPath(currentX + 1, currentY, currentZ, movesDone + 1);
                // Mark back the current cell as free
                labyrinth[currentX, currentY, currentZ] = 'U';
            }
        }

        static bool InRange(int positionX, int positionY, int positionZ)
        {
            return (positionX >= 0 && positionX < labyrinth.GetLength(0) &&
                positionY >= 0 && positionY < labyrinth.GetLength(1) &&
                positionZ >= 0 && positionZ < labyrinth.GetLength(2));
        }
    }
}
