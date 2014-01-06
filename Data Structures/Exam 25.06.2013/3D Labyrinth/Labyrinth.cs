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
        static char[,,] labyrinth;
        static Position start;
        static int minMoves;
        
        static void Main()
        {
            Console.SetIn(new StreamReader(@"..\..\input.txt"));
            GetInput();
            minMoves = int.MaxValue;
            FindPath(start, 0);
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

        static void FindPath(Position current, int movesDone)
        {
            // Check if we have found the exit
            if (current.X < 0 || current.X >= labyrinth.GetLength(0))
            {
                if (movesDone < minMoves)
                {
                    minMoves = movesDone;
                }

                return;
            }

            if (!InRange(current) || movesDone >= minMoves)
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


            if (labyrinth[current.X, current.Y, current.Z] == '.')
            {
                // Temporary mark the current cell as visited to avoid cycles
                labyrinth[current.X, current.Y, current.Z] = 'v';

                // Invoke recursion the explore all possible directions on current level
                FindPath(current.Bottom(), movesDone + 1); // bottom
                FindPath(current.Top(), movesDone + 1); // top
                FindPath(current.Right(), movesDone + 1); // right
                FindPath(current.Left(), movesDone + 1); // left

                // Mark back the current cell as free
                labyrinth[current.X, current.Y, current.Z] = '.';
            }
            else if (labyrinth[current.X, current.Y, current.Z] == 'D')
            {
                // Temporary mark the current cell as visited to avoid cycles
                labyrinth[current.X, current.Y, current.Z] = 'd';
                // The current cell is downstairs ladder -> go downstairs
                FindPath(current.Downstairs(), movesDone + 1);
                // Mark back the current cell as free
                labyrinth[current.X, current.Y, current.Z] = 'D';
            }
            else if (labyrinth[current.X, current.Y, current.Z] == 'U')
            {
                // Temporary mark the current cell as visited to avoid cycles
                labyrinth[current.X, current.Y, current.Z] = 'u';
                // The current cell is upstairs ladder -> go upstairs
                FindPath(current.Upstairs(), movesDone + 1);
                // Mark back the current cell as free
                labyrinth[current.X, current.Y, current.Z] = 'U';
            }
        }
        
        static bool InRange(Position position)
        {
            bool levelInRange = position.X >= 0 && position.X < labyrinth.GetLength(0);
            bool rowInRange = position.Y >= 0 && position.Y < labyrinth.GetLength(1);
            bool colInRange = position.Z >= 0 && position.Z < labyrinth.GetLength(2);
            return levelInRange && rowInRange && colInRange;
        }
    }
}
