using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossroads
{
    public class Crossroads
    {
        public static void Main()
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>();
            int counter = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                if (input == "green")
                {
                    // green light logic here
                    if (queue.Count > 0)
                    {
                        string currentCar = queue.Dequeue();

                        int greenLightCounter = greenLightDuration;
                        while (greenLightCounter > 0)
                        {
                            if (currentCar.Length < greenLightCounter)
                            {
                                greenLightCounter -= currentCar.Length;
                                counter++;
                                if (queue.Count > 0)
                                {
                                    currentCar = queue.Dequeue();
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else if (currentCar.Length <= greenLightCounter + freeWindowDuration)
                            {
                                greenLightCounter = 0;
                                counter++;
                            }
                            else
                            {
                                int characterHitIndex = currentCar.Length - greenLightCounter - freeWindowDuration - 1;
                                char characterHit = string.Join("", currentCar.Reverse())[characterHitIndex];
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{currentCar} was hit at {characterHit}.");
                                return;
                            }
                        }
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{counter} total cars passed the crossroads.");
        }
    }
}
