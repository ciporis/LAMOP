using System;

namespace ReadInt_3_0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Знаете, каждый раз я игнорировал валадацию вводимых данных\n" +
                "и вот настал момент когда уже пора это исправить, введите ЧИСЛО");

            int userNumber;

            bool canParseUserInput = int.TryParse(Console.ReadLine(), out int firstParsingResutl);
            userNumber = firstParsingResutl;

            while (canParseUserInput == false)
            {
                Console.WriteLine("Повторите попытку:");
                canParseUserInput = int.TryParse(Console.ReadLine(), out int cycledParsingResult);
                userNumber = cycledParsingResult;          
            }

            Console.WriteLine($"Ваше число: {userNumber}");
        }
    }
}
