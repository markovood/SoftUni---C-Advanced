using System;
using System.Collections.Generic;

namespace CitiesByContinentAndCountry
{
    public class CitiesByContinentAndCountry
    {
        public static void Main()
        {
            int linesCount = int.Parse(Console.ReadLine());

            var citiesByContinentAndCountry = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < linesCount; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = info[0];
                string country = info[1];
                string city = info[2];

                if (citiesByContinentAndCountry.ContainsKey(continent))
                {
                    if (citiesByContinentAndCountry[continent].ContainsKey(country))
                    {
                        citiesByContinentAndCountry[continent][country].Add(city);
                    }
                    else
                    {
                        citiesByContinentAndCountry[continent].Add(country, new List<string>() { city });
                    }
                }
                else
                {
                    citiesByContinentAndCountry.Add(continent, new Dictionary<string, List<string>>()
                    {
                        { country, new  List<string>() { city} }
                    });
                }
            }

            // print
            foreach (var continent in citiesByContinentAndCountry)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
