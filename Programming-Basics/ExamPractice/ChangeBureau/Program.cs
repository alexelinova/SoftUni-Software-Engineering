using System;

namespace ChangeBureau
{
    class Program
    {
        static void Main(string[] args)
        {


            int bitcoinNum = int.Parse(Console.ReadLine());
            double cnyNum = double.Parse(Console.ReadLine());
            double commision = double.Parse(Console.ReadLine());

            
            double bitcointoLv = bitcoinNum * 1168;
            double cnytoLv = cnyNum * 0.15 * 1.76;
            double alltoEur = (bitcointoLv + cnytoLv) / 1.95;
            double allWithoutCommision = alltoEur - (alltoEur * commision) / 100;
            Console.WriteLine($"{allWithoutCommision:f2}");
        }
    }
}
