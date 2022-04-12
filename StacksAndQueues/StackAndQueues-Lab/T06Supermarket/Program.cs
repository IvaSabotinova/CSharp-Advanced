using System;
using System.Collections.Generic;

namespace Т06Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {

            string name;
            Queue<string> queue = new Queue<string>();

            while ((name = Console.ReadLine()) != "End")
            {

                if (name == "Paid")
                {
                    Console.WriteLine(string.Join("\n", queue));
                    queue.Clear();

                }
                else
                {
                    queue.Enqueue(name);
                }


            }

            Console.WriteLine($"{queue.Count} people remaining.");



        }
    }
}