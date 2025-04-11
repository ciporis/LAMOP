using System;

namespace SimpleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero(150, 150, 20);
            Boss boss = new Boss(1000, 13);

            Console.WriteLine($"ВЫ ПОПАЛИ В ИГРУ, ВАМ НУЖНО ПОБЕДИТЬ БОССА, У НЕГО {boss.}");
        }
    }   
}
