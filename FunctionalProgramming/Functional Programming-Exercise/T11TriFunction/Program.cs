using System;
using System.Linq;

namespace T11TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxSumOfCharacters = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> filterWords = (word, maxNum) =>
                word.ToCharArray().Select(c => (int)c).Sum() >= maxNum;

            Func<string[], Func<string, int, bool>, int, string> getFirstWord = (array, func, numMax) =>
                array.Where(w => func(w, numMax)).First();

            Action<string> print = w => Console.WriteLine(w);

            print(getFirstWord(names, filterWords, maxSumOfCharacters));

        }
    }
}