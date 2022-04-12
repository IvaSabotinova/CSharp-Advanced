using System;
using System.Collections.Generic;
using System.Linq;

namespace T04MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[sizes[0], sizes[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "END")
            {


                if (command[0].ToLower() != "swap" ||
                    (int.TryParse(command[1], out int row1) && (row1 < 0 || row1 >= matrix.GetLength(0))) ||
                    (int.TryParse(command[2], out int col1) && (col1 < 0 || col1 >= matrix.GetLength(1))) ||
                    (int.TryParse(command[3], out int row2) && (row2 < 0 || row2 >= matrix.GetLength(0))) ||
                    (int.TryParse(command[4], out int col2) && (col2 < 0 || col2 >= matrix.GetLength(1))) || command.Length > 5 || command.Length < 5)

                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    int currRow = int.Parse(command[1]);
                    int currColumn = int.Parse(command[2]);
                    int nextRow = int.Parse(command[3]);
                    int nextColumn = int.Parse(command[4]);
                    string temp = matrix[currRow, currColumn];
                    matrix[currRow, currColumn] = matrix[nextRow, nextColumn];
                    matrix[nextRow, nextColumn] = temp;

                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            Console.Write($"{matrix[i, j]} ");
                        }
                        Console.WriteLine();
                    }


                }
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

        }
    }
}
