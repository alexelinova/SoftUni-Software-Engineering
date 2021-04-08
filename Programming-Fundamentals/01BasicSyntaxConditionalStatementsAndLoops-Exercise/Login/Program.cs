using System;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string password = "";

            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }


            string enteredPass = Console.ReadLine();
            int count = 0;

            while (enteredPass != password)
            {
                count++;
                if (count >= 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }
                Console.WriteLine("Incorrect password. Try again.");
                enteredPass = Console.ReadLine();
            }

            if (enteredPass == password)
            {
                Console.WriteLine($"User {username} logged in.");
            }
        }
    }
}
