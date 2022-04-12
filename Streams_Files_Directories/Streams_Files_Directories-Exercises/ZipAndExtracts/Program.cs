using System;
using System.IO.Compression;

namespace ZipAndExtract
{
    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFilePath = @"C:\Users\Asus\OneDrive\Работен плот\New folder";
            string fileName = "extracted.png";
            string zipArchiveFilePath = @"C:\Users\Asus\OneDrive\Работен плот\archive.zip";
            string outputFilepath = @"C:\Users\Asus\OneDrive\Работен плот\";
           
            ZipFileToArchive(inputFilePath, zipArchiveFilePath);
            ExtractFileFromArchive(zipArchiveFilePath, fileName, outputFilepath);

        }
        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            
           ZipFile.CreateFromDirectory(inputFilePath, zipArchiveFilePath);
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            outputFilePath += fileName;
            ZipFile.ExtractToDirectory(zipArchiveFilePath, outputFilePath);
           
        }
    }
}
