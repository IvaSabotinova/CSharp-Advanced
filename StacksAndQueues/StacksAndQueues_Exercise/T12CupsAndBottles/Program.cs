using System;
using System.Collections.Generic;
using System.Linq;

namespace T12CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            int[] bottlesCapacity = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            Stack<int> bottles = new Stack<int>(bottlesCapacity);
            Queue<int> cups = new Queue<int>(cupsCapacity);
            int wastedWater = 0;

            while (true)
            {

                if (bottles.Peek() >= cups.Peek())
                {
                    wastedWater += bottles.Pop() - cups.Dequeue();
                }
                else
                {
                    int currentCupCapacity = cups.Peek();
                    while (currentCupCapacity > 0)
                    {
                        currentCupCapacity -= bottles.Pop();
                        if (bottles.Count == 0 && currentCupCapacity > 0)
                        {
                            Console.WriteLine($"Cups: {currentCupCapacity} {String.Join(" ", cups)}");
                            Console.WriteLine($"Wasted litters of water: {wastedWater}");
                            break;
                        }

                        if (currentCupCapacity <= 0)
                        {
                            wastedWater -= currentCupCapacity;
                            cups.Dequeue();
                        }

                    }
                }

                if (bottles.Count == 0)
                {
                    Console.WriteLine($"Cups: {String.Join(" ", cups)}");
                    Console.WriteLine($"Wasted litters of water: {wastedWater}");
                    return;
                }

                if (cups.Count == 0)
                {
                    Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
                    Console.WriteLine($"Wasted litters of water: {wastedWater}");
                    return;
                }
                
            }
        }
    }
}
