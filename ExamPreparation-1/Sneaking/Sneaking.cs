using System;
using System.Linq;

namespace Sneaking
{
    public class Sneaking
    {
        public static void Main()
        {
            Action<char[][]> print = jaggedArr =>
            {
                foreach (var arr in jaggedArr)
                {
                    Console.WriteLine(string.Join("", arr));
                }
            };

            int roomRows = int.Parse(Console.ReadLine());

            char[][] room = new char[roomRows][];
            for (int i = 0; i < roomRows; i++)
            {
                room[i] = Console.ReadLine().ToCharArray();
            }

            string directions = Console.ReadLine();

            int[] samPosition = GetSamPosition(room);
            // check if an enemy is watching Sam from the beginning
            if (room[samPosition[0]].Contains('b') && Array.IndexOf(room[samPosition[0]], 'b') < samPosition[1])
            {
                room[samPosition[0]][samPosition[1]] = 'X';
                Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                return;
            }
            else if (room[samPosition[0]].Contains('d') && Array.IndexOf(room[samPosition[0]], 'd') > samPosition[1])
            {
                room[samPosition[0]][samPosition[1]] = 'X';
                Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                return;
            }

            for (int i = 0; i < directions.Length; i++)
            {
                // move enemies
                for (int row = 0; row < room.Length; row++)
                {
                    // If an enemy is standing on the edge of the room, he flips his direction and doesn’t move
                    // for the rest of the turn
                    if (room[row][0] == 'd')
                    {
                        room[row][0] = 'b';
                    }
                    else if (room[row][room[row].Length - 1] == 'b')
                    {
                        room[row][room[row].Length - 1] = 'd';
                    }
                    else
                    {
                        MoveEnemyOneStepAhead(room, row);
                    }
                }

                // check if Sam is alive
                if (room[samPosition[0]].Contains('b') && Array.IndexOf(room[samPosition[0]], 'b') < samPosition[1])
                {
                    room[samPosition[0]][samPosition[1]] = 'X';
                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                    break;
                }
                else if (room[samPosition[0]].Contains('d') && Array.IndexOf(room[samPosition[0]], 'd') > samPosition[1])
                {
                    room[samPosition[0]][samPosition[1]] = 'X';
                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                    break;
                }

                // move Sam
                char currentDir = directions[i];

                room[samPosition[0]][samPosition[1]] = '.';
                switch (currentDir)
                {
                    case 'U':// UP
                        samPosition[0]--;
                        break;
                    case 'D':// DOWN
                        samPosition[0]++;
                        break;
                    case 'L':// LEFT
                        samPosition[1]--;
                        break;
                    case 'R':// RIGHT
                        samPosition[1]++;
                        break;
                    case 'W':// WAIT
                        // Sam doesn’t move
                        break;
                }

                room[samPosition[0]][samPosition[1]] = 'S';

                // check if Nikoladze is alive
                if (room[samPosition[0]].Contains('N'))
                {
                    int indexN = Array.IndexOf(room[samPosition[0]], 'N');
                    room[samPosition[0]][indexN] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    break;
                }
            }

            print(room);
        }

        private static int[] GetSamPosition(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                int samIndex = Array.IndexOf(room[row], 'S');
                if (samIndex >= 0)
                {
                    return new int[] { row, samIndex };
                }
            }

            throw new ApplicationException("Sam is not in the room!");
        }

        private static void MoveEnemyOneStepAhead(char[][] room, int row)
        {
            int enemyIndex = Array.IndexOf(room[row], 'b');
            if (enemyIndex < 0)
            {
                enemyIndex = Array.IndexOf(room[row], 'd');
            }

            if (enemyIndex >= 0)
            {
                if (room[row][enemyIndex] == 'b')
                {
                    room[row][enemyIndex] = '.';
                    room[row][enemyIndex + 1] = 'b';
                }
                else
                {
                    room[row][enemyIndex] = '.';
                    room[row][enemyIndex - 1] = 'd';
                }
            }
        }
    }
}
