using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace T03TicketTrouble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\[)([^\[{]*?){(?<destination>[A-Z]{3} [A-Z]{2})}([^{\[\]}]*?){(?<seat>[A-Z]{1}[0-9]{1,2})}([^}\]]*?)(\])|({)([^\[{]*?)\[(?<destination>[A-Z]{3} [A-Z]{2})\]([^{\[\]}]*?)\[(?<seat>[A-Z]{1}[0-9]{1,2})\]([^}\]]*?)(})";

            string location = Console.ReadLine();
            string suitcaseContent = Console.ReadLine();

            MatchCollection matches = Regex.Matches(suitcaseContent, pattern);

            List<string> validTicketsSeats = new List<string>();
            List<string> ticketsWithSameNumber = new List<string>();

            foreach (Match match in matches)
            {

                if (match.Groups["destination"].Value == location)
                {
                    validTicketsSeats.Add(match.Groups["seat"].Value);

                }

            }

            foreach (string seat in validTicketsSeats)
            {
                if (validTicketsSeats.Count(x => x.Contains(seat.Substring(1))) == 2)
                {
                    ticketsWithSameNumber.Add(seat);
                }
             
            }
            string seat1 = null;
            string seat2 = null;
            if (ticketsWithSameNumber.Count == 2)
            {
                seat1 = ticketsWithSameNumber[0];
                seat2 = ticketsWithSameNumber[1];
            }
            else
            {
                seat1 = validTicketsSeats[0];
                seat2 = validTicketsSeats[1];
            }
            Console.WriteLine($"You are traveling to {location} on seats {seat1} and {seat2}.");
        }
    }
}
