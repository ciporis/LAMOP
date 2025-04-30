using System;

namespace Repeats_2_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int arrayLength = 30;
            int leftRandomBorder = 0;
            int rightRandomBorder = 100;

            int[] array = new int[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = InclusiveRandom.InclusiveNext(leftRandomBorder, rightRandomBorder);
            }

            int maxRepeatsCount = 0;
            int repeatsCount = 0;
            int repeatingNumber = 0;

            for (int i = 0; i < arrayLength - 1; i++)
            {
                if (array[i] == array[i + 1])
                {
                    repeatsCount++;
                    
                    if(repeatsCount > maxRepeatsCount)
                    {
                        maxRepeatsCount = repeatsCount + 1;
                        repeatingNumber = array[i];
                    }
                }
                else
                {
                    repeatsCount = 0;
                }
            }

            Console.WriteLine($"Array: {string.Join(" ", array)}");
            Console.WriteLine($"Number: {repeatingNumber}\nMax repeats: {maxRepeatsCount}");
        }

        public static class InclusiveRandom
        {
            private static Random s_random = new Random();

            public static int InclusiveNext(int min, int max)
            {
                return s_random.Next(min, max + 1);
            }
        }
    }
}