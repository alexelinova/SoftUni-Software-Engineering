using System;

namespace CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string str1 = input[0];

            string str2 = input[1];

            CharacterCodeMultiplier(str1, str2);
        }

        private static void CharacterCodeMultiplier(string str11, string str12)
        {
            int count = Math.Min(str11.Length, str12.Length);

            int countMax = Math.Max(str11.Length, str12.Length);

            string longer = str11.Length > str12.Length ? str11 : str12;

            int sum = 0;

            for (int i = 0; i < count; i++)
            {
                sum += str11[i] * str12[i];
            }

            for (int i = count; i < countMax; i++)
            {
                sum += longer[i];
            }

            Console.WriteLine(sum);
        }
    }
}
