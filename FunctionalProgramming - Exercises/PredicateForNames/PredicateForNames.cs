using System;
using System.Linq;

namespace PredicateForNames
{
    public class PredicateForNames
    {
        public static void Main()
        {
            int nameLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> predicate = n => n.Length <= nameLength;
            Func<string[], string[]> filterFunc = collection => collection.Where(predicate).ToArray();
            Action<string[]> printAction = collection => Console.WriteLine(string.Join(Environment.NewLine, collection));

            names = filterFunc(names);
            printAction(names);
        }
    }
}
