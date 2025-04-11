using System;
using System.Linq;

namespace DynamicArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] userNumbers = new int[0];

            const string StopWord = "exit";
            const string SumCommand = "sum";

            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("Введите число/sum/exit");
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
                    userNumbers = ArrayAppend(userNumbers, Convert.ToInt32(userInput));
                    for (int i = 0; i < userNumbers.Length; i++)
                    {
                        Console.Write($"{userNumbers[i]} ");
                    }
                }
            }
        }

        private static int[] ArrayAppend(int[] array, int number)
        {
            int[] resizedArray = new int[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
                resizedArray[i] = array[i];

            resizedArray[resizedArray.Length - 1] = number;

            return resizedArray;
        }
    }
}
