using System;
using System.Collections.Generic;
using System.Linq;

namespace T10ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] guests = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<(string, string)> filters = new List<(string, string)>();
            string command;
            while ((command = Console.ReadLine()) != "Print")
            {
                string[] tokens = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Add filter")
                {
                    filters.Add((tokens[1], tokens[2]));
                }
                else if (tokens[0] == "Remove filter")
                {
                    filters.Remove((tokens[1], tokens[2]));
                }
            }

            foreach ((string, string) filter in filters)
            {
                if (filter.Item1 == "Starts with")
                {
                    guests = guests.Where(w => !w.StartsWith(filter.Item2)).ToArray();
                }
                else if (filter.Item1 == "Ends with")
                {
                    guests = guests.Where(w => !w.EndsWith(filter.Item2)).ToArray();
                }
                else if (filter.Item1 == "Length")
                {
                    guests = guests.Where(w => w.Length == int.Parse(filter.Item2)).ToArray();
                }
                else if (filter.Item1 == "Contains")
                {
                    guests = guests.Where(w => !w.Contains(filter.Item2)).ToArray();
                }
            }

            Action<string[]> print = text => Console.WriteLine(string.Join(" ", text));
            print(guests);

        }
    }
}

