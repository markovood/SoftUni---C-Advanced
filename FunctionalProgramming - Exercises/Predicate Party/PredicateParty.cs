using System;
using System.Collections.Generic;
using System.Linq;

namespace Predicate_Party
{
    public class PredicateParty
    {
        public static void Main()
        {
            Action<string> printAction = s =>
            {
                if (s.Length == 0)
                {
                    Console.WriteLine("Nobody is going to the party!");
                }
                else
                {
                    Console.WriteLine(s + " are going to the party!");
                }
            };

            List<string> people = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .ToList();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Party!")
                {
                    break;
                }

                string[] commandTokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string operation = commandTokens[0];
                string criteria = commandTokens[1];
                string criteriaValue = commandTokens[2];

                Predicate<string> startsWithPredicate = str => str.StartsWith(criteriaValue);
                Predicate<string> endsWithPredicate = str => str.EndsWith(criteriaValue);
                Predicate<string> lengthPredicate = str => str.Length == int.Parse(criteriaValue);

                Func<List<string>, Predicate<string>, int> removeFunc = (list, predicate) => list.RemoveAll(predicate);
                Action<List<string>, Predicate<string>> doubleAction = (list, predicate) =>
                {
                    list.FindAll(predicate).ForEach(n => list.Insert(list.IndexOf(n), n));
                };
                
                switch (operation)
                {
                    case "Remove":
                        switch (criteria)
                        {
                            case "StartsWith":
                                removeFunc(people, startsWithPredicate);
                                break;
                            case "EndsWith":
                                removeFunc(people, endsWithPredicate);
                                break;
                            case "Length":
                                removeFunc(people, lengthPredicate);
                                break;
                        }

                        break;
                    case "Double":
                        switch (criteria)
                        {
                            case "StartsWith":
                                doubleAction(people, startsWithPredicate);
                                break;
                            case "EndsWith":
                                doubleAction(people, endsWithPredicate);
                                break;
                            case "Length":
                                doubleAction(people, lengthPredicate);
                                break;
                        }

                        break;
                }
            }

            printAction(string.Join(", ", people));
        }
    }
}
