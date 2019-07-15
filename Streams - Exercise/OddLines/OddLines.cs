using System;
using System.IO;

namespace OddLines
{
    public class OddLines
    {
        public static void Main()
        {
            string path = $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}text.txt";

            using (var reader = new StreamReader(path))
            {
                int lineCounter = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (lineCounter % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }

                    lineCounter++;
                    line = reader.ReadLine();
                } 
            }
        }
    }
}
