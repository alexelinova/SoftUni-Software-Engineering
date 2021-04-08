using System;
using System.Collections.Generic;
using System.Linq;

namespace OddOccurences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().ToLower().Split();

                
            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (var word in words)
            {

                if (counts.ContainsKey(word))
                {
                    counts[word]++;
                }
                else
                {
                    counts.Add(word, 1);
                }
            }

            foreach (var item in counts)
            {
                if (item.Value % 2 == 1 )
                {
                    Console.Write(item.Key + " ");
                }
            }
        }
    }
}
