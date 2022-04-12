using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace T10RadioactiveMutantVampBunnies
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
            .ToArray();

            char[,] lair = new char[sizes[0], sizes[1]];
            int playerCurrentRow = 0;
            int playercurrentColumn = 0;
            List<int[]> listBunnies = new List<int[]>();

            for (int i = 0; i < lair.GetLength(0); i++)
            {
                char[] currRow = Console.ReadLine().ToCharArray();
                for (int j = 0; j < lair.GetLength(1); j++)
                {
                    lair[i, j] = currRow[j];
                    if (lair[i, j] == 'P')
                    {
                        playerCurrentRow = i;
                        playercurrentColumn = j;
                    }

                    if (lair[i, j] == 'B')
                    {
                        int[] bunniesCoordinates = new[] { i, j };
                        listBunnies.Add(bunniesCoordinates);
                    }
                }
            }

            char[] commands = Console.ReadLine().ToCharArray();
            bool hasWon = false;
            int playerOldRow = 0;
            int playerOldColumn = 0;

            for (int i = 0; i < commands.Length; i++)
            {
                char currentCommand = commands[i];
                playerOldRow = playerCurrentRow;
                playerOldColumn = playercurrentColumn;
                if (currentCommand == 'U')
                {
                    playerCurrentRow -= 1;

                }
                else if (currentCommand == 'D')
                {
                    playerCurrentRow += 1;

                }
                else if (currentCommand == 'L')
                {
                    playercurrentColumn -= 1;

                }
                else if (currentCommand == 'R')
                {
                    playercurrentColumn += 1;
                }

                if (IsInLair(playerCurrentRow, playercurrentColumn, lair.GetLength(0), lair.GetLength(1)))
                {
                    if (!IsBunny(playerCurrentRow, playercurrentColumn, lair))
                    {
                        lair[playerOldRow, playerOldColumn] = '.';
                        lair[playerCurrentRow, playercurrentColumn] = 'P';
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    lair[playerOldRow, playerOldColumn] = '.';
                    hasWon = true;
                    break;
                }
                
                lair = BunniesMultiplications(listBunnies, lair);
                listBunnies = Bunnies(lair);

                if (BunnyHasHitPlayer(playerCurrentRow, playercurrentColumn, listBunnies))
                {
                    PrintMatrix(lair);
                    Console.WriteLine($"dead: {playerCurrentRow} {playercurrentColumn}");
                    return;
                }

            }
            lair = BunniesMultiplications(listBunnies, lair);
            PrintMatrix(lair);
            if (hasWon)
            {
                Console.WriteLine($"won: {playerOldRow} {playerOldColumn}");
            }
            else
            {

                Console.WriteLine($"dead: {playerCurrentRow} {playercurrentColumn}");
            }

        }

        public static bool IsInLair(int row, int column, int lengthRow, int lengthColumn)
        {
            return row >= 0 && row < lengthRow && column >= 0 && column < lengthColumn;
        }

        public static bool IsBunny(int row, int column, char[,] matrix)
        {
            return matrix[row, column] == 'B';

        }

        public static char[,] BunniesMultiplications(List<int[]> list, char[,] matrix)
        {
            int count = list.Count;
            for (int i = 0; i < count; i++)
            {
                int row = list[i][0];
                int column = list[i][1];

                if (row + 1 < matrix.GetLength(0))
                {
                    matrix[row + 1, column] = 'B';
                }
                if (row - 1 >= 0)
                {

                    matrix[row - 1, column] = 'B';
                }
                if (column + 1 < matrix.GetLength(1))
                {
                    matrix[row, column + 1] = 'B';
                }
                if (column - 1 >= 0)
                {
                    matrix[row, column - 1] = 'B';
                }
            }

            return matrix;
        }

        public static List<int[]> Bunnies(char[,] matrix)
        {
            List<int[]> bunnies = new List<int[]>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'B')
                    {
                        bunnies.Add(new[] { i, j });
                    }
                }
            }

            return bunnies;
        }

        public static bool BunnyHasHitPlayer(int playerRow, int playerColumn, List<int[]> bunnies)
        {
            foreach (int[] bunny in bunnies)
            {
                if (bunny[0] == playerRow && bunny[1] == playerColumn)
                {
                    return true;
                }
            }
            return false;
        }

        public static void PrintMatrix(char[,] matrix)
        {

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }

                Console.WriteLine();
            }

        }
    }
}

    




