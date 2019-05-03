using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    public class BasicQueueOperations
    {
        public static void Main()
        {
            int[] firstInputLine = Console.ReadLine().
                Split(' ', StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();
            
            int elementsToDequeue = firstInputLine[1];
            int elementToFind = firstInputLine[2];

            int[] secondInputLine = Console.ReadLine().
                Split(' ', StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();

            Queue<int> queue = new Queue<int>(secondInputLine);
            for (int i = 0; i < elementsToDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(elementToFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
