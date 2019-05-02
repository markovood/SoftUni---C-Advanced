using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumElement
{
    public class MaximumElement
    {
        public static void Main()
        {
            int numberQueries = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < numberQueries; i++)
            {
                string query = Console.ReadLine();
                char queryOperation = query[0];
                switch (queryOperation)
                {
                    case '1':
                        // 1 x - Push the element x into the stack.
                        string[] queryTokens = query.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        int elementToPush = int.Parse(queryTokens[1]);
                        stack.Push(elementToPush);
                        break;
                    case '2':
                        // 2 - Delete the element present at the top of the stack.
                        stack.Pop();
                        break;
                    case '3':
                        // 3 - Print the maximum element in the stack.
                        Console.WriteLine(stack.Max());
                        break;
                }
            }
        }
    }
}
