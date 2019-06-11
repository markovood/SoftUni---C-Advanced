using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveBunnies
{
    public class RadioactiveBunnies
    {
        public static void Main()
        {
            // Read input and set up the lair
            char[,] lair = SetUpALair();

            string commands = Console.ReadLine();

            // Apply commands
            int[] playerPosition = GetPlayerPosition(lair);
            int playerRow = playerPosition[0];
            int playerCol = playerPosition[1];

            string playerStatus = string.Empty;

            foreach (var command in commands)
            {
                if (command == 'L')
                {
                    // move player to the left one position
                    playerCol--;
                    if (playerCol < 0)
                    {
                        // out of the lair
                        playerStatus = GetOutOfTheLair(lair, playerPosition);
                        break;
                    }
                    else
                    {
                        if (lair[playerRow, playerCol] == '.')
                        {
                            MovePlayer(lair, playerPosition, playerRow, playerCol);
                        }
                        else if (lair[playerRow, playerCol] == 'B')
                        {
                            playerStatus = KillPlayer(lair, playerPosition, playerRow, playerCol);
                            break;
                        }
                    }
                }
                else if (command == 'R')
                {
                    // move player to the right one position
                    playerCol++;
                    if (playerCol >= lair.GetLength(1))
                    {
                        // out of the lair
                        playerStatus = GetOutOfTheLair(lair, playerPosition);
                        break;
                    }
                    else
                    {
                        if (lair[playerRow, playerCol] == '.')
                        {
                            MovePlayer(lair, playerPosition, playerRow, playerCol);
                        }
                        else if (lair[playerRow, playerCol] == 'B')
                        {
                            playerStatus = KillPlayer(lair, playerPosition, playerRow, playerCol);
                            break;
                        }
                    }
                }
                else if (command == 'U')
                {
                    // move player up one position
                    playerRow--;
                    if (playerRow < 0)
                    {
                        // out of the lair
                        playerStatus = GetOutOfTheLair(lair, playerPosition);
                        break;
                    }
                    else
                    {
                        if (lair[playerRow, playerCol] == '.')
                        {
                            MovePlayer(lair, playerPosition, playerRow, playerCol);
                        }
                        else if (lair[playerRow, playerCol] == 'B')
                        {
                            playerStatus = KillPlayer(lair, playerPosition, playerRow, playerCol);
                            break;
                        }
                    }
                }
                else if (command == 'D')
                {
                    // move player down one position
                    playerRow++;
                    if (playerRow >= lair.GetLength(0))
                    {
                        // out of the lair
                        playerStatus = GetOutOfTheLair(lair, playerPosition);
                        break;
                    }
                    else
                    {
                        if (lair[playerRow, playerCol] == '.')
                        {
                            MovePlayer(lair, playerPosition, playerRow, playerCol);
                        }
                        else if (lair[playerRow, playerCol] == 'B')
                        {
                            playerStatus = KillPlayer(lair, playerPosition, playerRow, playerCol);
                            break;
                        }
                    }
                }

                // spread bunnies to the left, right, up, down
                int[] playerDeathCoordinates = SpreadBunnies(lair);
                if (playerDeathCoordinates != null)
                {
                    playerPosition = playerDeathCoordinates;
                    playerStatus = "dead";
                    break;
                }
            }

            // Print the final state of the lair 
            Print(lair);
            Console.WriteLine($"{playerStatus}: {playerPosition[0]} {playerPosition[1]}");
        }

        private static char[,] SetUpALair()
        {
            int[] dimensions = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];
            char[,] lair = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string currentRow = Console.ReadLine();
                for (int j = 0; j < cols; j++)
                {
                    lair[i, j] = currentRow[j];
                }
            }

            return lair;
        }

        private static string KillPlayer(char[,] lair, int[] playerPosition, int playerRow, int playerCol)
        {
            // dies
            string playerStatus = "dead";
            playerPosition[0] = playerRow;
            playerPosition[1] = playerCol;
            SpreadBunnies(lair);
            return playerStatus;
        }

        private static void MovePlayer(char[,] lair, int[] playerPosition, int playerRow, int playerCol)
        {
            // swap symbols
            lair[playerRow, playerCol] = 'P';
            lair[playerPosition[0], playerPosition[1]] = '.';
            playerPosition[0] = playerRow;
            playerPosition[1] = playerCol;
        }

        private static string GetOutOfTheLair(char[,] lair, int[] playerPosition)
        {
            string playerStatus = "won";
            lair[playerPosition[0], playerPosition[1]] = '.';
            SpreadBunnies(lair);
            return playerStatus;
        }

        private static int[] SpreadBunnies(char[,] lair)
        {
            // Get current coordinates of all bunnies
            List<int[]> bunniesPositions = new List<int[]>();
            for (int i = 0; i < lair.GetLength(0); i++)
            {
                for (int j = 0; j < lair.GetLength(1); j++)
                {
                    if (lair[i, j] == 'B')
                    {
                        bunniesPositions.Add(new int[] { i, j });
                    }
                }
            }

            // spread bunnies to the up, down, left and right
            int[] playerDeathCoordinates = null;
            for (int i = 0; i < bunniesPositions.Count; i++)
            {
                int bunnyRow = bunniesPositions[i][0];
                int bunnyCol = bunniesPositions[i][1];

                // to the left
                bunnyCol--;
                if (bunnyCol >= 0)
                {
                    playerDeathCoordinates = ValidateMove(lair, playerDeathCoordinates, bunnyRow, bunnyCol);
                }

                // to the right
                bunnyCol = bunniesPositions[i][1];
                bunnyCol++;
                if (bunnyCol < lair.GetLength(1))
                {
                    playerDeathCoordinates = ValidateMove(lair, playerDeathCoordinates, bunnyRow, bunnyCol);
                }

                bunnyCol = bunniesPositions[i][1];

                // up
                bunnyRow--;
                if (bunnyRow >= 0)
                {
                    playerDeathCoordinates = ValidateMove(lair, playerDeathCoordinates, bunnyRow, bunnyCol);
                }

                // down
                bunnyRow = bunniesPositions[i][0];
                bunnyRow++;
                if (bunnyRow < lair.GetLength(0))
                {
                    playerDeathCoordinates = ValidateMove(lair, playerDeathCoordinates, bunnyRow, bunnyCol);
                }
            }

            return playerDeathCoordinates;
        }

        private static int[] ValidateMove(char[,] lair, int[] playerDeathCoordinates, int bunnyRow, int bunnyCol)
        {
            if (lair[bunnyRow, bunnyCol] == 'P')
            {
                playerDeathCoordinates = new int[] { bunnyRow, bunnyCol };
            }

            lair[bunnyRow, bunnyCol] = 'B';
            return playerDeathCoordinates;
        }

        private static void Print(char[,] lair)
        {
            for (int i = 0; i < lair.GetLength(0); i++)
            {
                for (int j = 0; j < lair.GetLength(1); j++)
                {
                    Console.Write(lair[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static int[] GetPlayerPosition(char[,] lair)
        {
            int[] playerPosition = new int[2];
            for (int i = 0; i < lair.GetLength(0); i++)
            {
                for (int j = 0; j < lair.GetLength(1); j++)
                {
                    if (lair[i, j] == 'P')
                    {
                        playerPosition[0] = i;
                        playerPosition[1] = j;
                    }
                }
            }

            return playerPosition;
        }
    }
}
