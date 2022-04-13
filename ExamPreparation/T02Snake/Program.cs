using System;

namespace T02Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            int snakeRow = 0;
            int snakeCol = 0;
            int firstBurrowRow = 0;
            int firstBurrowCol = 0;
            int secondBurrowRow = 0;
            int secondBurrowCol = 0;
            int burrowsCount = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] currRow = Console.ReadLine().ToCharArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currRow[j];
                    if (matrix[i, j] == 'S')
                    {
                        snakeRow = i;
                        snakeCol = j;
                    }

                    if (matrix[i, j] == 'B')
                    {
                        if (burrowsCount == 0)
                        {
                            firstBurrowRow = i;
                            firstBurrowCol = j;
                        }
                        else
                        {
                            secondBurrowRow = i;
                            secondBurrowCol = j;
                        }
                    }
                }
            }

            int foodQuantity = 0;
            while (true)
            {
                string command = Console.ReadLine();
                matrix[snakeRow, snakeCol] = '.';
                switch (command)
                {
                    case "up": snakeRow--; break;
                    case "down": snakeRow++; break;
                    case "left": snakeCol--; break;
                    case "right": snakeCol++; break;
                }

                if (!IsWithinMatrix(matrix, snakeRow, snakeCol))
                {
                    Console.WriteLine("Game over!");
                    break;
                }
                else
                {
                    if (matrix[snakeRow, snakeCol] == '*')
                    {
                        foodQuantity++;
                        if (foodQuantity == 10)
                        {
                            matrix[snakeRow, snakeCol] = 'S';
                            Console.WriteLine("You won! You fed the snake.");
                            break;
                        }
                        
                    }
                    else if (matrix[snakeRow, snakeCol] == 'B')
                    {
                        if (snakeRow == firstBurrowRow && snakeCol == firstBurrowCol)
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            snakeRow = secondBurrowRow;
                            snakeCol = secondBurrowCol;
                        }
                        else
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            snakeRow = firstBurrowRow;
                            snakeCol = firstBurrowCol;
                        }
                    }

                    matrix[snakeRow, snakeCol] = 'S';
                }


            }

            Console.WriteLine($"Food eaten: {foodQuantity}");
            PrintMatrix(matrix);
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
