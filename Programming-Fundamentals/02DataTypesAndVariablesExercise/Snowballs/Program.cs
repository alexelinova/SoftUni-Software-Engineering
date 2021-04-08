using System;
using System.Numerics;

namespace Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            byte numberOfBalls = byte.Parse(Console.ReadLine());
            BigInteger highestQuality = 0;
            byte bestsnowballSnow = 0;
            short bestsnowballTime = 0;
            byte bestsnowballQuality = 0;

            for (int i = 0; i < numberOfBalls; i++)
            {
                byte snowballSnow = byte.Parse(Console.ReadLine());
                short snowballTime = short.Parse(Console.ReadLine());
                byte snowballQuality = byte.Parse(Console.ReadLine());

                BigInteger volume = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);

                    if (volume > highestQuality)
                    {
                        highestQuality = volume;
                        bestsnowballQuality = snowballQuality;
                        bestsnowballSnow = snowballSnow;
                        bestsnowballTime = snowballTime;

                    }
                
                

            }
            Console.WriteLine($"{ bestsnowballSnow} : { bestsnowballTime} = {highestQuality} ({bestsnowballQuality})");
        }
    }
}
