using System;

namespace PascalTriangle
{
    public class PascalTriangle
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] pascalTriangle = new long[rows][];

            // Set the top of triangle as it is always the same
            pascalTriangle[0] = new long[3]; // always starts and finishes with 0, we'll use this later
            pascalTriangle[0][1] = 1;

            // Set next rows
            for (int row = 1; row < rows; row++) 
            {                                   
                pascalTriangle[row] = new long[pascalTriangle[row - 1].Length + 1];

                for (int currentCol = 1, prevRowsCol = 0;
                    currentCol < pascalTriangle[row].Length - 1;
                    currentCol++, prevRowsCol++)
                {
                    // Calculate the sum of the two elements above, i.e. previous row
                    long colValue = pascalTriangle[row - 1][prevRowsCol] + pascalTriangle[row - 1][prevRowsCol + 1];
                    pascalTriangle[row][currentCol] = colValue;
                }
            }

            // Print the triangle
            for (int i = 0; i < pascalTriangle.Length; i++)
            {
                // Don't print the 0
                for (int j = 1; j < pascalTriangle[i].Length - 1; j++)
                {
                    Console.Write(pascalTriangle[i][j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
