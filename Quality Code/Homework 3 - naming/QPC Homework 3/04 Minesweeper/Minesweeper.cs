using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Minesweeper
{
    public class Minesweeper
    {
        const int MaxOpenCells = 35;

        static void Main(string[] args)
        {
            string command = string.Empty;
            char[,] field = CreateField();
            char[,] mines = PutMines();
            int pointsEarned = 0;
            bool isEndOfGame = false;
            List<PlayerResult> hallOfFame = new List<PlayerResult>(6);
            int row = 0;
            int column = 0;
            bool isStartGame = true;
            bool hasMaxOpenCells = false;

            do
            {
                if (isStartGame)
                {
                    Console.WriteLine("Lets play \"Minesweeper\". Try your luck in finding the cells without mines." +
                    " Command \"top\" shows the Hall of Fame, \"restart\" starts new game, \"exit\" finishes the application.");
                    ShowGame(field);
                    isStartGame = false;
                }

                Console.Write("Command or coordinates(separated by space): ");
                command = Console.ReadLine().Trim();
                if (command.Length > 0 && Char.IsDigit(command[0]))
                {
                    string[] coordinates = command.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                    if (coordinates.Length == 2 &&
                        int.TryParse(coordinates[0], out row) &&
                        int.TryParse(coordinates[1], out column) &&
                        row < field.GetLength(0) &&
                        column < field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        ShowHallOfFame(hallOfFame);
                        break;
                    case "restart":
                        field = CreateField();
                        mines = PutMines();
                        ShowGame(field);
                        isEndOfGame = false;
                        isStartGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (mines[row, column] != '*')
                        {
                            if (mines[row, column] == '-')
                            {
                                NextMove(field, mines, row, column);
                                pointsEarned++;
                            }

                            if (MaxOpenCells == pointsEarned)
                            {
                                hasMaxOpenCells = true;
                            }
                            else
                            {
                                ShowGame(field);
                            }
                        }
                        else
                        {
                            isEndOfGame = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nUnknown command or coordinates out of the field!\n");
                        break;
                }

                if (isEndOfGame)
                {
                    ShowGame(mines);
                    Console.Write("\nBOOM! You are dead with {0} points. " +
                        "Please enter your nickname: ", pointsEarned);
                    string nickname = Console.ReadLine();
                    PlayerResult currentPlayer = new PlayerResult(nickname, pointsEarned);
                    if (hallOfFame.Count < 5)
                    {
                        hallOfFame.Add(currentPlayer);
                    }
                    else
                    {
                        for (int position = 0; position < hallOfFame.Count; position++)
                        {
                            if (hallOfFame[position].Points < currentPlayer.Points)
                            {
                                hallOfFame.Insert(position, currentPlayer);
                                hallOfFame.RemoveAt(hallOfFame.Count - 1);
                                break;
                            }
                        }
                    }

                    hallOfFame.Sort((PlayerResult player1, PlayerResult player2) => player2.Name.CompareTo(player1.Name));
                    hallOfFame.Sort((PlayerResult player1, PlayerResult player2) => player2.Points.CompareTo(player1.Points));
                    ShowHallOfFame(hallOfFame);

                    field = CreateField();
                    mines = PutMines();
                    pointsEarned = 0;
                    isEndOfGame = false;
                    isStartGame = true;
                }

                if (hasMaxOpenCells)
                {
                    Console.WriteLine("\nGREAT! You have successfully opened 35 cells.");
                    ShowGame(mines);
                    Console.WriteLine("Please enter your nickname: ");
                    string nickname = Console.ReadLine();
                    PlayerResult currentPlayer = new PlayerResult(nickname, pointsEarned);
                    hallOfFame.Add(currentPlayer);
                    ShowHallOfFame(hallOfFame);
                    field = CreateField();
                    mines = PutMines();
                    pointsEarned = 0;
                    hasMaxOpenCells = false;
                    isStartGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Thank you for playing. Good Bye!");
            Console.Read();
        }

        private static void ShowHallOfFame(List<PlayerResult> hallOfFame)
        {
            Console.WriteLine("\nPoints:");
            if (hallOfFame.Count > 0)
            {
                for (int i = 0; i < hallOfFame.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} cells opened",
                        i + 1, hallOfFame[i].Name, hallOfFame[i].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty Hall of Fame!\n");
            }
        }

        private static void NextMove(char[,] field, char[,] mines, int row, int column)
        {
            char numberOfMines = CountMinesAround(mines, row, column);
            mines[row, column] = numberOfMines;
            field[row, column] = numberOfMines;
        }

        private static void ShowGame(char[,] field)
        {
            int rowsCount = field.GetLength(0);
            int columnsCount = field.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int row = 0; row < rowsCount; row++)
            {
                Console.Write("{0} | ", row);
                for (int col = 0; col < columnsCount; col++)
                {
                    Console.Write(string.Format("{0} ", field[row, col]));
                }
                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateField()
        {
            int fieldRows = 5;
            int fieldColumns = 10;
            char[,] field = new char[fieldRows, fieldColumns];
            for (int i = 0; i < fieldRows; i++)
            {
                for (int j = 0; j < fieldColumns; j++)
                {
                    field[i, j] = '?';
                }
            }

            return field;
        }

        private static char[,] PutMines()
        {
            int fieldRows = 5;
            int fieldColumns = 10;
            char[,] field = new char[fieldRows, fieldColumns];

            for (int i = 0; i < fieldRows; i++)
            {
                for (int j = 0; j < fieldColumns; j++)
                {
                    field[i, j] = '-';
                }
            }

            List<int> minesCoordinates = new List<int>();
            while (minesCoordinates.Count < 15)
            {
                Random random = new Random();
                int currentCoordinates = random.Next(50);
                if (!minesCoordinates.Contains(currentCoordinates))
                {
                    minesCoordinates.Add(currentCoordinates);
                }
            }

            foreach (int currentCoordinates in minesCoordinates)
            {
                int currentColumn = (currentCoordinates / fieldColumns);
                int currentRow = (currentCoordinates % fieldColumns);
                if (currentRow == 0 && currentCoordinates != 0)
                {
                    currentColumn--;
                    currentRow = fieldColumns;
                }
                else
                {
                    currentRow++;
                }

                field[currentColumn, currentRow - 1] = '*';
            }

            return field;
        }

        private static char CountMinesAround(char[,] field, int row, int column)
        {
            int countMines = 0;
            int fieldRows = field.GetLength(0);
            int fieldColumns = field.GetLength(1);

            if (row - 1 >= 0)
            {
                if (field[row - 1, column] == '*')
                {
                    countMines++;
                }
            }

            if (row + 1 < fieldRows)
            {
                if (field[row + 1, column] == '*')
                {
                    countMines++;
                }
            }

            if (column - 1 >= 0)
            {
                if (field[row, column - 1] == '*')
                {
                    countMines++;
                }
            }

            if (column + 1 < fieldColumns)
            {
                if (field[row, column + 1] == '*')
                {
                    countMines++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (field[row - 1, column - 1] == '*')
                {
                    countMines++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < fieldColumns))
            {
                if (field[row - 1, column + 1] == '*')
                {
                    countMines++;
                }
            }

            if ((row + 1 < fieldRows) && (column - 1 >= 0))
            {
                if (field[row + 1, column - 1] == '*')
                {
                    countMines++;
                }
            }

            if ((row + 1 < fieldRows) && (column + 1 < fieldColumns))
            {
                if (field[row + 1, column + 1] == '*')
                {
                    countMines++;
                }
            }

            return char.Parse(countMines.ToString());
        }
    }
}
