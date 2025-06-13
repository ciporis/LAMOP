using System;
using System.Collections.Generic;

namespace CardsDeck_5_3
{
    internal class CardsDeck
    {
        private readonly List<Card> _cards;
        private Random _random = new Random();

        public CardsDeck()
        {
            _cards = new List<Card>();
        }

        public bool IsEmpty
        {
            get 
            { 
                return _cards.Count == 0; 
            }

            private set { }
        }

        public int DeckLength
        {
            get { return _cards.Count; }
            private set { }
        }

        public void AddCard(Card card)
        {
            _cards.Add(card);
        }

        public void ShowAllCards()
        {
            foreach (Card card in _cards)
                Console.WriteLine(card.GetCardInfo());
        }

        public Card GetRandomCard()
        {
            int randomIndex = _random.Next(0, _cards.Count);
            Card card = _cards[randomIndex];
            _cards.RemoveAt(randomIndex);
            return card;
        }
    }
}
