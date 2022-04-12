using System;
using System.Collections.Generic;
using System.Linq;

namespace T03CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Func<int[], int> minNum = MinNum;

            int minimum = minNum(numbers);
            Console.WriteLine(minimum);

        }

        public static int MinNum(int[] nums)
        {
            int minNumber = Int32.MaxValue;
            foreach (int num in nums)
            {
                if (num < minNumber)
                {
                    minNumber = num;
                }
            }

            return minNumber;
        }


    }
}