using System;
using System.Linq;

namespace T02SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> result = n => int.Parse(n);
            int[] numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(result)
                .ToArray();

            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());



        }
    }
}

