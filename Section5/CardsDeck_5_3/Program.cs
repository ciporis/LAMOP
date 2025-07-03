using System;

namespace CardsDeck_5_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CardsDeckFactory cardsDeckFactory = new CardsDeckFactory();

            bool isWorking = true;

            CardsDeck cardsDeck = cardsDeckFactory.CreateStandartDeck();
            var croupier = new Croupier();
            var player = new Player();

            while (isWorking)
            {
                if (cardsDeck.IsEmpty)
                {
                    Console.WriteLine("That's it, the deck is empty");
                    isWorking = false;
                    break;
                }

                Console.WriteLine("How many card do you have:");
                bool canParseUserInput = int.TryParse(Console.ReadLine(), out int result);

                while (canParseUserInput == false || 
                    result < 0 || 
                    result > cardsDeck.DeckLength)
                {
                    Console.WriteLine("Input a correct numer please:");
                    canParseUserInput = int.TryParse(Console.ReadLine(), out result);
                }

                int playerCardsCount = result;

                for (int i = 0; i < playerCardsCount; i++)
                {
                    Card randomCard = cardsDeck.GetRandomCard();
                    croupier.GiveCard(randomCard, player);
                }

                player.ShowUserInfo();
            }        
        }
    }
}