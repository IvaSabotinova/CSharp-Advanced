using System;
using System.Collections.Generic;
using System.Linq;

namespace T09SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {

            string input;

            Dictionary<string, int> allParticipants_Points = new Dictionary<string, int>();
            Dictionary<string, int> allLanguages_Points = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] data = input.Split("-", StringSplitOptions.RemoveEmptyEntries);
                string currentParticipant = data[0];
                string currentLanguage = data[1];

                if (currentLanguage == "banned")
                {
                    allParticipants_Points.Remove(currentParticipant);
                }
                else
                {
                    int currentPoints = int.Parse(data[2]);
                    if (!allParticipants_Points.ContainsKey(currentParticipant))
                    {
                        allParticipants_Points.Add(currentParticipant, 0);
                    }

                    if (allParticipants_Points[currentParticipant] < currentPoints)
                    {
                        allParticipants_Points[currentParticipant] = currentPoints;
                    }

                    if (!allLanguages_Points.ContainsKey(currentLanguage))
                    {
                        allLanguages_Points.Add(currentLanguage, 0);
                    }

                    allLanguages_Points[currentLanguage]++;
                }

            }

            Console.WriteLine("Results:");
            foreach (KeyValuePair<string, int> user in allParticipants_Points.OrderByDescending(v => v.Value).ThenBy(k => k.Key))
            {

                Console.WriteLine($"{user.Key} | {user.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (KeyValuePair<string, int> contest in allLanguages_Points.OrderByDescending(v => v.Value).ThenBy(k => k.Key))
            {
                Console.WriteLine($"{contest.Key} - {contest.Value}");
            }
        }
    }
}
