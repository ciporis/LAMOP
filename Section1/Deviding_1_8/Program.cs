using System;
using System.Collections.Generic;
 
namespace Deviding_1_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minRandomNumber = 10;
            int maxRandomNumber = 25;

            ModifiedRandom random = new ModifiedRandom();
            int randomNumber = random[minRandomNumber, maxRandomNumber];

            Console.WriteLine(randomNumber);

            List<int> multipliedNumbers = new List<int>();

            int startMultiplier = 1;
            int endMultiplier = 20;

            for (int i = startMultiplier; i <= endMultiplier; i++)
                multipliedNumbers.Add(MultiplyNumber(randomNumber, i));

            int startNumber = 50;
            int endNumber = 150;

            int numbersCount = 0;

            for (int i = startNumber; i <= endNumber; i++)
            {
                if (multipliedNumbers.Contains(i))
                    numbersCount++;
            }

            Console.WriteLine($"Count of numbers ({startNumber} to {endNumber}) which can be deviden by random number from " +
                $"{minRandomNumber} to {maxRandomNumber}:  {numbersCount}");
        }

        private static int MultiplyNumber(int number, int multiplier)
        {
            int multipliedNumber = 0;

            for (int i = 0; i < multiplier; i++)
                multipliedNumber += number;

            return multipliedNumber;
        }
    }

    public class ModifiedRandom
    {
        private Random _random = new Random();

        public int this[int min, int max] => _random.Next(min, max + 1);
    }
}
