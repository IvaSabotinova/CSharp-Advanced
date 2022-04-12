using System;
using System.Collections.Generic;

namespace T04MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i.ToString());
                }
                else if (input[i] == ')')
                {
                    int startIndex = int.Parse(stack.Pop());
                    Console.WriteLine(input.Substring(startIndex, i - startIndex + 1));
                }

            }

        }
    }
}

