namespace CardsDeck_5_3
{
    internal class CardsDeckFactory
    {
        public CardsDeck CreateStandartDeck()
        {
            string[] _cardsValues =
            {
                "6", "7", "8", "9", "10",
                "Jack", "Queen", "King", "Ace"
            };

            string[] _suitmarks =
            {
                    "clubs",
                    "spades",
                    "hearts",
                    "diamonds",
            };

            CardsDeck cardsDeck = new CardsDeck();

            foreach (string suitmark in _suitmarks)
            {
                foreach (string value in _cardsValues)
                {
                    Card card = new Card(suitmark, value);
                    cardsDeck.AddCard(card);
                }
            }

            return cardsDeck;
        }
    }
}
