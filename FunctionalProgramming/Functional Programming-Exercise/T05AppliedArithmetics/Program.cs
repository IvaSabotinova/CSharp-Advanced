using System;
using System.Collections.Generic;
using System.Linq;

namespace T05AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToList();

            Func<int, int> add = n => n + 1;
            Func<int, int> multiply = n => n * 2;
            Func<int, int> subtract = n => n - 1;
            Action<List<int>> print = nums => Console.WriteLine(string.Join(" ", nums));

            string command = Console.ReadLine();
            while (true)
            {
                if (command == "add")
                {
                    numbers = numbers.Select(x => add(x)).ToList();
                }
                else if (command == "multiply")
                {
                    numbers = numbers.Select(x => multiply(x)).ToList();
                }
                else if (command == "subtract")
                {
                    numbers = numbers.Select(x => subtract(x)).ToList();
                }
                else if (command == "print")
                {
                    print(numbers);
                }
                else if (command == "end")
                {
                    return;

                }
                command = Console.ReadLine();
            }

        }
    }
}