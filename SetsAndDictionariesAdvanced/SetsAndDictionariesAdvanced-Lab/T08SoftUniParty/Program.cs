using System;
using System.Collections.Generic;

namespace T08SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = String.Empty;

            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();
            bool partyStarted = false;

            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "PARTY")
                {
                    partyStarted = true;
                    continue;
                }

                if (partyStarted)
                {
                    vipGuests.Remove(input);
                    regularGuests.Remove(input);
                }
                else
                {
                    if (Char.IsDigit(input[0]))
                    {
                        vipGuests.Add(input);
                    }
                    else
                    {
                        regularGuests.Add(input);
                    }
                }
            }

            Console.WriteLine(vipGuests.Count + regularGuests.Count);
            foreach (string vip in vipGuests)
            {
                Console.WriteLine(vip);
            }

            foreach (string regularGuest in regularGuests)
            {
                Console.WriteLine(regularGuest);
            }
        }
    }
}
