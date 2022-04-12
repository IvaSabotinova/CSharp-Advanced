using System;

using System.Linq;

namespace T05SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] matrixSizes = ReadArrayFromConsole();

            int[,] matrix = new int[matrixSizes[0], matrixSizes[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] currentRow = ReadArrayFromConsole();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }
            int biggestSum = int.MinValue;
            int currentSum = 0;
            int row = 0;
            int column = 0;

            for (int i = 0; i < matrix.GetLength(0)-1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    currentSum = matrix[i, j] + matrix[i + 1, j] + matrix[i, j + 1] + matrix[i + 1, j + 1];

                    if (currentSum > biggestSum)
                    {
                        biggestSum = currentSum;
                        row = i;
                        column = j;
                    }
                }
            }

            Console.WriteLine($"{matrix[row, column]} {matrix[row, column+1]}");
            Console.WriteLine($"{matrix[row+1, column]} {matrix[row+1, column+1]}");
            Console.WriteLine(biggestSum);


        }
        private static int[] ReadArrayFromConsole()
        {
            return Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
        }
    }
}
