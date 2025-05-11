using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ModifiedHumanResources_4_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var humanResources = new Dictionary<string, List<string>>();

            bool isWorking = true;

            const string addCommand = "1";
            const string removeCommand = "2";
            const string displayCommand = "3";
            const string exitCommand = "4";

            while (isWorking)
            {
                Console.WriteLine("\nЭто жесточайшее меню, вот комманды");
                Console.WriteLine($"{addCommand} - Добавить досье");
                Console.WriteLine($"{removeCommand} - Удалить досье");
                Console.WriteLine($"{displayCommand} - Отобразить все досье");
                Console.WriteLine($"{exitCommand} - Выйти\n");

                string commandNumber = Console.ReadLine();
                bool canParseUserInput = int.TryParse(commandNumber, out int result);

                while (canParseUserInput == false)
                {
                    Console.WriteLine("Чето вы ввели bullshit, try again");
                    commandNumber = Console.ReadLine();
                    canParseUserInput = int.TryParse(commandNumber, out result);
                }

                switch (commandNumber)
                {
                    case addCommand:
                        int fullNameLength = 3;

                        Console.WriteLine("Введите ФИО человека");
                        string fullName = Console.ReadLine();

                        while (fullName.Split(' ').Length != fullNameLength)
                        {
                            Console.WriteLine("Снова вводишь bullshit, ай ай ай");
                            fullName = Console.ReadLine();
                        }

                        Console.WriteLine("Введите должность человека");
                        string job = Console.ReadLine();
                        AddWorker(humanResources, fullName, job);
                        break;
                    case removeCommand:
                        Console.WriteLine("Введите должность сотрудника, которого хотите удалить");

                        job = Console.ReadLine();

                        Console.WriteLine("Введите номер сотрудника");
                        string userInput = Console.ReadLine();
                        canParseUserInput = int.TryParse(userInput, out result);

                        while (canParseUserInput == false)
                        {
                            Console.WriteLine("Введите пожалуйста число, а не bullshit");

                            userInput = Console.ReadLine();
                            canParseUserInput = int.TryParse(userInput, out result);
                        }

                        int humanNumber = result;

                        RemoveWorker(humanResources, job, humanNumber);
                        break;
                    case displayCommand:
                        DisplayAllPeople(humanResources);
                        break;
                    case exitCommand:
                        isWorking = false;
                        break;
                }
            }
        }

        static void AddWorker(Dictionary<string, List<string>> humanResources,
            string fullName, string job)
        {
            if (humanResources.ContainsKey(job))
            {
                humanResources[job].Add(fullName);
            }
            else
            {
                humanResources.Add(job, new List<string>());
                humanResources[job].Add(fullName);
            }
        }

        static void RemoveWorker(Dictionary<string, List<string>> humanResources,
            string job, int number)
        {
            int index = number - 1;

            if (index < 0)
            {
                Console.WriteLine("Неправильный номер");
                return;
            }

            humanResources[job].RemoveAt(index);

            if (humanResources[job].Count == 0)
                humanResources.Remove(job);

            Console.WriteLine("Все отлично и легко удалилось");
        }

        static void DisplayAllPeople(Dictionary<string, List<string>> humanResources)
        {
            foreach (KeyValuePair<string, List<string>> jobWorkersPair in humanResources)
            {
                Console.WriteLine($"{jobWorkersPair.Key}");

                for (int i = 0; i < jobWorkersPair.Value.Count; i++)
                    Console.WriteLine($"\t{i + 1}. {jobWorkersPair.Value[i]}");
            }
        }
    }
}
