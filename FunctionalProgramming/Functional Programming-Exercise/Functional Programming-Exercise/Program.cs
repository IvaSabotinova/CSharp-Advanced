using System;
using System.Linq;

namespace T01ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = word => Console.WriteLine(word);

            string[] text = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string item in text)
            {
                print(item);
            }

        }
    }
}