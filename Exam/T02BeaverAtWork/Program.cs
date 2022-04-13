using System;
using System.Collections.Generic;
using System.Linq;


namespace T02BeaverAtWork
{
    class Program
    {
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            int beaverRow = 0;
            int beaverCol = 0;
            int countOfWoods = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] currRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse)
                    .ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currRow[j];
                    if (matrix[i, j] == 'B')
                    {
                        beaverRow = i;
                        beaverCol = j;
                    }

                    if (Char.IsLower(matrix[i, j]))
                    {
                        countOfWoods++;
                    }

                }
            }

            int initialCountOfWoods = countOfWoods;
            string command;
            List<char> collectedWoods = new List<char>();
            while ((command = Console.ReadLine()) != "end")
            {
                int oldBeaverRow = beaverRow;
                int oldbeaverCol = beaverCol;
                matrix[beaverRow, beaverCol] = '-';
                if (command == "up")
                {
                    beaverRow--;
                }
                else if (command == "down")
                {
                    beaverRow++;
                }
                else if (command == "left")
                {
                    beaverCol--;
                }
                else if (command == "right")
                {
                    beaverCol++;
                }

                if (!IsWIthinMatrix(matrix, beaverRow, beaverCol))
                {
                    if (collectedWoods.Count > 0)
                    {
                        collectedWoods.RemoveAt(collectedWoods.Count - 1);
                        initialCountOfWoods--;
                    }
                    beaverRow = oldBeaverRow;
                    beaverCol = oldbeaverCol;
                }
                else if (IsWIthinMatrix(matrix, beaverRow, beaverCol))
                {
                    if (Char.IsLower(matrix[beaverRow, beaverCol]))
                    {
                        collectedWoods.Add(matrix[beaverRow, beaverCol]);
                        countOfWoods--;
                        matrix[beaverRow, beaverCol] = 'B';
                        if (countOfWoods == 0)
                        {
                            break;
                        }

                    }
                    else if (matrix[beaverRow, beaverCol] == 'F' && beaverRow != 0 && beaverCol != 0 &&
                             beaverRow != matrix.GetLength(0) - 1 && beaverCol != matrix.GetLength(1))
                    {
                        matrix[beaverRow, beaverCol] = '-';
                        MovesToEnd(matrix, command, ref beaverRow, ref beaverCol);
                    }
                    else if (matrix[beaverRow, beaverCol] == 'F' && (beaverRow == 0 || beaverCol == 0 ||
                                                                     beaverRow == matrix.GetLength(0) - 1 ||
                                                                     beaverCol == matrix.GetLength(1)))
                    {
                        matrix[beaverRow, beaverCol] = '-';
                        SwimsOppositeEnd(matrix, command, ref beaverRow, ref beaverCol);
                        if (Char.IsLetter(matrix[beaverRow, beaverCol]))
                        {
                            collectedWoods.Add(matrix[beaverRow, beaverCol]);
                        }
                    }

                }
                matrix[beaverRow, beaverCol] = 'B';
            }

            if (initialCountOfWoods == collectedWoods.Count)
            {
                Console.WriteLine(
                    $"The Beaver successfully collect {collectedWoods.Count} wood branches: {string.Join(", ", collectedWoods)}.");
            }
            else
            {
                Console.WriteLine(
                    $"The Beaver failed to collect every wood branch. There are {initialCountOfWoods - collectedWoods.Count} branches left.");
            }

            PrintMatrix(matrix);

        }

        private static void SwimsOppositeEnd(char[,] matrix, string command, ref int beaverRow, ref int beaverCol)
        {

            if (command == "up")
            {
                beaverRow = matrix.GetLength(0) - 1;
            }
            else if (command == "down")
            {
                beaverRow = 0;
            }
            else if (command == "right")
            {
                beaverCol = 0;
            }
            else if (command == "left")
            {
                beaverCol = matrix.GetLength(1) - 1;
            }
        }

        private static void MovesToEnd(char[,] matrix, string command, ref int beaverRow, ref int beaverCol)
        {
            if (command == "up")
            {
                beaverRow = 0;
            }
            else if (command == "down")
            {
                beaverRow = matrix.GetLength(0) - 1;
            }
            else if (command == "left")
            {
                beaverCol = 0;
            }
            else if (command == "right")
            {
                beaverCol = matrix.GetLength(1) - 1;
            }
        }

        public static bool IsWIthinMatrix(char[,] matrix, int row, int col)
            => row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);

        public static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }

        }
    }
}
