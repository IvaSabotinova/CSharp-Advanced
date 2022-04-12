using System;
using System.Collections.Generic;
using System.Linq;

namespace T02SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] sets = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int set1 = sets[0];
            int set2 = sets[1];
            HashSet<int> setOne = new HashSet<int>();
            HashSet<int> setTwo = new HashSet<int>();

            for (int i = 0; i < set1; i++)
            {
                int number = int.Parse(Console.ReadLine());
                setOne.Add(number);
            }

            for (int i = 0; i < set2; i++)
            {
                setTwo.Add(int.Parse(Console.ReadLine()));
            }

            setOne.IntersectWith(setTwo);
            Console.WriteLine(string.Join(" ", setOne));

            //foreach (int num1 in setOne)
            //{
            //    foreach (int num2 in setTwo)
            //    {
            //        if (num1 == num2)
            //        {
            //            Console.Write($"{num1} ");
            //        }
            //    }
            //}

        }
    }
}
