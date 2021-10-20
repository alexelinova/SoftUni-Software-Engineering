using _01.InitialSetup;
using Microsoft.Data.SqlClient;
using System;

namespace _06.RemoveVillain
{
    class Program
    {
        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string villainName = GetVillainNameByID(villainId, connection);

                if (villainName == null)
                {
                    Console.WriteLine("No such villain was found.");
                    return;
                }

                int releasedMinions = DeleteFromMappingTable(villainId, connection);

                DeleteVillainById(villainId, connection);

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{releasedMinions} minions were released.");
            }
        }

        private static void DeleteVillainById(int villainId, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(Queries.DeleteVillainById, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);
                command.ExecuteNonQuery();
            }
        }

        private static int DeleteFromMappingTable(int villainId, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(Queries.DeleteMinionsFromMappingTable, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);

                return command.ExecuteNonQuery();
            }
        }

        private static string GetVillainNameByID(int villainId, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(Queries.GetVillainNameById, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);

                return (string)command.ExecuteScalar();
            }
        }
    }
}
