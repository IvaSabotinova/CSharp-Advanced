using System;
using System.Collections.Generic;
using System.Linq;

namespace T05PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();


            Queue<int> queue = new Queue<int>(numbers);

            for (int i = 0; i < numbers.Length; i++)
            {
                if (queue.Peek() % 2 == 0)
                {
                    queue.Enqueue(queue.Dequeue());

                }
                else if (queue.Peek() % 2 != 0)
                {
                    queue.Dequeue();
                }


            }


            Console.WriteLine(string.Join(", ", queue));



        }
    }
}
