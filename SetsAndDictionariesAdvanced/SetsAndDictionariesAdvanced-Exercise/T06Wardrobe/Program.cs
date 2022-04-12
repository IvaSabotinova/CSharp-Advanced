using System;
using System.Collections.Generic;


namespace T06Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> allColors_Clothes_Count = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                string currColor = input[0];

                if (allColors_Clothes_Count.ContainsKey(currColor) == false)
                {
                    allColors_Clothes_Count.Add(currColor, new Dictionary<string, int>());
                }

                for (int j = 1; j < input.Length; j++)
                {
                    string currClothing = input[j];
                    if (!allColors_Clothes_Count[currColor].ContainsKey(currClothing))
                    {
                        allColors_Clothes_Count[currColor].Add(currClothing, 0);

                    }

                    allColors_Clothes_Count[currColor][currClothing]++;
                }
            }

            string[] itemToFind = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string colorToFind = itemToFind[0];
            string clothingToFind = itemToFind[1];

            foreach (KeyValuePair<string, Dictionary<string, int>> color in allColors_Clothes_Count)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (KeyValuePair<string, int> clothing in color.Value)
                {
                    if (color.Key == colorToFind && clothing.Key == clothingToFind)
                    {
                        Console.WriteLine($"* {clothing.Key} - {clothing.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothing.Key} - {clothing.Value}");
                    }

                }
            }

        }
    }
}
