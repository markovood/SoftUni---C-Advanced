using System;
using System.Linq;

namespace GroupNumbers
{
    public class GroupNumbers
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[][] groups = new int[3][];  // remainders 0 1 2
            
            int groupZeroIndex = 0;
            int groupOneIndex = 0;
            int groupTwoIndex = 0;
            foreach (int number in input)
            {
                if (number % 3 == 0)
                {
                    groups[0] = EnsureCapacity(groups[0], groupZeroIndex);
                    groups[0][groupZeroIndex] = number;
                    groupZeroIndex++;
                }
                else if (Math.Abs(number % 3) == 1)
                {
                    groups[1] = EnsureCapacity(groups[1], groupOneIndex);
                    groups[1][groupOneIndex] = number;
                    groupOneIndex++;
                }
                else if (Math.Abs(number % 3) == 2)
                {
                    groups[2] = EnsureCapacity(groups[2], groupTwoIndex);
                    groups[2][groupTwoIndex] = number;
                    groupTwoIndex++;
                }
            }

            // print the jagged array 
            Print(groups);
        }

        private static void Print(int[][] groups)
        {
            for (int i = 0; i < groups.Length; i++)
            {
                if (groups[i] == null)
                {
                    Console.WriteLine();
                }
                else
                {
                    for (int j = 0; j < groups[i].Length; j++)
                    {
                        Console.Write(groups[i][j] + " ");
                    }

                    Console.WriteLine();
                }
            }
        }

        private static int[] EnsureCapacity(int[] arrayToBeEnsured, int currentIndex)
        {
            if (arrayToBeEnsured == null)
            {
                arrayToBeEnsured = new int[1];
            }

            if (currentIndex >= arrayToBeEnsured.Length)
            {
                int[] ensuredLengthArray = new int[arrayToBeEnsured.Length + 1];
                arrayToBeEnsured.CopyTo(ensuredLengthArray, 0);
                return ensuredLengthArray;
            }

            return arrayToBeEnsured;
        }
    }
}
