using System;
using System.Collections.Generic;

namespace Extremums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int rightRandomBorder = 10;

            int[] numbers = new int[30];
            List<int> localMaximums = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(rightRandomBorder);
                Console.Write($"{numbers[i]} ");
            }
            Console.WriteLine();

            Console.WriteLine("Локальные максимумы");

            if (numbers.Length == 1)
            {
                Console.WriteLine(numbers[0]);
                return;
            }

            if (numbers.Length == 0) return;

            if (numbers[0] > numbers[1])
                Console.Write($"{numbers[0]} ");

            for (int i = 1; i < numbers.Length - 1; i++)
            {
                if (numbers[i - 1] < numbers[i] && numbers[i] > numbers[i + 1])
                    Console.Write($"{numbers[i]} ");
            }

            if (numbers[numbers.Length - 1] > numbers[numbers.Length - 2])
                Console.WriteLine($"{numbers[numbers.Length - 1]}");
        }
    }
}