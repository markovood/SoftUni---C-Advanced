using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextEditor
{
    public class SimpleTextEditor
    {
        public static void Main()
        {
            int numberOfOperations = int.Parse(Console.ReadLine());

            Stack<string> textStates = new Stack<string>();
            string text = string.Empty;
            textStates.Push(text);

            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] operation = Console.ReadLine().
                    Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string commandName = operation[0];
                switch (commandName)
                {
                    case "1":
                        text += operation[1];
                        textStates.Push(text);
                        break;
                    case "2":
                        int count = int.Parse(operation[1]);
                        int startIndex = text.Length - count;
                        text = text.Remove(startIndex, count);
                        textStates.Push(text);
                        break;
                    case "3":
                        int index = int.Parse(operation[1]);
                        Console.WriteLine(text[index - 1]);
                        break;
                    case "4":
                        textStates.Pop();
                        text = textStates.Peek();
                        break;
                }
            }
        }
    }
}
