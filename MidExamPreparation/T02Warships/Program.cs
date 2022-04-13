using System;
using System.Linq;

namespace T02Warships
{
    class Program
    {
        static void Main(string[] args)
        {

            int sizes = int.Parse(Console.ReadLine());

            char[,] field = new char[sizes, sizes];

            int[] attacks = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int numOfShips_FirstPlayer = 0;
            int numOfShips_SecondPlayer = 0;

            for (int i = 0; i < field.GetLength(0); i++)
            {
                string rowInput = Console.ReadLine();
                char[] curRow = rowInput.Replace(" ", "").ToCharArray();
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = curRow[j];
                    if (field[i, j] == '<')
                    {
                        numOfShips_FirstPlayer++;
                    }

                    if (field[i, j] == '>')
                    {
                        numOfShips_SecondPlayer++;
                    }
                }
            }

            int initialNumShipsFirstPlayer = numOfShips_FirstPlayer;
            int initialNumOfShipsSecondPlayer = numOfShips_SecondPlayer;

            for (int i = 0; i < attacks.Length - 1; i += 2)
            {
                int attackRow = attacks[i];
                int attackCol = attacks[i + 1];

                if (IsInsideField(attackRow, attackCol, field) && field[attackRow, attackCol] == '#')
                {
                    MineExplosion(field, attackRow, attackCol);
                    int[] shipsLeft = CheckLeftShips(field);
                    numOfShips_FirstPlayer = shipsLeft[0]; ;
                    numOfShips_SecondPlayer = shipsLeft[1];
                }
                else if (IsInsideField(attackRow, attackCol, field) && field[attackRow, attackCol] == '<')
                {
                    numOfShips_FirstPlayer--;
                    field[attackRow, attackCol] = 'X';
                }
                else if (IsInsideField(attackRow, attackCol, field) && field[attackRow, attackCol] == '>')
                {
                    numOfShips_SecondPlayer--;
                    field[attackRow, attackCol] = 'X';
                }

                if (numOfShips_FirstPlayer <= 0)
                {
                    Console.WriteLine($"Player Two has won the game! {initialNumShipsFirstPlayer + initialNumOfShipsSecondPlayer - numOfShips_FirstPlayer - numOfShips_SecondPlayer} ships have been sunk in the battle.");
                    return;
                }
                else if (numOfShips_SecondPlayer <= 0)
                {
                    Console.WriteLine($"Player One has won the game! {initialNumShipsFirstPlayer + initialNumOfShipsSecondPlayer - numOfShips_FirstPlayer - numOfShips_SecondPlayer} ships have been sunk in the battle.");
                    Environment.Exit(0);
                }

            }

            Console.WriteLine($"It's a draw! Player One has {numOfShips_FirstPlayer} ships left. Player Two has {numOfShips_SecondPlayer} ships left.");

        }

        public static int[] CheckLeftShips(char[,] field)
        {
            int[] leftShips = new int[2];
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == '<')
                    {
                        leftShips[0]++;
                    }

                    if (field[i, j] == '>')
                    {
                        leftShips[1]++;
                    }
                }
            }

            return leftShips;
        }

        public static void MineExplosion(char[,] field, int mineRow, int mineCol)
        {

            if (IsInsideField(mineRow - 1, mineCol, field))
            {
                field[mineRow - 1, mineCol] = 'X';
            }

            if (IsInsideField(mineRow + 1, mineCol, field))
            {
                field[mineRow + 1, mineCol] = 'X';
            }

            if (IsInsideField(mineRow, mineCol - 1, field))
            {
                field[mineRow, mineCol - 1] = 'X';
            }

            if (IsInsideField(mineRow, mineCol + 1, field))
            {
                field[mineRow, mineCol + 1] = 'X';
            }

            if (IsInsideField(mineRow - 1, mineCol - 1, field))
            {
                field[mineRow - 1, mineCol - 1] = 'X';
            }

            if (IsInsideField(mineRow - 1, mineCol + 1, field))
            {
                field[mineRow - 1, mineCol + 1] = 'X';
            }

            if (IsInsideField(mineRow + 1, mineCol - 1, field))
            {
                field[mineRow + 1, mineCol - 1] = 'X';
            }

            if (IsInsideField(mineRow + 1, mineCol + 1, field))
            {
                field[mineRow + 1, mineCol + 1] = 'X';
            }

        }

        public static bool IsInsideField(int row, int column, char[,] field)
        {
            return row >= 0 && row < field.GetLength(0) && column >= 0 && column < field.GetLength(1);
        }

    }
}
