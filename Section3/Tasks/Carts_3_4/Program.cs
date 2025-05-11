using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;

namespace Map_3_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] map =
            {
                { '%', '%', '%', '%', '%', '%' },
                { '%', ' ', ' ', ' ', ' ', '%' },
                { '%', ' ', ' ', ' ', ' ', '%' },
                { '%', ' ', ' ', ' ', ' ', '%' },
                { '%', ' ', ' ', ' ', ' ', '%' },
                { '%', '%', '%', '%', '%', '%' },
            };

            string player = "#";

            Console.CursorVisible = false;
            Console.SetCursorPosition(1, 1);

            int x = 1;
            int y = 1;

            Console.SetCursorPosition(x, y);
            Console.Write(player);

            while (true)
            {
                Console.Clear();
                DrawMap(map);

                Console.SetCursorPosition(x, y);
                Console.Write(player);

                ConsoleKeyInfo pressedKey = Console.ReadKey();
                HandleInput(pressedKey, ref x, ref y, map);

                Console.SetCursorPosition(x, y);
                Console.Write(player);

                Thread.Sleep(100);
            }
        }

        private static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static void HandleInput(ConsoleKeyInfo pressedKey, ref int x, ref int y, char[,] map)
        {
            char wall = '%';

            int[] direction = GetDirection(pressedKey);

            int nextPositionX = x + direction[0];
            int nextPositionY = y + direction[1];

            if (map[nextPositionX, nextPositionY] != wall)
            {
                x = nextPositionX;
                y = nextPositionY;
            }
        }

        private static int[] GetDirection(ConsoleKeyInfo pressedKey)
        {
            int[] direction = { 0, 0 };

            if (pressedKey.Key == ConsoleKey.UpArrow)
                direction[1] = -1;
            else if (pressedKey.Key == ConsoleKey.DownArrow)
                direction[1] = 1;
            else if (pressedKey.Key == ConsoleKey.LeftArrow)
                direction[0] = -1;
            else if (pressedKey.Key == ConsoleKey.RightArrow)
                direction[0] = 1;

            return direction;
        }
    }
}
