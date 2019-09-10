using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberWars
{
    public class NumberWars
    {
        private static string[] possibleResults = new string[]
        {
            "Draw",
            "First player wins",
            "Second player wins"
        };

        private static char[] letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        public static void Main()
        {
            string[] firstPlayerCards = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] secondPlayerCards = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Queue<string> firstPlayerHand = new Queue<string>(firstPlayerCards);
            Queue<string> secondPlayerHand = new Queue<string>(secondPlayerCards);

            int turns = 0;
            string result = string.Empty;
            while (true)
            {
                if (firstPlayerHand.Count == 0 || secondPlayerHand.Count == 0)
                {
                    // find who wins
                    if (firstPlayerHand.Count == 0 && secondPlayerHand.Count == 0)
                    {
                        result = possibleResults[0];
                    }
                    else if (firstPlayerHand.Count == 0 && secondPlayerHand.Count > 0)
                    {
                        result = possibleResults[2];
                    }
                    else if (firstPlayerHand.Count > 0 && secondPlayerHand.Count == 0)
                    {
                        result = possibleResults[1];
                    }

                    break;
                }

                if (turns == 1_000_000)
                {
                    if (firstPlayerHand.Count > secondPlayerHand.Count)
                    {
                        result = possibleResults[1];
                    }
                    else if (firstPlayerHand.Count < secondPlayerHand.Count)
                    {
                        result = possibleResults[2];
                    }
                    else
                    {
                        result = possibleResults[0];
                    }

                    break;
                }

                // put one card of each hand and check the result
                string firstPlayerCard = firstPlayerHand.Dequeue();
                string secondPlayerCard = secondPlayerHand.Dequeue();

                int firstNum = int.Parse(firstPlayerCard.Substring(0, firstPlayerCard.Length - 1));
                int secondNum = int.Parse(secondPlayerCard.Substring(0, secondPlayerCard.Length - 1));
                if (firstNum > secondNum)
                {
                    firstPlayerHand.Enqueue(firstPlayerCard);
                    firstPlayerHand.Enqueue(secondPlayerCard);
                }
                else if (firstNum < secondNum)
                {
                    secondPlayerHand.Enqueue(secondPlayerCard);
                    secondPlayerHand.Enqueue(firstPlayerCard);
                }
                else
                {
                    // voina -> put 3 cards each and check for the bigger sum of letters at the end of the cards
                    List<string> cardsOnTheField = new List<string>() { firstPlayerCard, secondPlayerCard };

                    while (true)
                    {
                        if (firstPlayerHand.Count < 3 || secondPlayerHand.Count < 3)
                        {
                            if (firstPlayerHand.Count < 3 && secondPlayerHand.Count >= 3)
                            {
                                firstPlayerHand.Clear();
                            }
                            else if (firstPlayerHand.Count >= 3 && secondPlayerHand.Count < 3)
                            {
                                secondPlayerHand.Clear();
                            }
                            else
                            {
                                firstPlayerHand.Clear();
                                secondPlayerHand.Clear();
                            }

                            break;
                        }

                        string[] FPcards = new string[]
                        {
                            firstPlayerHand.Dequeue(),
                            firstPlayerHand.Dequeue(),
                            firstPlayerHand.Dequeue()
                        };

                        string[] SPcards = new string[]
                        {
                            secondPlayerHand.Dequeue(),
                            secondPlayerHand.Dequeue(),
                            secondPlayerHand.Dequeue()
                        };

                        int resultIndex = CheckForWinner(FPcards, SPcards);
                        if (resultIndex == 1)
                        {
                            cardsOnTheField.AddRange(FPcards);
                            cardsOnTheField.AddRange(SPcards);
                            cardsOnTheField = cardsOnTheField
                                .OrderByDescending(x => GetNum(x))
                                .ThenByDescending(x => GetChar(x))
                                .ToList();
                            for (int i = 0; i < cardsOnTheField.Count; i++)
                            {
                                firstPlayerHand.Enqueue(cardsOnTheField[i]);
                            }

                            break;
                        }
                        else if (resultIndex == 2)
                        {
                            cardsOnTheField.AddRange(FPcards);
                            cardsOnTheField.AddRange(SPcards);
                            cardsOnTheField = cardsOnTheField
                                .OrderByDescending(x => GetNum(x))
                                .ThenByDescending(x => GetChar(x))
                                .ToList();
                            for (int i = 0; i < cardsOnTheField.Count; i++)
                            {
                                secondPlayerHand.Enqueue(cardsOnTheField[i]);
                            }

                            break;
                        }
                        else
                        {
                            cardsOnTheField.AddRange(FPcards);
                            cardsOnTheField.AddRange(SPcards);
                        }
                    }
                }

                turns++;
            }

            Console.WriteLine($"{result} after {turns} turns");
        }

        private static char GetChar(string card)
        {
            return card.Last();
        }

        private static int GetNum(string card)
        {
            return int.Parse(card.Substring(0, card.Length - 1));
        }

        private static int CheckForWinner(string[] fPcards, string[] sPcards)
        {
            int firstSum = GetSum(fPcards);
            int secondSum = GetSum(sPcards);
            if (firstSum > secondSum)
            {
                return 1;
            }
            else if (firstSum < secondSum)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }

        private static int GetSum(string[] cards)
        {
            int sum = 0;
            for (int i = 0; i < cards.Length; i++)
            {
                char currentLetter = cards[i][cards[i].Length - 1];
                sum += currentLetter - 'a' + 1;
            }

            return sum;
        }
    }
}
