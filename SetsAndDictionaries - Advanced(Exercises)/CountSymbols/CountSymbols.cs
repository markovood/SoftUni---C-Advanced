using System;
using System.Collections.Generic;

namespace CountSymbols
{
    public class CountSymbols
    {
        public static void Main()
        {
            string text = Console.ReadLine();

            SortedDictionary<char, int> symbolsAndOccurences = new SortedDictionary<char, int>();
            foreach (var symbol in text)
            {
                if (symbolsAndOccurences.ContainsKey(symbol))
                {
                    symbolsAndOccurences[symbol]++;
                }
                else
                {
                    symbolsAndOccurences.Add(symbol, 1);
                }
            }

            // Print result
            foreach (var item in symbolsAndOccurences)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
