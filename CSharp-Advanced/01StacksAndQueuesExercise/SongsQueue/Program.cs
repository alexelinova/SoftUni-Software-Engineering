using System;
using System.Collections.Generic;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> playlist = new Queue<string>(songs);

            while (playlist.Count != 0)
            {
                string command = Console.ReadLine();

                if (command.Contains("Play"))
                {
                    playlist.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    string newSong = command.Substring(4);
                    if (playlist.Contains(newSong))
                    {
                        Console.WriteLine($"{newSong} is already contained!");
                    }
                    else
                    {
                        playlist.Enqueue(newSong);
                    }
                }
                else if (command.Contains("Show"))
                {
                    Console.WriteLine(string.Join(", ", playlist));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
