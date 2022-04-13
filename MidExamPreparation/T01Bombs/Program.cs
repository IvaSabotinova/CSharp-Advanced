using System;
using System.Collections.Generic;
using System.Linq;

namespace T01Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
         
            int[] bombEfectsElements = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] bombCasingElements = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> bombEffects = new Queue<int>(bombEfectsElements);
            Stack<int> bombCasings = new Stack<int>(bombCasingElements);


            Dictionary<string, int> bombs = new Dictionary<string, int>()
            {
                {"Datura Bombs", 0},
                {"Cherry Bombs", 0},
                {"Smoke Decoy Bombs", 0},
            };

            while (bombEffects.Count > 0 && bombCasings.Count > 0)
            {
                if (CanCreateBomb(bombEffects.Peek(), bombCasings.Peek()))
                {
                    bombs[BombType(bombEffects.Dequeue() + bombCasings.Pop())]++;
                }
                else
                {
                    bombCasings.Push(bombCasings.Pop() - 5);
                }

                if (bombs.Values.All(x => x >= 3))
                {
                    Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
                    break;
                }
            }

            if (bombs.Values.All(x=>x <3))
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }
            if (bombCasings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: { string.Join(", ", bombCasings)}");
            }

            foreach (KeyValuePair<string, int> item in bombs.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

        }

        private static bool CanCreateBomb(int bombEffect, int bombCasing)
        {
            return (bombEffect + bombCasing == 40) || (bombEffect + bombCasing == 60) || (bombEffect + bombCasing == 120);

        }

        private static string BombType(int sum)
        {
            switch (sum)
            {
                case 40: return "Datura Bombs";
                case 60: return "Cherry Bombs";
                    //case 120:
            }
            return "Smoke Decoy Bombs";
        }
    }
}
