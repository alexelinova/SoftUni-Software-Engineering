using System;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int dogs = int.Parse(Console.ReadLine());
            int otherAnimals = int.Parse(Console.ReadLine());
            double priceDogs = dogs * 2.5;
            double priceOtherAnimals = otherAnimals * 4;
            double finalPrice = priceDogs + priceOtherAnimals;
            Console.WriteLine($"{finalPrice} lv.");

        }
    }
}
