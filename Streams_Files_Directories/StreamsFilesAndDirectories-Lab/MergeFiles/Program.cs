using System;
using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            string firstFile = @"input1.txt";
            string secondFile = @"input2.txt";
            string outputFile = @"..\..\..\output.txt";
            MergeTextFiles(firstFile, secondFile, outputFile);

        }
        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {

            string[] text1 = File.ReadAllLines(firstInputFilePath);
            string[] text2 = File.ReadAllLines(secondInputFilePath);
            File.WriteAllText(outputFilePath, "");

            int biggerFile = text1.Length;
            if (text1.Length < text2.Length)
            {
                biggerFile = text2.Length;
            }

            for (int i = 0; i < biggerFile; i++)
            {
                if (text1.Length > i)
                {
                    File.AppendAllText(outputFilePath, text1[i] + "\n");
                }

                if (text2.Length > i)
                {
                    File.AppendAllText(outputFilePath, text2[i] + "\n");
                }
            }

        }

    }
}
