using System;
using System.Collections.Generic;

using System.Linq;


namespace T09PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string command;

            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string mainCommand = tokens[0];
                Predicate<string> result = Result(tokens[1], tokens[2]);
                if (mainCommand == "Remove")
                {
                    names.RemoveAll(result);
                }
                else if (mainCommand == "Double")
                {
                    List<string> matches = names.FindAll(result);
                    int index = names.FindIndex(result);
                    if (matches.Count > 0)
                    {
                        names.InsertRange(index, matches);
                    }
                }
            }

            if (names.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        public static Predicate<string> Result(string command, string substr)
        {
            if (command == "StartsWith")
            {
                return x => x.StartsWith(substr);
            }
            else if (command == "EndsWith")
            {
                return x => x.EndsWith(substr);
            }
            return x => x.Length == int.Parse(substr);

        }
    }
}

