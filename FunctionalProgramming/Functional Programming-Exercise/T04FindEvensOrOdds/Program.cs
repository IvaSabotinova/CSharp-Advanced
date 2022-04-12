using System;
using System.Collections.Generic;
using System.Linq;


namespace T04FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            int minNum = range[0];
            int maxNum = range[1];
            Predicate<int> evenNum = n => n % 2 == 0;
            Predicate<int> oddNum = n => n % 2 != 0;

            string evenOrOdd = Console.ReadLine();

            List<int> numbers = new List<int>();

            for (int i = minNum; i <= maxNum; i++)
            {
                if (evenOrOdd == "even" && evenNum(i))
                {
                    numbers.Add(i);
                }
                else if (evenOrOdd == "odd" && oddNum(i))
                {
                    numbers.Add(i);
                }

            }

            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}

