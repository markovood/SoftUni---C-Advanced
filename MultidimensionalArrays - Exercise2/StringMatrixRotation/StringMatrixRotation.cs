using System;
using System.Collections.Generic;
using System.Linq;

namespace StringMatrixRotation
{
    public class StringMatrixRotation
    {
        public static void Main()
        {
            string[] commandTokens = Console.ReadLine()
                .Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

            int degrees = int.Parse(commandTokens[1]);

            // collect all lines
            List<string> lines = new List<string>();
            string line = Console.ReadLine();
            while (line != "END")
            {
                lines.Add(line);

                line = Console.ReadLine();
            }

            // find longest line, pad the rest with ' ', to be all the same size
            int longestLineLenght = 0;
            longestLineLenght = lines.OrderByDescending(x => x.Length).First().Length;
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Length < longestLineLenght)
                {
                    lines[i] += new string(' ', longestLineLenght - lines[i].Length);
                }
            }

            // select rotation, rotate

            // As in rotation we have a full circle at 360 degrees, that means every 360 degrees we gonna have
            // the initial position of the lines. Since we've been told that degrees is a multiple of 90 then we
            // get that we have just four steps from 0 to 360 (0-90, 90-180, 180-270, 270-0 i.e. from initial
            // position to it again and again), therefore if we have to turn lines to 8100 degrees we'll get
            // them to the position as we turned them just to 180 degrees, so we can use that optimization.
            int rotation = degrees % 360;
            lines = Rotate(rotation, lines);

            // print result
            Print(lines);
        }

        private static void Print(List<string> lines)
        {
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }

        private static List<string> Rotate(int rotation, List<string> lines)
        {
            List<string> rotated = new List<string>();
            switch (rotation)
            {
                case 0:
                    // no need to do anything as we get the initial position
                    rotated = lines;
                    break;
                case 90:
                    rotated = Rotate90(lines);
                    break;
                case 180:
                    rotated = Rotate180(lines);
                    break;
                case 270:
                    rotated = Rotate270(lines);
                    break;
            }

            return rotated;
        }

        private static List<string> Rotate270(List<string> lines)
        {
            List<string> rotated90 = Rotate90(lines);
            rotated90.Reverse();
            for (int i = 0; i < rotated90.Count; i++)
            {
                string currentLine = rotated90[i];
                rotated90[i] = string.Join("", currentLine.Reverse());
            }

            return rotated90;
        }

        private static List<string> Rotate180(List<string> lines)
        {
            lines.Reverse();
            for (int i = 0; i < lines.Count; i++)
            {
                lines[i] = string.Join("", lines[i].Reverse());
            }

            return lines;
        }

        private static List<string> Rotate90(List<string> lines)
        {
            List<string> rotated90 = new List<string>();
            for (int j = 0; j < lines[0].Length; j++)
            {
                string currentLine = string.Empty;
                for (int i = lines.Count - 1; i >= 0; i--)
                {
                    currentLine += lines[i][j];
                }

                rotated90.Add(currentLine);
            }

            return rotated90;
        }
    }
}
