using System;
using System.Linq;

namespace T05SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            char[,] snakeMatrix = new char[sizes[0], sizes[1]];

            string input = Console.ReadLine();

            int lastIteration = -1;
            for (int i = 0; i < snakeMatrix.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0, k = lastIteration + 1; j < snakeMatrix.GetLength(1); j++, k++)
                    {
                        snakeMatrix[i, j] = input[k];
                        if (k == input.Length - 1)
                        {
                            k = -1;
                        }

                        if (j == snakeMatrix.GetLength(1) - 1)
                        {
                            lastIteration = k;
                        }
                    }
                }
                else
                {
                    for (int j = snakeMatrix.GetLength(1) - 1, k = lastIteration + 1; j >= 0; j--, k++)
                    {
                        snakeMatrix[i, j] = input[k];
                        if (k == input.Length - 1)
                        {
                            k = -1;
                        }

                        if (j == 0)
                        {
                            lastIteration = k;
                        }

                    }
                }
            }


            for (int k = 0; k < snakeMatrix.GetLength(0); k++)
            {
                for (int l = 0; l < snakeMatrix.GetLength(1); l++)
                {
                    Console.Write($"{snakeMatrix[k, l]}");
                }

                Console.WriteLine();
            }

        }
    }
}
