using System;
using System.Linq;

namespace T02KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string> printout = word => Console.WriteLine($"Sir {word}");

            names.ToList().ForEach(printout);
        }
    }
}