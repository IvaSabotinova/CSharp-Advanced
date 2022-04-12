using System;
using System.Linq;

namespace T03PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int[,] matrix = new int[number, number];

            
            for (int i = 0; i < number; i++)
            {
                int[] currentRow = ReadArrayFromConsole();
                for (int j = 0; j < number; j++)
                {
                    matrix[i, j] = currentRow[j];
                }

            }
            int diagonalSum = 0;
            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < number; j++)
                {
                    if (i == j)
                    {
                        diagonalSum += matrix[j, j];
                    }
                }
                
            }

            Console.WriteLine(diagonalSum);
            
            }
        private static int[] ReadArrayFromConsole()
        {
            return Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
        }
    }
}
