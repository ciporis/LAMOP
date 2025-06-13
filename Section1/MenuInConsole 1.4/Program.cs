using System;
using System.Collections.Generic;

namespace MenuInConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ShutDownCommand = "0";
            const string ClearConsoleCommand = "1";
            const string DisplayRandomNumberCommand = "2";
            const string DisplayFirstMessageCommand = "3";
            const string DisplaySecondMessageCommand = "4";

            bool isWorking = true;

            Random random = new Random();

            var methods = new Dictionary<string, Action>
            {
                { ClearConsoleCommand, ClearConsole },
                { DisplayRandomNumberCommand, DisplayRandomNumber(random) },
                { DisplayFirstMessageCommand, DisplayFirstMessage },
                { DisplaySecondMessageCommand, DisplaySecondMessage },
            };

            string[] commmandsForUser = new string[]
            {
                $"{ShutDownCommand}) Завершить работу",
                $"{ClearConsoleCommand}) Очистить консоль",
                $"{DisplayRandomNumberCommand}) Вывести рандомное число",
                $"{DisplayFirstMessageCommand}) Вывести первое сообщение",
                $"{DisplaySecondMessageCommand}) Вывести второе сообщение"
            };

            Console.WriteLine("Доступные комманды:");

            foreach (string command in commmandsForUser)
                Console.WriteLine($"{command}");

            while (isWorking)
            {
                string methodNumber = Console.ReadLine();

                if (methodNumber == ShutDownCommand)
                {
                    isWorking = false;
                    break;
                }

                methods[methodNumber].Invoke();
            }
        }

        private static void ClearConsole()
        {
            Console.Clear();
        }

        private static void DisplayRandomNumber(Random random)
        {
            Console.WriteLine(random.Next());
        }

        private static void DisplayFirstMessage()
        {
            string firstMessage = "Здравствуйте, это первое сообщение";
            Console.WriteLine(firstMessage);
        }

        private static void DisplaySecondMessage()
        {
            string secondMessage = "Здравствуйте, это второе сообщение";
            Console.WriteLine(secondMessage);
        }
    }
}