using System;
using System.Linq;

namespace PrimaryDiagonal
{
    public class PrimaryDiagonal
    {
        public static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];
            for (int i = 0; i < matrixSize; i++)
            {
                int[] currentRow = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int j = 0; j < currentRow.Length; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
            }

            Console.WriteLine(sum);
        }
    }
}
