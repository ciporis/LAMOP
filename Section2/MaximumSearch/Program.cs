using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите кол-во строк матрицы");
            int matrixRows = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите кол-во столбцов матрицы");
            int matrixColumns = Convert.ToInt32(Console.ReadLine());

            int[,] matrix = new int[matrixRows,matrixColumns];

            Random random = new Random();
            int rightRandomBorder = 100;

            int maxMatrixNumber = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(rightRandomBorder);
                    Console.Write($"{matrix[i, j]} ");
                }               
                
                Console.WriteLine();
            }

            Console.WriteLine();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxMatrixNumber)
                        maxMatrixNumber = matrix[i, j];
                }
            }

            Console.WriteLine($"Максимальный элемент: {maxMatrixNumber}");
            Console.WriteLine();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(matrix[i, j] == maxMatrixNumber)
                        matrix[i, j] = 0;
                    
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
