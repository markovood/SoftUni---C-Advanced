using System;
using System.Collections.Generic;
using System.Linq;

namespace PoisonousPlants
{
    public class PoisonousPlants
    {
        public static void Main()
        {
            int numberOfPlants = int.Parse(Console.ReadLine());
            List<int> plants = Console.ReadLine().
                Split(" ", StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToList();

            List<int> indexesToRemove = new List<int>();

            int days = 0;
            while (true)
            {
                for (int i = 0; i < plants.Count - 1; i++)
                {
                    int plantToTheLeft = plants[i];
                    int currentPlant = plants[i + 1];

                    if (plantToTheLeft < currentPlant)
                    {
                        indexesToRemove.Add(i + 1);
                    }
                }

                if (indexesToRemove.Count == 0)// must break when no dead plants found in the current day
                {
                    break;
                }

                int counter = 0;// balances the indexes that are changed, as we remove an element from plants
                for (int i = 0; i < indexesToRemove.Count; i++)
                {
                    plants.RemoveAt(indexesToRemove[i] - counter);
                    counter++;
                }

                days++;
                indexesToRemove.Clear();
            }

            Console.WriteLine(days);
        }
    }
}
