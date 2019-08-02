using System;
using System.Linq;

namespace CustomComparator
{
    public class CustomComparator
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Comparison<int> comparer = (x, y) =>
                                                (x % 2 == 0 && y % 2 != 0) ? -1 :
                                                (x % 2 != 0 && y % 2 == 0) ? 1 :
                                                x.CompareTo(y);
            Array.Sort(arr, comparer);
            Console.WriteLine(string.Join(' ', arr));
        }
    }
}
