using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    public class CountSameValuesInArray
    {
        public static void Main()
        {
            double[] inputArr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> occurences = new Dictionary<double, int>();

            // count all elements and write them to a dictionary as key == number and value == occurrences
            foreach (var number in inputArr)
            {
                if (occurences.ContainsKey(number))
                {
                    occurences[number]++;
                }
                else
                {
                    occurences[number] = 1;
                }
            }

            foreach (var occurence in occurences)
            {
                Console.WriteLine($"{occurence.Key} - {occurence.Value} times");
            }
        }
    }
}
