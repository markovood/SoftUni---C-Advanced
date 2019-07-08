using System;
using System.Collections.Generic;

namespace UniqueUsernames
{
    public class UniqueUsernames
    {
        public static void Main()
        {
            int usernamesCount = int.Parse(Console.ReadLine());

            HashSet<string> uniqueUsernames = new HashSet<string>();
            for (int i = 0; i < usernamesCount; i++)
            {
                string userName = Console.ReadLine();
                uniqueUsernames.Add(userName);
            }

            foreach (var username in uniqueUsernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}
