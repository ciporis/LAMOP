using System;
using System.Collections.Generic;

namespace Dictionary_4_0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWorking = true;
            string stopCommand = "exit";

            var dictionary = new Dictionary<string, string>();
            string skipCommand = "-";

            while(isWorking)
            {
                Console.WriteLine($"Введите слово, значение котого хотите узнать");
                string wordToSearch = Console.ReadLine();

                if(dictionary.ContainsKey(wordToSearch.ToLower()))
                {
                    Console.WriteLine($"Слово {wordToSearch} означает " +
                        $"\"{dictionary[wordToSearch]}\"");
                }
                else
                {
                    Console.WriteLine($"Добавьте значение этого слова " +
                        $"в словарь либо проигнорируйте, чтобы проигнорировать " +
                        $"введите в консоль \"-\"");

                    string userInput = Console.ReadLine();
                    
                    if (userInput == skipCommand)
                        continue;

                    if (userInput == stopCommand)
                        isWorking = false;
                    
                    dictionary[wordToSearch] = userInput;
                }
            }
        }
    }
}
