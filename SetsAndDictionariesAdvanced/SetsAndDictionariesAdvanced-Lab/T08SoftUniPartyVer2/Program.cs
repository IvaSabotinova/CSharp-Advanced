using System;
using System.Collections.Generic;

namespace T08SoftUniPartyVer2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            bool partyStarted = false;
            HashSet<string> guests = new HashSet<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "PARTY")
                {
                    partyStarted = true;
                    continue;
                }

                if (partyStarted)
                {
                    guests.Remove(input);
                }
                else
                {
                    guests.Add(input);
                }

            }

            Console.WriteLine(guests.Count);
            foreach (string guest in guests)
            {
                if (char.IsDigit(guest[0]))
                {
                    Console.WriteLine(guest);
                }
            }

            foreach (string guest in guests)
            {
                if (char.IsLetter(guest[0]))
                {
                    Console.WriteLine(guest);
                }
            }

        }
    }
}
