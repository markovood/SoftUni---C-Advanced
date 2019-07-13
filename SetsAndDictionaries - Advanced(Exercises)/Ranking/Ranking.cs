using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    public class Ranking
    {
        public static void Main()
        {
            Dictionary<string, string> contestsAndPasswords = new Dictionary<string, string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of contests")
                {
                    break;
                }

                string[] inputTokens = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string contest = inputTokens[0];
                string password = inputTokens[1];
                if (!contestsAndPasswords.ContainsKey(contest))
                {
                    contestsAndPasswords.Add(contest, password);
                }// if already have that contest change pass
            }

            var userContestsAndPoints = new Dictionary<string, Dictionary<string, int>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of submissions")
                {
                    break;
                }

                string[] inputTokens = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = inputTokens[0];
                string password = inputTokens[1];
                string username = inputTokens[2];
                int points = int.Parse(inputTokens[3]);

                if (contestsAndPasswords.ContainsKey(contest))
                {
                    if (contestsAndPasswords[contest] == password)
                    {
                        if (userContestsAndPoints.ContainsKey(username))
                        { 
                            if (userContestsAndPoints[username].ContainsKey(contest))
                            {
                                // update the points only if the new ones are more than the older ones
                                int currentPts = userContestsAndPoints[username][contest];
                                if (points > currentPts)
                                {
                                    userContestsAndPoints[username][contest] = points;
                                }
                            }
                            else
                            {
                                userContestsAndPoints[username].Add(contest, points);
                            }
                        }
                        else
                        {
                            userContestsAndPoints.Add(username, new Dictionary<string, int>()
                            {
                                {contest, points}
                            });
                        }
                    }
                }
            }

            string bestUser = userContestsAndPoints.OrderByDescending(u => u.Value.Values.Sum()).First().Key;
            int totalPts = userContestsAndPoints[bestUser].Values.Sum();
            Console.WriteLine($"Best candidate is {bestUser} with total {totalPts} points.");

            Console.WriteLine("Ranking:");
            userContestsAndPoints = userContestsAndPoints.OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            foreach (var user in userContestsAndPoints.Keys)
            {
                Console.WriteLine(user);
                foreach (var contestAndPts in userContestsAndPoints[user].OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contestAndPts.Key} -> {contestAndPts.Value}");
                }
            }
        }
    }
}
