using System;

namespace NumberSerquence
{
    class Program
    {
        static void Main(string[] args)
        {
            //Напишете програма, която чете n на брой цели числа. Принтирайте най-голямото и най-малкото число сред
            //въведените
            int count = int.Parse(Console.ReadLine());
            int max = int.MinValue;
            int min = int.MaxValue;

            for (int i = 0; i < count; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number > max)
                {
                    max = number;
                }
                if (number < min)
                {
                    min = number;
                }
            }
            Console.WriteLine($"Max number: {max}");
            Console.WriteLine($"Min number: {min}");
           
        }
    }
}
