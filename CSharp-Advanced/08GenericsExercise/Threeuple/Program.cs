using System;
using System.Linq;

namespace Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] nameAndTown = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string fullName = $"{nameAndTown[0]} {nameAndTown[1]}";
            string address = nameAndTown[2];
            string town = string.Join(" ", nameAndTown.Skip(3));

            string[] nameAndBeer = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = nameAndBeer[0];
            int beer = int.Parse(nameAndBeer[1]);
            bool isDrunk = nameAndBeer[2] == "drunk" ? true : false;

            string[] accountInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string firstName = accountInfo[0];
            double accountBalance = double.Parse(accountInfo[1]);
            string bankName = accountInfo[2];

            MyThreeuple<string, string, string> personInfo = new MyThreeuple<string, string, string>(fullName, address, town);
            MyThreeuple<string, int, bool> beerInfo = new MyThreeuple<string, int, bool>(name, beer, isDrunk);
            MyThreeuple<string, double, string> bankInfo = new MyThreeuple<string, double, string>(firstName, accountBalance, bankName);

            Console.WriteLine(personInfo);
            Console.WriteLine(beerInfo);
            Console.WriteLine(bankInfo);
        }
    }
}
