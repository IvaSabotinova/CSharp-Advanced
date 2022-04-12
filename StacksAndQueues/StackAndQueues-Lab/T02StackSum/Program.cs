using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace T02StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            string command;

            Stack<int> result = new Stack<int>(numbers);

            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] subcommands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (subcommands[0].ToLower() == "add")
                {
                    result.Push(int.Parse(subcommands[1]));
                    result.Push(int.Parse(subcommands[2]));

                }
                else if (subcommands[0].ToLower() == "remove")
                {

                    if (result.Count >= int.Parse(subcommands[1]))
                    {
                        for (int i = 0; i < int.Parse(subcommands[1]); i++)
                        {
                            result.Pop();
                        }

                    }

                }

            }

            Console.WriteLine($"Sum: {result.Sum()}");


        }
    }
}
