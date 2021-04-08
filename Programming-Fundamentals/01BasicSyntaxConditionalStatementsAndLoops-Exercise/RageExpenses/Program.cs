using System;

namespace RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int trashedHeadset = lostGamesCount / 2;
            int trashedMice = lostGamesCount / 3;
            int trashedKeyboard = lostGamesCount / 6;
            int trashedDisplay = trashedKeyboard / 2;

            double expenses = trashedHeadset * headsetPrice + trashedMice * mousePrice + trashedKeyboard * keyboardPrice + trashedDisplay * displayPrice;
            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
        }
    }
}
