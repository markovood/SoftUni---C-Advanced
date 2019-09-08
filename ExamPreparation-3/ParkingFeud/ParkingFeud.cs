using System;
using System.Linq;

namespace ParkingFeud
{
    public class ParkingFeud
    {
        public static void Main()
        {
            int[] sizes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int parkingRows = sizes[0];
            int entrances = sizes[0] - 1;

            int parkingCols = sizes[1] + 2;

            int samEntranceRow = int.Parse(Console.ReadLine());

            bool samHasParked = false;
            int passedDistance = 0;
            string parkingSpot = string.Empty;
            while (true)
            {
                if (samHasParked)
                {
                    break;
                }

                string[] parkingSpots = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                // Detect a conflict
                if (HasConflict(samEntranceRow, parkingSpots))
                {
                    parkingSpot = parkingSpots[samEntranceRow - 1];
                    int samDistance = CalcPassedDistance(samEntranceRow, parkingSpot, parkingCols);

                    // find conflict driver's entrance and calculate his distance
                    int conflictDriverEntrance = GetConflictDriverEntrance(samEntranceRow, parkingSpots);
                    int conflictDriverDistance = CalcPassedDistance(conflictDriverEntrance, parkingSpot, parkingCols);

                    if (samDistance <= conflictDriverDistance)
                    {
                        samHasParked = true;
                        passedDistance += samDistance;
                        break;
                    }
                    else
                    {
                        passedDistance += samDistance * 2;
                    }
                }
                else
                {
                    samHasParked = true;
                    parkingSpot = parkingSpots[samEntranceRow - 1];
                    passedDistance += CalcPassedDistance(samEntranceRow, parkingSpot, parkingCols);
                    break;
                }
            }

            // print output
            Console.WriteLine($"Parked successfully at {parkingSpot}.");
            Console.WriteLine($"Total Distance Passed: {passedDistance}");
        }

        private static int GetConflictDriverEntrance(int samEntranceRow, string[] parkingSpots)
        {
            string samDestinationSpot = parkingSpots[samEntranceRow - 1];
            int conflictIndex = -1;
            for (int i = 0; i < parkingSpots.Length; i++)
            {
                if (i == samEntranceRow - 1)
                {
                    continue;
                }
                else if (parkingSpots[i] == samDestinationSpot)
                {
                    conflictIndex = i;
                    break;
                }
            }

            return conflictIndex + 1;
        }

        private static int CalcPassedDistance(int entranceRow, string destinationSpot, int parkingCols)
        {
            // The parking lot will not have more than 10 parking rows and columns
            char[] destCoordinates = destinationSpot.ToCharArray();
            int destinationRow = destCoordinates[1] - '0';
            int destinationCol = GetCol(destCoordinates[0]);

            if (entranceRow == destinationRow || entranceRow + 1 == destinationRow)
            {
                // move on the same row
                return destinationCol;
            }
            else if (entranceRow > destinationRow)
            {
                // moving upwards
                int linesUp = entranceRow - destinationRow;
                int passedDistance = CountCurrentlyPassedDistance(parkingCols, destinationCol, linesUp);
                return passedDistance;
            }
            else
            {
                // moving downwards
                int linesDown = destinationRow - entranceRow - 1;
                int passedDistance = CountCurrentlyPassedDistance(parkingCols, destinationCol, linesDown);
                return passedDistance;
            }
        }

        private static int CountCurrentlyPassedDistance(int parkingCols, int destinationCol, int linesToMove)
        {
            int currentlyPassedDistance = 0;
            for (int i = 0; i < linesToMove; i++)
            {
                currentlyPassedDistance += parkingCols - 1 + 2;
            }

            // locating the current col position
            int currentCol = 0;
            if (linesToMove % 2 != 0)
            {
                currentCol = parkingCols - 1;
            }

            if (currentCol > destinationCol)
            {
                currentlyPassedDistance += currentCol - destinationCol;
            }
            else if (currentCol < destinationCol)
            {
                currentlyPassedDistance += currentCol + destinationCol;
            }

            return currentlyPassedDistance;
        }

        private static int GetCol(char colLetter)
        {
            switch (colLetter)
            {
                default: throw new NotSupportedException("Not implemented column letter!");
                case 'A': return 1;
                case 'B': return 2;
                case 'C': return 3;
                case 'D': return 4;
                case 'E': return 5;
                case 'F': return 6;
                case 'G': return 7;
                case 'H': return 8;
                case 'I': return 9;
            }
        }

        private static bool HasConflict(int samEntrance, string[] parkingSpots)
        {
            var spotsAsList = parkingSpots.ToList();
            string samDestinationSpot = parkingSpots[samEntrance - 1];
            spotsAsList.RemoveAt(samEntrance - 1);

            if (spotsAsList.Contains(samDestinationSpot))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
