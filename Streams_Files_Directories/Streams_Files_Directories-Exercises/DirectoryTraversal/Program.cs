using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DirectoryTraversal
{
    public class DirectoryTraversal
    {
        static void Main()
        {
            
            string inputFolderPath = @"C:\Users\Asus\source\repos\Advanced\Streams, Files & Directories\StreamsFilesAndDirectories - Lab\ExtractSpecialBytes";
            string textContent = TraverseDirectory(inputFolderPath);
            string reportFileName = "report.txt";
            WriteReportToDesktop(textContent, reportFileName);
            
        }
        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] filesInDirectory = Directory.GetFiles(inputFolderPath);
            Dictionary<string, List<FileInfo>> all_extensions_filesInfo = new Dictionary<string, List<FileInfo>>();
                
            StringBuilder sb = new StringBuilder();

            foreach (string file in filesInDirectory)
            {
                FileInfo fileInfo = new FileInfo(file);
                string currentFileExtension = fileInfo.Extension;
                if (!all_extensions_filesInfo.ContainsKey(currentFileExtension))
                {
                    all_extensions_filesInfo.Add(currentFileExtension, new List<FileInfo>());
                }
                all_extensions_filesInfo[currentFileExtension].Add(fileInfo);
            }

            foreach (KeyValuePair<string, List<FileInfo>> extension in all_extensions_filesInfo.OrderByDescending(v=>v.Value.Count).ThenBy(k=>k.Key))
            {
                sb.AppendLine($"{extension.Key}");
                foreach (FileInfo fileInfo in extension.Value.OrderByDescending(v=>v.Length))
                {
                    sb.AppendLine($"--{fileInfo.Name} - {Math.Ceiling((double) fileInfo.Length / 1024)}kb");
                }
            }

            return sb.ToString();


        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
           
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName, textContent );
            
        }

    }
}
