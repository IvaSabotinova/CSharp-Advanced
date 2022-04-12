using System;

namespace T07PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());

            long[][] jaggedArray = new long[size][];

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                long[] innerArray = new long[i + 1];
                innerArray[0] = 1;
                innerArray[i] = 1;
                for (int j = 1; j < innerArray.Length - 1; j++)
                {
                    innerArray[j] = jaggedArray[i - 1][j] + jaggedArray[i - 1][j - 1];
                }

                jaggedArray[i] = innerArray;

            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine(String.Join(" ", jaggedArray[i]));
            }


        }
    }
}
