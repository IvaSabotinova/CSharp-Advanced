using System;
using System.Collections.Generic;
using System.Linq;

namespace T01Blacksmith
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] steelElements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] carbonElements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> steel = new Queue<int>(steelElements);
            Stack<int> carbon = new Stack<int>(carbonElements);

            Dictionary<string, int> swards = new Dictionary<string, int>();

            while (steel.Count > 0 && carbon.Count > 0)
            {

                if (CanProduceSward(steel.Peek(), carbon.Peek()))
                {
                    if (!swards.ContainsKey(SwardType(steel.Peek(), carbon.Peek())))
                    {
                        swards.Add(SwardType(steel.Peek(), carbon.Peek()), 0);
                    }
                    swards[SwardType(steel.Dequeue(), carbon.Pop())]++;

                }
                else if (!CanProduceSward(steel.Peek(), carbon.Peek()))
                {
                    steel.Dequeue();
                    int newValue = carbon.Pop() + 5;
                    carbon.Push(newValue);
                }

            }

            if (swards.Count > 0)
            {
                Console.WriteLine($"You have forged {swards.Values.Sum()} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (steel.Count > 0)
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }
            if (carbon.Count > 0)
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            if (swards.Count > 0)
            {
                foreach (KeyValuePair<string, int> sward in swards.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"{sward.Key}: {sward.Value}");
                }
            }

        }

        public static bool CanProduceSward(int steel, int carbon)
        {
            if (steel + carbon == 70 || steel + carbon == 80 || steel + carbon == 90 || steel + carbon == 110 || steel + carbon == 150)
            {
                return true;
            }

            return false;
        }

        public static string SwardType(int steel, int carbon)
        {

            switch (steel + carbon)
            {
                case 70:
                    return "Gladius";
                case 80:
                    return "Shamshir";
                case 90:
                    return "Katana";
                case 110:
                    return "Sabre";
                    //case 150:

            }
            return "Broadsword";
        }
    }
}
