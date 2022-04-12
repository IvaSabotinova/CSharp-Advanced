using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {

            List<Trainer> allTrainers = new List<Trainer>();

            string command1;

            while ((command1 = Console.ReadLine()) != "Tournament")
            {
                string[] tokens = command1.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                Pokemon newPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                Trainer currTrainer = allTrainers.FirstOrDefault(x => x.Name == trainerName);

                if (currTrainer == null)
                {
                    currTrainer = new Trainer(trainerName, 0, new List<Pokemon>());
                    currTrainer.collectionPokemons.Add(newPokemon);
                    allTrainers.Add(currTrainer);
                }
                else
                {
                    currTrainer.collectionPokemons.Add(newPokemon);
                }
                
            }

            string command2;

            while ((command2 = Console.ReadLine()) != "End")
            {
                foreach (Trainer trainer in allTrainers)
                {
                    if (trainer.collectionPokemons.Any(x => x.PokemElement == command2))
                    {
                        trainer.NumBadges++;
                    }
                    else
                    {
                        trainer.collectionPokemons.Select(x => x.PokemHealth -= 10).ToList();
                        trainer.collectionPokemons.RemoveAll(x => x.PokemHealth <= 0);
                    }
                }

            }

            foreach (Trainer trainer in allTrainers.OrderByDescending(x => x.NumBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumBadges} {trainer.collectionPokemons.Count}");
            }

        }
    }
}
