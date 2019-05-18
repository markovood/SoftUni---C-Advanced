using System;
using System.Collections.Generic;

namespace BalancedParenthesis
{
    public class BalancedParenthesis
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentSymbol = input[i];
                char result;
                switch (currentSymbol)
                {
                    case '(':
                        stack.Push(currentSymbol);
                        break;
                    case '[':
                        stack.Push(currentSymbol);
                        break;
                    case '{':
                        stack.Push(currentSymbol);
                        break;
                    case ')':
                        if (stack.TryPeek(out result) && result == '(')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            return;
                        }

                        break;
                    case ']':
                        if (stack.TryPeek(out result) && result == '[')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            return;
                        }

                        break;
                    case '}':
                        if (stack.TryPeek(out result) && result == '{')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            return;
                        }

                        break;
                }
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
