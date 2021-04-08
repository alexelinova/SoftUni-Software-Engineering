using System;
using System.Linq;

namespace ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "end")
                {
                    break;
                }

                if (command[0] == "exchange")
                {
                    int index = int.Parse(command[1]);

                    Exchange(array, index);
                }
                else if (command[0] == "max")
                {
                    string parameter = command[1];

                    int index = GetMax(array, parameter);

                    if (index == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(index);
                    }
                }
                else if (command[0] == "min")
                {
                    string parameter = command[1];

                    int index = GetMin(array, parameter);

                    if (index == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(index);
                    }
                }
                else if (command[0] == "first")
                {
                    int count = int.Parse(command[1]);
                    string parameter = command[2];

                    if (count > array.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }

                    int[] firstElements = GetFirstElements(array, count, parameter);
                    PrintArray(firstElements);  
           
                }
                else if (command[0] == "last")
                {
                    int count = int.Parse(command[1]);
                    string parameter = command[2];

                    if (count > array.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }

                    int[] lastElements = GetLastElements(array, count, parameter);

                    PrintArray(lastElements);
                }

            }

            Console.WriteLine($"[{string.Join(", ", array)}]");
        }

        private static void PrintArray(int[] lastElements)
        {
            Console.Write("[");

            bool found = false;

            foreach (var element in lastElements)
            {
                if (element != -1)
                {
                    if (found)
                    {
                        Console.Write($", {element }");
                    }
                    else
                    {
                        Console.Write($"{element }");
                        found = true;
                    }
                }
            }
            Console.WriteLine("]");
        }

        private static int[] GetLastElements(int[] array, int count, string parameter)
        {
            int[] result = new int[count];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = -1;
            }
            int index = 0;

            int parity = GetParity(parameter);

            for (int i = array.Length-1; i >= 0; i--)
            {
                int number = array[i];

                if (number % 2 == parity)
                {
                    result[index] = number;
                    index++;

                    if (index >= result.Length)
                    {
                        break;
                    }
                }
            }

            return result.Reverse().ToArray();
        }

        private static int[] GetFirstElements(int[] array, int count, string parameter)
        {
            int[] result = new int[count];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = -1;
            }
            int index = 0;
            int parity = GetParity(parameter);

            foreach (int number in array)
            {
                if (number % 2 == parity)
                {
                    result[index] = number;
                    index++;

                    if (index >= result.Length)
                    {
                        break;
                    }
                }
            }

            return result;
        }

        private static int GetParity(string parameter)
        {
            if (parameter == "even")
            {
                return 0;
            }
            return 1;
        }

        private static int GetMin(int[] array, string parameter)
        {
            int parity = GetParity(parameter);

            int minNumber = int.MaxValue;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                int currentNumber = array[i];

                if (currentNumber <= minNumber && currentNumber % 2 == parity)
                {
                    minNumber = currentNumber;
                    index = i;
                }
            }
            return index;
        }

        private static int GetMax(int[] array, string parameter)
        {
            int parity = GetParity(parameter);

            int maxNumber = int.MinValue;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                int currentNumber = array[i];

                if (currentNumber >= maxNumber && currentNumber % 2 == parity)
                {
                    maxNumber = currentNumber;
                    index = i;
                }
            }
            return index;
        }

        private static void Exchange(int[] arr, int index)
        {
            if (index < 0 || index > arr.Length - 1)
            {
                Console.WriteLine("Invalid index");
                return;

            }
            for (int i = 0; i <= index; i++)
            {
                int firstNumber = arr[0];

                for (int j = 0; j < arr.Length-1; j++)
                {
                    arr[j] = arr[j + 1];
                }

                arr[arr.Length - 1] = firstNumber;
            }
        }
    }
}

