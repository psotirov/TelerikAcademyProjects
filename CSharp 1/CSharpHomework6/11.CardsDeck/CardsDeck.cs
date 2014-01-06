using System;

class CardsDeck
{
    static void Main()
    {
        string[] ranks = new string[] {"Ace","two","three","four","five","six","seven","eight","nine","ten","Jack","Queen","King"};
        string[] suits = new string[] {"clubs","diamonds","hearts","spades"};

        Console.WriteLine("A deck of cards contains:");
        for (int suit = 0; suit < suits.Length; suit++)        
        {
            Console.WriteLine();
            string suitname = "";
            switch (suit)
            {
                case 0: suitname = suits[0]; break;
                case 1: suitname = suits[1]; break;
                case 2: suitname = suits[2]; break;
                case 3: suitname = suits[3]; break;
                default:break;
            }
            for (int rank = 0; rank < ranks.Length; rank++)
            {
                Console.WriteLine("{0,2} - {1} of {2}", suit*ranks.Length + rank + 1,ranks[rank], suitname);
            }
        }
    }
}

