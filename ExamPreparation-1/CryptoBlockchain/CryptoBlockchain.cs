using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CryptoBlockchain
{
    public class CryptoBlockchain
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            string[] cryptoBlockchain = new string[rows];
            for (int i = 0; i < rows; i++)
            {
                cryptoBlockchain[i] = Console.ReadLine();
            }

            // extract the cryptoBlocks
            string CBCondensed = string.Join("", cryptoBlockchain);
            string pattern = @"(?<={)([^{\[\]]+)(?=})|(?<=\[)([^{}\[]+)(?=\])";
            var matches = Regex.Matches(CBCondensed, pattern);

            // get only numbers from every cryptoBlock, and the length of the whole cryptoBlock incl. {} or []
            List<KeyValuePair<string, int>> numbersAndLengths = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < matches.Count; i++)
            {
                string number = string.Join("", Regex.Matches(matches[i].ToString(), "[0-9]+"));
                numbersAndLengths.Add(new KeyValuePair<string, int>(number, matches[i].Length + 2));
            }

            // process only those numbers which length is divisible to 3 without a remainder
            List<string> results = new List<string>();
            foreach (var pair in numbersAndLengths)
            {
                if (pair.Key.Length % 3 == 0)
                {
                    // process
                    results.Add(Decrypt(pair));
                }
            }

            // collect the results into one string
            string decryptedText = string.Join("", results);
            Console.WriteLine(decryptedText);
        }

        private static string Decrypt(KeyValuePair<string, int> pair)
        {
            string decrypted = string.Empty;
            for (int i = 0; i < pair.Key.Length; i += 3)
            {
                string tempCharCode = string.Empty;
                tempCharCode += pair.Key[i];
                tempCharCode += pair.Key[i + 1];
                tempCharCode += pair.Key[i + 2];

                int charCode = int.Parse(tempCharCode);
                charCode -= pair.Value;
                decrypted += (char)charCode;
            }

            return decrypted;
        }
    }
}
