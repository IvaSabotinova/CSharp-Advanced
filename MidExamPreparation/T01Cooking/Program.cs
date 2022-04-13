using System;
using System.Collections.Generic;

using System.Linq;


namespace T01Cooking
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] liquidsElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] ingredientsElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Dictionary<string, int> allDishes = new Dictionary<string, int>()
            {
                {"Bread", 0},
                {"Cake", 0},
                {"Pastry", 0},
                {"Fruit Pie", 0},

            };
           
            Queue<int> liquids = new Queue<int>(liquidsElements);
            Stack<int> ingredients = new Stack<int>(ingredientsElements);

            while (liquids.Count > 0 && ingredients.Count > 0)
            {

                if (CanProduceFood(liquids.Peek(), ingredients.Peek()))
                {
                   allDishes[FoodType(liquids.Dequeue(), ingredients.Pop())]++;
                }
                else
                {
                    liquids.Dequeue();
                    ingredients.Push(ingredients.Pop() + 3);
                }

            }

            if (allDishes["Bread"] > 0 && allDishes["Cake"] > 0 && allDishes["Pastry"] > 0 && allDishes["Fruit Pie"] > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            if (ingredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: { string.Join(", ", ingredients)}");
            }

            foreach (KeyValuePair<string, int> dish in allDishes.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{dish.Key}: {dish.Value}");
            }

        }

        private static bool CanProduceFood(int liquidValue, int ingredientValue)
        {
            if ((liquidValue + ingredientValue == 25) || (liquidValue + ingredientValue == 50) || (liquidValue + ingredientValue == 75) || (liquidValue + ingredientValue == 100))
            {
                return true;
            }

            return false;
        }

        private static string FoodType(int liquidValue, int ingredientValue)
        {
            switch (liquidValue + ingredientValue)
            {
                case 25: return "Bread";
                case 50: return "Cake";
                case 75: return "Pastry";
                //case 100
            }
            return "Fruit Pie";
            
        }

    }
}
