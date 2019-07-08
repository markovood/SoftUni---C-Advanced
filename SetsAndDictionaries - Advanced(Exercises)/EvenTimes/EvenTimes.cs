using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    public class EvenTimes
    {
        public static void Main()
        {
            Dictionary<int, int> numbersAndCount = new Dictionary<int, int>();
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (numbersAndCount.ContainsKey(number))
                {
                    numbersAndCount[number]++;
                }
                else
                {
                    numbersAndCount.Add(number, 1);
                }
            }

            var result = numbersAndCount.Where(x => x.Value % 2 == 0);
            Console.WriteLine(result.First().Key);
        }
    }
}
