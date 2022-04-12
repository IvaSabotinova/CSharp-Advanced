using System;
using System.Collections.Generic;
using System.Linq;

namespace T08Ranking
{
    class Program
    {
        static void Main(string[] args)
        {

            string firtsCommand;

            Dictionary<string, string> allContestAndPasswords = new Dictionary<string, string>();

            while ((firtsCommand = Console.ReadLine()) != "end of contests")
            {
                string[] tokens = firtsCommand.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contest = tokens[0];
                string password = tokens[1];
                allContestAndPasswords.Add(contest, password);

            }

            string secondCommand;
            Dictionary<string, Dictionary<string, int>> allUsers_Contests_Points =
                new Dictionary<string, Dictionary<string, int>>();

            while ((secondCommand = Console.ReadLine()) != "end of submissions")
            {
                string[] data = secondCommand.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string currentContest = data[0];
                string currentPassword = data[1];
                string currentUser = data[2];
                int currentPoints = int.Parse(data[3]);
                bool haveValidContest = false;
                if (allContestAndPasswords.ContainsKey(currentContest) && allContestAndPasswords[currentContest] == currentPassword)
                {
                    haveValidContest = true;
                }

                if (haveValidContest)
                {
                    if (!allUsers_Contests_Points.ContainsKey(currentUser))
                    {
                        allUsers_Contests_Points.Add(currentUser, new Dictionary<string, int>());
                    }

                    if (!allUsers_Contests_Points[currentUser].ContainsKey(currentContest))
                    {
                        allUsers_Contests_Points[currentUser].Add(currentContest, 0);
                    }

                    if (allUsers_Contests_Points[currentUser][currentContest] < currentPoints)
                    {
                        allUsers_Contests_Points[currentUser][currentContest] = currentPoints;
                    }
                }
            }

            string bestUser = allUsers_Contests_Points.OrderByDescending(x => x.Value.Values.Sum()).First().Key;
            int bestUserPoints = allUsers_Contests_Points.OrderByDescending(x => x.Value.Values.Sum()).First().Value
                .Values.Sum();

            Console.WriteLine($"Best candidate is {bestUser} with total {bestUserPoints} points.");
            Console.WriteLine("Ranking: ");
            foreach (KeyValuePair<string, Dictionary<string, int>> user in allUsers_Contests_Points.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{user.Key}");
                foreach (KeyValuePair<string, int> contest in user.Value.OrderByDescending(v=>v.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
            
        }
    }
}
