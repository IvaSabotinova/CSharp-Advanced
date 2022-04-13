using System;
using System.Collections.Generic;
using System.Linq;

namespace T01Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] first = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(); 
            int[] second = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> firstLootBox = new Queue<int>(first);
            Stack<int> secondLootBox = new Stack<int>(second);

            int sumofClaimedItems = 0;
            while (firstLootBox.Count > 0 && secondLootBox.Count > 0)
            {
                if ((firstLootBox.Peek() +  secondLootBox.Peek()) % 2 == 0)
                {
                    sumofClaimedItems += firstLootBox.Dequeue() + secondLootBox.Pop();
                }
                else
                {
                    firstLootBox.Enqueue(secondLootBox.Pop());
                }
                
            }

            if (firstLootBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (secondLootBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (sumofClaimedItems >=100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sumofClaimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sumofClaimedItems}");
            }
            
        }
    }
}
