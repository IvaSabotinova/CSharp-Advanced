using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ExtractBytes
{
    public class ExtractBytes
    {
        static void Main()
        {

            string binaryFilePath = @"C:\Users\Asus\source\repos\Advanced\Streams, Files & Directories\StreamsFilesAndDirectories - Lab\ExtractSpecialBytes\example.png";
            string bytesFilePath = @"bytes.txt";
            string outputFilePath =  @"..\..\..\output.bin";
            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputFilePath);
            
        }
        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            byte[] binaryFile = Encoding.UTF8.GetBytes(binaryFilePath);

            string[] textFile = File.ReadAllLines(bytesFilePath);

            StringBuilder result = new StringBuilder();

            foreach (byte item in binaryFile)
            {
                if (textFile.Contains(item.ToString()))
                {
                    result.Append(item.ToString());
                }
            }
            
            File.WriteAllText(outputPath, result.ToString());
        }

    }
}
