using System;
using System.Linq;

namespace SquaresInMatrix
{
    public class SquaresInMatrix
    {
        public static void Main()
        {
            // read input and fill up the matrix
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            char[,] matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                char[] colsValues = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < colsValues.Length; col++)
                {
                    matrix[row, col] = colsValues[col];
                }
            }

            // find the number of 2x2 matrices of equal chars
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1] &&     // next char
                        matrix[i, j] == matrix[i + 1, j] &&     // char underneath
                        matrix[i, j] == matrix[i + 1, j + 1])   // char in diagonal
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
