using System;
using System.Linq;

namespace MatrixOfPalindromes
{
    public class MatrixOfPalindromes
    {
        public static void Main()
        {
            int[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int r = sizes[0];
            int c = sizes[1];

            string[,] matrix = new string[r, c];
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int row = 0; row < r; row++)
            {
                for (int col = 0, letterIndex = row; col < c; col++, letterIndex++)
                {
                    string currentPalindrome = $"{alphabet[row]}{alphabet[letterIndex]}{alphabet[row]}";
                    matrix[row, col] = currentPalindrome;
                }
            }

            // Print matrix
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
