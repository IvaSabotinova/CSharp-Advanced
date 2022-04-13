using System;


namespace T02Re_Volt
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


                if (IsWithinMatrix(matrix, playerRow, playerCol))
                {
                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        int playerNewRow = RowMoveAgain(command, playerRow);
                        int playerNewCol = ColMoveAgain(command, playerCol);
                        playerRow = playerNewRow;
                        playerCol = playerNewCol;
                        int newPlayerRow = RowOfPlayerComingFromOppositeEnd(matrix, playerRow);
                        int newPlayerCol = ColOfPlayerComingFromOppositeEnd(matrix, playerCol);
                        playerRow = newPlayerRow;
                        playerCol = newPlayerCol;

                    }
                    if (matrix[playerRow, playerCol] == 'T')
                    {
                        playerRow = playerOldRow;
                        playerCol = playerOldCol;
                        matrix[playerRow, playerCol] = 'f';
                    }
                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = 'f';
                        Console.WriteLine("Player won!");
                        PrintMatrix(matrix);
                        return;
                    }

                }
                if (!IsWithinMatrix(matrix, playerRow, playerCol))
                {
                    int newPlayerRow = RowOfPlayerComingFromOppositeEnd(matrix, playerRow);
                    int newPlayerCol = ColOfPlayerComingFromOppositeEnd(matrix, playerCol);
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;

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

        public static int RowMoveAgain(string command, int playerRow)
        {
            switch (command)
            {
                case "up": return --playerRow;
                case "down": return ++playerRow;
            }

            return playerRow;

        }
        public static int ColMoveAgain(string command, int playerCol)
        {
            switch (command)
            {
                case "left": return --playerCol;
                case "right": return ++playerCol;
            }

            return playerCol;

        }

        public static int RowOfPlayerComingFromOppositeEnd(char[,] field, int playerRow)
        {
            if (playerRow == -1)
            {
                return field.GetLength(0) - 1;
            }
            if (playerRow == field.GetLength(0))
            {
                return 0;
            }
            return playerRow;
        }
        public static int ColOfPlayerComingFromOppositeEnd(char[,] field, int playerCol)
        {
            if (playerCol == -1)
            {
                return field.GetLength(1) - 1;
            }
            if (playerCol == field.GetLength(1))
            {
                return 0;
            }
            return playerCol;
        }

        public static bool IsWithinMatrix(char[,] matrix, int row, int col)
            => row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
    }
}


