using System;
using System.Collections.Generic;

namespace SoftuniParty
{
    public class SoftuniParty
    {
        public static void Main()
        {
            HashSet<string> reqularGuests = new HashSet<string>();
            HashSet<string> vipGuests = new HashSet<string>();

            while (true)
            {
                string guest = Console.ReadLine();
                if (guest == "PARTY")
                {
                    break;
                }

                if (char.IsDigit(guest[0]))
                {
                    vipGuests.Add(guest);
                }
                else
                {
                    reqularGuests.Add(guest);
                }
            }

            // party is on and guests start coming
            while (true)
            {
                string guest = Console.ReadLine();
                if (guest == "END")
                {
                    break;
                }

                if (char.IsDigit(guest[0]))
                {
                    vipGuests.Remove(guest);
                }
                else
                {
                    reqularGuests.Remove(guest);
                }
            }

            // party is over, and no more guest will come
            Console.WriteLine(vipGuests.Count + reqularGuests.Count);
            if (vipGuests.Count > 0)
            {
                foreach (var guest in vipGuests)
                {
                    Console.WriteLine(guest);
                }
            }

            if (reqularGuests.Count > 0)
            {
                foreach (var guest in reqularGuests)
                {
                    Console.WriteLine(guest);
                }
            }
        }
    }
}
