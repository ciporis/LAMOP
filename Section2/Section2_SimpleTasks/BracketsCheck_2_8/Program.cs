using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BracketsCheck_2_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку, состоящую только из '(' и ')'");
            string userLine = Console.ReadLine();
            int lineLength = userLine.Length;

            int bracketsCounter = 0;
            int depthValue = 0;

            char openBracket = '(';
            char closeBracket = ')';

            int lastIndex = lineLength - 1;

            var depths = new List<int>();

            for (int i = 0; i < lineLength; i++)
            {
                if (userLine[i] == openBracket)
                {
                    bracketsCounter++;
                }
                else if (userLine[i] == closeBracket)
                {
                    if(i !=  lastIndex && userLine[i + 1] != openBracket)
                    {
                        depthValue++;
                    }

                    bracketsCounter--;
                }
                if(bracketsCounter == 0)
                {
                    depths.Add(depthValue);
                }
            }

            depths.Sort();

            if(bracketsCounter == 0)
            {
                Console.WriteLine($"Максимальная вложенная глубина " +
                    $"{depths[depths.Count - 1] + 1}");
            }
            else
            {
                Console.WriteLine("Строка не валидна");
            }
        }
    }
}
