using System;
using System.Collections.Generic;
using System.Linq;

namespace Т01WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] hats = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            int[] scarfs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            
            Stack<int> allHats = new Stack<int>(hats);
            Queue<int> allScarf = new Queue<int>(scarfs);
            List<int> sets = new List<int>();

            while (allHats.Count > 0 && allScarf.Count > 0)
            {
                if (allHats.Peek() > allScarf.Peek())
                {
                    sets.Add(allHats.Pop() + allScarf.Dequeue());
                }
                else if (allHats.Peek() < allScarf.Peek())
                {
                    allHats.Pop();
                }
                else if (allHats.Peek() == allScarf.Peek())
                {
                    allScarf.Dequeue();
                    int hatValue = allHats.Pop() + 1;
                    allHats.Push(hatValue);
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ", sets));

        }
    }
}
