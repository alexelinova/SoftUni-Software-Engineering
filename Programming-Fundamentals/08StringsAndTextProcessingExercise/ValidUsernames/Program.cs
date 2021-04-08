using System;

namespace ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(" ,");

            bool isValid = true;

            foreach (var password in usernames)
            {
                if (password.Length < 3 || password.Length > 16)
                {
                    continue;
                }

                for (int i = 0; i < password.Length; i++)
                {
                    char current = password[i];

                    if (!char.IsLetterOrDigit(current) && current != '-' && current != '_')
                    {
                        isValid = false;
                    }
                }

                if (isValid)
                {
                    Console.WriteLine(password);
                }

                isValid = true;
            }
            
        }
    }
}
