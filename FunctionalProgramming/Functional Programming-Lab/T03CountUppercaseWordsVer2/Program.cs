using System;
using System.Collections.Immutable;
using System.Linq;

namespace T03CountUppercaseWordsVer2
{
    class Program
    {
        static void Main(string[] args)
        {

            Predicate<string> firstCharUpper = word => char.IsUpper(word[0]);

            Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(w => firstCharUpper(w)).ToList().ForEach(Console.WriteLine);


        }
    }
}