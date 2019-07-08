using System;
using System.Collections.Generic;
using System.Linq;

namespace TheVLogger
{
    public class TheVLogger
    {
        public static void Main()
        {
            // what we need is data structure to keep:

            // total vloggers --> as every vlogger has a list with only 2 elements -> List<string> followers and
            // List<string> followings
            var vloggers = new Dictionary<string, List<List<string>>>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Statistics")
                {
                    break;
                }

                string[] commandTokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string vloggerName = commandTokens[0];

                switch (commandTokens[1])
                {
                    case "joined":
                        if (!vloggers.ContainsKey(vloggerName))
                        {
                            var followers = new List<string>();
                            var followings = new List<string>();
                            vloggers.Add(vloggerName, new List<List<string>>() { followers, followings });
                        }

                        break;
                    case "followed":
                        string vloggerName2 = commandTokens[2];
                        if (vloggers.ContainsKey(vloggerName) &&
                            vloggers.ContainsKey(vloggerName2) &&
                            vloggerName != vloggerName2)
                        {
                            if (!vloggers[vloggerName][1].Contains(vloggerName2))
                            {
                                vloggers[vloggerName][1].Add(vloggerName2);
                            }

                            if (!vloggers[vloggerName2][0].Contains(vloggerName))
                            {
                                vloggers[vloggerName2][0].Add(vloggerName);
                            }
                        }

                        break;
                }
            }

            // print statistics
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            // find most famous vlogger (the vlogger with the most followers), print him along with his
            // followers ordered in lexicographical order
            var theMostFamousVloggers = vloggers
                                        .OrderByDescending(v => v.Value[0].Count)
                                        .ThenBy(v => v.Value[1].Count);

            string theMostFamous = theMostFamousVloggers.First().Key;
            Console.WriteLine($"1. {theMostFamous} : {theMostFamousVloggers.First().Value[0].Count} followers, {theMostFamousVloggers.First().Value[1].Count} following");
            var theMostFamouseVloggerFollowers = theMostFamousVloggers.First().Value[0];
            if (theMostFamouseVloggerFollowers.Count > 0)
            {
                theMostFamouseVloggerFollowers.Sort();
                foreach (var follower in theMostFamouseVloggerFollowers)
                {
                    Console.WriteLine($"*  {follower}");
                }
            }

            // print all other vloggers, ordered by number of followers (descending) and number of followings
            // (ascending)
            int nextNumber = 2;
            foreach (var vlogger in theMostFamousVloggers)
            {
                if (vlogger.Key == theMostFamous)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine($"{nextNumber++}. {vlogger.Key} : {vlogger.Value[0].Count} followers, {vlogger.Value[1].Count} following");
                }
            }
        }
    }
}
