using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    public class SimpleCalculator
    {
        public static void Main()
        {
            string[] inputTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Stack<string> calcExpression = new Stack<string>(inputTokens.Reverse());

            int result = 0;
            int leftOperand = int.Parse(calcExpression.Pop());
            while (calcExpression.Count > 1)    // if there is only 1 element, that's the result of the calculation
            {
                // since we always have operand followed by operator no need of checks for validity
                string @operator = calcExpression.Pop();
                int rightOperand = int.Parse(calcExpression.Pop());

                switch (@operator)
                {
                    case "+":
                        result = leftOperand + rightOperand;
                        break;
                    case "-":
                        result = leftOperand - rightOperand;
                        break;
                }

                leftOperand = result;
            }

            Console.WriteLine(result);
        }
    }
}
