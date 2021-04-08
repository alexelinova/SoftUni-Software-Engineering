using System;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfWagons = int.Parse(Console.ReadLine());
            int[] arr = new int[countOfWagons];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());

            }
            Console.WriteLine(string.Join(" ", arr));
            Console.Write(arr.Sum());
        }
    }
}
