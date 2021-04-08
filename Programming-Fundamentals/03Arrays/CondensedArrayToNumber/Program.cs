using System;
using System.Linq;

namespace CondensedArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

            while (numbers.Length != 1)
            {
                int[] newArr = new int[numbers.Length - 1];

                for (int i = 0; i < newArr.Length; i++)
                {
                    newArr[i] = numbers[i] + numbers[i + 1];
                }

                numbers = newArr;
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
