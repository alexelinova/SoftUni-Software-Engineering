using System;
using System.IO.Compression;

namespace ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory("../../../Test", @"D:\Test2\TestArchive.zip");

            ZipFile.ExtractToDirectory(@"D:\Test2\TestArchive.zip", @"D:\Test2");
        }
    }
}
