using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new List<Ingredient>();

        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel => Ingredients.Sum(x => x.Alcohol);

        public List<Ingredient> Ingredients { get; set; }

        public void Add(Ingredient ingredient)
        {
            if (Ingredients.All(x=>x.Name != ingredient.Name) && Ingredients.Count < Capacity && (CurrentAlcoholLevel + ingredient.Alcohol) <= MaxAlcoholLevel)
            {
                Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            Ingredient ingredient = Ingredients.FirstOrDefault(x => x.Name == name);
            return Ingredients.Remove(ingredient);
        }


        public Ingredient FindIngredient(string name)
        {
            Ingredient ingredient = Ingredients.FirstOrDefault(x => x.Name == name);
            return ingredient;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            Ingredient mostAlcoholIngredient = Ingredients.OrderByDescending(x => x.Alcohol).First();
            return mostAlcoholIngredient;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (Ingredient item in Ingredients)
            {
                sb.AppendLine($"{item}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
