using System;
using System.Collections.Generic;
using System.Linq;

namespace ModifiedDynamicArray_4_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool isWorking = true;
            const string sumCommand = "sum";
            const string addCommand = "add";
            const string exitCommand = "exit";

            List<int> userNumbers = new List<int>();

            while(isWorking)
            {
                Console.WriteLine($"\nДоступные комманды:");
                Console.WriteLine($"{addCommand} - добавить элемент в массив");
                Console.WriteLine($"{sumCommand} - вывести сумму элементов массива");
                Console.WriteLine($"{exitCommand} - выход\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case sumCommand:
                        Console.WriteLine($"Сумма элементов: {userNumbers.Sum()}");
                        break;
                    case addCommand:
                        Console.WriteLine("Введите число, которое хотите добавить");
                        bool canParseUserInput = int.TryParse(Console.ReadLine(), out int result);

                        while(canParseUserInput == false)
                        {
                            Console.WriteLine("Повтори");
                            canParseUserInput = int.TryParse(Console.ReadLine(), out result);
                        }

                        userNumbers.Add(result);
                        break;
                    case exitCommand:
                        isWorking = false;
                        break;
                }
            }
        }
    }
}
