using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseNumbersWithAStack
{
    public class ReverseNumbersWithAStack
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().
                Split(' ', StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();

            Stack<int> stack = new Stack<int>(numbers);
            foreach (var number in stack)
            {
                Console.Write(number + " ");
            }
        }
    }
}
