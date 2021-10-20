using _01.InitialSetup;
using Microsoft.Data.SqlClient;
using System;

namespace _03.MinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter villain Id: ");
            int villainId = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                using SqlCommand command = new SqlCommand(Queries.VillainName, connection);

                command.Parameters.AddWithValue("@Id", villainId);

                string villainName = command.ExecuteScalar() as string;

                if (villainName == null)
                {
                    Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                }
                else
                {
                    Console.WriteLine($"Villain: {villainName}");

                    using (SqlCommand commandMinions = new SqlCommand(Queries.MinionsName, connection))
                    {
                        commandMinions.Parameters.AddWithValue("@Id", villainId);

                        using (SqlDataReader reader = commandMinions.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                Console.WriteLine("(no minions)");
                            }
                            else
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine($"{ reader["RowNum"]}. {reader["Name"]} {reader["Age"]}");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
