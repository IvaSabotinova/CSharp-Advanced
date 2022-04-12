using System;
using System.Collections.Generic;
using System.Linq;


namespace T06ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            int n = int.Parse(Console.ReadLine());

            Func<int, int, bool> removedElements = (num1, num2) => num1 % num2 == 0;
            Action<List<int>> print = list => Console.WriteLine(String.Join(" ", list));

            numbers.Reverse();
            numbers.RemoveAll(x => removedElements(x, n));

            print(numbers);

        }


    }
}