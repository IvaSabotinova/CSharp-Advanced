using System;
using System.Collections.Generic;
using System.Linq;

namespace T02BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            int numberToEnqueue = commands[0];
            int numnerToDequeue = commands[1];
            int numberToLookFor = commands[2];

            int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < numberToEnqueue; i++)
            {
                queue.Enqueue(array[i]);
            }

            for (int i = 0; i < numnerToDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(numberToLookFor))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine(queue.Count);
            }
            else
            {
                Console.WriteLine(queue.Min());
            }





        }
    }
}
