using System;

namespace _2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int rows = 10;
            int columns = 10;
            int min = 0;
            int max = 16;

            int[,] nums = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    nums[i, j] = random.Next(min, max);
                }
            }

            int maxElement = nums[0, 0];

            Console.WriteLine("Изначальная матрица: ");

            for (int i = 0;i < rows; i++)
            {
                for (int j = 0;j < columns; j++)
                {
                    Console.Write(nums[i,j]+"\t");

                    if (nums[i,j] > maxElement)
                    {
                        maxElement = nums[i,j];
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine($"\nМаксимальный элемент: {maxElement}");

            int numberForReplacement = 0;

            Console.WriteLine("\nИзмененная матрица:");

            for (int i = 0;i<rows; i++)
            {
                for(int j = 0;j<columns; j++)
                {
                    if (nums[i,j] == maxElement)
                    {
                        nums[i, j] = numberForReplacement;
                    }

                    Console.Write(nums[i, j] + "\t");
                }

                Console.WriteLine();
            }
        }
    }
}
