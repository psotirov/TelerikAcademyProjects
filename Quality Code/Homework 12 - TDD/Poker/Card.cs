using System;

namespace Poker
{
    public class Card : ICard, IComparable
    {
        private static readonly char[] suits = { '♣', '♦', '♥', '♠' };
        private static readonly string[] faces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public Card(string cardName)
        {
            int face = Array.IndexOf(faces, cardName.Substring(0, cardName.Length - 1));
            int suit = Array.IndexOf(suits, cardName[cardName.Length - 1]); 
            this.Face = (CardFace)(face+2);
            this.Suit = (CardSuit)(suit+1);
        }

        public override string ToString()
        {
            return faces[(int)this.Face - 2] + suits[(int)this.Suit - 1];
        }

        int IComparable.CompareTo(Object other)
        {
            return this.Face.CompareTo(((ICard)other).Face);
        }

        public override bool Equals(Object other)
        {
            return this.Face == ((ICard)other).Face && this.Suit == ((ICard)other).Suit;
        }

        public override int GetHashCode()
        {
            // hashcode has its major part of face and minor part of suit  
            return ((int)this.Face - 2) * 10 + (int)this.Suit;
        }
    }
}
