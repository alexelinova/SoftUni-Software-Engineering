using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> dirInfo = new Dictionary<string, Dictionary<string, double>>();

            string path = Console.ReadLine();

            string[] files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);

                string extension = info.Extension;
                string fileName = info.Name;
                double size = Math.Ceiling((double)info.Length / 1024);

                if (!dirInfo.ContainsKey(extension))
                {
                    dirInfo.Add(extension, new Dictionary<string, double>());
                }

                dirInfo[extension].Add(fileName, size);
            }

            using StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt");

            foreach (var kvp in dirInfo.OrderByDescending(v => v.Value.Count).ThenBy(k => k.Key))
            {
                writer.WriteLine(kvp.Key);

                foreach (var fileInfo in kvp.Value.OrderBy(x => x.Value))
                {
                    writer.WriteLine($"--{fileInfo.Key} - {fileInfo.Value}kb");
                }
            }
        }
    }
}
