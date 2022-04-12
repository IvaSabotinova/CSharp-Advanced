using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace FolderSize
{
    public class FolderSize
    {
        static void Main()
        {
            string inputFilePath = @"C:\Users\Asus\source\repos\Advanced\Streams, Files & Directories\StreamsFilesAndDirectories - Lab\FolderSize\TestFolder";
            string outputFilePath = @"..\..\..\output.txt";
            GetFolderSize(inputFilePath, outputFilePath);


        }
        public static void GetFolderSize(string folderPath, string outputFilePath)
        {

            double size = 0;
            DirectoryInfo directory = new DirectoryInfo(folderPath);
            FileInfo[] filesNames = directory.GetFiles();

            foreach (FileInfo fileName in filesNames)
            {
                size += fileName.Length;
            }

            size = size / 1024;
            File.WriteAllText(outputFilePath, size.ToString());
        }

    }
}
