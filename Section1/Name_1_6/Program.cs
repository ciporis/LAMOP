using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Name_1_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите свое имя:");
            string name = Console.ReadLine();

            char symbol = '#';

            Console.WriteLine("Введите символ, которым хотите обвести имя:");
            try
            {
                symbol = Char.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("No no mister fish, you will go in this tazik");
            }


            int extraSymbolsAmount = 2;

            PrintLine(name, extraSymbolsAmount, symbol);

            Console.Write(symbol);
            Console.Write(name);
            Console.WriteLine(symbol);

            PrintLine(name, extraSymbolsAmount, symbol);
        }

        private static void PrintLine(string name, int extraSymbolsAmount, char symbol)
        {
            for (int i = 0; i < name.Length + extraSymbolsAmount; i++)
                Console.Write(symbol);
            Console.Write("\n");
        }
    }
}
