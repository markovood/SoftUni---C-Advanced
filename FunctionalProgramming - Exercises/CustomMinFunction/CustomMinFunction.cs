using System;
using System.Linq;

namespace CustomMinFunction
{
    public class CustomMinFunction
    {
        public static void Main()
        {
            int[] ints = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> min = Min;

            Console.WriteLine(min(ints));
        }

        private static int Min(int[] nums)
        {
            int smallest = int.MaxValue;
            foreach (var num in nums)
            {
                if (num < smallest)
                {
                    smallest = num;
                }
            }

            return smallest;
        }
    }
}
