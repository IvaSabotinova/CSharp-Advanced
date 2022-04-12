using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {


            string input = File.ReadAllText("words.txt");
            string text = File.ReadAllText("text1.txt");
            string outputFilePath = @"..\..\..\output.txt";
            CalculateWordCounts(input, text, outputFilePath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            string pattern = @"[A-Za-z]+[-]?[A-Za-z]*[']?[A-Za-z]*";
            Dictionary<string, int> words_counts = new Dictionary<string, int>();
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(wordsFilePath.ToLower());
            MatchCollection matchesInText = regex.Matches(textFilePath.ToLower());
            using StreamWriter sw = new StreamWriter(outputFilePath);

            foreach (Match match in matches)
            {
                foreach (Match item in matchesInText)
                {
                    if (match.Value == item.Value)
                    {
                        if (!words_counts.ContainsKey(match.Value))
                        {
                            words_counts.Add(match.Value, 0);
                        }

                        words_counts[match.Value]++;
                    }
                }

            }

            foreach (KeyValuePair<string, int> word in words_counts.OrderByDescending(v => v.Value))
            {
                sw.WriteLine($"{word.Key} - {word.Value}");

            }
        }

    }
}
