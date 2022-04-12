using System;
using System.Linq;

namespace T07KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());

            char[][] jaggedArray = new char[size][];

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                jaggedArray[i] = Console.ReadLine().ToCharArray();

            }

            int removedKnights = 0;

            while (true)
            {
                int maxHits = 0;
                int row = 0;
                int column = 0;

                for (int i = 0; i < jaggedArray.Length; i++)
                {

                    for (int j = 0; j < jaggedArray[i].Length; j++)
                    {
                        int currentKnightHits = 0;
                        if (jaggedArray[i][j] == 'K')
                        {

                            if (i - 1 >= 0 && i - 1 < jaggedArray.Length && j - 2 >= 0 && j - 2 < jaggedArray[i - 1].Length && jaggedArray[i - 1][j - 2] == 'K')
                            {
                                currentKnightHits++;
                            }
                            if (i - 2 >= 0 && i - 2 < jaggedArray.Length && j - 1 >= 0 && j - 1 < jaggedArray[i - 2].Length && jaggedArray[i - 2][j - 1] == 'K')
                            {
                                currentKnightHits++;
                            }
                            if (i - 1 >= 0 && i - 1 < jaggedArray.Length && j + 2 >= 0 && j + 2 < jaggedArray[i - 1].Length && jaggedArray[i - 1][j + 2] == 'K')
                            {
                                currentKnightHits++;
                            }
                            if (i - 2 >= 0 && i - 2 < jaggedArray.Length && j + 1 >= 0 && j + 1 < jaggedArray[i - 2].Length && jaggedArray[i - 2][j + 1] == 'K')
                            {
                                currentKnightHits++;
                            }
                            if (i + 1 >= 0 && i + 1 < jaggedArray.Length && j - 2 >= 0 && j - 2 < jaggedArray[i + 1].Length && jaggedArray[i + 1][j - 2] == 'K')
                            {
                                currentKnightHits++;
                            }
                            if (i + 2 >= 0 && i + 2 < jaggedArray.Length && j - 1 >= 0 && j - 1 < jaggedArray[i + 2].Length && jaggedArray[i + 2][j - 1] == 'K')
                            {
                                currentKnightHits++;
                            }
                            if (i + 1 >= 0 && i + 1 < jaggedArray.Length && j + 2 >= 0 && j + 2 < jaggedArray[i + 1].Length && jaggedArray[i + 1][j + 2] == 'K')
                            {
                                currentKnightHits++;
                            }

                            if (i + 2 >= 0 && i + 2 < jaggedArray.Length && j + 1 >= 0 && j + 1 < jaggedArray[i + 2].Length && jaggedArray[i + 2][j + 1] == 'K')
                            {
                                currentKnightHits++;
                            }
                        }

                        if (currentKnightHits > maxHits)
                        {
                            maxHits = currentKnightHits;
                            row = i;
                            column = j;
                        }

                    }

                }
                if (maxHits > 0)
                {
                    jaggedArray[row][column] = '0';
                    removedKnights++;

                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(removedKnights);

        }
    }
}
