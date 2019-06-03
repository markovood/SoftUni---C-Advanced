using System;
using System.Linq;

namespace MaximalSum
{
    public class MaximalSum
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                int[] colsValues = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < colsValues.Length; col++)
                {
                    matrix[row, col] = colsValues[col];
                }
            }

            // find the biggest sum of elements in 3x3 matrix
            int biggestSum = int.MinValue;
            int biggestSumRowIndex = 0;
            int biggestSumColIndex = 0;
            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    int currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] +
                                    matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] +
                                    matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
                    if (currentSum > biggestSum)
                    {
                        biggestSum = currentSum;
                        biggestSumRowIndex = i;
                        biggestSumColIndex = j;
                    }
                }
            }

            // Result
            Console.WriteLine($"Sum = {biggestSum}");
            Console.WriteLine($"{matrix[biggestSumRowIndex,biggestSumColIndex]} {matrix[biggestSumRowIndex, biggestSumColIndex + 1]} {matrix[biggestSumRowIndex, biggestSumColIndex + 2]}");
            Console.WriteLine($"{matrix[biggestSumRowIndex + 1,biggestSumColIndex]} {matrix[biggestSumRowIndex + 1, biggestSumColIndex + 1]} {matrix[biggestSumRowIndex + 1, biggestSumColIndex + 2]}");
            Console.WriteLine($"{matrix[biggestSumRowIndex + 2,biggestSumColIndex]} {matrix[biggestSumRowIndex + 2, biggestSumColIndex + 1]} {matrix[biggestSumRowIndex + 2, biggestSumColIndex + 2]}");
        }
    }
}
