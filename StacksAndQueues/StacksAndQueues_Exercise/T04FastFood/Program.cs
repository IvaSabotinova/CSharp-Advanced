using System;
using System.Collections.Generic;
using System.Linq;

namespace T04FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalDailyFoodQnty = int.Parse(Console.ReadLine());

            int[] orderQuantity = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(orderQuantity);

            Console.WriteLine(queue.Max());

            for (int i = 0; i < orderQuantity.Length; i++)
            {
                if (totalDailyFoodQnty >= orderQuantity[i])
                {
                    totalDailyFoodQnty -= queue.Dequeue();
                }
                else
                {
                    break;
                }

                
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
            
        }
    }
}
