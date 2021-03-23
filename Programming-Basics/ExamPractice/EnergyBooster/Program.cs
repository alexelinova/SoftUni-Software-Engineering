using System;
using System.Xml.Schema;

namespace EnergyBooster
{
    class Program
    {
        static void Main(string[] args)
        {

            string fruit = Console.ReadLine();
            string sizeOfSet = Console.ReadLine();
            int numberOfSets = int.Parse(Console.ReadLine());
            double priceWatermelon = 0;
            double priceMango = 0;
            double pricePineapple = 0;
            double priceRaspberry = 0;
            double totalPrice = 0;

            switch (fruit)
            {
                case "Watermelon":
                    if (sizeOfSet == "small")
                    {
                        priceWatermelon = 2 * 56;
                        totalPrice = priceWatermelon * numberOfSets;
                    }
                    else
                    {
                        priceWatermelon = 5 * 28.7;
                        totalPrice = priceWatermelon * numberOfSets;
                    } 
                    break;
                case "Mango":
                    if (sizeOfSet == "small")
                    {
                        priceMango = 2 * 36.66;
                        totalPrice = priceMango * numberOfSets;
                    }
                    else
                    {
                        priceMango = 5 * 19.60;
                        totalPrice = priceMango * numberOfSets;
                    }

                    break;
                case "Pineapple":

                    if (sizeOfSet == "small")
                    {
                        pricePineapple = 2 * 42.10;
                        totalPrice = pricePineapple * numberOfSets;
                    }
                    else
                    {
                        pricePineapple = 5 * 24.80;
                        totalPrice = pricePineapple * numberOfSets;
                    }
                    break;
                case "Raspberry":

                    if (sizeOfSet == "small")
                    {
                        priceRaspberry = 2 * 20;
                        totalPrice = priceRaspberry * numberOfSets;
                    }
                    else
                    {
                        priceRaspberry = 5 * 15.20;
                        totalPrice = priceRaspberry * numberOfSets;
                    }
                    break;

            }
            if (totalPrice >= 400 && totalPrice <= 1000)
            {
                totalPrice -= totalPrice * 0.15;
                Console.WriteLine($"{ totalPrice:f2} lv.");
            }
            else if (totalPrice > 1000)
            {
                totalPrice -= totalPrice * 0.5;
                Console.WriteLine($"{ totalPrice:f2} lv.");
            }
            else
            {
                Console.WriteLine($"{ totalPrice:f2} lv.");
            }
        }
    }
}
