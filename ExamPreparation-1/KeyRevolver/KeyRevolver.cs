using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    public class KeyRevolver
    {
        public static void Main()
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int[] bulletsArr = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
            int[] locksArr = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
            int inteligenceValue = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(bulletsArr);
            Queue<int> locks = new Queue<int>(locksArr);
            int currentlyFiredBullets = 0;
            int totalFiredBullets = 0;

            // start shooting
            while (true)
            {
                int currentBullet = bullets.Pop();
                currentlyFiredBullets++;

                int currentLock = locks.Peek();

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (currentlyFiredBullets == gunBarrelSize && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    totalFiredBullets += currentlyFiredBullets;
                    currentlyFiredBullets = 0;
                }

                if (bullets.Count == 0 || locks.Count == 0)
                {
                    if (currentlyFiredBullets > 0)
                    {
                        totalFiredBullets += currentlyFiredBullets;
                    }

                    break;
                }
            }

            // shooting finished
            int locksLeft = locks.Count;
            int bulletsLeft = bullets.Count;
            if (locksLeft == 0)
            {
                int moneyEarned = inteligenceValue - (totalFiredBullets * bulletPrice);
                Console.WriteLine($"{bulletsLeft} bullets left. Earned ${moneyEarned}");
            }
            else if (bulletsLeft == 0 && locksLeft > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksLeft}");
            }
        }
    }
}
