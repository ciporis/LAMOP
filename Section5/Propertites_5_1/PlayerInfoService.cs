using System;

namespace Propertites_5_1
{
    internal class PlayerInfoService
    {
        public void ShowPlayerInfo(Player player)
        {
            Console.WriteLine($"x position: {player.X}");
            Console.WriteLine($"y position: {player.Y}");
            Console.WriteLine($"symbol: {player.Symbol}");
        }
    }
}
