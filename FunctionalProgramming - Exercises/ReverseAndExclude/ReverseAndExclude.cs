using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    public class ReverseAndExclude
    {
        public static void Main()
        {
            List<int> collection = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int n = int.Parse(Console.ReadLine());

            Action<List<int>> reverseAction = nums => nums.Reverse();
            Func<List<int>, List<int>> removeFunc = nums => nums.Where(num => num % n != 0).ToList();
            Action<List<int>> printAction = nums => Console.WriteLine(string.Join(' ', nums));

            reverseAction(collection);
            collection = removeFunc(collection);
            printAction(collection);
        }
    }
}
