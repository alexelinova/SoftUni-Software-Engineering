using System;
using System.Collections.Generic;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string text = string.Empty;
            Stack<string> operations = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "1")
                {
                    for (int k = 1; k < command.Length; k++)
                    {
                        text += command[k];
                    }

                    operations.Push(text);
                }
                else if (command[0] == "2")
                {
                    int lettersToRemove = int.Parse(command[1]);
                    text = text.Remove(text.Length - lettersToRemove);
                    operations.Push(text);
                }
                else if (command[0] == "3")
                {
                    int index = int.Parse(command[1]) - 1;
                    Console.WriteLine(text[index]);
                }
                else
                {
                    if (operations.Count > 1)
                    {
                        operations.Pop();
                        text = operations.Peek();
                    }
                    else
                    {
                        text = string.Empty;
                    }
                   
                }
            }

        }
    }
}
