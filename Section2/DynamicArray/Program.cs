using System;
using System.Linq;

namespace DynamicArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] userNumbers = new int[0];

            const string StopCommand = "exit";
            const string SumCommand = "sum";

            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine($"Введите число или одну из комманд:" +
                    $"\n{SumCommand} или {StopCommand}");
                string userInput = Console.ReadLine();

                if (userInput == StopWord)
                {
                    isWorking = false;
                    break;
                }

                if (userInput == SumCommand)
                {
                    Console.WriteLine(userNumbers.Sum());
                }
                else
                {
                    ArrayAppend(ref userNumbers, Convert.ToInt32(userInput));

                    for (int i = 0; i < userNumbers.Length; i++)
                    {
                        Console.Write($"{userNumbers[i]} ");
                    }
                }
            }
        }

        private static void ArrayAppend(ref int[] array, int number)
        {
            int[] resizedArray = new int[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
                resizedArray[i] = array[i];

            resizedArray[resizedArray.Length - 1] = number;

            array = resizedArray;
        }
    }
}
