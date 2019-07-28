using System;
using System.Linq;

namespace CountUppercaseWords
{
    public class CountUppercaseWords
    {
        public static void Main()
        {
            // Func<string, bool> isUpper = IsUpper;
            Func<string, bool> isUpper = w => char.IsUpper(w[0]);

            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(isUpper)
                .ToList()
                .ForEach(w => Console.WriteLine(w));
        }

        public static bool IsUpper(string word)
        {
            return char.IsUpper(word[0]);
        }
    }
}
