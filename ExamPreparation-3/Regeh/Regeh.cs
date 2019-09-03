using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Regeh
{
    public class Regeh
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"\[[^\s\[\]]+<(\d+)REGEH(\d+)>[^\s\[\]]+\]";
            MatchCollection validMatches = Regex.Matches(input, pattern);

            List<int> indexes = new List<int>();
            foreach (Match validMatch in validMatches)
            {
                indexes.Add(int.Parse(validMatch.Groups[1].Value));
                indexes.Add(int.Parse(validMatch.Groups[2].Value));
            }

            string result = string.Empty;

            int prevIndex = 0;
            for (int i = 0; i < indexes.Count; i++)
            {
                int currentIndex = indexes[i] + prevIndex;
                if (currentIndex >= input.Length)
                {
                    currentIndex %= input.Length;
                    result += input[currentIndex];
                }
                else
                {
                    result += input[currentIndex];
                }

                prevIndex += indexes[i];
            }

            Console.WriteLine(result);
        }
    }
}
