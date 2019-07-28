using System;
using System.Linq;

namespace SumNumbers
{
    public class SumNumbers
    {
        public static void Main()
        {
            var result = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            Console.WriteLine(result.Count());
            Console.WriteLine(result.Sum());
        }
    }
}
