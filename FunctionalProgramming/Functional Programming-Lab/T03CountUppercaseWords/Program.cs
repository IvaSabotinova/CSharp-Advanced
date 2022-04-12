using System;
using System.Linq;

namespace T03CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<string, bool> firstUpperCase = word => char.IsUpper(word[0]);

            string[] text = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(firstUpperCase).ToArray();

            Console.WriteLine(string.Join("\n", text));

        }
    }
}
