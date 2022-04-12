using System;

using System.Collections.Generic;

namespace T01ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            Stack<char> reversedString = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                reversedString.Push(input[i]);
            }

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(reversedString.Pop());
            }

        }
    }
}