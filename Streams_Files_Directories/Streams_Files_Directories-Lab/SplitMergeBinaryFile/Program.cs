using System;
using System.IO;
using System.Linq;
using System.Text;

namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main(string[] args)
        {
            string sourceFilePath = @"C:\Users\Asus\source\repos\Advanced\Streams, Files & Directories\StreamsFilesAndDirectories - Lab\ExtractSpecialBytes\example.png";
            string partOneFilePath = @"..\..\..\part-1.bin";
            string partTwoFilePath = @"..\..\..\part-2.bin";
            string joinedFilePath = @"..\..\..\example-joined.png";
            SplitBinaryFile(sourceFilePath, partOneFilePath, partTwoFilePath);
            MergeBinaryFiles(partOneFilePath, partTwoFilePath, joinedFilePath);
        }
        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            byte[] binaryFile = Encoding.UTF8.GetBytes(sourceFilePath);
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();

            for (int i = 0; i < binaryFile.Length; i++)
            {
                if (binaryFile.Length % 2 == 0)
                {
                    if (i <= binaryFile.Length / 2)
                    {
                        sb1.Append(binaryFile[i]);
                    }
                    else
                    {
                        sb2.Append(binaryFile[i]);
                    }

                }
                else
                {
                    if (i <= binaryFile.Length / 2 + 1)
                    {
                        sb1.Append(binaryFile[i]);
                    }
                    else
                    {
                        sb2.Append(binaryFile[i]);
                    }

                }
            }
            File.WriteAllText(partOneFilePath, sb1.ToString());
            File.WriteAllText(partTwoFilePath, sb2.ToString());
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            byte[] firstFile = Encoding.UTF8.GetBytes(partOneFilePath);
            byte[] secondFile = Encoding.UTF8.GetBytes(partTwoFilePath);
            byte[] joinedFile = new byte[firstFile.Length + secondFile.Length];

            for (int i = 0; i < firstFile.Length; i++)
            {
                joinedFile[i] = firstFile[i];
            }

            for (int i = 0; i < secondFile.Length; i++)
            {
                joinedFile[firstFile.Length - 1 + i] = secondFile[i];
            }

            File.WriteAllBytes(joinedFilePath, joinedFile);
            
        }

    }
}
