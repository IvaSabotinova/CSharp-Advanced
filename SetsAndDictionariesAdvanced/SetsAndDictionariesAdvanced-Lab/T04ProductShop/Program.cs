using System;
using System.Collections.Generic;
using System.Linq;

namespace T04ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Dictionary<string, double>> allShops_Products_prices =
                new Dictionary<string, Dictionary<string, double>>();
            string command;

            while ((command = Console.ReadLine()) != "Revision")
            {
                string[] input = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string currentShop = input[0];
                string currentProduct = input[1];
                double currentPrice = double.Parse(input[2]);

                if (!allShops_Products_prices.ContainsKey(currentShop))
                {
                    allShops_Products_prices.Add(currentShop, new Dictionary<string, double>());
                }

                if (!allShops_Products_prices[currentShop].ContainsKey(currentProduct))
                {
                    allShops_Products_prices[currentShop].Add(currentProduct, currentPrice);
                }
                
            }

            foreach (KeyValuePair<string, Dictionary<string, double>> shop in allShops_Products_prices.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (KeyValuePair<string, double> product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }

        }
    }
}
