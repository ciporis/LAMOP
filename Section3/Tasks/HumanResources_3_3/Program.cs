using System;

namespace HumanResources_3_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWorking = true;

            string[] people = new string[0];
            string[] jobs = new string[0];

            const string addCommand = "1";
            const string removeCommand = "2";
            const string displayCommand = "3";
            const string findBySecondNameCommand = "4";
            const string exitCommand = "5";

            while (isWorking)
            {
                Console.WriteLine("\nЭто жесточайшее меню, вот комманды");
                Console.WriteLine($"{addCommand} - Добавить досье");
                Console.WriteLine($"{removeCommand} - Удалить досье");
                Console.WriteLine($"{displayCommand} - Отобразить все досье");
                Console.WriteLine($"{findBySecondNameCommand} - Найти по фамилии");
                Console.WriteLine($"{exitCommand} - Выйти\n");

                string userInput = Console.ReadLine();
                bool canParseUserInput = int.TryParse(userInput, out int result);

                while (canParseUserInput == false)
                {
                    Console.WriteLine("Чето вы ввели bullshit, try again");
                    userInput = Console.ReadLine();
                    canParseUserInput = int.TryParse(userInput, out result);
                }

                switch (userInput)
                {
                    case addCommand:
                        int fullNameLength = 3;

                        Console.WriteLine("Введите ФИО человека");
                        string fullName = Console.ReadLine();

                        while(fullName.Split(' ').Length != fullNameLength)
                        {
                            Console.WriteLine("Снова вводишь bullshit, ай ай ай");
                            fullName = Console.ReadLine();
                        }

                        Console.WriteLine("Введите должность человека");
                        string job = Console.ReadLine();
                        AddPerson(ref people, ref jobs, fullName, job);
                        break;
                    case removeCommand:
                        Console.WriteLine("Введите номер досье, которое хотите удалить");
                        userInput = Console.ReadLine();
                        canParseUserInput = int.TryParse(userInput, out result);

                        while (canParseUserInput == false)
                        {
                            Console.WriteLine("Введите пожалуйста число, а не bullshit");
                            userInput = Console.ReadLine();
                            canParseUserInput = int.TryParse(userInput, out result);
                        }

                        RemovePerson(ref people, ref jobs, int.Parse(userInput));
                        break;
                    case displayCommand:
                        DisplayAllPeople(people, jobs);
                        break;
                    case findBySecondNameCommand:
                        Console.WriteLine("Введите фамилию человека");
                        userInput = Console.ReadLine();
                        FindBySecondName(people, jobs, userInput);
                        break;
                    case exitCommand:
                        isWorking = false;
                        break;
                }
            }
        }

        static void AddPerson(ref string[] people, ref string[] jobs, string fullName, string job)
        {
            int length = people.Length;

            string[] tempPeople = new string[length + 1];
            string[] tempJobs = new string[length + 1];

            for (int i = 0; i < length; i++)
            {
                tempPeople[i] = people[i];
                tempJobs[i] = jobs[i];
            }

            tempPeople[tempPeople.Length - 1] = fullName;
            tempJobs[tempPeople.Length - 1] = job;

            people = tempPeople;
            jobs = tempJobs;
        }

        static void RemovePerson(ref string[] people, ref string[] jobs, int index)
        {
            string[] tempPeople = new string[people.Length - 1];
            string[] tempJobs = new string[jobs.Length - 1];    

            int length = people.Length;

            for (int i = 0; i < length; i++)
            {
                if(i == index)
                    continue;

                tempPeople[i] = people[i];
                tempJobs[i] = jobs[i];
            }

            people = tempPeople;
            jobs = tempJobs;
        }

        static void DisplayAllPeople(string[] people, string[] jobs)
        {
            int length = people.Length;

            if (length == 0)
            {
                Console.WriteLine("Пока досье не добавлены");
                return;
            }

            for (int i = 0; i < length; i++)
                Console.WriteLine($"{i + 1}) {people[i]} - {jobs[i]}");
        }

        static void FindBySecondName(string[] people, string[] jobs, string secondName)
        {
            for (int i = 0; i < people.Length; i++)
            {
                if (people[i].Split(' ')[0] == secondName)
                    Console.WriteLine($"{i + 1}) {people[i]}");
            }
        }
    }
}
