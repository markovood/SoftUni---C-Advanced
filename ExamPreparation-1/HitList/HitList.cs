using System;
using System.Collections.Generic;
using System.Linq;

namespace HitList
{
    public class HitList
    {
        public static void Main()
        {
            int targetInfoIndex = int.Parse(Console.ReadLine());

            var infoDict = new Dictionary<string, Dictionary<string, string>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end transmissions")
                {
                    break;
                }

                // group the info for every person by their name
                // {name}={key}:{value};{key}:{value};...
                string[] inputTokens = input.Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = inputTokens[0];
                string[] kvps = inputTokens[1].Split(';', StringSplitOptions.RemoveEmptyEntries);

                var currentNameInfos = new Dictionary<string, string>();
                foreach (var kvp in kvps)
                {
                    string[] kvpTokens = kvp.Split(':', StringSplitOptions.RemoveEmptyEntries);
                    string key = kvpTokens[0];
                    string value = kvpTokens[1];
                    currentNameInfos.Add(key, value);
                }

                if (infoDict.ContainsKey(name))
                {
                    foreach (var item in currentNameInfos)
                    {
                        if (infoDict[name].ContainsKey(item.Key))
                        {
                            infoDict[name][item.Key] = item.Value;
                        }
                        else
                        {
                            infoDict[name].Add(item.Key, item.Value);
                        }
                    }
                }
                else
                {
                    infoDict.Add(name, new Dictionary<string, string>(currentNameInfos));
                }
            }

            string personToKill = Console.ReadLine().Split()[1];
            // find all the info on that name, print it, ordered alphabetically by key and build the info index
            var ordered = infoDict[personToKill].OrderBy(x => x.Key);

            int infoIndex = 0;
            Console.WriteLine($"Info on {personToKill}:");
            foreach (var info in ordered)
            {
                Console.WriteLine($"---{info.Key}: {info.Value}");
                infoIndex += info.Key.Length + info.Value.Length;
            }

            Console.WriteLine($"Info index: {infoIndex}");

            if (infoIndex >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                int infoNeeded = targetInfoIndex - infoIndex;
                Console.WriteLine($"Need {infoNeeded} more info.");
            }
        }
    }
}
