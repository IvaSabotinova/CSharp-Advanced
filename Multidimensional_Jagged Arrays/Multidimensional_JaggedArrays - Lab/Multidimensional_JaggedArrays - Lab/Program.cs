using System;
using System.Linq;

namespace T01SumMatrixElements
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

            int sum = 0;
            foreach (int element in matrix)
            {
                sum += element;
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);


        }

        private static int[] ReadArrayFromConsole()
        {
            return Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
        }
    }
}
