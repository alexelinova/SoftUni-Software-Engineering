using System;
using System.IO;

namespace CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using FileStream streamReader = new FileStream("copyMe.png", FileMode.Open);
            using FileStream streamWriter = new FileStream("copyMe-copy.png", FileMode.Create);

            while (true)
            {
                byte[] buffer = new byte[4096];

                int readSize = streamReader.Read(buffer, 0, buffer.Length);

                if (readSize == 0)
                {
                    break;
                }

                streamWriter.Write(buffer, 0, readSize);
            }
        }
    }
}
