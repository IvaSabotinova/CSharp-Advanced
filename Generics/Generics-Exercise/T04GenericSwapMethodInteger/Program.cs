using System;
using System.Linq;

namespace T04GenericSwapMethodInteger
{
    class Program
    {
        static void Main(string[] args)
        {

            int numOfLines = int.Parse(Console.ReadLine());
            Box<int> content = new Box<int>();

            for (int i = 0; i < numOfLines; i++)
            {
                int line = int.Parse(Console.ReadLine());

                content.Add(line);
            }

            int[] swapIndexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            content.Swap(swapIndexes[0], swapIndexes[1]);

            Console.WriteLine(content.ToString());

        }
    }
}
