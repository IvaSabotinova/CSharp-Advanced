using System;
using System.Collections.Generic;
using System.Linq;

namespace T01KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletprice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int[] bulletsInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).ToArray();
            int[] locksInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).ToArray();
            int intelligenceValue = int.Parse(Console.ReadLine());

            Queue<int> locks = new Queue<int>(locksInput);
            Stack<int> bullets = new Stack<int>(bulletsInput);

            int totalPriceOfBullets = 0;
            int gunBarrelLoaded = gunBarrelSize;
            while (locks.Count > 0 && bullets.Count > 0)
            {
                int currentBulletSize = bullets.Peek();
                int currentLockSize = locks.Peek();
                if (currentBulletSize <= currentLockSize)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();

                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                bullets.Pop();
                gunBarrelLoaded -= 1;
                totalPriceOfBullets += bulletprice;
                if(gunBarrelLoaded == 0 && bullets.Count != 0)
                {
                    Console.WriteLine("Reloading!");
                    gunBarrelLoaded = gunBarrelSize;
                   
                }

            }

            string output = bullets.Count == 0 && locks.Count != 0 
                ? $"Couldn't get through. Locks left: {locks.Count}" 
                : $"{bullets.Count} bullets left. Earned ${intelligenceValue-totalPriceOfBullets}";
            Console.WriteLine(output);
        }


    }
}

