using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Poker;

namespace PokerTest
{
    [TestClass]
    public class HandTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestHandConstructor1_ThrowsException()
        {
            List<ICard> cards = null;
            IHand hand = new Hand(cards);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestHandConstructor2_ThrowsException()
        {
            string cardNames = null;
            IHand hand = new Hand(cardNames);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestHandConstructor3_ThrowsException()
        {
            string cardNames = string.Empty;
            IHand hand = new Hand(cardNames);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestHandConstructor4_ThrowsException()
        {
            string cardNames = "   ";
            IHand hand = new Hand(cardNames);
        }

        [TestMethod]
        public void TestHandToString1()
        {
            IHand hand = new Hand("2♥ 4♦ 10♠ Q♣ A♦");

            Assert.AreEqual("2♥ 4♦ 10♠ Q♣ A♦", hand.ToString());
        }

        [TestMethod]
        public void TestHandToString2()
        {
            IHand hand = new Hand("K♣");

            Assert.AreEqual("K♣", hand.ToString());
        }
    }
}
