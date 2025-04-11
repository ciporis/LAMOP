using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[10,10];

            Random random = new Random();
            int rightRandomBorder = 100;

            List<int> matrixElements = new List<int>(); 

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(rightRandomBorder);
                    matrixElements.Add(matrix[i, j]);
                    Console.Write($"{matrix[i, j]} ");
                }                
                Console.WriteLine();
            }
            Console.WriteLine();

            int maxMatrixElement = matrixElements.Max();

            Console.WriteLine($"Максимальный элемент: {maxMatrixElement}");
            Console.WriteLine();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(matrix[i, j] == maxMatrixElement)
                        matrix[i, j] = 0;
                    
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
