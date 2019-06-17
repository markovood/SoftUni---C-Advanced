using System;

namespace TheHeiganDance
{
    public class TheHeiganDance
    {
        private static char[,] chamber = new char[15, 15];

        public static void Main()
        {
            int[] player = new int[] { 7, 7, 18500 };
            double heiganHitPts = 3_000_000;

            // read how much damage we do to heigan
            double damageToHeigan = double.Parse(Console.ReadLine());

            // read and apply spells until someone dies
            string lastSpell = string.Empty;
            bool isHitByCloudSpell = false;
            while (true)
            {
                if (player[2] > 0)
                {
                    // do damage to heigan
                    heiganHitPts -= damageToHeigan;
                }

                if (isHitByCloudSpell)
                {
                    player[2] -= 3500;
                    isHitByCloudSpell = false;
                }

                if (player[2] <= 0 || heiganHitPts <= 0)
                {
                    break;
                }

                string[] spellTokens = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string spell = spellTokens[0];
                int row = int.Parse(spellTokens[1]);
                int col = int.Parse(spellTokens[2]);

                ApplySpellToChamber(spell, row, col);

                if (IsInAreaOfDamage(player))
                {
                    // try to move
                    bool canMoveUp = MoveUp(player);
                    if (canMoveUp)
                    {
                        ResetChamber();
                        continue;
                    }

                    bool canMoveRight = MoveRight(player);
                    if (canMoveRight)
                    {
                        ResetChamber();
                        continue;
                    }

                    bool canMoveDown = MoveDown(player);
                    if (canMoveDown)
                    {
                        ResetChamber();
                        continue;
                    }

                    bool canMoveLeft = MoveLeft(player);
                    if (canMoveLeft)
                    {
                        ResetChamber();
                        continue;
                    }

                    // if cannot move, stays in place and takes the damage
                    ProcessDamage(player, ref lastSpell, ref isHitByCloudSpell);
                }

                ResetChamber();
            }

            // print the final
            PrintHeigan(heiganHitPts);
            PrintPlayer(player, lastSpell);
        }

        private static void ProcessDamage(int[] player, ref string lastSpell, ref bool isHitByCloudSpell)
        {
            if (chamber[player[0], player[1]] == 'C')
            {
                player[2] -= 3500;
                isHitByCloudSpell = true;
                lastSpell = "Plague Cloud";
            }
            else if (chamber[player[0], player[1]] == 'E')
            {
                player[2] -= 6000;
                lastSpell = "Eruption";
            }
        }

        private static void PrintPlayer(int[] player, string lastSpell)
        {
            if (player[2] <= 0)
            {
                Console.WriteLine($"Player: Killed by {lastSpell}");
            }
            else
            {
                Console.WriteLine($"Player: {player[2]}");
            }

            Console.WriteLine($"Final position: {player[0]}, {player[1]}");
        }

        private static void PrintHeigan(double heiganHitPts)
        {
            if (heiganHitPts <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {heiganHitPts:F2}");
            }
        }

        private static void ResetChamber()
        {
            chamber = new char[15, 15];
        }

        private static bool MoveLeft(int[] player)
        {
            player[1]--;
            if (player[1] >= 0 && player[1] < chamber.GetLength(1) &&
                chamber[player[0],player[1]] == default(char))
            {
                return true;
            }
            else
            {
                player[1]++;
                return false;
            }
        }

        private static bool MoveDown(int[] player)
        {
            player[0]++;
            if (player[0] >= 0 && player[0] < chamber.GetLength(0) &&
                chamber[player[0],player[1]] == default(char))
            {
                return true;
            }
            else
            {
                player[0]--;
                return false;
            }
        }

        private static bool MoveRight(int[] player)
        {
            player[1]++;
            if (player[1] >= 0 && player[1] < chamber.GetLength(1) &&
                chamber[player[0], player[1]] == default(char))
            {
                return true;
            }
            else
            {
                player[1]--;
                return false;
            }
        }

        private static bool MoveUp(int[] player)
        {
            player[0]--;
            if (player[0] >= 0 && player[0] < chamber.GetLength(0) &&
                chamber[player[0], player[1]] == default(char))
            {
                return true;
            }
            else
            {
                player[0]++;
                return false;
            }
        }

        private static bool IsInAreaOfDamage(int[] player)
        {
            if (chamber[player[0], player[1]] == 'C' ||
                chamber[player[0], player[1]] == 'E')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void ApplySpellToChamber(string spell, int row, int col)
        {
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (IsValid(i, j))
                    {
                        if (spell == "Cloud")
                        {
                            chamber[i, j] = 'C';
                        }
                        else if (spell == "Eruption")
                        {
                            chamber[i, j] = 'E';
                        }
                    }
                }
            }
        }

        private static bool IsValid(int row, int col)
        {
            return row >= 0 &&
                row < chamber.GetLength(0) &&
                col >= 0 &&
                col < chamber.GetLength(1);
        }
    }
}
