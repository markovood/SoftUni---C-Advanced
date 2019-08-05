using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePartyReservationFilterModule
{
    public class ThePartyReservationFilterModule
    {
        public static void Main()
        {
            Action<List<string>> print = list => Console.WriteLine(string.Join(" ", list));

            List<string> guests = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .ToList();

            // here we'll save the names from the current filter without actually filtering them yet (this way we
            // will preserve the original order of the names in the guests list)
            List<string> filteredStartsWith = new List<string>();
            List<string> filteredEndsWith = new List<string>();
            List<string> filteredLength = new List<string>();
            List<string> filteredContains = new List<string>();

            // start reading commands and at the end in the lists above should stay only names that are to be
            // removed
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Print")
                {
                    break;
                }

                string[] commandArgs = command.Split(';', StringSplitOptions.RemoveEmptyEntries);
                // command;filter type;filter parameter
                string operation = commandArgs[0];
                string filterType = commandArgs[1];
                string filterParameter = commandArgs[2];

                Predicate<string> startsWithPredicate = str => str.StartsWith(filterParameter);
                Predicate<string> endsWithPredicate = str => str.EndsWith(filterParameter);
                Predicate<string> LengthPredicate = str => str.Length == int.Parse(filterParameter);
                Predicate<string> containsPredicate = str => str.Contains(filterParameter);

                Func<List<string>, Predicate<string>, List<string>> addFilterFunc = (list, predicate) =>
                {
                    var filtered = list.FindAll(predicate);
                    return filtered;
                };

                Action<List<string>, Predicate<string>> removeFilterAction = (list, predicate) => list.RemoveAll(predicate);

                switch (operation)
                {
                    case "Add filter":
                        switch (filterType)
                        {
                            case "Starts with":
                                filteredStartsWith.AddRange(addFilterFunc(guests, startsWithPredicate));
                                break;
                            case "Ends with":
                                filteredEndsWith.AddRange(addFilterFunc(guests, endsWithPredicate));
                                break;
                            case "Length":
                                filteredLength.AddRange(addFilterFunc(guests, LengthPredicate));
                                break;
                            case "Contains":
                                filteredContains.AddRange(addFilterFunc(guests, containsPredicate));
                                break;
                        }

                        break;
                    case "Remove filter":
                        switch (filterType)
                        {
                            case "Starts with":
                                removeFilterAction(filteredStartsWith, startsWithPredicate);
                                break;
                            case "Ends with":
                                removeFilterAction(filteredEndsWith, endsWithPredicate);
                                break;
                            case "Length":
                                removeFilterAction(filteredLength, LengthPredicate);
                                break;
                            case "Contains":
                                removeFilterAction(filteredContains, containsPredicate);
                                break;
                        }

                        break;
                }
            }

            // here we'll apply actual filtering to the guests list
            Action<List<string>, List<string>> filterAction = (listToModify, containingList) =>
            {
                containingList.ForEach(str => 
                {
                    if (listToModify.Contains(str))
                    {
                        listToModify.Remove(str);
                    }
                });
            };

            filterAction(guests, filteredStartsWith);
            filterAction(guests, filteredEndsWith);
            filterAction(guests, filteredLength);
            filterAction(guests, filteredContains);

            print(guests);
        }
    }
}
