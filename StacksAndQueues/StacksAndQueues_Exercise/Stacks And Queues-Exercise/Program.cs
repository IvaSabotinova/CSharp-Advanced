using System;
using System.Collections.Generic;
using System.Linq;

namespace T01BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            int numberToPush = commands[0];
            int numberToPop = commands[1];
            int numberToLookFor = commands[2];

            Stack<int> stack = new Stack<int>();

            int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            for (int i = 0; i < numberToPush; i++)
            {
                stack.Push(array[i]);
            }

            for (int i = 0; i < numberToPop; i++)
            {
                if (stack.Count>0)
                {
                    stack.Pop();
                }
                else
                {
                    break;
                }
                
            }

            if (stack.Contains(numberToLookFor))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(stack.OrderBy(x=>x).First());
            }
        }
    }
}
