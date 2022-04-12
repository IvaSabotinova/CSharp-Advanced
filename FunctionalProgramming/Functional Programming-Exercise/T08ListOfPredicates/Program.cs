using System;
using System.Collections.Generic;

using System.Linq;

namespace T08ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {

            int endNum = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            List<int> final = new List<int>();

            for (int i = 1; i <= endNum; i++)
            {

                if (IsDivisible(dividers, i))
                {
                    final.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", final));

        }

        public static bool IsDivisible(int[] dividers, int number)
        {

            foreach (int num in dividers)
            {
                if (number % num != 0)
                {
                    return false;
                }
            }

            return true;

        }
    }
}

