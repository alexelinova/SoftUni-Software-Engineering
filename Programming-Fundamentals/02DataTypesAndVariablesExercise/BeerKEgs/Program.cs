using System;

namespace BeerKEgs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            float biggestKeg = 0;
            string modelOfBiggestKeg = "";

            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                float volume = (float)Math.PI * (float)radius * (float)radius * height;
                if (volume > biggestKeg)
                {
                    biggestKeg = volume;
                    modelOfBiggestKeg = model;
                }

            }
            Console.WriteLine(modelOfBiggestKeg);
            
        }
    }
}
