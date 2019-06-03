using System;
using System.Linq;

namespace DiagonalDifference
{
    public class DiagonalDifference
    {
        public static void Main()
        {
            // read input & fill up the matrix
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
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

            // Calculate the sum from the primary diagonal 
            int primaryDiagonal = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                primaryDiagonal += matrix[i, i];
            }

            // Calculate the sum from the secondary diagonal 
            int secondaryDiagonal = 0;
            for (int i = 0, j = matrix.GetLength(1) - 1; i < matrix.GetLength(0); i++, j--)
            {
                secondaryDiagonal += matrix[i, j];
            }

            int difference = Math.Abs(primaryDiagonal - secondaryDiagonal);
            Console.WriteLine(difference);
        }
    }
}
