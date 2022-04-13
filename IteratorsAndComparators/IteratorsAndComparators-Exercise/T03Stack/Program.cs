using System;


using System.Linq;

namespace T03Stack
{
    class Program
    {
        static void Main(string[] args)
        {

            string input;

            CustomStack<string> myStack = new CustomStack<string>();

            while ((input = Console.ReadLine()) != "END")
            {

                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                if (command == "Push")
                {
                    string[] elements = tokens.Skip(1).Select(x => x.Split(",", StringSplitOptions.RemoveEmptyEntries).First()).ToArray();
                    myStack.Push(elements);
                }
                else
                {
                    try
                    {
                        myStack.Pop();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("No elements");
                    }
                }
            }

            foreach (string stack in myStack)
            {
                Console.WriteLine(stack + " ");
            }
            foreach (string stack in myStack)
            {
                Console.WriteLine(stack + " ");
            }
        }
    }
}
