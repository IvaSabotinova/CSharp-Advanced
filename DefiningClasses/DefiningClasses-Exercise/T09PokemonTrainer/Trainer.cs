using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        public string Name { get; set; }
        public int NumBadges { get; set; }

        public List<Pokemon> collectionPokemons { get; set; }

        public Trainer(string name, int badges, List<Pokemon> pokemons)
        {
            Name = name;
            NumBadges = badges;
            collectionPokemons = pokemons;
        }

    }

    public class Pokemon
    {
        public Pokemon(string name, string element, int health)
        {
            PokemName = name;
            PokemElement = element;
            PokemHealth = health;
        }
        public string PokemName { get; set; }
        public string PokemElement { get; set; }
        public int PokemHealth { get; set; }

    }

}
