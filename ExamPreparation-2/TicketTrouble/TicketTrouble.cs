using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TicketTrouble
{
    public class TicketTrouble
    {
        public static void Main()
        {
            string targetLocation = Console.ReadLine();
            string suitcase = Console.ReadLine();

            string validTicketPattern = @"(?<={)[^{}\[\]]*(\[[A-Z]{3} [A-Z]{2}\])[^{}\[\]]*(\[[A-Z]{1}\d{1,2}\])[^{}\[\]]*(?=})|(?<=\[)[^\[\]{}]*({[A-Z]{3} [A-Z]{2}})[^\[\]{}]*({[A-Z]{1}\d{1,2}})[^{}\[\]]*(?=\])";
            MatchCollection validTickets = Regex.Matches(suitcase, validTicketPattern);

            string locationSeatPattern = @"(?<={)([A-Z]{3} [A-Z]{2})(?=})|(?<={)([A-Z]{1}\d{1,2})(?=})|(?<=\[)([A-Z]{3} [A-Z]{2})(?=\])|(?<=\[)([A-Z]{1}\d{1,2})(?=\])";
            Dictionary<string, List<string>> locationsAndSeats = new Dictionary<string, List<string>>();
            foreach (Match ticket in validTickets)
            {
                var locationSeat = Regex.Matches(ticket.ToString(), locationSeatPattern);
                string location = locationSeat[0].ToString();
                string seat = locationSeat[1].ToString();
                if (locationsAndSeats.ContainsKey(location))
                {
                    locationsAndSeats[location].Add(seat);
                }
                else
                {
                    locationsAndSeats.Add(location, new List<string>() { seat });
                }
            }

            var targetLocationAndSeats = locationsAndSeats.First(x => x.Key == targetLocation);
            if (targetLocationAndSeats.Value.Count == 2)
            {
                string firstSeat = targetLocationAndSeats.Value[0];
                string secondSeat = targetLocationAndSeats.Value[1];
                Console.WriteLine($"You are traveling to {targetLocationAndSeats.Key} on seats {firstSeat} and {secondSeat}.");
            }
            else
            {
                int[] rows = new int[targetLocationAndSeats.Value.Count];
                for (int i = 0; i < targetLocationAndSeats.Value.Count; i++)
                {
                    string currentSeat = targetLocationAndSeats.Value[i];
                    int row = GetRow(currentSeat);
                    rows[i] = row;
                }

                int[] indexes = GetTheSameRowIndex(rows);
                string firstSeat = targetLocationAndSeats.Value[indexes[0]];
                string secondSeat = targetLocationAndSeats.Value[indexes[1]];
                Console.WriteLine($"You are traveling to {targetLocationAndSeats.Key} on seats {firstSeat} and {secondSeat}.");
            }
        }

        private static int[] GetTheSameRowIndex(int[] rows)
        {
            for (int i = 0; i < rows.Length - 1; i++)
            {
                int currentRow = rows[i];
                int sameRowIndex = Array.IndexOf(rows, currentRow, i + 1);
                if (sameRowIndex >= 0)
                {
                    return new int[] { i, sameRowIndex };
                }
            }

            return null;
        }

        private static int GetRow(string seat)
        {
            int row = int.Parse(seat.Remove(0, 1));
            return row;
        }
    }
}
