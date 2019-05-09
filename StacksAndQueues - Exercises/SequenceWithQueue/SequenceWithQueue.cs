using System;
using System.Collections.Generic;
using System.Linq;

namespace SequenceWithQueue
{
    public class SequenceWithQueue
    {
        public static void Main()
        {
            long initialInput = long.Parse(Console.ReadLine());

            Queue<long> queue = new Queue<long>();
            List<long> finalResult = new List<long>();

            queue.Enqueue(initialInput);
            finalResult.Add(initialInput);

            // optimization - loop is going to 17 only, as we need just the first 50 members(we are adding 3
            // members every time)
            for (int i = 0; i < 17; i++)
            {
                long currenNumber = queue.Dequeue();

                long a = currenNumber + 1;
                long b = currenNumber * 2 + 1;
                long c = currenNumber + 2;

                queue.Enqueue(a);
                queue.Enqueue(b);
                queue.Enqueue(c);

                finalResult.Add(a);
                finalResult.Add(b);
                finalResult.Add(c);
            }

            Console.WriteLine(string.Join(" ", finalResult.Take(50)));
        }
    }
}
