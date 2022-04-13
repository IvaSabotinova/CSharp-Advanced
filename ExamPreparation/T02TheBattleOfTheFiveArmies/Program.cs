using System;



namespace T02TheBattleOfTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {

            int armorvalue = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            char[][] matrix = new char[size][];
            int armyRow = 0;
            int armyCol = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'A')
                    {
                        armyRow = i;
                        armyCol = j;
                    }
                }
            }

            while (true)
            {

                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = command[0];
                int currRow = int.Parse(command[1]);
                int currCol = int.Parse(command[2]);

                matrix[currRow][currCol] = 'O';

                int oldArmyRow = armyRow;
                int oldArmyCol = armyCol;
                matrix[armyRow][armyCol] = '-';
                armorvalue--;
                switch (direction)
                {
                    case "up":
                        armyRow--;
                        break;
                    case "down":
                        armyRow++;
                        break;
                    case "left":
                        armyCol--;
                        break;
                    case "right":
                        armyCol++;
                        break;
                }

                if (IsWithinMatrix(matrix, armyRow, armyCol))
                {

                    if (matrix[armyRow][armyCol] == 'O')
                    {
                        armorvalue -= 2;
                    }
                    else if (matrix[armyRow][armyCol] == 'M')
                    {
                        matrix[armyRow][armyCol] = '-';
                        Console.WriteLine($"The army managed to free the Middle World! Armor left: {armorvalue}");
                        PrintMatrix(matrix);
                        Environment.Exit(0);
                    }
                    else
                    {
                        matrix[armyRow][armyCol] = 'A';
                    }

                }
                else if (!IsWithinMatrix(matrix, armyRow, armyCol))
                {
                    armyRow = oldArmyRow;
                    armyCol = oldArmyCol;
                    matrix[armyRow][armyCol] = 'A';
                }

                if (armorvalue <= 0)
                {
                    matrix[armyRow][armyCol] = 'X';
                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                    PrintMatrix(matrix);
                    return;
                }

            }

        }

        public static bool IsWithinMatrix(char[][] matrix, int row, int col)
            => row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;

        public static void PrintMatrix(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join("", matrix[i]));
            }
        }
    }
}
