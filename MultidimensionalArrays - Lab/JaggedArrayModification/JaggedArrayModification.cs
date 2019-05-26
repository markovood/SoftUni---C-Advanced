using System;
using System.Linq;

namespace JaggedArrayModification
{
    public class JaggedArrayModification
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rows][];

            // filling up the jagged array matrix
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            }

            // processing the jagged array
            while (true)
            {
                string[] commandArguments = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (commandArguments[0])
                {
                    case "Add":
                        int row = int.Parse(commandArguments[1]);
                        int col = int.Parse(commandArguments[2]);
                        int value = int.Parse(commandArguments[3]);
                        if (ValidateCoordinates(row, col, matrix))
                        {
                            matrix[row][col] += value;
                        }
                        else
                        {
                            Console.WriteLine("Invalid coordinates");
                        }

                        break;
                    case "Subtract":
                        row = int.Parse(commandArguments[1]);
                        col = int.Parse(commandArguments[2]);
                        value = int.Parse(commandArguments[3]);
                        if (ValidateCoordinates(row, col, matrix))
                        {
                            matrix[row][col] -= value;
                        }
                        else
                        {
                            Console.WriteLine("Invalid coordinates");
                        }

                        break;
                    case "END":
                        for (int i = 0; i < matrix.Length; i++)
                        {
                            for (int j = 0; j < matrix[i].Length; j++)
                            {
                                Console.Write(matrix[i][j] + " ");
                            }

                            Console.WriteLine();
                        }

                        return;
                }
            }
        }

        private static bool ValidateCoordinates(int row, int col, int[][] matrix)
        {
            if (row < 0 || row >= matrix.Length)
            {
                return false;
            }

            if (col < 0 || col >= matrix[row].Length)
            {
                return false;
            }

            return true;
        }
    }
}
