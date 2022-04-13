using System;


namespace T02Bee
{
    class Program
    {
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int beeRow = 0;
            int beeCol = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] currRow = Console.ReadLine().ToCharArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currRow[j];
                    if (matrix[i, j] == 'B')
                    {
                        beeRow = i;
                        beeCol = j;
                    }
                }
            }

            int countofPollinatedFlowers = 0;
            string command;
            while ((command = Console.ReadLine()) != "End")
            {

                matrix[beeRow, beeCol] = '.';
                if (command == "up")
                {
                    beeRow--;
                }
                else if (command == "down")
                {
                    beeRow++;
                }
                else if (command == "right")
                {
                    beeCol++;
                }
                else if (command == "left")
                {
                    beeCol--;
                }

                if (!IsWithinMatrix(matrix, beeRow, beeCol))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (matrix[beeRow, beeCol] == 'O')
                {
                    matrix[beeRow, beeCol] = '.';
                    MoveAgain(command, ref beeRow, ref beeCol);
                }
                if (matrix[beeRow, beeCol] == 'f')
                {
                    countofPollinatedFlowers++;

                }

                matrix[beeRow, beeCol] = 'B';
            }

            if (countofPollinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {countofPollinatedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - countofPollinatedFlowers} flowers more");
            }
            PrintMatrix(matrix);
            
        }

        private static void MoveAgain(string command, ref int beeRow, ref int beeCol)
        {
            switch (command)
            {
                case "up": beeRow--; break;
                case "down": beeRow++; break;
                case "left": beeCol--; break;
                case "right": beeCol++; break;
            }
        }

        public static bool IsWithinMatrix(char[,] matrix, int row, int col)
            => row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);

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
    }
}
