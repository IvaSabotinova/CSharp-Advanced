using System;
using System.Linq;

namespace T05AppliedArithmeticsVer2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            Action<int[]> print = array => Console.WriteLine(string.Join(" ", array));
            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = ApplyOnAllElements(numbers, n => ++n);
                        break;
                    case "multiply":
                        numbers = ApplyOnAllElements(numbers, n => n * 2);
                        break;
                    case "subtract":
                        numbers = ApplyOnAllElements(numbers, n => --n);
                        break;
                    case "print":
                        print(numbers);
                        break;
                }
            }
        }

        public static int[] ApplyOnAllElements(int[] nums, Func<int, int> func)
        {
            return nums.Select(x => func(x)).ToArray();

        }

    }
}