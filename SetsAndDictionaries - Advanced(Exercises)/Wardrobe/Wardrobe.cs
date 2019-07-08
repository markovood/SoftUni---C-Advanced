using System;
using System.Collections.Generic;

namespace Wardrobe
{
    public class Wardrobe
    {
        public static void Main()
        {
            int linesCount = int.Parse(Console.ReadLine());

            var colorsAndItems = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < linesCount; i++)
            {
                string[] inputTokens = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                // count all items
                string[] itemsTokens = inputTokens[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                Dictionary<string, int> itemsAndCount = new Dictionary<string, int>();
                for (int j = 0; j < itemsTokens.Length; j++)
                {
                    string currentItem = itemsTokens[j];
                    if (itemsAndCount.ContainsKey(currentItem))
                    {
                        itemsAndCount[currentItem]++;
                    }
                    else
                    {
                        itemsAndCount.Add(currentItem, 1);
                    }
                }

                // organize items by color
                string color = inputTokens[0];
                if (colorsAndItems.ContainsKey(color))
                {
                    // pass through all items and add what is not there or increase count if duplicated
                    foreach (var item in itemsAndCount)
                    {
                        if (colorsAndItems[color].ContainsKey(item.Key))
                        {
                            colorsAndItems[color][item.Key] += item.Value;
                        }
                        else
                        {
                            colorsAndItems[color].Add(item.Key, item.Value);
                        }
                    }

                }
                else
                {
                    colorsAndItems.Add(color, itemsAndCount);
                }
            }

            // Print final result
            string[] toBeFound = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string colorToFind = toBeFound[0];
            string itemToFind = toBeFound[1];
            foreach (var color in colorsAndItems.Keys)
            {
                Console.WriteLine($"{color} clothes:");
                foreach (var item in colorsAndItems[color])
                {
                    if (color == colorToFind && item.Key == itemToFind)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
