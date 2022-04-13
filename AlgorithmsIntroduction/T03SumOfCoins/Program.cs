using System;
using System.Linq;

namespace SumOfCoins
{
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IList<int> input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToList();
            int desiredSum = int.Parse(Console.ReadLine());

            Dictionary<int, int> result = ChooseCoins(input, desiredSum);

            Console.WriteLine($"Number of coins to take: {result.Values.Sum()}");
            foreach (KeyValuePair<int, int> item in result)
            {
                Console.WriteLine($"{item.Value} coin(s) with value {item.Key} ");
            }

        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            Dictionary<int, int> coin_NumberOfCoins = new Dictionary<int, int>();
            coins = coins.OrderBy(x => x).ToList();
            int currIndex = coins.Count - 1;


            while (targetSum != 0 && currIndex >= 0)
            {
                if (targetSum / coins[currIndex] >= 1)
                {
                    coin_NumberOfCoins.Add(coins[currIndex], targetSum / coins[currIndex]);
                    targetSum -= targetSum / coins[currIndex] * coins[currIndex];
                    currIndex--;
                }
                else
                {
                    currIndex--;
                }
            }

            if (targetSum > 0)
            {
                throw new InvalidOperationException();
                //Console.WriteLine("Error");
                //Environment.Exit(0);

            }
            return coin_NumberOfCoins;

        }
    }
}
