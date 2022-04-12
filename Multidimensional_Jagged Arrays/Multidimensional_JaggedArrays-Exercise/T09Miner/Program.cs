using System;
using System.Linq;

namespace T09Miner
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[fieldSize, fieldSize];

            string[] commands = ReadArrayFromConsole();
            int currentRow = 0;
            int currentColumn = 0;
            int countOfCoals = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] currRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currRow[j];
                    if (matrix[i, j] == 's')
                    {
                        currentRow = i;
                        currentColumn = j;
                    }

                    if (matrix[i, j] == 'c')
                    {
                        countOfCoals++;
                    }
                }
            }

            for (int i = 0; i < commands.Length; i++)
            {
                string currentCommand = commands[i];
                int oldRow = currentRow;
                int oldColumn = currentColumn;
                if (currentCommand == "up")
                {

                    currentRow -= 1;
                }
                else if (currentCommand == "down")
                {
                    currentRow += 1;
                }
                else if (currentCommand == "right")
                {
                    currentColumn += 1;
                }
                else
                {
                    currentColumn -= 1;
                }

                if (currentRow < 0 || currentRow >= fieldSize)
                {
                    currentRow = oldRow;
                }

                if (currentColumn < 0 || currentColumn >= fieldSize)
                {
                    currentColumn = oldColumn;
                }

                if (IsWithinMatrix(currentRow, currentColumn, fieldSize) && matrix[currentRow, currentColumn] == 'c')
                {
                    countOfCoals--;
                    if (countOfCoals == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({currentRow}, {currentColumn})");
                        return;
                    }

                    matrix[currentRow, currentColumn] = '*';
                }

                if (IsWithinMatrix(currentRow, currentColumn, fieldSize) && matrix[currentRow, currentColumn] == 'e')
                {
                    Console.WriteLine($"Game over! ({currentRow}, {currentColumn})");
                    return;
                }

            }

            Console.WriteLine($"{countOfCoals} coals left. ({currentRow}, {currentColumn})");

        }

        public static string[] ReadArrayFromConsole()
        {
            return Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }

        public static bool IsWithinMatrix(int row, int column, int length)
        {
            return row >= 0 && row < length && column >= 0 && column < length;
        }
    }
}
