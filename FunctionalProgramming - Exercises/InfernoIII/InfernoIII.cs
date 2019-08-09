using System;
using System.Collections.Generic;
using System.Linq;

namespace InfernoIII
{
    public class InfernoIII
    {
        public static void Main()
        {
            List<int> sequence = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList();

            Action<List<int>, List<int>> excludeAction = (listToModify, listToExclude) =>
            {
                foreach (var num in listToExclude)
                {
                    if (listToModify.Contains(num))
                    {
                        listToModify.Remove(num);
                    }
                }
            };

            List<int> markedL = new List<int>();
            List<int> markedR = new List<int>();
            List<int> markedLR = new List<int>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Forge")
                {
                    break;
                }

                // command;filter type;filter parameter
                string[] commandArgs = command.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string operation = commandArgs[0];
                string filterType = commandArgs[1];
                int filterParameter = int.Parse(commandArgs[2]);

                Func<List<int>, int, List<int>> markLExcludeFunc = (list, filterValue) =>
                {
                    var marked = new List<int>();
                    int leftNum = 0;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (leftNum + list[i] == filterValue)
                        {
                            marked.Add(list[i]);
                        }

                        leftNum = list[i];
                    }

                    return marked;
                };
                Func<List<int>, int, List<int>> markRExcludeFunc = (list, filterValue) =>
                {
                    var marked = new List<int>();
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (i + 1 >= list.Count)
                        {
                            if (list[i] == filterValue)
                            {
                                marked.Add(list[i]);
                            }
                        }
                        else if (list[i] + list[i + 1] == filterValue)
                        {
                            marked.Add(list[i]);
                        }
                    }

                    return marked;
                };
                Func<List<int>, int, List<int>> markLRExcludeFunc = (list, filterValue) =>
                {
                    var marked = new List<int>();
                    int leftElement = 0;
                    for (int i = 0; i < list.Count; i++)
                    {
                        int currentElement = list[i];
                        if (i + 1 >= list.Count)
                        {
                            if (leftElement + currentElement == filterValue)
                            {
                                marked.Add(currentElement);
                            }
                        }
                        else
                        {
                            int rightElement = list[i + 1];
                            if (leftElement + currentElement + rightElement == filterValue)
                            {
                                marked.Add(list[i]);
                            }
                        }

                        leftElement = list[i];
                    }

                    return marked;
                };
                Action<List<int>, List<int>> reverseAction = (listToManipulate, values) =>
                {
                    foreach (var value in values)
                    {
                        if (listToManipulate.Contains(value))
                        {
                            listToManipulate.Remove(value);
                        }
                    }
                };

                switch (operation)
                {
                    case "Exclude":
                        switch (filterType)
                        {
                            case "Sum Left":
                                markedL = markLExcludeFunc(sequence, filterParameter);
                                break;
                            case "Sum Right":
                                markedR = markRExcludeFunc(sequence, filterParameter);
                                break;
                            case "Sum Left Right":
                                markedLR = markLRExcludeFunc(sequence, filterParameter);
                                break;
                        }

                        break;
                    case "Reverse":
                        switch (filterType)
                        {
                            case "Sum Left":
                                var toRemove = markLExcludeFunc(sequence, filterParameter);
                                reverseAction(markedL, toRemove);
                                break;
                            case "Sum Right":
                                toRemove = markRExcludeFunc(sequence, filterParameter);
                                reverseAction(markedR, toRemove);
                                break;
                            case "Sum Left Right":
                                toRemove = markLRExcludeFunc(sequence, filterParameter);
                                reverseAction(markedLR, toRemove);
                                break;
                        }

                        break;
                }
            }

            // apply changes to the sequence
            excludeAction(sequence, markedL);
            excludeAction(sequence, markedR);
            excludeAction(sequence, markedLR);

            // print
            Console.WriteLine(string.Join(' ', sequence));
        }
    }
}
