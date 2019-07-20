using System;
using System.IO;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        public static void Main()
        {
            char dirSeparator = Path.DirectorySeparatorChar;
            string fileNameToCopy = "copyMe.png";
            string copiedFileName = "copyMe.png - copy.png";
            string pathIn = $"..{dirSeparator}..{dirSeparator}..{dirSeparator}{fileNameToCopy}";
            string pathOut = $"..{dirSeparator}..{dirSeparator}..{dirSeparator}{copiedFileName}";

            using (var reader = new FileStream(pathIn, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var writer = new FileStream(pathOut, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    byte[] buffer = new byte[4096];

                    int readBytes = reader.Read(buffer, 0, buffer.Length);

                    while (readBytes != 0)
                    {
                        writer.Write(buffer, 0, readBytes);

                        readBytes = reader.Read(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
