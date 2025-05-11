using System;

namespace Bar_3_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int health = 5;
            int maxHealth = 10;

            DrawBar(health, maxHealth, ConsoleColor.Cyan);
        }

        static void DrawBar(int value, int maxValue, ConsoleColor color)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;

            string bar = "";
            char symbol = ' ';
            char startSymbol = '[';
            char endSymbol = ']';

            for (int i = 0; i < value; i++)
                bar += symbol;

            Console.SetCursorPosition(0, 0);
            Console.Write(startSymbol);
            Console.BackgroundColor = color;
            Console.Write(bar);
            Console.BackgroundColor = defaultColor;

            bar = "";

            for (int i = value; i < maxValue; i++)
                bar += symbol;

            Console.Write(bar);
            Console.Write(endSymbol);
        }
    }
}
