using System;
using System.Collections.Generic;
using System.Linq;

namespace Т11KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrel_ReloadingInterval = int.Parse(Console.ReadLine());
            int[] bulletsSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            int[] locksSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            int intelligenceValue = int.Parse(Console.ReadLine());

            Queue<int> locks = new Queue<int>(locksSize);
            Stack<int> bullets = new Stack<int>(bulletsSize);
            int gunBarrelCount = 0;

            while (true)
            {

                if (bullets.Peek() > locks.Peek())
                {
                    bullets.Pop();
                    intelligenceValue -= bulletPrice;
                    Console.WriteLine("Ping!");

                }
                else
                {
                    bullets.Pop();
                    locks.Dequeue();
                    intelligenceValue -= bulletPrice;
                    Console.WriteLine("Bang!");

                }
                gunBarrelCount++;
                if (gunBarrelCount == gunBarrel_ReloadingInterval && bullets.Count != 0)
                {
                    Console.WriteLine("Reloading!");
                    gunBarrelCount = 0;
                }

                if (locks.Count == 0)
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue}");
                    return;
                }


                if (bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    return;
                }

            }
        }
    }
}
