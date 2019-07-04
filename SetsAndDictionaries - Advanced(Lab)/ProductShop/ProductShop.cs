using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductShop
{
    public class ProductShop
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, double>> shopsRecords = new Dictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();
            while (input != "Revision")
            {
                string[] inputTokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shopName = inputTokens[0];
                string product = inputTokens[1];
                double price = double.Parse(inputTokens[2]);

                if (shopsRecords.ContainsKey(shopName))
                {
                    if (!shopsRecords[shopName].ContainsKey(product))
                    {
                        shopsRecords[shopName].Add(product, price);
                    }
                }
                else
                {
                    shopsRecords.Add(shopName, new Dictionary<string, double>() { { product, price } });
                }

                input = Console.ReadLine();
            }

            // print
            var orderedByShopName = shopsRecords.OrderBy(s => s.Key).ToDictionary(x => x.Key, y => y.Value);
            foreach (var shop in orderedByShopName)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
