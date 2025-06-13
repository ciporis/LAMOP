using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Propertites_5_1
{
    internal class Player
    {
        public Player(int xPosition, int yPosition, char symbol)
        {
            X = xPosition;
            Y = yPosition;
            Symbol = symbol;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public char Symbol { get; private set; }
    }
}
