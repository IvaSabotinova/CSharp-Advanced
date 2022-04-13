using System;
using System.Linq;

namespace T02GardenVer2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[dimensions[0], dimensions[1]];

            string command;
            while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] flowerCoordinates = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();
                int flowerRow = flowerCoordinates[0];
                int flowerCol = flowerCoordinates[1];
                if (!IsWithinMatrix(matrix, flowerRow, flowerCol))
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                else
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (i == flowerRow)
                            {
                                matrix[i, j] += 1;
                            }

                            if (j == flowerCol && i !=flowerRow)
                            {
                                matrix[i, j] += 1;
                            }
                        }
                    }
                }
                
            }
            PrintMatrix(matrix);
        }
        public static bool IsWithinMatrix(int[,] matrix, int row, int col)
            => row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);

        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
