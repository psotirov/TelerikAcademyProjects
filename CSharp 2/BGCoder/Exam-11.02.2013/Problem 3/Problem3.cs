using System;
using System.Text;

class Problem3
{
    static void Main()
    {
        // temporary console input redirection
        //Console.SetIn(new System.IO.StreamReader("test.001.in.txt"));
        string[,] surface = new string[3,3]
        { {"RED", "BLUE", "RED"},
          {"BLUE", "GREEN", "BLUE"},
          {"RED", "BLUE", "RED"} };

        //int dirX = 0; // initial direction is down
        //int dirY = 1;
        //int posX = 1; // initial position is center
        //int posY = 1;

        int lines = int.Parse(Console.ReadLine());
        StringBuilder output = new StringBuilder();
        for (int i = 0; i < lines; i++)
        {
            int dirX = 0; // initial direction is down
            int dirY = 1;
            int posX = 1; // initial position is center
            int posY = 1;
            string moves = Console.ReadLine();
            if (moves.Length < 1 || moves.Length > 50) throw new ArgumentOutOfRangeException(); 
            for (int move = 0; move < moves.Length; move++)
            {
                switch (moves[move])
                {
                    case 'L':
                        if (dirX == 0)
                        {
                            dirX = dirY;
                            dirY = 0;
                        }
                        else 
                        {
                            dirY = -dirX;
                            dirX = 0;
                        }
                        break;
                    case 'R':
                        if (dirX == 0)
                        {
                            dirX = -dirY;
                            dirY = 0;
                        }
                        else
                        {
                            dirY = dirX;
                            dirX = 0;
                        }
                        break;
                    case 'W':
                        posX += dirX;
                        if (posX == 3) posX = 0;
                        if (posX == -1) posX = 2;
                        posY += dirY;
                        if (posY == 3) posY = 0;
                        if (posY == -1) posY = 2; 
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                        break;
                }
            }
            output.Append(surface[posX, posY]+"\n");
        }
        Console.Write(output);
        //Console.ReadLine();
    }
}
