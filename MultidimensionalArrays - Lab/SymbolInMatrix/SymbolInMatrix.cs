using System;

namespace SymbolInMatrix
{
    public class SymbolInMatrix
    {
        public static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];
            for (int rows = 0; rows < matrixSize; rows++)
            {
                string columns = Console.ReadLine();
                for (int cols = 0; cols < columns.Length; cols++)
                {
                    matrix[rows, cols] = columns[cols];
                }
            }

            char symbolToFind = char.Parse(Console.ReadLine());
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    char currentSymbol = matrix[i, j];
                    if (currentSymbol == symbolToFind)
                    {
                        Console.WriteLine($"({i}, {j})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{symbolToFind} does not occur in the matrix ");
        }
    }
}
