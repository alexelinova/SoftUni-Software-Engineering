using System;

namespace Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string fullName = $"{personInfo[0]} {personInfo[1]}";
            string address = personInfo[2];

            string[] nameAndBeer = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = nameAndBeer[0];
            int beer = int.Parse(nameAndBeer[1]);

            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int intNum = int.Parse(numbers[0]);
            double doubleNum = double.Parse(numbers[1]);


            MyTuple<string, string> firstTuple = new MyTuple<string, string>(fullName, address);
            MyTuple<string, int> secondTuple = new MyTuple<string, int>(name, beer);
            MyTuple<int, double> thirdTuple = new MyTuple<int, double>(intNum, doubleNum);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
