using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    public class MatchingBrackets
    {
        public static void Main()
        {
            string expression = Console.ReadLine();

            Stack<int> indexes = new Stack<int>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    indexes.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int startIndex = indexes.Pop();
                    int endIndex = i;
                    Console.WriteLine(expression.Substring(startIndex, endIndex - startIndex + 1));
                }
            }
        }
    }
}
