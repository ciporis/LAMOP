using System;
using System.Collections.Generic;

namespace CardsDeck_5_3
{
    internal class Player
    {
        private readonly List<Card> _cards;

        public Player()
        {
            _cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            _cards.Add(card);
        }

        public void ShowUserInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Player info");

            foreach (Card card in _cards)
            {
                Console.WriteLine(card.GetCardInfo());
            }

            Console.WriteLine();
        }
    }
}
