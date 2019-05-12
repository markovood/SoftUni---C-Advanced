using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    public class TruckTour
    {
        public static void Main()
        {
            // reading input
            int numberOfPumps = int.Parse(Console.ReadLine());

            Queue<int[]> listOfPumps = new Queue<int[]>();
            for (int i = 0; i < numberOfPumps; i++)
            {
                int[] currentPumpDetails = Console.ReadLine().
                    Split(" ", StringSplitOptions.RemoveEmptyEntries).
                    Select(int.Parse).
                    ToArray();

                listOfPumps.Enqueue(currentPumpDetails);
            }

            // actual calculation
            int pumpIndex = 0;
            while (true)
            {
                int totalAmountOfPetrol = 0;
                foreach (var currentPump in listOfPumps)
                {
                    int amountOfPetrol = currentPump[0];
                    int distanceToNextPump = currentPump[1];
                    totalAmountOfPetrol += amountOfPetrol;
                    totalAmountOfPetrol -= distanceToNextPump;

                    if (totalAmountOfPetrol < 0)
                    {
                        listOfPumps.Enqueue(listOfPumps.Dequeue());
                        pumpIndex++;
                        break;
                    }
                }

                if (totalAmountOfPetrol >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(pumpIndex);
        }
    }
}
