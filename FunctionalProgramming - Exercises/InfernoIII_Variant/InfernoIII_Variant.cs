using System;
using System.Collections.Generic;
using System.Linq;

namespace InfernoIII_Variant
{
    public class InfernoIII_Variant
    {
        public static void Main()
        {
            Action<List<int>> printAction = list => Console.WriteLine(string.Join(' ', list));

            List<int> sequence = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList();

            List<string> commands = new List<string>();

            // here we collect all the commands to execute after Forge
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
                string filterParameter = commandArgs[2];

                switch (operation)
                {
                    case "Exclude":
                        commands.Add(filterType + ";" + filterParameter);
                        break;
                    case "Reverse":
                        int indexToRemove = commands.LastIndexOf(filterType + ";" + filterParameter);
                        commands.RemoveAt(indexToRemove);
                        break;
                }
            }

            // apply changes to the sequence
            foreach (var command in commands)
            {
                string[] commandArgs = command.Split(';');
                string filterType = commandArgs[0];
                int filterParameter = int.Parse(commandArgs[1]);

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

                switch (filterType)
                {
                    case "Sum Left":
                        var toExclude = markLExcludeFunc(sequence, filterParameter);
                        excludeAction(sequence, toExclude);
                        break;
                    case "Sum Right":
                        toExclude = markRExcludeFunc(sequence, filterParameter);
                        excludeAction(sequence, toExclude);
                        break;
                    case "Sum Left Right":
                        toExclude = markLRExcludeFunc(sequence, filterParameter);
                        excludeAction(sequence, toExclude);
                        break;
                }
            }

            // print
            printAction(sequence);
        }
    }
}
