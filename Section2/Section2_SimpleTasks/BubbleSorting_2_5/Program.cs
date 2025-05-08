using System;   

namespace BubbleSorting_2_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minLength = 10;
            int maxLength = 100;

            int minNumber = 0;
            int maxNumber = 100;

            ModifiedRandom random = new ModifiedRandom();

            int arrayLength = random[minLength, maxLength];
            int[] array = new int[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = random[minNumber, maxNumber];
            }

            Console.WriteLine($"Before: {string.Join(" ", array)}");
            Console.WriteLine($"After: {string.Join(" ", GetSortedArray(array))}");
        }

        public static int[] GetSortedArray(int[] array)
        {
            int arrayLength = array.Length;
            bool isSorted = false;
            int sortedPairsCount = 0;

            while (isSorted == false)
            {
                for (int i = 0; i < arrayLength - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                    else
                    {
                        sortedPairsCount++;

                        if(sortedPairsCount == arrayLength - 1)
                        {
                            isSorted = true;
                        }
                    }
                }

                sortedPairsCount = 0;
            }

            return array;
        }
    }

    public class ModifiedRandom
    {
        private Random _random = new Random();

        public int this[int min, int max]
        {
            get { return _random.Next(min, max + 1); }
        }
    }
}
