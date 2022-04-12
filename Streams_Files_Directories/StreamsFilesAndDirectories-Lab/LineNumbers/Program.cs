using System;
using System.IO;
using System.Threading.Tasks;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"txt1.txt";
            string outputFilePath = @"..\..\..\output2.txt";

            RewriteFileWithLineNumbers(inputFilePath, outputFilePath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using StreamReader sr = new StreamReader(inputFilePath);
            using StreamWriter sw = new StreamWriter(outputFilePath);

            int lineNumbers = 1;
            string lineToRead = sr.ReadLine();

            while (lineToRead != null)
            {

                sw.WriteLine($"{lineNumbers}. {lineToRead}");
                lineNumbers++;
                lineToRead = sr.ReadLine();


            }
            
        }


    }
}


