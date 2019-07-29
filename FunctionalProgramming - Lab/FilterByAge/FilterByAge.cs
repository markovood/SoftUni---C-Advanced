using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    public class FilterByAge
    {
        public static void Main()
        {
            int inputLines = int.Parse(Console.ReadLine());

            List<KeyValuePair<string, int>> persons = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < inputLines; i++)
            {
                string[] nameAgePair = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                var person = new KeyValuePair<string, int>(nameAgePair[0], int.Parse(nameAgePair[1]));
                persons.Add(person);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            string printPattern = Console.ReadLine();
            persons
                .Where(p => condition == "younger" ? p.Value < age : p.Value >= age)
                .ToList()
                .ForEach(p => Print(p, printPattern));
        }

        private static void Print(KeyValuePair<string, int> person, string pattern)
        {
            switch (pattern)
            {
                case "name":
                    Console.WriteLine($"{person.Key}");
                    break;
                case "age":
                    Console.WriteLine($"{person.Value}");
                    break;
                case "name age":
                    Console.WriteLine($"{person.Key} - {person.Value}");
                    break;
            }
        }
    }
}
