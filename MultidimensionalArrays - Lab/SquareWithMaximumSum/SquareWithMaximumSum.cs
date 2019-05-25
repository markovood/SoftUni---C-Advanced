using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    public class SquareWithMaximumSum
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                int[] currentColumn = Console.ReadLine().Split(",").Select(int.Parse).ToArray();
                for (int col = 0; col < currentColumn.Length; col++)
                {
                    matrix[row, col] = currentColumn[col];
                }
            }

            // find biggest sum of 2x2 sub-matrix and print it
            int biggestSum = int.MinValue;
            int biggestSumRowIndex = 0;
            int biggestSumColIndex = 0;
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    int upperLeft = matrix[i, j];
                    int upperRight = matrix[i, j + 1];
                    int lowerLeft = matrix[i + 1, j];
                    int lowerRight = matrix[i + 1, j + 1];
                    int currentSum = upperLeft + upperRight + lowerLeft + lowerRight;
                    if (currentSum > biggestSum)
                    {
                        biggestSum = currentSum;
                        biggestSumRowIndex = i;
                        biggestSumColIndex = j;
                    }
                }
            }

            Console.WriteLine($"{matrix[biggestSumRowIndex, biggestSumColIndex]} {matrix[biggestSumRowIndex, biggestSumColIndex + 1]}");
            Console.WriteLine($"{matrix[biggestSumRowIndex + 1, biggestSumColIndex]} {matrix[biggestSumRowIndex + 1, biggestSumColIndex + 1]}");
            Console.WriteLine(biggestSum);
        }
    }
}
