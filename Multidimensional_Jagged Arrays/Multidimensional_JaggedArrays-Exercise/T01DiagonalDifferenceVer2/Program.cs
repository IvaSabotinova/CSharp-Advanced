using System;

using System.Linq;

namespace T01DiagonalDifferenceVer2
{
    class Program
    {
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());

            int[,] squareMatrix = new int[size, size];

            int sumPrimaryDiagonal = 0;
            int sumSecondaryDiagonal = 0;

            for (int i = 0; i < squareMatrix.GetLength(0); i++)
            {
                int[] currentRow = ReadArrayFromConsole();
                for (int j = 0; j < squareMatrix.GetLength(1); j++)
                {
                    squareMatrix[i, j] = currentRow[j];
                    if (i == j)
                    {
                        sumPrimaryDiagonal += squareMatrix[i, j];
                    }
                }
            }


            for (int i = 0, j = squareMatrix.GetLength(0) - 1; i < size; i++, j--)
            {
                sumSecondaryDiagonal += squareMatrix[j, i];
            }

            Console.WriteLine(Math.Abs(sumPrimaryDiagonal-sumSecondaryDiagonal));

            

        }
        private static int[] ReadArrayFromConsole()
        {
            return Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
        }
    }
}
