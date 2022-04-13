using System;

namespace T02Re_VoltVer2
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int numOfCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];
            int playerRow = 0;
            int playerCol = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] curRow = Console.ReadLine().ToCharArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = curRow[j];
                    if (matrix[i, j] == 'f')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }

            for (int i = 0; i < numOfCommands; i++)
            {
                string command = Console.ReadLine();
                int playerOldRow = playerRow;
                int playerOldCol = playerCol;
                matrix[playerRow, playerCol] = '-';
                switch (command)
                {
                    case "up":
                        playerRow--; break;
                    case "down":
                        playerRow++; break;
                    case "left":
                        playerCol--; break;
                    case "right":
                        playerCol++; break;
                }
                if (!IsWithinMatrix(matrix, playerRow, playerCol))
                {
                    PlayerComingFromOppositeEnd(matrix, ref playerRow, ref playerCol);
                }

                if (IsWithinMatrix(matrix, playerRow, playerCol))
                {
                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        MoveAgain(command, ref playerRow, ref playerCol);
                        PlayerComingFromOppositeEnd(matrix, ref playerRow, ref playerCol);

                    }
                    if (matrix[playerRow, playerCol] == 'T')
                    {
                        playerRow = playerOldRow;
                        playerCol = playerOldCol;

                    }
                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = 'f';
                        Console.WriteLine("Player won!");
                        PrintMatrix(matrix);
                        return;
                    }
                }

                matrix[playerRow, playerCol] = 'f';

            }

            Console.WriteLine("Player lost!");
            PrintMatrix(matrix);
        }

        public static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        public static void MoveAgain(string command, ref int playerRow, ref int playerCol)
        {
            switch (command)
            {
                case "up": playerRow -= 1; break;
                case "down": playerRow += 1; break;
                case "left": playerCol -= 1; break;
                case "right": playerCol += 1; break;
            }
        }

        public static void PlayerComingFromOppositeEnd(char[,] field, ref int playerRow, ref int playerCol)
        {
            if (playerRow == -1)
            {
                playerRow = field.GetLength(0) - 1;
            }

            if (playerRow == field.GetLength(0))
            {
                playerRow = 0;
            }

            if (playerCol == -1)
            {
                playerCol = field.GetLength(1) - 1;
            }

            if (playerCol == field.GetLength(1))
            {
                playerCol = 0;
            }

        }

        public static bool IsWithinMatrix(char[,] matrix, int row, int col)
            => row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
    }
}

