using System;
using System.Linq;

namespace SortEvenNumbers
{
    public class SortEvenNumbers
    {
        public static void Main()
        {
            var result = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(x => x);

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
