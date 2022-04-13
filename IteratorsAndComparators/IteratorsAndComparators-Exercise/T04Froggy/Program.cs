using System;
using System.Linq;

namespace T04Froggy
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] orderOfStones = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            Lake stones = new Lake(orderOfStones);

            Console.WriteLine(string.Join(", ", stones));
        }
    }
}
