using System;
using System.Collections.Generic;
using System.Threading;

class FallingRocks
{
    enum RockShape {Dot, vLine, hLine, Square, Crest}
    public const int fieldWidth = 40;
    public const int fieldHeight = 30;
    public const int bonusStep = 500;

    class Rock
    {
        static int maxSize = 5;
        static string allowedChars  = "*@&+%$#!.;";
        int posX;
        int posY;
        char symbol;
        RockShape shape;
        int length;
        ConsoleColor color;

        public Rock()
        {
            Random innerRockGenerator = new Random();
            symbol = allowedChars[innerRockGenerator.Next(allowedChars.Length)];
            length = innerRockGenerator.Next(1, maxSize+1);
            color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Convert.ToString(innerRockGenerator.Next(1, 16))); // selects one of the 16 foregroud colors
            shape = (RockShape)Enum.Parse(typeof(RockShape), Convert.ToString(innerRockGenerator.Next((int)RockShape.Crest + 1))); // selects some shape
            posY = 0;
            posX = innerRockGenerator.Next(0, fieldWidth - length);
        }

        public uint GetRockLength()
        {
            return (uint)length;
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            switch (shape)
            {
                case RockShape.Dot:
                    Console.SetCursorPosition(posX, posY);
                    Console.Write(symbol);
                    break;
                case RockShape.vLine:
                    for (int i = 0; (i < length) && (posY + i < fieldHeight); i++)
                    {
                        Console.SetCursorPosition(posX, posY+i);
                        Console.Write(symbol);
                    }
                    break;
                case RockShape.hLine:
                    Console.SetCursorPosition(posX, posY);
                    Console.Write(new string(symbol, length));
                    break;
                case RockShape.Square:
                    string rockRow = new string(symbol, length);
                    for (int i = 0; (i < length) && (posY + i < fieldHeight); i++)
                    {
                        Console.SetCursorPosition(posX, posY+i);
                        Console.Write(rockRow);
                    }
                    break;
                case RockShape.Crest:
                    for (int i = 0; (i < length) && (posY+i < fieldHeight); i++)
                    {
                        Console.SetCursorPosition(posX+length/2, posY+i);
                        Console.Write(symbol);
                    }
                    if ((posY + length / 2) < fieldHeight)
                    {
                        Console.SetCursorPosition(posX, posY + length / 2);
                        Console.Write(new string(symbol, length));
                    }
                    break;
                default:
                    break;
            }
        }

        public bool Down()
        {
            posY++;
            return (posY < fieldHeight); // if it is outside the boundary returns false, otherwise if OK returns true 
        }

