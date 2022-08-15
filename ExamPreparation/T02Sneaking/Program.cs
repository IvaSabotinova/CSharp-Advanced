using System;
using System.Linq;

namespace T02Sneaking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfRows = int.Parse(Console.ReadLine());

            char[][] matrix = new char[numOfRows][];

            for (int i = 0; i < numOfRows; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }

            int SamRow = 0;
            int SamColumn = 0;
            int NikoladzeRow = 0;
            int NikoladzeColumn = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'S')
                    {
                        SamRow = i;
                        SamColumn = j;
                    }
                    if (matrix[i][j] == 'N')
                    {
                        NikoladzeRow = i;
                        NikoladzeColumn = j;
                    }
                }
            }
            char[] commands = Console.ReadLine().ToCharArray();

            for (int i = 0; i < commands.Length; i++)
            {
                MoveEnemies(matrix, SamRow, SamColumn);
                matrix[SamRow][SamColumn] = '.';
                if (commands[i] == 'U')
                {
                    SamRow--;
                }
                else if (commands[i] == 'D')
                {
                    SamRow++;
                }
                else if (commands[i] == 'L')
                {
                    SamColumn--;
                }
                else if (commands[i] == 'R')
                {
                    SamColumn++;
                }
                else if (commands[i] == 'W')
                {
                    matrix[SamRow][SamColumn] = 'S';
                    continue;
                }
                matrix[SamRow][SamColumn] = 'S';

                if (SamRow == NikoladzeRow)
                {
                    matrix[NikoladzeRow][NikoladzeColumn] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    PrintMatrix(matrix);
                    Environment.Exit(0);
                }

            }

        }

        private static void MoveEnemies(char[][] matrix, int SamRow, int SamColumn)
        {

            for (int i = 0; i < matrix.Length; i++)
            {
                bool hasBMoved = false;
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'b' && j != matrix[i].Length - 1)
                    {
                        if (!hasBMoved)
                        {
                            matrix[i][j] = '.';
                            matrix[i][j + 1] = 'b';
                            hasBMoved = true;
                        }

                    }
                    else if (matrix[i][j] == 'd' && j != 0)
                    {
                        matrix[i][j] = '.';
                        matrix[i][j - 1] = 'd';
                    }
                    else if (matrix[i][j] == 'b' && j == matrix[i].Length - 1 && !hasBMoved)
                    {
                        matrix[i][j] = 'd';
                    }
                    else if (matrix[i][j] == 'd' && j == 0)
                    {
                        matrix[i][j] = 'b';
                    }
                }

            }
            if ((matrix[SamRow].Contains('b') && Array.IndexOf(matrix[SamRow], 'b') < SamColumn)
                || (matrix[SamRow].Contains('d') && Array.IndexOf(matrix[SamRow], 'd') > SamColumn))
            {
                Console.WriteLine($"Sam died at {SamRow}, {SamColumn}");
                matrix[SamRow][SamColumn] = 'X';
                PrintMatrix(matrix);
                Environment.Exit(0);
            }
                        
        }
        private static void PrintMatrix(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join("", matrix[i]));

            }
        }
    }
}
