using System;

class TicTacToe
{
    static int[,] board = new int[3, 3];
    // board 3x3 - value -> 0 = empty, 1 = X, 2 = O
    static int[] results = new int[3];
    // results - index -> 0 = parity, 1 = X winner, 2 = O winner
    static bool turnX = true; // X always starts first

    static void Main()
    {
        return; // THIS TASK IS NOT FINISHED YET
        // temporary console input redirection
        Console.SetIn(new System.IO.StreamReader("test.000.002.in.txt"));



        for (int row = 0; row < 3; row++)
        {
            string line = Console.ReadLine();
            for (int col = 0; col < 3; col++)
            {
                if (line[col] == 'X') board[row, col] = 1;
                if (line[col] == 'O') board[row, col] = 2; 
            }
        }

        PlayGame();
        Console.WriteLine(results[1]);
        Console.WriteLine(results[0]);
        Console.WriteLine(results[2]);
    }

    static void PlayGame()
    {
        bool hasMoves = false;
        for (int r = 0; r < 3; r++)
            for (int c = 0; c < 3; c++)
			{
                if (board[r, c] == 0) // empty cell
                {
                    hasMoves = true;
                    if (turnX) board[r, c] = 1; // X play
                    else board[r, c] = 2; // O play
                    turnX = !turnX; // next player
                    if (HasThreeInRow()) continue; // if we have winner stops current fill iteration
                    PlayGame(); // plays recursively all next moves
                    turnX = !turnX; // restores the previous state
                    board[r, c] = 0;
                }                
  			}
        if (!hasMoves) results[1]++; //parity game
     }

    static bool HasThreeInRow()
    {
        if ((board[0, 0] ^ board[1, 1] ^ board[2, 2]) == 0 || (board[0, 2] ^ board[1, 1] ^ board[2, 0]) == 0)// checks diagonals
        {
            results[board[1, 1]]++;
            return true;
        }
        for (int i = 0; i < 3; i++)
        {
            if ((board[i,0] ^ board[i,1] ^ board[i,2]) == 0 || (board[0,i] ^ board[1,i] ^ board[2, i]) == 0 )
            // checks each horizontal or vertical line
            {
                results[board[i, i]]++;
                return true;
            }
        }
        return false;
    }
}
