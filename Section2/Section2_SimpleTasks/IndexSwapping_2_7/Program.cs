using System;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace IndexSwapping_2_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InclusiveRandom inclusiveRandom = new InclusiveRandom();

            int leftArrayLengthBorder = 2;
            int rightArrayLengthBorder = 15;
            int arrayLength = inclusiveRandom[leftArrayLengthBorder, rightArrayLengthBorder];

            int leftRandomBorder = 0;
            int rightRandomBorder = 100;

            int[] array = new int[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = inclusiveRandom[leftRandomBorder, rightRandomBorder];
            }

            Console.WriteLine(string.Join(" ", array));
            Console.WriteLine("Введите колиство индексов сдвига:");

            int userIndexesCount = int.Parse(Console.ReadLine());

            int[] shiftedArray = MoveElements(array, userIndexesCount);

            Console.WriteLine(string.Join(" ", shiftedArray));
        }

        private static int[] MoveElements(int[] array, int shift)
        {
            if(shift == 0)
                return array;

            shift %= array.Length;

            if (shift < 0)
            {
                shift = -shift;
                return array
                    .Skip(shift)
                    .Concat(array.Take(shift))
                    .ToArray();
            }
            else
            {
                return array
                    .Skip(array.Length - shift)
                    .Concat(array.Take(array.Length - shift))
                    .ToArray();
            }
        }
    }

    public class InclusiveRandom
    {
        Random _random = new Random();

        public int this[int min, int max]
        {
            get { return _random.Next(min, max + 1); }
        }
    }
}
