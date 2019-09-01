using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace MovieTime
{
    public class MovieTime
    {
        public static void Main()
        {
            string genre = Console.ReadLine();
            string duration = Console.ReadLine();

            var movies = new Dictionary<string, Dictionary<string, TimeSpan>>();
            while (true)
            {
                string movieInfo = Console.ReadLine();
                if (movieInfo == "POPCORN!")
                {
                    break;
                }

                // {name}|{genre}|{duration}
                string[] movieInfoTokens = movieInfo.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string movieName = movieInfoTokens[0];
                string movieGenre = movieInfoTokens[1];
                string[] durationTokens = movieInfoTokens[2].Split(':', StringSplitOptions.RemoveEmptyEntries);
                TimeSpan movieDuration = new TimeSpan(int.Parse(durationTokens[0]), int.Parse(durationTokens[1]), int.Parse(durationTokens[2]));

                if (movies.ContainsKey(movieGenre))
                {
                    if (!movies[movieGenre].ContainsKey(movieName))
                    {
                        movies[movieGenre].Add(movieName, movieDuration);
                    }
                }
                else
                {
                    movies.Add(movieGenre, new Dictionary<string, TimeSpan>() { { movieName, movieDuration } });
                }
            }

            // Print information about the next best movie in the chosen genre, until you receive 'Yes'

            var ordered = duration == "Short" ?
                movies[genre].OrderBy(x => x.Value) :
                movies[genre].OrderByDescending(x => x.Value);

            foreach (var movie in ordered)
            {
                Console.WriteLine(movie.Key);
                string answer = Console.ReadLine();
                if (answer == "Yes")
                {
                    TimeSpan totalPlayListDuration = GetTotalDuration(movies);
                    Console.WriteLine($"We're watching {movie.Key} - {movie.Value.Hours:D2}:{movie.Value.Minutes:D2}:{movie.Value.Seconds:D2}");
                    Console.WriteLine($"Total Playlist Duration: {totalPlayListDuration.Hours:D2}:{totalPlayListDuration.Minutes:D2}:{totalPlayListDuration.Seconds:D2}");
                    break;
                }
            }
        }

        private static TimeSpan GetTotalDuration(Dictionary<string, Dictionary<string, TimeSpan>> movies)
        {
            TimeSpan time = new TimeSpan();
            foreach (var genre in movies.Keys)
            {
                foreach (var movie in movies[genre])
                {
                    time = time.Add(movie.Value);
                }
            }

            return time;
        }
    }
}
