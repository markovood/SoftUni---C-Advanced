using System;
using System.Linq;

namespace KnightsOfHonor
{
    public class KnightsOfHonor
    {
        public static void Main()
        {
            var names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(n => "Sir " + n)
                .ToArray();

            Action<string[]> print = n => Console.WriteLine(string.Join(Environment.NewLine, n));

            print(names);
        }
    }
}
