using System;
using System.Linq;

namespace T02SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] matrixSizes = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[matrixSizes[0], matrixSizes[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[]currentRow = ReadArrayFromConsole();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int sumCurrentColumn = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    sumCurrentColumn += matrix[j, i];
                }

                Console.WriteLine(sumCurrentColumn);
            }

        }
        private static int[] ReadArrayFromConsole()
        {
            return Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
        }
    }
}
