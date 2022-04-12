using System;


using System.Linq;

namespace T08Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizes = int.Parse(Console.ReadLine());

            int[,] matrix = new int[sizes, sizes];

            for (int i = 0; i < sizes; i++)
            {
                int[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int j = 0; j < sizes; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            int[] bombs = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();


            for (int i = 0; i < bombs.Length - 1; i += 2)
            {
                int bombCurrentRow = bombs[i];
                int bombCurrentColumn = bombs[i + 1];
                int bombValue = matrix[bombCurrentRow, bombCurrentColumn];
                if (IsInMatrix(bombCurrentRow, bombCurrentColumn, sizes) && IsAlive(bombValue))
                {
                    matrix[bombCurrentRow, bombCurrentColumn] = 0;
                    if (IsInMatrix(bombCurrentRow - 1, bombCurrentColumn - 1, sizes) &&
                        IsAlive(matrix[bombCurrentRow - 1, bombCurrentColumn - 1]))
                    {
                        matrix[bombCurrentRow - 1, bombCurrentColumn - 1] -= bombValue;
                    }
                    if (IsInMatrix(bombCurrentRow - 1, bombCurrentColumn, sizes) &&
                        IsAlive(matrix[bombCurrentRow - 1, bombCurrentColumn]))
                    {
                        matrix[bombCurrentRow - 1, bombCurrentColumn] -= bombValue;
                    }
                    if (IsInMatrix(bombCurrentRow - 1, bombCurrentColumn + 1, sizes) &&
                        IsAlive(matrix[bombCurrentRow - 1, bombCurrentColumn + 1]))
                    {
                        matrix[bombCurrentRow - 1, bombCurrentColumn + 1] -= bombValue;
                    }
                    if (IsInMatrix(bombCurrentRow, bombCurrentColumn - 1, sizes) &&
                        IsAlive(matrix[bombCurrentRow, bombCurrentColumn - 1]))
                    {
                        matrix[bombCurrentRow, bombCurrentColumn - 1] -= bombValue;
                    }
                    if (IsInMatrix(bombCurrentRow, bombCurrentColumn + 1, sizes) &&
                        IsAlive(matrix[bombCurrentRow, bombCurrentColumn + 1]))
                    {
                        matrix[bombCurrentRow, bombCurrentColumn + 1] -= bombValue;
                    }
                    if (IsInMatrix(bombCurrentRow + 1, bombCurrentColumn - 1, sizes) &&
                        IsAlive(matrix[bombCurrentRow + 1, bombCurrentColumn - 1]))
                    {
                        matrix[bombCurrentRow + 1, bombCurrentColumn - 1] -= bombValue;
                    }
                    if (IsInMatrix(bombCurrentRow + 1, bombCurrentColumn, sizes) &&
                        IsAlive(matrix[bombCurrentRow + 1, bombCurrentColumn]))
                    {
                        matrix[bombCurrentRow + 1, bombCurrentColumn] -= bombValue;
                    }
                    if (IsInMatrix(bombCurrentRow + 1, bombCurrentColumn + 1, sizes) &&
                        IsAlive(matrix[bombCurrentRow + 1, bombCurrentColumn + 1]))
                    {
                        matrix[bombCurrentRow + 1, bombCurrentColumn + 1] -= bombValue;
                    }
                }
            }

            int countOfAliveCells = 0;
            int sumOfAliveCells = 0;
            foreach (int number in matrix)
            {
                if (number > 0)
                {
                    countOfAliveCells++;
                    sumOfAliveCells += number;
                }
            }

            Console.WriteLine($"Alive cells: {countOfAliveCells}");
            Console.WriteLine($"Sum: {sumOfAliveCells}");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }
        
        public static bool IsInMatrix(int row, int column, int matrixLength)
        {
            return row >= 0 && row < matrixLength && column >= 0 && column < matrixLength;

        }
        public static bool IsAlive(int number)
        {
            return number > 0;
        }
    }
}
