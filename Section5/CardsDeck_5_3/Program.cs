using System;

namespace CardsDeck_5_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] cardsValues =     
            { 
                "6", "7", "8", "9", "10", 
                "Jack", "Queen", "King", "Ace" 
            };

            string[] suitmarks =
            {
                "clubs",
                "spades",
                "hearts",
                "diamonds",
            };

            bool isWorking = true;

            var cardDeck = new CardsDeck();
            var croupier = new Croupier();
            var player = new Player();

            foreach (string suitmark in suitmarks)
            {
                foreach (string value in cardsValues)
                {
                    Card card = new Card(suitmark, value);
                    cardDeck.AddCard(card);
                }
            }

            while (isWorking)
            {
                if (cardDeck.IsEmpty)
                {
                    Console.WriteLine("That's it, the deck is empty");
                    isWorking = false;
                    break;
                }

                Console.WriteLine("How many card do you have:");
                bool canParseUserInput = int.TryParse(Console.ReadLine(), out int result);

                while (canParseUserInput == false || 
                    result < 0 || 
                    result > cardDeck.DeckLength)
                {
                    Console.WriteLine("Input a correct numer please:");
                    canParseUserInput = int.TryParse(Console.ReadLine(), out result);
                }

                int playerCardsCount = result;

                for (int i = 0; i < playerCardsCount; i++)
                {
                    Card randomCard = cardDeck.GetRandomCard();
                    croupier.GiveCard(randomCard, player);
                }

                player.ShowUserInfo();
            }        
        }
    }
}