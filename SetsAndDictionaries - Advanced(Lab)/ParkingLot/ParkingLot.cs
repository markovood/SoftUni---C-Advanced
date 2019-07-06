using System;
using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingLot
    {
        public static void Main()
        {
            HashSet<string> parkingLot = new HashSet<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                string[] inputTokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string direction = inputTokens[0];
                string carPlate = inputTokens[1];

                switch (direction)
                {
                    case "IN":
                        parkingLot.Add(carPlate);
                        break;
                    case "OUT":
                        parkingLot.Remove(carPlate);
                        break;
                }
            }

            // Print
            if (parkingLot.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var carNumber in parkingLot)
                {
                    Console.WriteLine(carNumber);
                }
            }
        }
    }
}
