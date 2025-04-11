using System;

namespace ArrayElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix =
            {
                { 4, 3, 5 },
                { 6, 3, 2 },
                { 7, 3, 1 },
            };

            int sumOfSecondRow = 0;
            int productOfFirstColumn = 1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                    if (i == 1)
                        sumOfSecondRow += matrix[i, j];
                    if(j == 0)
                        productOfFirstColumn *= matrix[i, j];
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Сумма второй строки: {sumOfSecondRow}");
            Console.WriteLine($"Произведение первого столбца: {productOfFirstColumn}");
        }
    }
}
