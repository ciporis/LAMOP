using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace SimpleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int heroHealth = 150;
            int heroMana = 150;
            int heroDamage = 20;

            int bossHealth = 1000;
            int bossDamage = 13;

            bool miniGameSuccess = false;

            Hero hero = new Hero(heroHealth, heroMana, heroDamage);
            Boss boss = new Boss(bossHealth, bossDamage);

            string attackCommand = "1";
            string fireBallCommand = "2";
            string explosionCommand = "3";
            string restorePropertiesCommand = "4";

            Dictionary<string, Action<Boss>> _heroAttacks = new Dictionary<string, Action<Boss>>
            {
                { attackCommand, hero.Attack },
                { fireBallCommand, hero.FireBallAttack },
                { explosionCommand, hero.Explode },
                { restorePropertiesCommand, hero.RestoreProperties },
            };

            Console.WriteLine($"ВЫ ПОПАЛИ В ИГРУ, ВАМ НУЖНО ПОБЕДИТЬ БОССА, " +
                $"У НЕГО {boss.Health} HP");

            while(boss.IsAlive && hero.IsAlive)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White; 

                Console.WriteLine($"Ваши атаки:");

                foreach (string key in _heroAttacks.Keys)
                {
                    string attackName = _heroAttacks[key].GetMethodInfo().Name;
                    Console.WriteLine($"{key} - {attackName}");
                }

                string userChoice = Console.ReadLine();

                MiniGame miniGame = new MiniGame();
                miniGame.StartMiniGame();
                
                miniGameSuccess = miniGame.GetMiniGameSucces();

                if (miniGameSuccess == false)
                {
                    boss.UseRandomAttack(hero);
                    Console.WriteLine($"Босс атаковал, ваше здоровье: {hero.Health}");
                }
                else
                {
                    _heroAttacks[userChoice].Invoke(boss);
                    Console.WriteLine($"Здоровье босса: {boss.Health}");
                }
            }

            Console.WriteLine("EASY!!!");
        }
    }   
}