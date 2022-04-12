using System;
using System.IO;
using System.Text;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"text.txt";
            string outputFilePath = @"..\..\..\output.txt";
            ProcessLines(inputFilePath, outputFilePath);

        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] text = File.ReadAllLines(inputFilePath);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                int countLetters = 0;
                int countPunctuationMarks = 0;
                for (int j = 0; j < text[i].Length; j++)
                {
                    if (Char.IsLetterOrDigit(text[i][j]))
                    {
                        countLetters++;
                    }
                    else if (char.IsPunctuation(text[i][j]))
                    {
                        countPunctuationMarks++;
                    }
                }

                sb.Append($"Line {i + 1}: {text[i]} ({countLetters})({countPunctuationMarks})\n");
            }
            File.WriteAllText(outputFilePath, sb.ToString());
        }
    }

}
