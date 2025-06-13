using System.Collections.Generic;

namespace CardsDeck_5_3
{
    internal class Croupier
    {
        public void GiveCard(Card card, Player player)
        {
            player.AddCard(card);
        }
    }
}
