using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    public class BasicStackOperations
    {
        public static void Main()
        {
            int[] firstInputLine = Console.ReadLine().
                Split(' ',StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();

            //int elementsToPush = firstInputLine[0];
            int elementsToPop = firstInputLine[1];
            int elementToFind = firstInputLine[2];

            int[] secondInputLine = Console.ReadLine().
                Split(' ', StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();

            Stack<int> stack = new Stack<int>(secondInputLine);
            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(elementToFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
