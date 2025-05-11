using System;
using System.Collections.Generic;

namespace Shuffling_3_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minLength = 1;
            int maxLength = 10;

            int arrayLength = InclusiveRandom.Next(minLength, maxLength);
            var array = new int[arrayLength];

            int minArrayItem = 0;
            int maxArrayItem = 99;

            for (int i = 0; i < arrayLength; i++)
                array[i] = InclusiveRandom.Next(minArrayItem, maxArrayItem);

            Console.WriteLine(string.Join(" ", array));
            ShuffleArray(ref array);
            Console.WriteLine(string.Join(" ", array));
        }

        static void ShuffleArray(ref int[] array)
        {
            var shuffledArray = new List<int>();
            int startIndex = 0;
            int endIndex = array.Length - 1;

            var randomIndexes = new List<int>();

            for (int i = startIndex; i <= endIndex; i++)
            {
                int randomIndex = InclusiveRandom.Next(startIndex, endIndex);

                while (randomIndexes.Contains(randomIndex))
                {
                    randomIndex = InclusiveRandom.Next(startIndex, endIndex);
                }

                randomIndexes.Add(randomIndex);
            }

            for (int i = startIndex; i <= endIndex; i++)
                shuffledArray.Add(array[randomIndexes[i]]);

            array = shuffledArray.ToArray();
        }
    }

    public static class InclusiveRandom
    {
        private static Random s_random = new Random();
        
        public static int Next(int min, int max)
        {
            return s_random.Next(min, max + 1);
        }
    }
}