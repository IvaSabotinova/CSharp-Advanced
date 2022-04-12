using System;
using System.Collections.Generic;

namespace T05CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> allContinents_Countries_Cities =
                new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < number; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string currentContinent = data[0];
                string currentCountry = data[1];
                string currentCity = data[2];

                if (!allContinents_Countries_Cities.ContainsKey(currentContinent))
                {
                    allContinents_Countries_Cities.Add(currentContinent, new Dictionary<string, List<string>>());
                }

                if (!allContinents_Countries_Cities[currentContinent].ContainsKey(currentCountry))
                {
                    allContinents_Countries_Cities[currentContinent].Add(currentCountry, new List<string>());
                }
                allContinents_Countries_Cities[currentContinent][currentCountry].Add(currentCity);
                
            }

            foreach (KeyValuePair<string, Dictionary<string, List<string>>> continent in allContinents_Countries_Cities)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (KeyValuePair<string, List<string>> country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
            
        }
    }
}
