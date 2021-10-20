using _01.InitialSetup;
using Microsoft.Data.SqlClient;
using System;
using System.Linq;

namespace _08.IncreaseMinionAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] minionIds = Console.ReadLine().Split().Select(int.Parse).ToArray();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                UpdateMinionsAgeAndCase(connection, minionIds);

                PrintMinionNameAndAge(connection);
            }
        }

        private static void PrintMinionNameAndAge(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(Queries.MinionNameAndAge, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]} {reader["age"]}");
                    }
                }
            }
        }

        private static void UpdateMinionsAgeAndCase(SqlConnection connection, params int[] minionIds)
        {
            foreach (var id in minionIds)
            {
                using (SqlCommand command = new SqlCommand(Queries.UpdateMinionsAgeAndCase, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
