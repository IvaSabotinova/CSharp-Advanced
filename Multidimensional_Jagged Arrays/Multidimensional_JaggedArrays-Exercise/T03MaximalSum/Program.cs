using System;
using System.Linq;

namespace T03MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] sizes = ReadArrayFromConsole();

            int[,] matrix = new int[sizes[0], sizes[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] currentRow = ReadArrayFromConsole();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            int maxSum3x3 = Int32.MinValue;
            int row = 0;
            int column = 0;

            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    int currentSum3x3 = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] + matrix[i + 1, j] +
                                matrix[i + 1, j + 1] + matrix[i + 1, j + 2] + matrix[i + 2, j] + matrix[i + 2, j + 1] +
                                matrix[i + 2, j + 2];
                    if (currentSum3x3 > maxSum3x3)
                    {
                        maxSum3x3 = currentSum3x3;
                        row = i;
                        column = j;
                    }

                }
            }

            Console.WriteLine($"Sum = {maxSum3x3}");
            Console.WriteLine($"{matrix[row, column]} {matrix[row, column + 1]} {matrix[row, column + 2]}");
            Console.WriteLine($"{matrix[row + 1, column]} {matrix[row + 1, column + 1]} {matrix[row + 1, column + 2]}");
            Console.WriteLine($"{matrix[row + 2, column]} {matrix[row + 2, column + 1]} {matrix[row + 2, column + 2]}");
            

        }
        private static int[] ReadArrayFromConsole()
        {
            return Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            
        }
    }
}
