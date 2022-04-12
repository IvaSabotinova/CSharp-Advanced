using System;
using System.Collections.Generic;
using System.Linq;

namespace T08ListOfPredicatesVer2
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxNum = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            List<int> final = new List<int>();

            Action<List<int>> print = w => Console.WriteLine(string.Join(" ", w));

            for (int i = 1; i <= maxNum; i++)
            {
                bool isDivisible = true;
                foreach (int num in dividers)
                {
                    Func<int, int, bool> divisibleNum = (x1, x2) => x1 % x2 == 0;
                    if (!divisibleNum(i, num))
                    {
                        isDivisible = false;
                        break;
                    }

                }

                if (isDivisible)
                {
                    final.Add(i);
                }
            }

            print(final);
        }
    }
}