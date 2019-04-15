using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseStrings
{
    public class ReverseStrings
    {
        public static void Main()
        {
            Console.WriteLine("Please enter a string...");
            string userInputStr = Console.ReadLine();

            string output = ReverseUserInputString(userInputStr);
            Console.WriteLine(output);
        }

        private static string ReverseUserInputString(string userInputStr)
        {
            var reverser = new Stack<char>();
            foreach (var symbol in userInputStr)
            {
                reverser.Push(symbol);
            }

            StringBuilder output = new StringBuilder();
            int reverserCount = reverser.Count;
            for (int i = 0; i < reverserCount; i++)
            {
                output.Append(reverser.Pop());
            }

            return output.ToString();
        }
    }
}