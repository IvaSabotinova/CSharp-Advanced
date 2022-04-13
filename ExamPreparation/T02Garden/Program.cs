using System;
using System.Collections.Generic;
using System.Linq;


namespace T02Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[dimensions[0], dimensions[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 0;
                }
            }

            Queue<int[]> coordinates = new Queue<int[]>();
            string command;
            while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
            {

                int[] flowerCoordinates = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int flowerRow = flowerCoordinates[0];
                int flowerCol = flowerCoordinates[1];

                if (!IsWithinMatrix(matrix, flowerRow, flowerCol))
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                else
                {
                    matrix[flowerRow, flowerCol] = 1;
                    coordinates.Enqueue(flowerCoordinates);
                }

            }

            BloomBloomPlow(matrix, coordinates);
            PrintMatrix(matrix);

        }

        private static void BloomBloomPlow(int[,] matrix, Queue<int[]> coordinatesOfFlowers)
        {
            while (coordinatesOfFlowers.Count > 0)
            {
                int initialRowToBloom = coordinatesOfFlowers.Peek()[0];
                int initialColToBloom = coordinatesOfFlowers.Peek()[1];
                int currRowToBloom = initialRowToBloom;
                int currColToBloom = initialColToBloom;
                coordinatesOfFlowers.Dequeue();
                while (IsWithinMatrix(matrix, currRowToBloom + 1, currColToBloom))
                {

                    matrix[currRowToBloom + 1, currColToBloom] += 1;
                    currRowToBloom++;
                }

                currRowToBloom = initialRowToBloom;
                currColToBloom = initialColToBloom;
                while (IsWithinMatrix(matrix, currRowToBloom - 1, currColToBloom))
                {

                    matrix[currRowToBloom - 1, currColToBloom] += 1;
                    currRowToBloom--;
                }
                currRowToBloom = initialRowToBloom;
                currColToBloom = initialColToBloom;
                while (IsWithinMatrix(matrix, currRowToBloom, currColToBloom + 1))
                {

                    matrix[currRowToBloom, currColToBloom + 1] += 1;
                    currColToBloom++;
                }
                currRowToBloom = initialRowToBloom;
                currColToBloom = initialColToBloom;
                while (IsWithinMatrix(matrix, currRowToBloom, currColToBloom - 1))
                {

                    matrix[currRowToBloom, currColToBloom - 1] += 1;
                    currColToBloom--;
                }

            }
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
