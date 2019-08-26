using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightGame
{
    public class KnightGame
    {
        private static char[][] board;

        public static void Main()
        {
            int boardSize = int.Parse(Console.ReadLine());

            board = new char[boardSize][];
            for (int row = 0; row < boardSize; row++)
            {
                board[row] = Console.ReadLine().ToCharArray();
            }

            // Remove a minimum of the knights, so there will be no knights left that can attack another knight.

            // Logic: There are only 8 possible moves for the knight from the currentPosition, so we check for
            // every knight all possible moves and if we find another knight on any target position we count
            // that and continue to the next knight. Once we have passed through all knights we'll have how many
            // enemies each one have, then we start removing the ones with the most enemies as we check after
            // every remove how many enemies the rest of the knights have left and we do that until there are
            // left only knights without enemies

            int removed = 0;
            while (true)
            {
                List<KeyValuePair<int[], int>> positionAndEnemies = CountEnemies();
                if (positionAndEnemies.Count == 0)
                {
                    break;
                }
                else
                {
                    var knightWithMostEnemies = positionAndEnemies.OrderByDescending(x => x.Value).First();
                    if (knightWithMostEnemies.Value == 0)
                    {
                        break;
                    }
                    else
                    {
                        board[knightWithMostEnemies.Key[0]][knightWithMostEnemies.Key[1]] = '0';
                        removed++;
                    }
                }
            }

            Console.WriteLine(removed);
        }

        private static List<KeyValuePair<int[], int>> CountEnemies()
        {
            List<KeyValuePair<int[], int>> positionAndEnemies = new List<KeyValuePair<int[], int>>();

            for (int row = 0; row < board.Length; row++)
            {
                for (
                    int col = 0; col < board[row].Length; col++)
                {

                    if (board[row][col] == 'K')
                    {
                        int enemiesCount = 0;

                        // possible move #1
                        int targetRow = row - 2;
                        int targetCol = col - 1;
                        if (IsValidMove(targetRow, targetCol) && board[targetRow][targetCol] == 'K')
                        {
                            enemiesCount++;
                        }

                        // possible move #2
                        targetRow = row - 2;
                        targetCol = col + 1;
                        if (IsValidMove(targetRow, targetCol) && board[targetRow][targetCol] == 'K')
                        {
                            enemiesCount++;
                        }

                        // possible move #3
                        targetRow = row - 1;
                        targetCol = col + 2;
                        if (IsValidMove(targetRow, targetCol) && board[targetRow][targetCol] == 'K')
                        {
                            enemiesCount++;
                        }

                        // possible move #4
                        targetRow = row + 1;
                        targetCol = col + 2;
                        if (IsValidMove(targetRow, targetCol) && board[targetRow][targetCol] == 'K')
                        {
                            enemiesCount++;
                        }

                        // possible move #5
                        targetRow = row + 2;
                        targetCol = col + 1;
                        if (IsValidMove(targetRow, targetCol) && board[targetRow][targetCol] == 'K')
                        {
                            enemiesCount++;
                        }

                        // possible move #6
                        targetRow = row + 2;
                        targetCol = col - 1;
                        if (IsValidMove(targetRow, targetCol) && board[targetRow][targetCol] == 'K')
                        {
                            enemiesCount++;
                        }

                        // possible move #7
                        targetRow = row + 1;
                        targetCol = col - 2;
                        if (IsValidMove(targetRow, targetCol) && board[targetRow][targetCol] == 'K')
                        {
                            enemiesCount++;
                        }

                        // possible move #8
                        targetRow = row - 1;
                        targetCol = col - 2;
                        if (IsValidMove(targetRow, targetCol) && board[targetRow][targetCol] == 'K')
                        {
                            enemiesCount++;
                        }

                        // save current knight position and enemies count
                        positionAndEnemies.Add(new KeyValuePair<int[], int>(new int[] { row, col }, enemiesCount));
                    }
                }
            }

            return positionAndEnemies;
        }

        private static bool IsValidMove(int targetRow, int targetCol)
        {
            if (targetRow < 0 || targetCol < 0)
            {
                return false;
            }
            else if (targetRow >= board.Length || targetCol >= board[targetRow].Length)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
