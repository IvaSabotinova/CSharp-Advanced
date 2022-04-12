using System;
using System.Collections.Generic;
using System.Linq;

namespace T07TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            Dictionary<string, Dictionary<string, HashSet<string>>> allVLoggers_Followers_Following =
                new Dictionary<string, Dictionary<string, HashSet<string>>>();


            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 4)
                {
                    string currVLogger = tokens[0];
                    if (!allVLoggers_Followers_Following.ContainsKey(currVLogger))
                    {
                        allVLoggers_Followers_Following.Add(currVLogger, new Dictionary<string, HashSet<string>>());
                        allVLoggers_Followers_Following[currVLogger].Add("followers", new HashSet<string>());
                        allVLoggers_Followers_Following[currVLogger].Add("following", new HashSet<string>());
                        
                    }


                }
                else
                {
                    string follower = tokens[0];
                    string VLogger = tokens[2];

                    if (follower != VLogger)
                    {
                        if (!allVLoggers_Followers_Following.ContainsKey(VLogger) || !allVLoggers_Followers_Following.ContainsKey(follower))
                        {
                            continue;
                        }

                        else
                        {
                            allVLoggers_Followers_Following[VLogger]["followers"].Add(follower);
                            allVLoggers_Followers_Following[follower]["following"].Add(VLogger);
                        }
                    }
                   
                    
                }

            }

            Console.WriteLine($"The V-Logger has a total of {allVLoggers_Followers_Following.Keys.Count} vloggers in its logs.");
            int count = 1;
            foreach (KeyValuePair<string, Dictionary<string, HashSet<string>>> vlogger in
                allVLoggers_Followers_Following.OrderByDescending(v => v.Value["followers"].Count)
                    .ThenBy(v => v.Value["following"].Count))
            {

                Console.WriteLine(
                    $"{count++}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");

                if (count == 2)
                {
                    foreach (string person in vlogger.Value["followers"].OrderBy(x => x))
                    {

                        if (vlogger.Value["followers"].Count > 0)
                        {
                            Console.WriteLine($"*  {person}");
                        }


                    }
                    
                }
            }

        }
    }
}
