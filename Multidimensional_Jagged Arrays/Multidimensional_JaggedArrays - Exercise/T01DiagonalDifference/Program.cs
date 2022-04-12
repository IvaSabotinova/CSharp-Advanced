using System;
using System.Linq;

namespace T01DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] squareMatrix = new int[size, size];

            int sumPrimaryDiagonal = 0;
            int sumSecondaryDiagonal = 0;
            for (int i = 0; i < size; i++)
            {
                int[] currentRow = ReadArrayFromConsole();
                for (int j = 0; j < size; j++)
                {

                    squareMatrix[i, j] = currentRow[j];
                    if (i == j)
                    {
                        sumPrimaryDiagonal += squareMatrix[i, j];
                    }

                }
            }

            
            for (int i = 0; i < size; i++)
            {
                sumSecondaryDiagonal += squareMatrix[i, size-1 - i];
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
