using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Poker
{
    static void Main()
    {
        int[] cards = new int[5];
        string[] output = { "Nothing", "One Pair", "Two Pairs", "Three of a Kind", "Full House", "Four of a Kind", "Straight", "Impossible" };
        for (int i = 0; i < 5; i++)
        {
            string card = Console.ReadLine();
            switch (card)
            {
                case "10": cards[i] = 10; break;
                case "J": cards[i] = 11; break;
                case "Q": cards[i] = 12; break;
                case "K": cards[i] = 13; break;
                case "A": cards[i] = 14; break;
                default: cards[i] = card[0] - '0'; break;
            }
        }
        Array.Sort(cards);
        int result = 0;

        bool hasPair = false;
        bool hasTripple = false;
        bool hasQuad = false;
        bool isStraight = false;

        for (int i = 1; i < 5; i++)
        {
            if (cards[i] == cards[i - 1])
            {
                isStraight = false;
                if (hasQuad)
                {
                    result = 7;
                    break;
                }
                else if (hasTripple)
                {
                    hasTripple = false;
                    hasQuad = true;
                    result = 5;
                }
                else if (hasPair)
                {
                    hasPair = false;
                    hasTripple = true;
                }
                else hasPair = true;
            }
            else
            {
                hasPair = false;
                hasTripple = false;
            }

            if (cards[i] - cards[i - 1] == 1)
            {
                if (i == 1) isStraight = true;  
            } else if (i < 5 && (cards[0] != 2 || cards[4] != 14))
                {
                    isStraight = false;
                }

            if (hasPair) result++;
            if (hasTripple)
            {
                if (result > 0) result += 2;
                else result = 3;
            }
        }

        if (isStraight) result = 6;
        Console.WriteLine(output[result]);
    }
}
