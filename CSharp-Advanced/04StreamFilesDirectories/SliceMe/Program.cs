using System;
using System.IO;
using System.Linq;

namespace SliceMe
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream stream = new FileStream("Text.txt", FileMode.OpenOrCreate))
            {
                int parts = 4;

                int length = (int)Math.Ceiling(stream.Length /(decimal) parts);

                byte[] buffer = new byte[length];

                for (int i = 0; i < parts; i++)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    if (bytesRead < buffer.Length)
                    {
                        buffer = buffer
                            .Take(bytesRead)
                            .ToArray();
                    }

                    using (FileStream currentPartStream = new FileStream($"Part{i + 1}.txt", FileMode.Create))
                    {
                        currentPartStream.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
