using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }
        
        public Hand(IList<ICard> hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException("a hand cannot be null");
            }

            this.Cards = hand;
        }

        public Hand(string handByName)
        {
            if (string.IsNullOrWhiteSpace(handByName))
            {
                throw new ArgumentException("a hand cannot be null or empty");
            }

            string[] names = handByName.Trim().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            this.Cards = new List<ICard>();

            for (int i = 0; i < names.Length; i++)
            { 
                this.Cards.Add(new Card(names[i]));
            }
        }

        public void Sort()
        {
            List<ICard> sorted = this.Cards.ToList<ICard>();
            sorted.Sort();
            this.Cards = sorted;
        }

        public override string ToString()
        {
            this.Sort();
            return string.Join<ICard>(" ", this.Cards);
        }
    }
}
