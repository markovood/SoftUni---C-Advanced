using System;
using System.Collections.Generic;

namespace StackFibonacci
{
    public class StackFibonacci
    {
        public static void Main()
        {
            int sequenceLength = int.Parse(Console.ReadLine());

            Stack<long> sequence = new Stack<long>();
            sequence.Push(0);
            sequence.Push(1);
            
            for (int i = 0; i < sequenceLength - 1; i++)
            {
                long lastElement = sequence.Pop();
                long elementBeforeLast = sequence.Peek();

                sequence.Push(lastElement);
                sequence.Push(lastElement + elementBeforeLast); 
            }

            Console.WriteLine(sequence.Pop());
        }
    }
}
