using System;
using System.Collections.Generic;

namespace PeriodicTable
{
    public class PeriodicTable
    {
        public static void Main()
        {
            int compoundsCount = int.Parse(Console.ReadLine());

            SortedSet<string> containingElements = new SortedSet<string>();
            for (int i = 0; i < compoundsCount; i++)
            {
                string[] compoundElements = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var element in compoundElements)
                {
                    containingElements.Add(element);
                }
            }

            Console.WriteLine(string.Join(' ', containingElements));
        }
    }
}
