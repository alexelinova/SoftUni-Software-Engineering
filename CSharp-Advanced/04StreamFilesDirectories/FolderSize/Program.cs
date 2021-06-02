using System;
using System.IO;

namespace FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles(".");
           
            double sum = 0;

            foreach (var file in files)
            {
                FileInfo fileInf = new FileInfo(file);
                sum += fileInf.Length;
            }

            sum = sum / 1024 / 1024;

            File.WriteAllText("output.txt", sum.ToString());
        }
    }
}
