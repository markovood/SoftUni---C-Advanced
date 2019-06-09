using System;
using System.Linq;

namespace LegoBlocks
{
    public class LegoBlocks
    {
        public static void Main()
        {
            // Reading input
            int rows = int.Parse(Console.ReadLine());

            int[][] firstArr = new int[rows][];
            int[][] secondArr = new int[rows][];

            // Filling-up the first jagged array
            FillUpArray(rows, firstArr);

            // Filling-up the second jagged array
            FillUpArray(rows, secondArr);

            // Reverse second jagged array
            Reverse(secondArr);

            // Fitting arrays
            int totalNumbOfElementsPerRow = firstArr[0].Length + secondArr[0].Length;
            for (int row = 1; row < rows; row++)
            {
                if (firstArr[row].Length + secondArr[row].Length != totalNumbOfElementsPerRow)
                {
                    int count = Count(firstArr);
                    count += Count(secondArr);
                    Console.WriteLine($"The total number of cells is: {count}");
                    return;
                }
            }

            // Combine the two jagged arrays and print the result
            int[,] matrix = new int[rows, firstArr[0].Length + secondArr[0].Length];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < firstArr[i].Length; j++)
                {
                    matrix[i, j] = firstArr[i][j];
                }          
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = firstArr[i].Length, col = 0; j < matrix.GetLength(1); j++, col++)
                {
                    matrix[i, j] = secondArr[i][col];
                }
            }

            Print(matrix);
        }

        private static int Count(int[][] jaggedArr)
        {
            int count = 0;
            for (int i = 0; i < jaggedArr.Length; i++)
            {
                count += jaggedArr[i].Length;
            }

            return count;
        }

        private static void FillUpArray(int rows, int[][] jaggedArr)
        {
            for (int row = 0; row < rows; row++)
            {
                jaggedArr[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
        }

        private static void Reverse(int[][] secondArr)
        {
            for (int row = 0; row < secondArr.Length; row++)
            {
                secondArr[row] = secondArr[row]
                                    .Reverse()
                                    .ToArray();
            }
        }

        private static void Print(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.Write("[");
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col == matrix.GetLength(1) - 1)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    else
                    {
                        Console.Write(matrix[row, col] + ", ");
                    }
                }

                Console.WriteLine("]");
            }
        }
    }
}
