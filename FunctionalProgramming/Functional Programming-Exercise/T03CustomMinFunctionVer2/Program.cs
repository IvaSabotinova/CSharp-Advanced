using System;
using System.Linq;

namespace T03CustomMinFunctionVer2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Func<int[], int> smallest = n => n.Min();

            Console.WriteLine(smallest(numbers));

            //int minNum = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Min();
            //Console.WriteLine(minNum);
        }
    }
}

