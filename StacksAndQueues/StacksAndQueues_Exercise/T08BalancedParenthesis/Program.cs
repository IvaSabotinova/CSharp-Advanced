using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace T08BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{' || input[i] == '(' || input[i] == '[')
                {
                    stack.Push(input[i]);
                }

                if (stack.Count == 0 && i < input.Length)
                {
                    Console.WriteLine("NO");
                    return;
                }

                if (stack.Any())
                {
                    if (input[i] == '}' && stack.Peek() == '{')
                    {
                        stack.Pop();
                    }
                    else if (input[i] == ')' && stack.Peek() == '(')
                    {
                        stack.Pop();
                    }
                    else if (input[i] == ']' && stack.Peek() == '[')
                    {
                        stack.Pop();
                    }
                }
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }
    }
}
