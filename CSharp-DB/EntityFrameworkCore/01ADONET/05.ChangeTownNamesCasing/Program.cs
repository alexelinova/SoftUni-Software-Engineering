using _01.InitialSetup;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace _05.ChangeTownNamesCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            string countryName = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                int affectedRows = ChangeTownNamesToUppercase(countryName, connection);

                if (affectedRows == 0)
                {
                    Console.WriteLine("No town names were affected.");
                    return;
                }

                Console.WriteLine($"{affectedRows} town names were affected.");

                List<string> townNames = GetTownNamesByCountry(countryName, connection);

                Console.Write($"[{string.Join(", ", townNames)}]");
            }
            
        }

        private static List<string> GetTownNamesByCountry(string countryName, SqlConnection connection)
        {
            List<string> townNames = new List<string>();

            using (SqlCommand townsCmd = new SqlCommand(Queries.TownsByCountry, connection))
            {
                townsCmd.Parameters.AddWithValue("@countryName", countryName);

                using (SqlDataReader reader = townsCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        townNames.Add(reader["Name"] as string);
                    }
                }

                return townNames;
            }
        }

        private static int ChangeTownNamesToUppercase(string countryName, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(Queries.ChangeTownNamesToUpperCase, connection))
            {
                command.Parameters.AddWithValue(@"countryName", countryName);
                return command.ExecuteNonQuery();
            }
        }
    }
}

