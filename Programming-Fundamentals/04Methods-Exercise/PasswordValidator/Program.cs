using System;

namespace PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isValid = true;

            if (!HasValidLength(password))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                isValid = false;
            }

            if (ContainsInvalidCharacters(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
                isValid = false;
            }

            if (!ContainsDigits(password, 2))
            {
                Console.WriteLine("Password must have at least 2 digits");
                isValid = false;
            }

            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool ContainsDigits(string password, int count)
        { 
            int digitCount = 0;
        
            foreach (var item in password)
            {
                if (char.IsDigit(item))
                {
                    digitCount++;
                }

                if (digitCount == count)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool ContainsInvalidCharacters(string password)
        {
            foreach (var item in password)
            {
                if (!char.IsLetterOrDigit(item))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool HasValidLength(string password)
        {
            return password.Length >= 6 && password.Length <= 10;
        }
    }

}
