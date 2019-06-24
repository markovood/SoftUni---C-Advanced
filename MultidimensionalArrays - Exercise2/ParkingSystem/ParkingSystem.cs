using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
    public class ParkingSystem
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            bool[,] parkingLot = new bool[rows, cols];

            string currentCommand = Console.ReadLine();
            while (currentCommand != "stop")
            {
                int[] commandTokens = currentCommand
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int entryRow = commandTokens[0];
                int targetRow = commandTokens[1];
                int targetCol = commandTokens[2];

                int distance = 0;
                bool rowIsFull = false;
                bool targetSpotIsFull = parkingLot[targetRow, targetCol];
                if (targetSpotIsFull)
                {
                    // target spot is not free, find the nearest spot next to TARGETED and calculate the distance.
                    int counter = 1;
                    while (true)
                    {
                        // check for a free spot on the left of targeted
                        int leftCol = targetCol - counter;

                        // check for a free spot on the right of targeted
                        int rightCol = targetCol + counter;

                        // both left and right col indexes are out of matrix
                        if (leftCol < 1 && rightCol >= parkingLot.GetLength(1))
                        {
                            Console.WriteLine($"Row {targetRow} full");
                            rowIsFull = true;
                            break;
                        }
                        // left col index is out, but right is still in
                        else if (leftCol < 1 && rightCol < parkingLot.GetLength(1))
                        {
                            bool isRightCellFull = parkingLot[targetRow, rightCol];
                            if (!isRightCellFull)
                            {
                                distance = CalculateDistance(entryRow, targetRow, rightCol);
                                parkingLot[targetRow, rightCol] = true;
                                break;
                            }
                        }
                        // right col index is out but left is still in
                        else if (rightCol >= parkingLot.GetLength(1) && leftCol >= 1)
                        {
                            bool isLeftCellFull = parkingLot[targetRow, leftCol];
                            if (!isLeftCellFull)
                            {
                                distance = CalculateDistance(entryRow, targetRow, leftCol);
                                parkingLot[targetRow, leftCol] = true;
                                break;
                            }
                        }
                        // both left and right col indexes are in the matrix
                        else
                        {
                            bool isLeftCellFull = parkingLot[targetRow, leftCol];
                            bool isRightCellFull = parkingLot[targetRow, rightCol];
                            // if left spot is empty set it, calc distance and break
                            if (!isLeftCellFull)
                            {
                                parkingLot[targetRow, leftCol] = true;
                                distance = CalculateDistance(entryRow, targetRow, leftCol);
                                break;
                            }
                            // if left spot is not empty, but right is, set right spot, calc distance and break
                            else if (!isRightCellFull)
                            {
                                parkingLot[targetRow, rightCol] = true;
                                distance = CalculateDistance(entryRow, targetRow, rightCol);
                                break;
                            }
                            // if left spot is not empty and right spot is not empty - nothing
                        }

                        counter++;
                    }
                }
                else
                {
                    // target spot is free calculate distance
                    distance = CalculateDistance(entryRow, targetRow, targetCol);
                    parkingLot[targetRow, targetCol] = true;
                }


                // Print distance
                if (!rowIsFull)
                {
                    Console.WriteLine(distance);
                }

                rowIsFull = false;
                currentCommand = Console.ReadLine();
            }
        }

        private static int CalculateDistance(int entryRow, int targetRow, int targetCol)
        {
            return Math.Abs(targetRow - entryRow) + targetCol + 1;
        }
    }
}
