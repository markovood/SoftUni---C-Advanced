using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    public class FindEvensOrOdds
    {
        public static void Main()
        {
            string[] boundaries = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int lowerBound = int.Parse(boundaries[0]);
            int upperBound = int.Parse(boundaries[1]);

            string filter = Console.ReadLine();

            int[] range = Enumerable.Range(lowerBound, upperBound - lowerBound + 1).ToArray();

            Predicate<int> isEven = x => x % 2 == 0;
            Predicate<int> isOdd = x => x % 2 != 0;

            List<int> result = new List<int>();
            foreach (var number in range)
            {
                if (filter == "even" ? isEven(number) : isOdd(number))
                {
                    result.Add(number);
                }
            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
