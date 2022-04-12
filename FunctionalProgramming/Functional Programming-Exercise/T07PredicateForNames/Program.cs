using System;
using System.Linq;

namespace T07PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int wordMaxLength = int.Parse(Console.ReadLine());

            Func<string, int, bool> shorterWord = (w1, wMaxLen) => w1.Length <= wMaxLen;

            Action<string[]> print = w => Console.WriteLine(string.Join("\n", w));

            print(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => shorterWord(x, wordMaxLength)).ToArray());

        }
    }
}