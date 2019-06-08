using System;
using System.Collections.Generic;
using System.Linq;

namespace TargetPractice
{
    public class TargetPractice
    {
        public static void Main()
        {
            // read input
            int[] dimemsions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string snake = Console.ReadLine();

            int[] shotParameters = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            // create and fill-up the matrix
            int rows = dimemsions[0];
            int cols = dimemsions[1];
            char[,] matrix = new char[rows, cols];

            FillUpMatrix(snake, matrix);

            // Shoot
            int impactRow = shotParameters[0];
            int impactCol = shotParameters[1];
            int radius = shotParameters[2];
            ApplyImpact(matrix, impactRow, impactCol, radius);
            PullElementsDown(matrix);
            Print(matrix);
        }

        private static void PullElementsDown(char[,] matrix)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                // get the current column without the empty elements
                var currentColumn = GetCurrentColumn(matrix, col);

                // set the matrix column with the current one
                for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                {
                    if (currentColumn.Count > 0)
                    {
                        matrix[row, col] = currentColumn.Pop();
                    }
                    else
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
        }

        private static Stack<char> GetCurrentColumn(char[,] matrix, int colIndex)
        {
            Stack<char> currentColumn = new Stack<char>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, colIndex] == ' ')
                {
                    continue;
                }
                else
                {
                    currentColumn.Push(matrix[row, colIndex]);
                }
            }


            return currentColumn;
        }

        private static void ApplyImpact(char[,] matrix, int impactRow, int impactCol, int radius)
        {
            matrix[impactRow, impactCol] = ' ';

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    bool isInside = Math.Pow(row - impactRow, 2) + Math.Pow(col - impactCol, 2) <= Math.Pow(radius, 2);
                    if (isInside)
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
        }

        private static void Print(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static void FillUpMatrix(string snake, char[,] matrix)
        {
            int index = 0;
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                // if number of rows in matrix is even:
                //  - even rowsIndexes move right
                //  - odd rowsIndexes move left
                // else i.e. number of rows in matrix is odd:
                //  - even rowsIndexes move left
                //  - odd rowsIndexes move right
                if (matrix.GetLength(0) % 2 == 0)
                {
                    if (row % 2 == 0)
                    {
                        MoveRight(snake, matrix, row, ref index);
                    }
                    else
                    {
                        MoveLeft(snake, matrix, row, ref index);
                    }
                }
                else
                {
                    if (row % 2 == 0)
                    {
                        MoveLeft(snake, matrix, row, ref index);
                    }
                    else
                    {
                        MoveRight(snake, matrix, row, ref index);
                    }
                }
            }
        }

        private static void MoveLeft(string snake, char[,] matrix, int row, ref int index)
        {
            for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
            {
                if (index >= snake.Length)
                {
                    index = 0;
                }


                matrix[row, col] = snake[index];
                index++;
            }
        }

        private static void MoveRight(string snake, char[,] matrix, int row, ref int index)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (index >= snake.Length)
                {
                    index = 0;
                }

                matrix[row, col] = snake[index];
                index++;
            }
        }
    }
}
