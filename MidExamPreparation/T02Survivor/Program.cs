using System;

using System.Linq;

namespace T02Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int numOfRows = int.Parse(Console.ReadLine());

            char[][] jaggedArray = new char[numOfRows][];

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                jaggedArray[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse)
                    .ToArray();
            }

            int collectedTokens = 0;
            int opponentsTokens = 0;
            string currCommand;

            while ((currCommand = Console.ReadLine()) != "Gong")
            {

                string[] subCommands = currCommand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (subCommands[0] == "Find")
                {
                    int curRow = int.Parse(subCommands[1]);
                    int curCol = int.Parse(subCommands[2]);
                    if (IsWithinMatrix(jaggedArray, curRow, curCol))
                    {
                        if (jaggedArray[curRow][curCol] == 'T')
                        {
                            collectedTokens++;
                        }
                        jaggedArray[curRow][curCol] = '-';
                    }
                }
                else if (subCommands[0] == "Opponent")
                {
                    int currRow = int.Parse(subCommands[1]);
                    int currCol = int.Parse(subCommands[2]);
                    string opponentDirection = subCommands[3];

                    if (IsWithinMatrix(jaggedArray, currRow, currCol))
                    {
                        if (jaggedArray[currRow][currCol] == 'T')
                        {
                            opponentsTokens++;
                        }

                        jaggedArray[currRow][currCol] = '-';


                        switch (opponentDirection)
                        {
                            case "up":

                                if (IsWithinMatrix(jaggedArray, currRow - 1, currCol))
                                {
                                    if (jaggedArray[currRow - 1][currCol] == 'T')
                                    {
                                        opponentsTokens++;
                                    }

                                    jaggedArray[currRow - 1][currCol] = '-';

                                }

                                currRow--;
                                if (IsWithinMatrix(jaggedArray, currRow - 1, currCol))
                                {
                                    if (jaggedArray[currRow - 1][currCol] == 'T')
                                    {
                                        opponentsTokens++;
                                    }

                                    jaggedArray[currRow - 1][currCol] = '-';

                                }

                                currRow--;
                                if (IsWithinMatrix(jaggedArray, currRow - 1, currCol))
                                {
                                    if (jaggedArray[currRow - 1][currCol] == 'T')
                                    {
                                        opponentsTokens++;
                                    }

                                    jaggedArray[currRow - 1][currCol] = '-';

                                }

                                currRow--;
                                break;
                            case "down":
                                if (IsWithinMatrix(jaggedArray, currRow + 1, currCol))
                                {
                                    if (jaggedArray[currRow + 1][currCol] == 'T')
                                    {
                                        opponentsTokens++;
                                    }

                                    jaggedArray[currRow + 1][currCol] = '-';

                                }

                                currRow++;

                                if (IsWithinMatrix(jaggedArray, currRow + 1, currCol))
                                {
                                    if (jaggedArray[currRow + 1][currCol] == 'T')
                                    {
                                        opponentsTokens++;
                                    }

                                    jaggedArray[currRow + 1][currCol] = '-';

                                }

                                currRow++;
                                if (IsWithinMatrix(jaggedArray, currRow + 1, currCol))
                                {
                                    if (jaggedArray[currRow + 1][currCol] == 'T')
                                    {
                                        opponentsTokens++;
                                    }

                                    jaggedArray[currRow + 1][currCol] = '-';

                                }

                                currRow++;
                                break;
                            case "left":
                                if (IsWithinMatrix(jaggedArray, currRow, currCol - 1))
                                {
                                    if (jaggedArray[currRow][currCol - 1] == 'T')
                                    {
                                        opponentsTokens++;
                                    }

                                    jaggedArray[currRow][currCol - 1] = '-';

                                }

                                currCol--;
                                if (IsWithinMatrix(jaggedArray, currRow, currCol - 1))
                                {
                                    if (jaggedArray[currRow][currCol - 1] == 'T')
                                    {
                                        opponentsTokens++;
                                    }

                                    jaggedArray[currRow][currCol - 1] = '-';

                                }

                                currCol--;
                                if (IsWithinMatrix(jaggedArray, currRow, currCol - 1))
                                {
                                    if (jaggedArray[currRow][currCol - 1] == 'T')
                                    {
                                        opponentsTokens++;
                                    }

                                    jaggedArray[currRow][currCol - 1] = '-';

                                }

                                currCol--;
                                break;
                            case "right":
                                if (IsWithinMatrix(jaggedArray, currRow, currCol + 1))
                                {
                                    if (jaggedArray[currRow][currCol + 1] == 'T')
                                    {
                                        opponentsTokens++;
                                    }

                                    jaggedArray[currRow][currCol + 1] = '-';

                                }

                                currCol++;
                                if (IsWithinMatrix(jaggedArray, currRow, currCol + 1))
                                {
                                    if (jaggedArray[currRow][currCol + 1] == 'T')
                                    {
                                        opponentsTokens++;
                                    }

                                    jaggedArray[currRow][currCol + 1] = '-';

                                }

                                currCol++;
                                if (IsWithinMatrix(jaggedArray, currRow, currCol + 1))
                                {
                                    if (jaggedArray[currRow][currCol + 1] == 'T')
                                    {
                                        opponentsTokens++;
                                    }

                                    jaggedArray[currRow][currCol + 1] = '-';

                                }

                                currCol++;
                                break;

                        }
                    }
                }


            }

            PrintMatrix(jaggedArray);
            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentsTokens}");
        }

        public static bool IsWithinMatrix(char[][] jaggedArr, int row, int col)
                => row >= 0 && row < jaggedArr.Length && col >= 0 && col < jaggedArr[row].Length;

        public static void PrintMatrix(char[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(string.Join(" ", array[i]));
            }
        }
    }
}

