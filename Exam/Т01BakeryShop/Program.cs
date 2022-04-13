using System;
using System.Collections.Generic;
using System.Linq;

namespace MidExam
{
    class Program
    {
        static void Main(string[] args)
        {

            double[] waterElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            double[] flourElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            Queue<double> water = new Queue<double>(waterElements);
            Stack<double> flour = new Stack<double>(flourElements);
            Dictionary<string, double> allProducts = new Dictionary<string, double>()
                {
                    {"Croissant", 0},
                    {"Muffin", 0},
                    {"Baguette", 0},
                    {"Bagel", 0},
                };

            while (water.Count > 0 && flour.Count > 0)
            {
                double waterQnty = water.Peek();
                double flourQnty = flour.Peek();
                if (CanProduceProduct(waterQnty, flourQnty))
                {
                    allProducts[ProductType(water.Dequeue(), flour.Pop())]++;
                }
                else
                {
                    double neededFlour = water.Peek();
                    double leftFlour = flour.Peek() - neededFlour;
                    allProducts[ProductType(water.Dequeue(), neededFlour)]++;
                    flour.Pop();
                    flour.Push(leftFlour);
                }

            }

            foreach (KeyValuePair<string, double> item in allProducts.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Where(x => x.Value > 0))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            if (water.Count == 0)
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }

            if (flour.Count == 0)
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }

        }
        public static bool CanProduceProduct(double water, double flour)
        {
            if ((water * 100 / (water + flour)) == 50 || (water * 100 / (water + flour)) == 40 || (water * 100 / (water + flour)) == 30 || (water * 100 / (water + flour)) == 20)
            {
                return true;
            }

            return false;
        }

        private static string ProductType(double water, double flour)
        {
            switch (water * 100 / (water + flour))
            {
                case 50: return "Croissant";
                case 40: return "Muffin";
                case 30: return "Baguette";
                    //case 100
            }
            return "Bagel";

        }

    }
}