        public bool DwarfCollisionCheck(int dwarfPosition)
        {
            int rockHeight = ((shape == RockShape.Dot) || (shape == RockShape.hLine)) ? 1 : length;
            if ((posY + rockHeight) >= fieldHeight)
            {
                int hLength = length;
                int tempPosX = posX;
                if (shape == RockShape.vLine || shape == RockShape.Dot) hLength = 1; // the width of "vertical line" and "dot" rock is always 1
                if ((shape == RockShape.Crest) && ((posY + length / 2 + 1) != fieldHeight))
                {
                    hLength = 1; // the width of "crest"rock is always 1 except of its middle vertical line
                    tempPosX += length / 2; // and vertical line of the crest is shifted at the middle of the figure
                }

                if ((dwarfPosition > (tempPosX - 3)) && (dwarfPosition < (tempPosX+hLength))) return true; //Checks if position of dwarf (including 3 chars width) is within the rock's current line
            }

            return false;
        }
    }

    static class Dwarf
    {
        static string dwarfBody;
        static int posX;
        static bool hasDamage;
        static int damageStatusCounter;
        static ConsoleColor color;

        static Dwarf()
        {
            dwarfBody = "(0)";
            posX = fieldWidth / 2 - 1;
            color = ConsoleColor.Green;
            hasDamage = false;
            damageStatusCounter = 0;
        }

        public static void Draw()
        {
            Console.SetCursorPosition(posX, Console.WindowHeight - 1);
            Console.ForegroundColor = (hasDamage)?ConsoleColor.Red:color;
            Console.Write(dwarfBody);
            if (hasDamage && (--damageStatusCounter == 0)) hasDamage=false;
        }

        public static void Clear()
        {
            Console.SetCursorPosition(posX, Console.WindowHeight - 1);
            Console.ForegroundColor = color;
            Console.Write(new string(' ',dwarfBody.Length));
        }

        public static void Left()
        {
            if (posX == 0) return;
            Clear();
            posX--;
            Draw();
        }

        public static void Right()
        {
            if (posX == fieldWidth) return;
            Clear();
            posX++;
            Draw();
        }

        public static void SetDamage()
        {
            hasDamage = true;
            damageStatusCounter = 4;
        }

        public static bool GetDamage()
        {
            return (hasDamage && damageStatusCounter==4);
        }

        public static int GetDwarfPosition()
        {
            return posX;
        }
    }

    static void Main()
    {
        Console.BufferWidth = Console.WindowWidth = fieldWidth + 15;
        Console.BufferHeight = Console.WindowHeight = fieldHeight;
        uint dwarfScore = 0;
        uint dwarfLives = 5;
        Random randGenerator = new Random();
        List<Rock> allRocks = new List<Rock>();
        allRocks.Add(new Rock());

        while (true)
        {
            // Clear console
            Console.Clear();
            // Move our dwarf on key presssed
            if (Console.KeyAvailable)
            { 
                while (Console.KeyAvailable) // you can press control keys multiple times per loop in order to move faster
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    if (pressedKey.Key == ConsoleKey.LeftArrow) Dwarf.Left(); // moves dwarf left
                    if (pressedKey.Key == ConsoleKey.RightArrow) Dwarf.Right(); // moves dwarf right
                    if (pressedKey.Key == ConsoleKey.Escape)
                    {
                        Console.ResetColor();
                        Console.WriteLine("GOOD BYE\n\n");
                        Console.ResetColor();
                        Console.ReadKey(true);
                        return; // Exits the game
                    }
                }
            }
            // Move rocks
            int RocksIndex = 0;
            while (RocksIndex < allRocks.Count)
            {
                if (allRocks[RocksIndex].Down()) //Moves down the current rock
                {
                    allRocks[RocksIndex].Draw();
                    if (allRocks[RocksIndex].DwarfCollisionCheck(Dwarf.GetDwarfPosition())) Dwarf.SetDamage(); // Checks for collision with the Dwarf
                    RocksIndex++;
                }
                else
                {
                    uint plusScore = allRocks[RocksIndex].GetRockLength();
                    bool hasBonus = (dwarfScore / bonusStep) != ((dwarfScore + plusScore) / bonusStep);
                    if (hasBonus) dwarfLives++; // BONUS: for each "bonusStep" points, the player wins one additional spare life
                    dwarfScore += plusScore;
                    allRocks.Remove(allRocks[RocksIndex]); // removes item if it is outside the boundary 
                }
            }

            // Add new rock with 20% possibility
            if (randGenerator.Next(5) == 1) allRocks.Add(new Rock());

            // Check for hit
            if (Dwarf.GetDamage())
            {
                dwarfLives--;
                allRocks.Clear();
                if (dwarfLives == 0)
                {
                    Console.SetCursorPosition(5, fieldHeight / 2);
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("  !!!  GAME OVER  !!!   ");
                    Console.ResetColor();
                    Console.ReadKey(true);
                    return;
                }
            }


            // Redraw field
            Dwarf.Draw();
            
            // Draw info
            Console.SetCursorPosition(fieldWidth + 5, 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("SCORE:");
            Console.SetCursorPosition(fieldWidth + 2, 3);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("{0,10}", dwarfScore);
            Console.SetCursorPosition(fieldWidth + 5, 5);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("LIVES:");
            Console.SetCursorPosition(fieldWidth + 2, 6);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("{0,10}", dwarfLives);
            
            // Slowdown the program
            Thread.Sleep(150);
        }
    }
}
