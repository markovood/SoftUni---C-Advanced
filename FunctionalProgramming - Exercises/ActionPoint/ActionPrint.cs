using System;

namespace ActionPrint
{
    public class ActionPrint
    {
        public static void Main()
        {
            string[] strs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> print = x => Console.WriteLine(string.Join(Environment.NewLine, x));

            print(strs);
        }


    }
}
