using System;
using System.Collections.Generic;

using System.Linq;

namespace T01Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {


            int[] ingredientElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] freshnessElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> ingredients = new Queue<int>(ingredientElements);
            Stack<int> freshnessLevel = new Stack<int>(freshnessElements);
            Dictionary<string, int> dishesAndQnty = new Dictionary<string, int>();
            while (ingredients.Count > 0 && freshnessLevel.Count > 0)
            {
                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                    
                }

                else if (CanProduceDish(ingredients.Peek(), freshnessLevel.Peek()))
                {
                    if (!dishesAndQnty.ContainsKey(DishesType(ingredients.Peek(), freshnessLevel.Peek())))
                    {
                        dishesAndQnty.Add(DishesType(ingredients.Peek(), freshnessLevel.Peek()), 0);
                    }

                    dishesAndQnty[DishesType(ingredients.Dequeue(), freshnessLevel.Pop())]++;
                }
                else if (!CanProduceDish(ingredients.Peek(), freshnessLevel.Peek()))
                {
                    freshnessLevel.Pop();
                    ingredients.Enqueue(ingredients.Dequeue() + 5);
                }
            }


            if (dishesAndQnty.Keys.Count == 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            PrintDishes(dishesAndQnty);

        }

        public static string DishesType(int ingredient, int freshness)
        {
            switch (ingredient * freshness)
            {
                case 150: return "Dipping sauce";
                case 250: return "Green salad";
                case 300: return "Chocolate cake";
                    //case 400:
            }

            return "Lobster";
        }

        public static bool CanProduceDish(int ingredient, int freshnessLevel)
        {
            if (ingredient * freshnessLevel == 150 || ingredient * freshnessLevel == 250 ||
                ingredient * freshnessLevel == 300 || ingredient * freshnessLevel == 400)
            {
                return true;
            }

            return false;
        }

        public static void PrintDishes(Dictionary<string, int> dishes)
        {
            foreach (KeyValuePair<string, int> item in dishes.OrderBy(x => x.Key))
            {
                Console.WriteLine($" # {item.Key} --> {item.Value}");
            }
        }
    }
}
