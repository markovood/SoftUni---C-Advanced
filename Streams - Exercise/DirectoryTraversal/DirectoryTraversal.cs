using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DirectoryTraversal
{
    public class DirectoryTraversal
    {
        public static void Main()
        {
            // create directory with files and sizes as in the picture in the task assignment for debugging purposes
            // GenerateTestDirectory($"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}TestDirectory");

            Console.WriteLine("Please, enter a directory to scan:");
            string directory = Path.GetFullPath(Console.ReadLine());

            string[] allFiles = Directory.GetFiles(directory);

            Dictionary<string, Dictionary<string, double>> extensionsPathsAndSizes = new Dictionary<string, Dictionary<string, double>>();

            // group all files by extension
            foreach (var file in allFiles)
            {
                string fileExtension = Path.GetExtension(file);
                double fileSizeKB = new FileStream(file, FileMode.Open, FileAccess.Read).Length / 1000.0;

                if (extensionsPathsAndSizes.ContainsKey(fileExtension))
                {
                    if (!extensionsPathsAndSizes[fileExtension].ContainsKey(file))
                    {
                        extensionsPathsAndSizes[fileExtension].Add(file, fileSizeKB);
                    }
                }
                else
                {
                    extensionsPathsAndSizes.Add(fileExtension, new Dictionary<string, double>()
                    {
                        {file, fileSizeKB }
                    });
                }
            }

            // order extensions by the count of their files descending, then by name alphabetically
            var ordered = extensionsPathsAndSizes
                            .OrderByDescending(x => x.Value.Count)
                            .ThenBy(x => x.Key)
                            .ToDictionary(x => x.Key, y => y.Value);

            // Files under an extension should be ordered by their size. Save result in 'report.txt' on the
            // Desktop. Ensure the desktop path is always valid, regardless of the user
            string desktopDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string outputFile = "report.txt";
            string outputPath = Path.Combine(desktopDirectory, outputFile);
            using (var writer = new StreamWriter(outputPath, false, Encoding.UTF8))
            {
                foreach (var extension in ordered.Keys)
                {
                    writer.WriteLine(extension);

                    var orderedPathsAndSizes = ordered[extension].OrderBy(x => x.Value);
                    foreach (var path in orderedPathsAndSizes)
                    {
                        string fileName = Path.GetFileName(path.Key);
                        writer.WriteLine($"--{fileName} - {path.Value}kb");
                    }
                }
            }
        }

        private static void GenerateTestDirectory(string directory)
        {
            Directory.CreateDirectory(directory);
            Directory.CreateDirectory($"{directory}{Path.DirectorySeparatorChar}bin");
            Directory.CreateDirectory($"{directory}{Path.DirectorySeparatorChar}obj");
            Directory.CreateDirectory($"{directory}{Path.DirectorySeparatorChar}Properties");

            string fileName = "Mecanismo.cs";
            string fileToCreate = Path.Combine(directory, fileName);

            using (var fs = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.SetLength(994);
            }

            fileName = "Program.cs";
            fileToCreate = Path.Combine(directory, fileName);

            using (var fs = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.SetLength(1108);
            }

            fileName = "Nashmat.cs";
            fileToCreate = Path.Combine(directory, fileName);

            using (var fs = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.SetLength(3967);
            }

            fileName = "Wedding.cs";
            fileToCreate = Path.Combine(directory, fileName);

            using (var fs = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.SetLength(23787);
            }

            fileName = "Program - Copy.cs";
            fileToCreate = Path.Combine(directory, fileName);

            using (var fs = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.SetLength(35679);
            }

            fileName = "Salimur.cs";
            fileToCreate = Path.Combine(directory, fileName);

            using (var fs = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.SetLength(588657);
            }

            fileName = "backup.txt";
            fileToCreate = Path.Combine(directory, fileName);

            using (var fs = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.SetLength(28);
            }

            fileName = "log.txt";
            fileToCreate = Path.Combine(directory, fileName);

            using (var fs = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.SetLength(6720);
            }

            fileName = "script.asm";
            fileToCreate = Path.Combine(directory, fileName);

            using (var fs = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.SetLength(28);
            }

            fileName = "App.config";
            fileToCreate = Path.Combine(directory, fileName);

            using (var fs = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.SetLength(187);
            }

            fileName = "01. Writing-To-Files.csproj";
            fileToCreate = Path.Combine(directory, fileName);

            using (var fs = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.SetLength(2570);
            }

            fileName = "controller.js";
            fileToCreate = Path.Combine(directory, fileName);

            using (var fs = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.SetLength(1635143);
            }

            fileName = "model.php";
            fileToCreate = Path.Combine(directory, fileName);

            using (var fs = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.SetLength(0);
            }
        }
    }
}
