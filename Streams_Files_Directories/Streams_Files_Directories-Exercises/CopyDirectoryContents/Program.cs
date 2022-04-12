using System;
using System.IO;
using System.Linq;


namespace CopyDirectory
{
    public class CopyDirectory
    {
        static void Main()
        {
            string inputFolderPath = @"C:\Users\Asus\Downloads\Paus";
            string outputFolderPath = @"C:\Users\Asus\Downloads\myfolder";


            CopyAllFiles(inputFolderPath, outputFolderPath);

        }
        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath);
            }
            else
            {
                Directory.CreateDirectory(outputPath);
            }
            string[] filesInDir = Directory.GetFiles(inputPath);

            foreach (string file in filesInDir)
            {
                string fileName = outputPath + "\\" + Path.GetFileName(file);

                File.Copy(file, fileName);

            }

          
        }

    }
}
