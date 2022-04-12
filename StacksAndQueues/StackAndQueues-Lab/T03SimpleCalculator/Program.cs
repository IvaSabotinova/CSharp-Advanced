using System;
using System.Collections.Generic;
using System.Linq;



namespace T03SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();

            Stack<string> stack = new Stack<string>(input);

            while (stack.Count > 1)
            {
                int num1 = int.Parse(stack.Pop());
                string oper = stack.Pop();
                int num2 = int.Parse(stack.Pop());

                if (oper == "+")
                {
                    stack.Push((num1 + num2).ToString());
                }
                else if (oper == "-")
                {
                    stack.Push((num1 - num2).ToString());
                }
            }

            Console.WriteLine(stack.Pop());


        }
    }
}
