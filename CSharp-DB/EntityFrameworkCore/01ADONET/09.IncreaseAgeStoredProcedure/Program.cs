using _01.InitialSetup;
using Microsoft.Data.SqlClient;
using System;

namespace _09.IncreaseAgeStoredProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

               // CreateProcedure(connection);

                ExecuteProcedure(id, connection);

                PrintMinionById(id, connection);
            }
        }

        private static void PrintMinionById(int id, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(Queries.MinionNameAndAgeById, connection))
            {
                command.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]} - {reader["Age"]} years old");
                    }     
                }
            }
        }

        private static void CreateProcedure(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(Queries.CreateGetOlderProcedure, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        private static void ExecuteProcedure(int id, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(Queries.ExecuteProcedure, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
