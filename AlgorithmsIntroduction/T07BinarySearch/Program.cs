using System;

using System.Linq;


namespace T07BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            int num = int.Parse(Console.ReadLine());
            int index = BinarySearch(input, num);

            Console.WriteLine(index);
            
        }

        private static int BinarySearch(int[] arr, int element)
        {
            int startIndex = 0;
            int endIndex = arr.Length - 1;

            while (endIndex >= startIndex)
            {
                int midIndex = startIndex + (endIndex - startIndex) / 2;

                if (arr[midIndex] < element)
                {
                    startIndex = midIndex + 1;

                }
                else if (arr[midIndex] > element)
                {
                    endIndex = midIndex - 1;
                }
                else
                {
                    return midIndex;
                }
                
            }
            return -1;
            
        }
    }
}
