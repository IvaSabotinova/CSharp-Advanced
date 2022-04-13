using System;

namespace T02Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];
            int myPosRow = 0;
            int myPosCol = 0;
            int firstPillarRow = 0;
            int firstPillarCol = 0;
            int secondPillarRow = 0;
            int secondPillarCol = 0;
            int countOfPillars = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] currRow = Console.ReadLine().ToCharArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currRow[j];
                    if (matrix[i, j] == 'S')
                    {
                        myPosRow = i;
                        myPosCol = j;
                    }

                    if (matrix[i, j] == 'O')
                    {
                        if (countOfPillars == 0)
                        {
                            firstPillarRow = i;
                            firstPillarCol = j;
                            countOfPillars++;
                        }
                        else
                        {
                            secondPillarRow = i;
                            secondPillarCol = j;
                        }

                    }

                }
            }

            int collectedMoney = 0;

            while (true)
            {
                if (collectedMoney >= 50)
                {
                    break;
                }
                string command = Console.ReadLine();

                matrix[myPosRow, myPosCol] = '-';
                if (command == "up")
                {
                    myPosRow--;
                }
                else if (command == "down")
                {
                    myPosRow++;
                }
                else if (command == "left")
                {
                    myPosCol--;
                }
                else if (command == "right")
                {
                    myPosCol++;
                }

                if (!IsWithinmatrix(matrix, myPosRow, myPosCol))
                {
                    break;
                }
                if (IsWithinmatrix(matrix, myPosRow, myPosCol))
                {
                    if (char.IsDigit(matrix[myPosRow, myPosCol]))
                    {
                        collectedMoney += int.Parse(matrix[myPosRow, myPosCol].ToString());

                    }
                    else if (matrix[myPosRow, myPosCol] == 'O')
                    {
                        if (myPosRow == firstPillarRow && myPosCol == firstPillarCol)
                        {
                            matrix[myPosRow, myPosCol] = '-';
                            myPosRow = secondPillarRow;
                            myPosCol = secondPillarCol;
                        }
                        else if (myPosRow == secondPillarRow && myPosCol == secondPillarCol)
                        {
                            matrix[myPosRow, myPosCol] = '-';
                            myPosRow = firstPillarRow;
                            myPosCol = firstPillarCol;

                        }
                    }
                    matrix[myPosRow, myPosCol] = 'S';
                }

            }

            if (collectedMoney >= 50)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            else
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }

            Console.WriteLine($"Money: {collectedMoney}");
            PrintMatrix(matrix);

        }

        public static bool IsWithinmatrix(char[,] matrix, int row, int col)
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
