using System;
using System.Collections.Generic;
using System.Linq;

namespace T04MovieTime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string favouriteGenre = Console.ReadLine();
            string shortOrLong = Console.ReadLine();
            TimeSpan totalPlayListDuration = TimeSpan.Zero;
            string input;
            Dictionary<string, TimeSpan> allMovies_Durations = new Dictionary<string, TimeSpan>();

            while ((input = Console.ReadLine()) != "POPCORN!")
            {
                string[] tokens = input.Split('|');
                string currentMovieName = tokens[0];
                string currentMovieGenre = tokens[1];
                TimeSpan currentMovieDuration = TimeSpan.Parse(tokens[2]);
                if (currentMovieGenre == favouriteGenre)
                {
                    allMovies_Durations.Add(currentMovieName, currentMovieDuration);
                    
                }
                totalPlayListDuration += currentMovieDuration;
            }
            
            if(shortOrLong == "Short")
            {
                allMovies_Durations = allMovies_Durations.OrderBy(x => x.Value).ThenBy(x => x.Key)
                    .ToDictionary(k => k.Key, v => v.Value);
            }
            else
            {
                allMovies_Durations = allMovies_Durations.OrderByDescending(x => x.Value).ThenBy(x => x.Key)
                    .ToDictionary(k => k.Key, v => v.Value);
            }

            Queue<KeyValuePair<string, TimeSpan>> moviesToPop = new Queue<KeyValuePair<string, TimeSpan>>(allMovies_Durations);

           
            KeyValuePair<string, TimeSpan> currentMovie_Duration = new KeyValuePair<string, TimeSpan>();
            while (true)
            {
                currentMovie_Duration = moviesToPop.Dequeue();
                Console.WriteLine($"{currentMovie_Duration.Key}");
                string reply = Console.ReadLine();                
                if (reply == "Yes")
                {
                    Console.WriteLine($"We're watching {currentMovie_Duration.Key} - {currentMovie_Duration.Value}");
                    Console.WriteLine($"Total Playlist Duration: {totalPlayListDuration}");
                    return;
                }

            }
           
        }
    }
}
