using System;
using System.Collections.Generic;
using System.Linq;

namespace RubiksMatrix
{
    public class RubiksMatrix
    {
        public static void Main()
        {
            // read input and fill-up the matrix
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];
            int[,] matrix = FillUpMatrix(rows, cols);

            // Shuffling
            Shuffle(matrix);

            // Rearranging
            int value = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == value)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        // find at what indexes is the element with value == 'value' and swap it with current
                        int[] elementIndexes = FindElement(matrix, i, value);
                        Console.WriteLine($"Swap ({i}, {j}) with ({elementIndexes[0]}, {elementIndexes[1]})");
                        int temp = matrix[i, j];
                        matrix[i, j] = matrix[elementIndexes[0], elementIndexes[1]];
                        matrix[elementIndexes[0], elementIndexes[1]] = temp;
                    }

                    value++;
                }
            }
        }

        private static int[] FindElement(int[,] matrix, int startIndex, int elementValue)
        {
            for (int r = startIndex; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == elementValue)
                    {
                        return new int[] { r, c };
                    }
                }
            }

            throw new ApplicationException("Element doesn't exist!");
        }

        private static int[,] FillUpMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            int value = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = value;
                    value++;
                }
            }

            return matrix;
        }

        private static void Shuffle(int[,] matrix)
        {
            int numbOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numbOfCommands; i++)
            {
                string[] commandTokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string direction = commandTokens[1];
                switch (direction)
                {
                    case "up":
                        int col = int.Parse(commandTokens[0]);
                        int moves = int.Parse(commandTokens[2]);

                        // Get current column
                        Queue<int> currentColumn = GetColumnValues(matrix, col);
                        // Move elements in the column 'moves' times
                        RotateForwards(moves, currentColumn);
                        // set matrix column with the elements from the queue
                        SetColumnValues(matrix, col, currentColumn);
                        break;
                    case "down":
                        col = int.Parse(commandTokens[0]);
                        moves = int.Parse(commandTokens[2]);

                        currentColumn = GetColumnValues(matrix, col);
                        currentColumn = RotateBackwards(moves, currentColumn);
                        SetColumnValues(matrix, col, currentColumn);
                        break;
                    case "left":
                        int row = int.Parse(commandTokens[0]);
                        moves = int.Parse(commandTokens[2]);

                        Queue<int> currentRow = GetRowValues(matrix, row);
                        RotateForwards(moves, currentRow);
                        SetRowValues(matrix, row, currentRow);
                        break;
                    case "right":
                        row = int.Parse(commandTokens[0]);
                        moves = int.Parse(commandTokens[2]);

                        currentRow = GetRowValues(matrix, row);
                        currentRow = RotateBackwards(moves, currentRow);
                        SetRowValues(matrix, row, currentRow);
                        break;
                }
            }
        }

        private static void RotateForwards(int rotationCounter, Queue<int> queueToRotate)
        {
            // optimization: no need to rotate rotationCounter times as every queueToRotate.Count times the
            //               elements in the queue will come to their initial positions
            rotationCounter %= queueToRotate.Count;

            for (int round = 0; round < rotationCounter; round++)
            {
                queueToRotate.Enqueue(queueToRotate.Dequeue());
            }

        }

        private static Queue<int> RotateBackwards(int rotationCounter, Queue<int> queueToRotate)
        {
            // optimization: no need to rotate rotationCounter times as every queueToRotate.Count times the
            //               elements in the queue will come to their initial positions
            rotationCounter %= queueToRotate.Count;

            queueToRotate = new Queue<int>(queueToRotate.Reverse());

            for (int round = 0; round < rotationCounter; round++)
            {
                queueToRotate.Enqueue(queueToRotate.Dequeue());
            }

            return new Queue<int>(queueToRotate.Reverse());
        }

        private static void SetColumnValues(int[,] matrix, int col, Queue<int> currentColumn)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row, col] = currentColumn.Dequeue();
            }
        }

        private static Queue<int> GetColumnValues(int[,] matrix, int col)
        {
            Queue<int> currentColumn = new Queue<int>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                currentColumn.Enqueue(matrix[row, col]);
            }

            return currentColumn;
        }

        private static Queue<int> GetRowValues(int[,] matrix, int row)
        {
            Queue<int> currentRow = new Queue<int>();
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                currentRow.Enqueue(matrix[row, col]);
            }

            return currentRow;
        }

        private static void SetRowValues(int[,] matrix, int row, Queue<int> currentRow)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = currentRow.Dequeue();
            }
        }
    }
}
