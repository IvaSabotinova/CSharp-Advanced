using System;
using System.IO;
using System.Linq;
using System.Text;

namespace EvenLines
{
    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using StreamReader sr = new StreamReader(inputFilePath);

            string line = sr.ReadLine();
            int count = 0;
            StringBuilder sb = new StringBuilder();

            while (line != null)
            {

                if (count % 2 == 0)
                {
                    string[] currentLine = line.Split(" ").Reverse().ToArray();
                    for (int i = 0; i < currentLine.Length; i++)
                    {
                        sb.Append(currentLine[i] + " ");
                    }

                    sb.Replace('-', '@');
                    sb.Replace(',', '@');
                    sb.Replace('.', '@');
                    sb.Replace('!', '@');
                    sb.Replace('?', '@');
                    sb.Append("\n");
                }

                count++;
                line = sr.ReadLine();
            }

            return sb.ToString();

        }

    }
}
