using System;

namespace ArrayElements_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[,]
            {
                { 4, 3, 5 },
                { 6, 3, 2 },
                { 7, 3, 1 },
            };

            int sumOfRow = 0;
            int productOfColumn = 1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j]} ");

                Console.WriteLine();
            }

            Console.WriteLine("Введите номер строки, сумму, которой хотите получить");
            int rowForSum = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите номер столбца, произведение, которого хотите получить");
            int columnForProduct = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");

                    if (i == rowForSum - 1)
                        sumOfRow += matrix[i, j];

                    if (j == columnForProduct - 1)
                        productOfColumn *= matrix[i, j];
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Сумма второй строки: {sumOfRow}");
            Console.WriteLine($"Произведение первого столбца: {productOfColumn}");
        }
    }
}
