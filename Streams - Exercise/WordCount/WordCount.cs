using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    public class WordCount
    {
        public static void Main()
        {
            char dirSeparator = Path.DirectorySeparatorChar;
            string inputFileName = "words.txt";
            string targetFileName = "text.txt";
            string outputFileName = "result.txt";

            string pathToWords = $"..{dirSeparator}..{dirSeparator}..{dirSeparator}{inputFileName}";
            string pathIn = $"..{dirSeparator}..{dirSeparator}..{dirSeparator}{targetFileName}";
            string pathOut = $"..{dirSeparator}..{dirSeparator}..{dirSeparator}{outputFileName}";

            var words = GetWords(pathToWords);
            var wordsAndCount = CountWords(pathIn, words);
            WriteDownResult(pathOut, wordsAndCount);
        }

        private static void WriteDownResult(string pathOut, Dictionary<string, int> wordsAndCount)
        {
            var ordered = wordsAndCount.OrderByDescending(x => x.Value);
            using (var writer = new StreamWriter(pathOut))
            {
                foreach (var word in ordered)
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }

        private static Dictionary<string, int> CountWords(string pathIn, List<string> words)
        {
            var wordsAndCount = new Dictionary<string, int>();
            using (var textReader = new StreamReader(pathIn))
            {
                string line = textReader.ReadLine();
                while (line != null)
                {
                    foreach (var word in words)
                    {
                        int wordCount = Count(word, line);

                        if (wordsAndCount.ContainsKey(word))
                        {
                            wordsAndCount[word] += wordCount;
                        }
                        else
                        {
                            wordsAndCount.Add(word, wordCount);
                        }
                    }

                    line = textReader.ReadLine();
                }
            }

            return wordsAndCount;
        }

        private static int Count(string word, string line)
        {
            int count = 0;
            var punctuation = line.Where(Char.IsPunctuation).Distinct().ToArray();
            var words = line.Split().Select(x => x.Trim(punctuation));
            foreach (var item in words)
            {
                if (item.ToLower() == word.ToLower())
                {
                    count++;
                }
            }

            return count;
        }

        private static List<string> GetWords(string pathToWords)
        {
            List<string> words = new List<string>();
            using (var wordReader = new StreamReader(pathToWords))
            {
                string word = wordReader.ReadLine();
                while (word != null)
                {
                    words.Add(word);
                    word = wordReader.ReadLine();
                }
            }

            return words;
        }
    }
}
