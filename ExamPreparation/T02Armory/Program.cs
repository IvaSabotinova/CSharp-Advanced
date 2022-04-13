using System;

namespace T02Armory
{
    class Program
    {
        static void Main(string[] args)
        {

            int sizes = int.Parse(Console.ReadLine());
            char[,] armoryMatrix = new char[sizes, sizes];
            int armoryOfficerRow = 0;
            int armoryOfficerCol = 0;

            int firstMirrorRow = 0;
            int firstMirrorCol = 0;
            int secondMirrorRow = 0;
            int secondMirrorCol = 0;
            int countMirrors = 0;

            for (int i = 0; i < armoryMatrix.GetLength(0); i++)
            {
                char[] currRow = Console.ReadLine().ToCharArray();
                for (int j = 0; j < armoryMatrix.GetLength(1); j++)
                {
                    armoryMatrix[i, j] = currRow[j];
                    if (armoryMatrix[i, j] == 'A')
                    {
                        armoryOfficerRow = i;
                        armoryOfficerCol = j;
                    }

                    if (armoryMatrix[i, j] == 'M')
                    {
                        if (countMirrors == 0)
                        {
                            firstMirrorRow = i;
                            firstMirrorCol = j;
                            countMirrors++;
                        }
                        else
                        {
                            secondMirrorRow = i;
                            secondMirrorCol = j;
                        }
                    }
                }
            }

            int boughtSwardsAmount = 0;

            while (IsWithinMatrix(armoryMatrix, armoryOfficerRow, armoryOfficerCol) && boughtSwardsAmount <= 65)
            {
                string direction = Console.ReadLine();
                armoryMatrix[armoryOfficerRow, armoryOfficerCol] = '-';
                
                switch (direction)
                {
                    case "left":
                        armoryOfficerCol -= 1;
                        break;
                    case "right":
                        armoryOfficerCol += 1;
                        break;
                    case "up":
                        armoryOfficerRow -= 1;
                        break;
                    case "down":
                        armoryOfficerRow += 1;
                        break;
                }

                if (IsWithinMatrix(armoryMatrix, armoryOfficerRow, armoryOfficerCol) &&
                    Char.IsDigit(armoryMatrix[armoryOfficerRow, armoryOfficerCol]))
                {
                    boughtSwardsAmount += int.Parse(armoryMatrix[armoryOfficerRow, armoryOfficerCol].ToString());
                    armoryMatrix[armoryOfficerRow, armoryOfficerCol] = 'A';
                }
                else if (IsWithinMatrix(armoryMatrix, armoryOfficerRow, armoryOfficerCol) &&
                         armoryMatrix[armoryOfficerRow, armoryOfficerCol] == 'M')
                {
                    if (armoryOfficerRow == firstMirrorRow && armoryOfficerCol == firstMirrorCol)
                    {
                        armoryMatrix[armoryOfficerRow, armoryOfficerCol] = '-';
                        armoryOfficerRow = secondMirrorRow;
                        armoryOfficerCol = secondMirrorCol;

                    }
                    else if (armoryOfficerRow == secondMirrorRow && armoryOfficerCol == secondMirrorCol)
                    {
                        armoryMatrix[armoryOfficerRow, armoryOfficerCol] = '-';
                       armoryOfficerRow = firstMirrorRow;
                        armoryOfficerCol = firstMirrorCol;
                    }
                    armoryMatrix[armoryOfficerRow, armoryOfficerCol] = 'A';
                }
                
            }

            if (!IsWithinMatrix(armoryMatrix, armoryOfficerRow, armoryOfficerCol))
            {
                Console.WriteLine("I do not need more swords!");
            }

            else if (boughtSwardsAmount > 65)
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }

            Console.WriteLine($"The king paid {boughtSwardsAmount} gold coins.");
            Printmatrix(armoryMatrix);
        }

        public static bool IsWithinMatrix(char[,] matrix, int row, int col)
            => row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);

        public static void Printmatrix(char[,] matrix)
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
