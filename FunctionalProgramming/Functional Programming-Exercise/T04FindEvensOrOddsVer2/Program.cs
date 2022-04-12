using System;
using System.Collections.Generic;
using System.Linq;

namespace T04FindEvensOrOddsVer2
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] range = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            string evenOrOdd = Console.ReadLine();
            //List<int> nums = new List<int>();

            Predicate<int> even_Odd = evenOrOdd == "even" ? n => n % 2 == 0 : new Predicate<int>(n => n % 2 != 0);

            //for (int i = range[0]; i <= range[1]; i++)
            //{
            //    if (even_Odd(i))
            //    {
            //        nums.Add(i);
            //    }
            //}

            //Console.WriteLine(string.Join(" ", nums));

            Console.WriteLine(string.Join(" ", Enumerable.Range(range[0], range[1] - range[0] + 1).Where(x => even_Odd(x))));
        }
    }
}