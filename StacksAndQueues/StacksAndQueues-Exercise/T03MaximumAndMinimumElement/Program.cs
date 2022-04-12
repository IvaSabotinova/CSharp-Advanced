using System;
using System.Collections.Generic;
using System.Linq;

namespace T03MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberOfCommands = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();


            for (int i = 0; i < numberOfCommands; i++)
            {
                int[] commmand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();

                if (commmand[0] == 1)
                {
                    stack.Push(commmand[1]);

                }
                else if (commmand[0] == 2 && stack.Count>0)
                {
                    stack.Pop();
                }
                else if (commmand[0] == 3 && stack.Count > 0)
                {
                    Console.WriteLine(stack.Max());
                }
                else if (commmand[0] == 4 && stack.Count > 0)
                {
                    Console.WriteLine(stack.Min());
                }

            }

            Console.WriteLine(string.Join(", ", stack));



        }
    }
}
