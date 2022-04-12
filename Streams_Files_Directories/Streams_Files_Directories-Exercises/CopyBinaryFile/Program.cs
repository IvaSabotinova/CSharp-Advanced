using System;
using System.IO;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";
            CopyFile(inputFilePath, outputFilePath);


        }
        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            FileStream fs = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read);
            FileStream fs1 = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write);
            byte[] buffer = new byte[4096];

            int currentBytes;
            while ((currentBytes = fs.Read(buffer, 0, buffer.Length)) > 0)
            {
                fs1.Write(buffer, 0, currentBytes);

            }

        }
    }
}
