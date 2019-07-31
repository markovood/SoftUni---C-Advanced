using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    public class AppliedArithmetics
    {
        public static void Main()
        {
            List<int> collection = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string operation = Console.ReadLine();

                if (operation == "end")
                {
                    break;
                }

                switch (operation)
                {
                    case "add":
                        collection = Executor(collection, Add);
                        break;
                    case "subtract":
                        collection = Executor(collection, Subtract);
                        break;
                    case "multiply":
                        collection = Executor(collection, Multiply);
                        break;
                    case "print":
                        Console.WriteLine(string.Join(' ', collection));
                        break;
                }
            }
        }

        private static List<int> Multiply(List<int> collectionToManipulate)
        {
            return collectionToManipulate
                            .Select(x => x *= 2)
                            .ToList();
        }

        private static List<int> Subtract(List<int> collectionToManipulate)
        {
            return collectionToManipulate
                            .Select(x => --x)
                            .ToList();
        }

        private static List<int> Add(List<int> collectionToManipulate)
        {
            return collectionToManipulate
                            .Select(x => ++x)
                            .ToList();
        }

        private static List<int> Executor(List<int> collection, Func<List<int>, List<int>> resultFunc)
        {
            return resultFunc(collection);
        }
    }
}
