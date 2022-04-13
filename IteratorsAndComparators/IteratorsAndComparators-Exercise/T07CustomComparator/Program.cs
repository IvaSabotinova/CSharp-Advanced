using System;

using System.Linq;

namespace T07CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            Func<int, int, int> comparer = (num1, num2) =>
                (num1 % 2 == 0 && num2 % 2 != 0) ? -1 : (num1 % 2 != 0 && num2 % 2 == 0) ? 1 : num1.CompareTo(num2);

            
            Array.Sort(input, new Comparison<int>(comparer));
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
