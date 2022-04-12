using System;
using System.Linq;

namespace T03GenericSwapMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfLines = int.Parse(Console.ReadLine());
            Box<string> content = new Box<string>();

            for (int i = 0; i < numOfLines; i++)
            {
                string line = Console.ReadLine();

                content.Add(line);
            }

            int[] swapIndexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            content.Swap(swapIndexes[0], swapIndexes[1]);

            Console.WriteLine(content);
            
        }
    }
}
