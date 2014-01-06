using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTest
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void TestCardToString1()
        {
            Card card = new Card(CardFace.Two, CardSuit.Clubs);
            Assert.AreEqual("2♣", card.ToString());
        }

        [TestMethod]
        public void TestCardToString2()
        {
            Card card = new Card(CardFace.Four, CardSuit.Diamonds);
            Assert.AreEqual("4♦", card.ToString());
        }

        [TestMethod]
        public void TestCardToString3()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Hearts);
            Assert.AreEqual("10♥", card.ToString());
        }

        [TestMethod]
        public void TestCardToString4()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Spades);
            Assert.AreEqual("A♠", card.ToString());
        }

        [TestMethod]
        public void TestCardToString5()
        {
            Card card = new Card("4♦");
            Assert.AreEqual("4♦", card.ToString());
        }

        [TestMethod]
        public void TestCardToString6()
        {
            Card card = new Card("10♥");
            Assert.AreEqual("10♥", card.ToString());
        }
    }
}
