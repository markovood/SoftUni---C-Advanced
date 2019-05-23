using System;
using System.Linq;

namespace SumMatrixColumns
{
    public class SumMatrixColumns
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[,] matrix = new int[dimensions[0], dimensions[1]];
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] currentRow = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[rows, col] = currentRow[col];
                }
            }

            int sum = 0;
            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                for (int rows = 0; rows < matrix.GetLength(0); rows++)
                {
                    sum += matrix[rows, cols];
                }

                Console.WriteLine(sum);
                sum = 0;
            }
        }
    }
}
