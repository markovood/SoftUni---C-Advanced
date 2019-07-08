using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    public class SetsOfElements
    {
        public static void Main()
        {
            string[] lengthsTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int firstSetLength = int.Parse(lengthsTokens[0]);
            int secondSetLength = int.Parse(lengthsTokens[1]);

            int[] firstSet = new int[firstSetLength];
            int[] secondSet = new int[secondSetLength];
        

            for (int i = 0; i < firstSetLength; i++)
            {
                int number = int.Parse(Console.ReadLine());
                firstSet[i] = number;
            }

            for (int i = 0; i < secondSetLength; i++)
            {
                int number = int.Parse(Console.ReadLine());
                secondSet[i] = number;
            }

            HashSet<int> repeatingElements = new HashSet<int>();
            for (int i = 0; i < firstSet.Length; i++)
            {
                if (secondSet.Contains(firstSet[i]))
                {
                    repeatingElements.Add(firstSet[i]);
                }
            }

            Console.WriteLine(string.Join(' ', repeatingElements));
        }
    }
}
