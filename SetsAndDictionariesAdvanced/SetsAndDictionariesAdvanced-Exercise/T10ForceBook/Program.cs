using System;
using System.Collections.Generic;
using System.Linq;


namespace T10ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            Dictionary<string, HashSet<string>> allForceSides_Users = new Dictionary<string, HashSet<string>>();

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                if (input.Contains("|"))
                {
                    string[] data = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    string currSide = data[0];
                    string currForceUser = data[1];

                    if (!allForceSides_Users.ContainsKey(currSide))
                    {
                        allForceSides_Users.Add(currSide, new HashSet<string>());
                    }

                    if (!allForceSides_Users.Values.Any(x=>x.Contains(currForceUser)))
                    {
                        allForceSides_Users[currSide].Add(currForceUser);
                    }
                   

                }
                else if (input.Contains("->"))
                {
                    string[] data = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string currentForceUser = data[0];
                    string currentForceSide = data[1];

                    if (allForceSides_Users.Values.Any(v => v.Contains(currentForceUser)))
                    {
                        allForceSides_Users.Values.Any(v => v.Remove(currentForceUser));
                    }

                    if (!allForceSides_Users.ContainsKey(currentForceSide))
                    {
                        allForceSides_Users.Add(currentForceSide, new HashSet<string>());
                    }
                    allForceSides_Users[currentForceSide].Add(currentForceUser);
                    Console.WriteLine($"{currentForceUser} joins the {currentForceSide} side!");
                }

            }


            foreach (KeyValuePair<string, HashSet<string>> forceSide in allForceSides_Users.Where(v => v.Value.Count > 0).OrderByDescending(v => v.Value.Count).ThenBy(k => k.Key))
            {
                Console.WriteLine($"Side: {forceSide.Key}, Members: {forceSide.Value.Count}");
                foreach (string forceUser in forceSide.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {forceUser}");
                }
            }
        }
    }
}
