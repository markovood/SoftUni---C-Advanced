using System;
using System.Linq;

namespace TriFunction
{
    public class TriFunction
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> isSumGreaterOrEqualFunc = (name, sum) => name.Sum(ch => ch) >= sum;

            Func<string[], Func<string, int, bool>, string> getFirstName = (arr, func) => 
            {
                foreach (var name in arr)
                {
                    if (isSumGreaterOrEqualFunc(name, n))
                    {
                        return name;
                    }
                }

                return null;
            };

            Action<string> printAction = str => Console.WriteLine(str);

            printAction(getFirstName(names, isSumGreaterOrEqualFunc));
        }
    }
}
