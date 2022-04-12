using System;
using System.Linq;

namespace T03Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            foreach (int number in array.OrderByDescending(x=>x).Take(3))
            {
                Console.Write($"{number} ");
            }
            
        }
    }
}
